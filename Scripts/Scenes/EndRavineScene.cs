using ThatShittyBearGame.Scripts.Dialog;
using Godot;
using System;

public partial class EndRavineScene : Node2D
{
    [Export]
    public Area2D ActorEnteredArea { get; set; }
    [Export]
    public DialogBox DialogBox { get; set; }

    private Action _sceneEndCallback;

    public override void _Ready()
    {
        this.Visible = false;
        base._Ready();
        ActorEnteredArea.BodyEntered += ActorEnteredArea_BodyEntered;
    }

    private void ActorEnteredArea_BodyEntered(Node2D body)
    {
        if(body is BearRigidBody brb)
        {
            DialogBox.ShowDialog(DialogResourceManager.Instance.GetRandomLine("DiaperWolf"), DialogEnded);
        }
    }

    public void DialogEnded()
    {
        _sceneEndCallback.Invoke();
    }

    public void StartScene(Vector2 connectionPoint, Action _callback)
    {
        this.Position = connectionPoint;
        this.Visible = true;
        _sceneEndCallback = _callback;
    }
}
