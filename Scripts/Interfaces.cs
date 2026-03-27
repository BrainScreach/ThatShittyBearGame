using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts
{
    public interface IPlayer
    {
    }

    public interface ICollisionDetector
    {        
        public EventHandler<CollisionEventArgs> CollisionEvent { get; set; }
    }

    public class CollisionEventArgs
    {
        public Vector2 Position { get; set; }

        public Node2D Node { get; set; }
    }
}
