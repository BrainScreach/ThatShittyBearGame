using Godot;
using GodotLibs;
using System;
using ThatShittyBearGame.Scripts;

public partial class ShitStainer : Area2D, ICollisionDetector
{
    [Export]
    public float Velocity { get; set; }

    [ExportGroup("TimeActive", "TimeActive")]
    [Export(PropertyHint.Range, "0,10")]
    public int TimeActiveMin { get; set; } = 1;
    [Export(PropertyHint.Range, "0,10")]
    public int TimeActiveMax { get; set; } = 5;

    public EventHandler<CollisionEventArgs> CollisionEvent { get; set; }

    private Timer _timer;
    private Vector2 _velocityVector;

    public override void _Ready()
    {
        _timer = NodeHelper.GetNodeByType<Timer>(this);
    }

    public void Launch(Vector2 direction)
    {
        _velocityVector = direction * Velocity;
        this.SetDeferred(Area2D.PropertyName.Monitoring, true);
        _timer.Timeout += _timer_Timeout;
        _timer.Start(GD.RandRange(TimeActiveMin, TimeActiveMax));
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += _velocityVector * (float)delta;
    }

    private void _timer_Timeout()
    {
        _timer.Stop();
        QueueFree();
    }

    public void _on_body_entered(Node2D body)
    {
        CollisionEvent?.Invoke(this, new CollisionEventArgs() { Node = body, Position = this.Position });
        QueueFree();
    }
}
