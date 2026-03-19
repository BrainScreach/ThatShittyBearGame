using Godot;
using System;

public partial class LongSoundPlayer : Node2D
{
    [Export]
    public float PlayStart { get; set; }

    [Export]
    public float PlayStop { get; set; }

    [Export]
    public float RandomSubSoundTime { get; set; }

    [Export]
    public AudioStreamPlayer MainPlayer { get; set; } 
    [Export]
    public AudioStreamPlayer SubPlayer { get; set; }

    [Export]
    public AudioStream MainSound { get; set; } 

    [Export]
    public AudioStream[] SubSounds { get; set; } = new AudioStream[5];

    private bool inProgress = false;
    private bool playRandonSound = false;

    public override void _Ready()
    {
        MainPlayer.Stream = MainSound;
    }

    public void Play()
    {
        MainPlayer.Play();
        inProgress = true;
        playRandonSound = false;
    }

    public void Stop()
    {
        inProgress = false;
        playRandonSound = true;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (!inProgress)
            return;
        if (playRandonSound && SubPlayer.GetPlaybackPosition() == 0)
        {
            var sound = SubSounds[GD.RandRange(0, SubSounds.Length - 1)];
            SubPlayer.Stream = sound;
            SubPlayer.Play();
        }
        if (MainPlayer.GetPlaybackPosition() >= PlayStop)
        {
            MainPlayer.Stop();
            MainPlayer.Play(PlayStart);
            playRandonSound = true;
        }
    }
}
