using Godot;
using System;

public partial class Exhaust : Node2D
{
    [Export]
    public GpuParticles2D Particles { get; set; }

    public override void _Ready()
    {
        base._Ready();
    }

    public void Activate()
    {
        Particles.Emitting = true;
    }

    public void Deactivate()
    {
        Particles.Emitting = false;
    }

    public override void _Process(double delta)
    {
        Vector2 mousePos = GetGlobalMousePosition();
        this.LookAt(mousePos);
    }
}
