using ThatShittyBearGame.Helpers;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public partial class Floater : Node2D
{
    [Export]
    public AnimatedSprite2D AnimatedSprite { get; set; }
    [Export]
    public float SpeedMin { get; set; } = 200F;
    [Export]
    public float SpeedMax { get; set; } = 100F;

    private float m_Speed;

    public override void _Ready()
    {
        m_Speed = (float)GD.RandRange(SpeedMin, SpeedMax);
        AnimationHelper.PlayRandomAnimation(AnimatedSprite);
        base._Ready();
    }

    public override void _Process(double delta)
    {
        Position -= new Vector2(m_Speed * (float)delta, 0);
    }
}
