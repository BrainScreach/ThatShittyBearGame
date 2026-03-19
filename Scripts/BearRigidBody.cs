using ThatShittyBearGame.Scripts;
using Godot;
using System;

public partial class BearRigidBody : RigidBody2D, IPlayer
{
    [Export]
    public Node2D SpriteNode { get; set; }

    public void _on_visibility_changed()
    {
        SpriteNode.Visible = this.Visible;
    }

    public override void _Process(double delta)
    {
        //if (Input.IsActionJustPressed(ACTION_NAME))
        //{
        //}
        //else if (Input.IsActionJustReleased(ACTION_NAME))
        //{
        //}
    }
}
