using Godot;
using System;

public partial class Exaust : Node2D
{
    private const string ACTION_NAME = "Poop";

    [Export]
    public GpuParticles2D Particles { get; set; }
    [Export]
    public LongSoundPlayer Sound { get; set; }

    public override void _Ready()
    {
        base._Ready();
    }

    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed(ACTION_NAME))
        {
            Sound.Play();
            Particles.Emitting = true;
        }
        else if (Input.IsActionJustReleased(ACTION_NAME))
        {
            Sound.Stop();
            Particles.Emitting = false;
        }
    }
}
