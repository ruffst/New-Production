using System;
using System.Timers;
using System.Text;
using System.IO;
using System.Collections.Generic;

using VRageMath;
using VRage;
using VRage.Game;
using VRage.Game.Entity;
using VRage.Game.Components;
using VRage.Game.Definitions;
using VRage.Game.ModAPI;
using VRage.Game.ModAPI.Interfaces;
using VRage.Game.ObjectBuilders.ComponentSystem;
using VRage.Game.ObjectBuilders.Definitions.SessionComponents;
using VRage.Game.ObjectBuilders.Components;
using VRage.Audio;
using VRage.Data.Audio;
using VRage.Utils;
using VRage.ModAPI;
using VRage.ObjectBuilders;
using Ingame = VRage.Game.ModAPI.Ingame;

using Sandbox.Game;
using Sandbox.Game.Entities;
using Sandbox.Game.EntityComponents;
using Sandbox.Game.World;
using Sandbox.Game.Weapons;
using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Weapons;
using Sandbox.ModAPI.Interfaces;
using Sandbox.ModAPI.Interfaces.Terminal;

using SpaceEngineers.Game.ModAPI;

namespace NewProduction
{

#region WOOD CUTTING

    [MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
    public class WoodCut : MySessionComponentBase
	{


		int _replacedCount_s = 0; // steel plate to 10 wood planks
		int _replacedCount_i = 0; // interior plate to 5 wood planks
		int _nullCubeDefCount = 0;

		
		double HowMuchWoodToGive = 38.0;
		static public MyObjectBuilder_Component LogBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Component>("WoodLogs");

		public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
		{
			if (MyAPIGateway.Session.IsServer )
			{
				MyEntities.OnEntityAdd += MyEntities_OnEntityAdd;
			}
		}

		private void MyEntities_OnEntityAdd(MyEntity obj)
		{
			
			String usestring = obj.ToString(); 
			
			if (usestring.StartsWith("MyDebrisTr")) 
			{
				
				IMyEntity ie = obj as IMyEntity;
				String treemodel = ie.Model.AssetName;

				double woodamount = HowMuchWoodToGive;
				
				if (treemodel.Contains("Medium"))
				woodamount *= 0.9;
				if (treemodel.Contains("Dead"))
				woodamount *= 0.9;
				if (treemodel.Contains("Desert"))
				woodamount *= 0.9;
				if (treemodel.Contains("Snow")) // snow trees seem to be consistently taller
				woodamount *= 2.0;
				if (treemodel.Contains("Pine")) // I like pines, so there.
				woodamount *= 1.1;
				
				VRage.MyFixedPoint amount = (VRage.MyFixedPoint) ((int)(woodamount/5.0));

				Vector3D upp = ie.WorldMatrix.Up;
				Vector3D fww = ie.WorldMatrix.Forward;
				Vector3D rtt = ie.WorldMatrix.Right;
				Vector3D pos = ie.GetPosition();//+upp*9; // needed because of the 8 meter dropdown hardcoded in
				
				
				// c# random is a pain in the ass, so i'm going to use the identifier string since i already have it
				int rnd1 = (((((byte)(usestring[14]))+128)%6)-3);
				int rnd2 = (((((byte)(usestring[15]))+128)%6)-3);
				int rnd3 = (((((byte)(usestring[16]))+128)%6)-3);
				int rnd4 = (((((byte)(usestring[17]))+128)%6)-3);
				int rnd5 = (((((byte)(usestring[18]))+128)%6)-3);
				int rnd6 = (((((byte)(usestring[19]))+128)%6)-3);
				int rnd7 = (((((byte)(usestring[20]))+128)%6)-3);
				int rnd8 = (((((byte)(usestring[21]))+128)%6)-3);
				
				// the 9 meters height adjust is because there's a -8 meter height adjust in the original spengies code

				MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, LogBuilder), pos+(upp*13)+(fww*(0.33*rnd1))+((rtt*0.33*rnd2)), fww, upp);
				MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, LogBuilder), pos+(upp*12)+(fww*(0.33*rnd3))+((rtt*0.33*rnd4)), fww, upp);
				MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, LogBuilder), pos+(upp*11)+(fww*(0.33*rnd5))+((rtt*0.33*rnd6)), fww, upp);
				MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, LogBuilder), pos+(upp*10)+(fww*(0.33*rnd7))+((rtt*0.33*rnd8)), fww, upp);
				MyFloatingObjects.Spawn(new MyPhysicalInventoryItem(amount, LogBuilder), pos+(upp*09)                                    , fww, upp);

			}
		}	

		private void MyEntities_OnEntityCreate(MyEntity obj)
		{
			//MyAPIGateway.Utilities.ShowMessage("cre", ""+obj.ToString());
		}	
	}

#endregion 


#region DElETE PROTECTION
   [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Beacon), true, new string[] { "Beacon", "DeleteProtectionLarge", "DeleteProtectionSmall" })]
    public class BeaconDeleteProtection : MyGameLogicComponent
    {
        IMyTerminalBlock beacon;
        private MyObjectBuilder_EntityBase m_objectBuilder;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            m_objectBuilder = objectBuilder;
            beacon = Entity as IMyTerminalBlock;

            if (beacon is IMyBeacon)
            {
                Beacon_PropertiesChanged(beacon);
                beacon.PropertiesChanged += Beacon_PropertiesChanged;
            }
        }

        private void Beacon_PropertiesChanged(IMyTerminalBlock block)
        {
            if (!Config.loaded) Config.InitConfig();

            if (!Config.allowOffBeacon) block.SetValueBool("OnOff", true);

            IMyBeacon beacon = block as IMyBeacon;
            if (beacon.Radius < Config.minBeaconRadius)
                beacon.Radius = Config.minBeaconRadius;
        }
    }

    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_TimerBlock), true)]
    public class TriggerNowFix : MyGameLogicComponent
    {
        IMyTerminalBlock pBlock;
        private MyObjectBuilder_EntityBase m_objectBuilder;

        public override void Init(MyObjectBuilder_EntityBase objectBuilder)
        {
            base.Init(objectBuilder);
            m_objectBuilder = objectBuilder;
            pBlock = Entity as IMyTerminalBlock;

            if (pBlock is IMyTimerBlock)
            {                
                PBlock_PropertiesChanged(pBlock);
                pBlock.PropertiesChanged += PBlock_PropertiesChanged;                
            }
        }

        private void PBlock_PropertiesChanged(IMyTerminalBlock block)
        {
            if (!Config.loaded) Config.InitConfig();

            IMyTimerBlock timerBlock = block as IMyTimerBlock;
            if (timerBlock.TriggerDelay < Config.triggerDelay)
                timerBlock.TriggerDelay = Config.triggerDelay;
        }        
    }

    public class Config
    {
        private const string FILE = "new-production.cfg";

        //options
        public static bool allowOffBeacon = false;
        public static float minBeaconRadius = 7500f;

        public static float triggerDelay = 3f;

        public static bool loaded = false;

        public static void InitConfig()
        {
            if (!Load())
            {
                Save();
                Load();
                loaded = true;
            }
        }

        private static bool Load()
        {
            try
            {
                if (MyAPIGateway.Utilities.FileExistsInLocalStorage(FILE, typeof(Config)))
                {
                    var file = MyAPIGateway.Utilities.ReadFileInLocalStorage(FILE, typeof(Config));
                    ReadSettings(file);
                    file.Close();
                    return true;
                }
            }
            catch (Exception) {}
            return false;
        }

        private static void Save()
        {
            try
            {
                var file = MyAPIGateway.Utilities.WriteFileInLocalStorage(FILE, typeof(Config));
                file.Write(GetSettingsString());
                file.Flush();
                file.Close();
            }
            catch (Exception) { }
        }

        private static string GetSettingsString()
        {
            var str = new StringBuilder();

            str.Append("allow-off-beacon=").Append(allowOffBeacon).AppendLine();
            str.Append("min-beacon-radius=").Append(minBeaconRadius).AppendLine();
            str.Append("min-trigger-delay=").Append(triggerDelay);

            return str.ToString();
        }

        private static void ReadSettings(TextReader file)
        {
            try
            {
                string line;
                string[] args;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length == 0) continue;

                    args = line.Split(new char[] { '=' }, 2);
                    if (args.Length != 2) continue;

                    args[0] = args[0].Trim().ToLower();
                    args[1] = args[1].Trim().ToLower();

                    switch(args[0])
                    {
                        case "allow-off-beacon":
                            allowOffBeacon = bool.Parse(args[1]);
                            break;
                        case "min-beacon-radius":
                            minBeaconRadius = float.Parse(args[1]);
                            break;
                        case "min-trigger-delay":
                            triggerDelay = float.Parse(args[1]);
                            break;
                    }
                }
            }
            catch (Exception) { }
        }
    }
#endregion
}










