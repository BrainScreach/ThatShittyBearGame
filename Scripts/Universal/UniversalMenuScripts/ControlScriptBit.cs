using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{

    [GlobalClass]
    public partial class ControlScriptBit : Resource, IControlScriptBit
    {
        protected GenericScriptState State { get; set; } = GenericScriptState.Initial;

        public ControlScriptBit() { }
        public virtual bool Process(double delta, Control target)
        {
            return true;
        }
    }
}
