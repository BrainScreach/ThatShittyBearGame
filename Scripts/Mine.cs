using Godot;
using System;

public partial class Mine : Node2D
{
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; set; }
    [Export]
    public Area2D Area { get; set; }
    [Export]
    public AudioStreamPlayer2D StreamSound { get; set; }

    [Export]
    public int AverageForce { get; set; } = 8000;
    [Export]
    public int ForceOscilation { get; set; } = 2000;

    private int _force;

    public override void _Ready()
    {
        _force = GD.RandRange(AverageForce - ForceOscilation, AverageForce + ForceOscilation);
        Area.BodyEntered += Area_BodyEntered;
        base._Ready();
    }

    private void Area_BodyEntered(Node2D body)
    {
        if(body is BearRigidBody rigidBody)
        {
            Area.SetDeferred(nameof(Area.Monitoring), false);
            rigidBody.ApplyImpulse(new Vector2(_force * 0.5F, -1.5F * _force));
            AnimatedSprite.Play("exploded");
            StreamSound.Play(0.3f);
        }
    }
}
