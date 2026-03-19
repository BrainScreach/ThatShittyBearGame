using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    [GlobalClass]
    public partial class WaitScript : ControlScriptBit
    {
        [Export]
        public float Time { get; set; }
        private float _timeLeft;

        public override bool Process(double delta, Control target)
        {
            if(State == GenericScriptState.Initial)
            {
                _timeLeft = Time;
                State = GenericScriptState.Running;
            }
            _timeLeft -= (float)delta;
            if(_timeLeft <= 0)
            {
                State = GenericScriptState.Initial;
                return true;
            }
            return false;
        }
    }
}
