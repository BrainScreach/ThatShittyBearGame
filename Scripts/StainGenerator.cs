using Godot;
using System;
using System.Collections.Generic;
using ThatShittyBearGame.Helpers;
using ThatShittyBearGame.Scripts;

public partial class StainGenerator : Node
{
    [Export]
    public Texture2D[] Textures { get; set; } = [];

    public void SubscribeCollision(ICollisionDetector collisionDetector)
    {
        collisionDetector.CollisionEvent += CollisionEventHandler;
    }

    private void CollisionEventHandler(object sender, CollisionEventArgs args)
    {

        Sprite2D sprite = new Sprite2D()
        {
            Texture = RandomHelper.GetRandomFromArray(Textures),
            Position = args.Position,
            ZIndex = 1,
            Rotation = GD.RandRange(0, 360)
        };
        args.Node.AddChild(sprite);
    }
}
