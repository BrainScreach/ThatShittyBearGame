using Godot;
using System;
using System.Collections.Generic;
using System.Text;

public partial class EntitiesCreator : Node2D
{
    [Export]
    public PackedScene[] ToCreate { get; set; } = new PackedScene[1];

    [Export]
    public Camera2D Camera { get; set; }


    [Export]
    public Timer CreationTimer { get; set; }

    [Export]
    public float TimerMax { get; set; } = 2F;
    [Export]
    public float TimerMin { get; set; } = 0.5F;

    [Export]
    public bool Enabled { get; set; } = true;


    public override void _Ready()
    {
        GD.Print("CREATOR READY");
        CreationTimer.Timeout += OnCreationTimerTimeout;
        CreationTimer.Start();
        base._Ready();
    }

    private void Start()
    {
        if (Enabled)
            return;
        Enabled = true;
        CreationTimer.Start();
        CreationTimer.WaitTime = GD.RandRange(TimerMin, TimerMax);
    }

    private void Stop()
    {
        if (!Enabled)
            return;
        Enabled = false;
        CreationTimer.Stop();
    }

    private void OnCreationTimerTimeout()
    {
        if (!Enabled) 
            return;
        Node2D instance = ToCreate[GD.Randi() % ToCreate.Length].Instantiate<Node2D>();
        var view = GetViewportRect();
        Vector2 center = Camera.GetScreenCenterPosition();
        
        var randY = (float)GD.RandRange(center.Y, center.Y + view.Size.Y);
        instance.GlobalPosition = new Vector2(center.X + view.Size.X + 800, randY);

        AddChild(instance);
        CreationTimer.WaitTime = GD.RandRange(TimerMin, TimerMax);
    }
}
