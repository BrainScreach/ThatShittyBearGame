using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotLibs
{
    public class PositionHelper
    {
        public static Vector2 ClampPosition(Vector2 position, Vector2 screenSize)
        {
            return new Vector2(
                x: Mathf.Clamp(position.X, 0, screenSize.X),
                y: Mathf.Clamp(position.Y, 0, screenSize.Y)
            );
        }
    }
}
