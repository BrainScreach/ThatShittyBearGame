using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts
{
    [GlobalClass]
    public partial class MoveControlScript : ControlScriptBit
    {
        [Export]
        public Vector2 TargetPosition { get; set; }
        [Export]
        public float Speed { get; set; }


        public override bool Process(double delta, Control target)
        {
            target.Position = target.Position.MoveToward(TargetPosition, Speed * (float)delta);
            return target.Position == TargetPosition;
        }
    }
}
