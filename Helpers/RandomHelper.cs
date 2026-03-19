using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Helpers
{
    public static class RandomHelper
    {

        public static Vector2 CreateRandomDirectionVector()
        {
            float x = GD.Randf() - 0.5f;
            float y = GD.Randf() - 0.5f;
            float length = GD.Randf();
            return new Vector2(Math.Sign(x) * length, Math.Sign(y) * (1 -length));
        }
    }
}
