using ThatShittyBearGame.Scripts.Intro;
using Godot;
using System;

public partial class IntroBearScript : Area2D, IScriptActor
{
    [Export]
    public int BearSpeed { get; set; } = 800;

    public bool InProgress { get; private set; }

    private Action _scriptEndCallback;

    public void _on_area_entered(Node2D node)
    {
        if(node.Name == "ToiletArea")
        {
            this.Visible = false;
            this.SetDeferred(nameof(Area2D.Monitoring), false);
            InProgress = false;
            _scriptEndCallback.Invoke();
        }
    }

    public override void _Process(double delta)
    {
        if (!InProgress)
            return;
        Position += new Vector2(BearSpeed * (float)delta, 0);
        base._Process(delta);
    }

    public void StartActorScript(string scriptName, Action scriptEndCallback)
    {
        InProgress = true;
        _scriptEndCallback = scriptEndCallback;
    }
}
