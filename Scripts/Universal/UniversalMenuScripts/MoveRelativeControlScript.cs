using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    [GlobalClass]
    public partial class MoveRelativeControlScript : ControlScriptBit
    {
        [Export]
        public Vector2 RelativePosition { get; set; }
        [Export]
        public float Speed { get; set; }

        private Vector2 _movePosition = Vector2.Zero;

        public override bool Process(double delta, Control target)
        {
            if(State == GenericScriptState.Initial)
            {
                _movePosition = Vector2.Zero;
                State = GenericScriptState.Running;
            }
            var moved = _movePosition.MoveToward(RelativePosition, Speed * (float)delta);
            target.Position += moved - _movePosition;
            if(moved == RelativePosition)
            {
                State = GenericScriptState.Initial;
                return true;
            }
            _movePosition = moved;
            return false;
        }
    }
}
