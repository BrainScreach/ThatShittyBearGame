using ThatShittyBearGame.Scripts.Intro;
using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class IntroScript : Node2D, IScriptActor
{
    [Export]
    public IntroBearScript BearMain { get; set; }
    [Export]
    public ToiletScript ToiletScript { get; set; }

    public bool InProgress { get; private set; }

    private States _state = States.start;
    private Action _scriptEndCallback;

    public override void _Process(double delta)
    {
        if (!InProgress)
            return;
        switch(_state)
        {
            case States.start:
                _state = States.walking;
                break;
            case States.walking:
                BearMain.StartActorScript("", () => _state = States.InToilet);
                break;
            case States.InToilet:
                ToiletScript.StartActorScript("", () => _state = States.End);
                break;
            case States.End:
                _scriptEndCallback.Invoke();
                InProgress = false;
                break;
            default:
                break;                
        }
        base._Ready();
    }

    public void StartActorScript(string scriptName, Action scriptEndCallback)
    {
        InProgress = true;
        _scriptEndCallback = scriptEndCallback;
    }

    public enum States
    {
        start,
        walking,
        InToilet,
        Explosion,
        End
    }
}
