using Sandbox.Common.ObjectBuilders;
using Sandbox.ModAPI;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI;
using System;
using System.IO;
using System.Text;
using VRage.Game.Components;
using VRage.ObjectBuilders;

namespace DeleteProtection
{
    
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
        private const string FILE = "configs.cfg";

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
}
