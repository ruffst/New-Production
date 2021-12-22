namespace WoodCut
{
	using System;
	using System.Timers;
	using Sandbox.ModAPI;
	using VRage.Game;
	using VRage.Game.Components;
	using VRage.Game.Entity;
	using Sandbox.Game.EntityComponents;
	using System;
	using System.Collections.Generic;
	using Sandbox.Game.Entities;
	using Sandbox.Game.World;
	using VRage.Audio;
	using VRage.Data.Audio;
	using VRage.Game.Components;
	using VRage.Game.Entity;
	using VRage.Game.ObjectBuilders.Components;
	using VRage.Utils;
	using VRageMath;
	using VRage.ModAPI;
	using VRage.ObjectBuilders;
	using VRage;
	using VRage.Game.Entity;
	using Ingame = VRage.Game.ModAPI.Ingame;
	using Sandbox.ModAPI.Interfaces;
	using Sandbox.Common.ObjectBuilders;
	using System;
	using System.Collections.Generic;
	using Sandbox.Game;
	using Sandbox.ModAPI;
	using Sandbox.ModAPI.Weapons;
	using SpaceEngineers.Game.ModAPI;
	using VRage.Game;
	using VRage.Game.Components;
	using VRage.Game.ModAPI;
	using VRage.ModAPI;
	using VRageMath;
	using System;
	using System.Text;
	using Sandbox.Common.ObjectBuilders;
	using Sandbox.Game.EntityComponents;
	using Sandbox.ModAPI;
	using Sandbox.ModAPI.Interfaces;
	using VRage.Game;
	using VRage.Game.Components;
	using VRage.ModAPI;
	using VRage.ObjectBuilders;
	using VRage.Utils;
	using Sandbox.Game.Weapons;
	using VRage.Game.ModAPI;
	using VRageMath;
	using VRage.Game.Entity;
	using Sandbox.Game.Entities;
	using VRage.Game.ModAPI.Interfaces;
	using Sandbox.Definitions;
	using Sandbox.ModAPI.Interfaces.Terminal;
	using SpaceEngineers.Game.ModAPI;

	using VRage.Game.ObjectBuilders.ComponentSystem;
	using VRage.ObjectBuilders;
	using VRage.Game.Components;
	using VRage.Game.Definitions;
	using VRage.Game.ObjectBuilders.Definitions.SessionComponents;


	[MySessionComponentDescriptor(MyUpdateOrder.NoUpdate)]
	public class Main : MySessionComponentBase
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
}
