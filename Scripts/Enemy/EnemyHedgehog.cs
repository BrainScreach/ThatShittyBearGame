using ThatShittyBearGame.Scripts;
using ThatShittyBearGame.Scripts.Enemy;
using Godot;
using GodotLibs;
using System;

public partial class EnemyHedgehog : RigidBody2D, IEnemy
{
    [Export]
    public AnimatedSprite2D Sprite { get; set; }
    [Export]
    public AudioStreamPlayer2D Sound { get; set; }

    private State _state = State.Idle;


    public void _on_body_entered(Node body)
    {        
        var area = NodeHelper.GetNodeByType<Area2D>(this);
        area.SetDeferred(Area2D.PropertyName.Monitoring, false);
        area.SetDeferred(Area2D.PropertyName.Monitorable, false);
        this.SetDeferred(RigidBody2D.PropertyName.Freeze, false);
        Sound.Play();
        Sprite.Play("dead");
        _state = State.Dying;
    }

    public override void _PhysicsProcess(double delta)
    {
        if(_state == State.Dying)
        {
            Freeze = false;
            this.ApplyCentralImpulse(new Vector2(3000, -3000));
            _state = State.Dead;
        }
    }

    private enum State
    {
        Idle,
        Dying,
        Dead
    }
}
