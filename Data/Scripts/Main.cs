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


#region wooddrop

		// all credit to Whiplash https://steamcommunity.com/sharedfiles/filedetails/?id=2042716312&searchtext=edge
		int _replacedCount_s = 0; // steel plate to 10 wood planks
		int _replacedCount_i = 0; // interior plate to 5 wood planks
		int _nullCubeDefCount = 0;

		
		double HowMuchWoodToGive = 3500.0;
		
		//        static MyStringHash m_explosives = MyStringHash.GetOrCompute("Explosives");
		static public MyObjectBuilder_Ore ScrapBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Ore>("Scrap");
		static public MyObjectBuilder_Ingot IronBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Ingot>("Iron");
		static public MyObjectBuilder_Component PlateBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Component>("SteelPlate");
		static public MyObjectBuilder_Component PlankBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Component>("WoodPlank");
		static public MyObjectBuilder_Component LogBuilder = MyObjectBuilderSerializer.CreateNewObject<MyObjectBuilder_Component>("WoodLogs");
        static public readonly SerializableDefinitionId WoodPlankID = new SerializableDefinitionId {TypeIdString = "Component", SubtypeId = "WoodPlank"};

		public override void Init(MyObjectBuilder_SessionComponent sessionComponent)
		{
			if (MyAPIGateway.Session.IsServer )
			{
				MyEntities.OnEntityAdd += MyEntities_OnEntityAdd;
				//                MyEntities.OnEntityCreate += MyEntities_OnEntityCreate;
			}
		}

		private void MyEntities_OnEntityAdd(MyEntity obj)
		{
			
			String usestring = obj.ToString(); // can ths be made any faster?
			
/*			
			MyAPIGateway.Utilities.ShowMessage("add", ""+usestring);
			if (usestring.StartsWith("MyMiss")) //ile
			{
				IMyEntity ie = obj as IMyEntity;
				String missilemodel = ie.Model.AssetName;
				MyAPIGateway.Utilities.ShowMessage("missile yeeted:", ""+missilemodel);
				if (missilemodel.Contains("yeet"))
				{
			                MyVisualScriptLogicProvider.SpawnPrefab("ParachuteMK1", ie.GetPosition(), ie.WorldMatrix.Forward, ie.WorldMatrix.Up, 0, null, null);

//void 	SpawnPrefab (String prefabName, Vector3 position, Vector3 forward, Vector3 up, Vector3 initialLinearVelocity=default(Vector3), Vector3 initialAngularVelocity=default(Vector3), String beaconName=null, SpawningOptions spawningOptions=SpawningOptions.None, long ownerId=0, bool updateSync=false, Stack< Action > callbacks=null)

				}
			}
			
			*/
			
			
			if (usestring.StartsWith("MyDebrisTr")) //ee
			{
				
				
				//				MyAPIGateway.Utilities.ShowMessage("spawn", "wood here"+usestring[14]+usestring[15]+usestring[16]);
				IMyEntity ie = obj as IMyEntity;
				String treemodel = ie.Model.AssetName;

				// we can now identify trees! Yay! This will let us do fruits and so on.At At the very least pine cones for pines. Make pesto?
				//MyAPIGateway.Utilities.ShowMessage("tree felled:", ""+treemodel);
				double woodamount = HowMuchWoodToGive;
				// let's profile the tree.
				
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
				
				//                MyVisualScriptLogicProvider.SpawnPrefab("ParachuteMK1", spaPlayer.PositionComp.GetPosition(), spaPlayer.WorldMatrix.Forward, spaPlayer.WorldMatrix.Up, playerid, null, null);
				//works!
				//                MyVisualScriptLogicProvider.SpawnPrefab("ParachuteMK1", ie.GetPosition(), ie.WorldMatrix.Forward, ie.WorldMatrix.Up, 0, null, null);

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
			//          MyVisualScriptLogicProvider.SendChatMessage("NEW ENTITY ADD: " + obj.ToString());
		}	

		private void MyEntities_OnEntityCreate(MyEntity obj)
		{
			MyAPIGateway.Utilities.ShowMessage("cre", ""+obj.ToString());
			//            MyVisualScriptLogicProvider.SendChatMessage("NEW ENTITY CREATE: " + obj.ToString());
		}	

#endregion
#region woodreplace


// procedureally replace steel plates with wood planks in other mods' wood blocks?

/*
		
		public override void LoadData()
		{
			base.LoadData();
			try
			{
	        var plankdef = MyDefinitionManager.Static.GetComponentDefinition(WoodPlankID);
				foreach (var def in MyDefinitionManager.Static.GetAllDefinitions())
				{
					if (def is MyCubeBlockDefinition && def.Id.SubtypeName.ToLower().Contains("wood"))
					{
						_replacedCount_i++;
						var wooden = (MyCubeBlockDefinition)def;
						if (wooden.CubeDefinition == null)
						{
	//						MyLog.Default.WriteLine("WoodReplace | WARNING | No CubeDefinition for: " + def.Id.SubtypeName);
							_nullCubeDefCount++;
							continue;
						}
						if (true)
						{
//							MyLog.Default.WriteLine("WoodReplace | DERP    | Hello");//Derped for: " + component.ToString());//+ " " + component.Subtype);
							
							
							if (wooden.Components != null && wooden.Components.Length != 0)
							{
								
                var oldComponents = wooden.Components;
//                cube.Components = new MyCubeBlockDefinition.Component[oldComponents.Length + 1];
//                cube.Components[0] =
//                    new MyCubeBlockDefinition.Component {Definition = imagdef, Count = 1, DeconstructItem = imagdef};
//                oldComponents.CopyTo(cube.Components, 1);
								
								
								//var Comps = new MyCubeBlockDefinition.Component[wooden.Components.Length];
								foreach (var component in oldComponents)
								{
									
									//MyLog.Default.WriteLine("WoodReplace | DERP    | Derped for component.");
									//                         var definition = MyDefinitionManager.Static.GetComponentDefinition(new MyDefinitionId(component.Type, component.Subtype));
									
								}
							}
							//armorDef.CubeDefinition.ShowEdges = false;
							
//							MyLog.Default.WriteLine("WoodReplace | INFO    | Removed edges for: " + def.Id.SubtypeName);
							_replacedCount_s++;
						}
					}
				}

			}
			catch (Exception e)
			{
//				MyLog.Default.WriteLine($"WoodReplace | ERROR   | {e}");
			}
		}
		
		public override void BeforeStart()
		{
			base.BeforeStart();
			try
			{
//				MyAPIGateway.Utilities.ShowMessage("WoodReplace", $"Replaced steel plate with wood planks for {_replacedCount_s} blocks");
//				MyAPIGateway.Utilities.ShowMessage("WoodReplace", $"Replaced interior plate with wood planks for {_replacedCount_i} blocks");
			}
			catch (Exception e)
			{
//				MyLog.Default.WriteLine($"WoodReplace | ERROR   | {e}");
			}
		}
*/
#endregion




	}




}
