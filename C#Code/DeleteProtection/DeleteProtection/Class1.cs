using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using VRageMath;
using VRage.Utils;
using VRage.ModAPI;
using VRage.Collections;
using VRage.ObjectBuilders;

using VRage.Game;
using VRage.Game.Common;
using VRage.Game.Components;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Interfaces;
using VRage.Game.ObjectBuilders.Definitions;

using Sandbox.Common;
using Sandbox.Common.ObjectBuilders;

using Sandbox.Engine;
using Sandbox.ModAPI;

using Sandbox.Game;
using Sandbox.Game.EntityComponents;
using Sandbox.Game.Components;

using SpaceEngineers.ObjectBuilders;
using SpaceEngineers.Game;
using SpaceEngineers.Game.ModAPI.Ingame;



namespace DeleteProtection
{
    [MyEntityComponentDescriptor(typeof(MyObjectBuilder_Beacon))]
    public class DeleteProtection :MyGameLogicComponent
    {
        public override void Close()
        {
            base.Close();
        }
        public override void MarkForClose()
        {
            base.MarkForClose();
        }
        public override void Init(MyObjectBuilder_EntityBase beacon)
        {
            var deleteprot = Entity as IMyBeacon;
 
        }
        void deleteprot_StateChanged (bool obj)
        {

        }
    }
}