using Godot;
using System;

public partial class TriggerSoundNode : Area2D
{
    [Export]
    public AudioStreamPlayer2D SoundPlayer { get; set; }
    [Export]
    public AudioStream AudioStream { get; set; }

    public override void _Ready()
    {
        SoundPlayer.Stream = AudioStream;
    }

    public void _on_area_entered(Node2D node)
    {
        this.SetDeferred(Area2D.PropertyName.Monitoring, false);
        SoundPlayer.Play();
    }
}
