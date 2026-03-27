using ThatShittyBearGame.Scripts.Universal;
using Godot;
using System;
using System.Diagnostics.Contracts;

public partial class MainLoop : Node2D
{
    [Export]
    public IntroScript IntroScript { get; set; }
    [Export]
    public SlideScene SlideScene { get; set; }
    [Export]
    public EndRavineScene EndRavineScene { get; set; }
    [Export]
    public CameraMoveScript MenuStartCamera { get; set; }
    [Export]
    public MenuManager MenuManager { get; set; }

    private MainState _state = MainState.Initial;

    public override void _Ready()
    {
        MenuStartCamera.MakeCurrent();
        _state = MainState.Initial;       
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        switch(_state)
        {
            case MainState.Initial:
                MenuManager.ShowMainMenu();
                _state = MainState.MainMenu;
                break;
            case MainState.MainMenu:
                break;
            case MainState.Cliff:
                break;
            case MainState.SlideStart:
                SlideScene.StartScene(SlideEnd);
                _state = MainState.Slide;
                break;
            case MainState.Slide:
                break;
            case MainState.StartEnding:
                EndRavineScene.StartScene(SlideScene.EndPoint, ShowRestart);
                _state = MainState.Ending;
                break;
            case MainState.Ending:
                break;
            case MainState.Restart:

                break;
        }
    }

    public void SlideEnd()
    {
        _state = MainState.StartEnding;
    }

    public void ShowRestart()
    {
        _state = MainState.Restart;
        MenuManager.ShowRestartMenu();
    }

    public void _on_main_menu_start_button_clicked()
    {
        IntroScript.StartActorScript("", () => _state = MainState.SlideStart);
        MenuStartCamera.MoveCamera(new Vector2(0, 0), 300);
        _state = MainState.Cliff;
        MenuManager.HideAll();
    }

    public void _on_restart_menu_restart_clicked()
    {
        this.GetTree().ReloadCurrentScene();
    }

    private enum MainState
    {
        Initial,
        MainMenu,
        Cliff,
        SlideStart,
        Slide,
        StartEnding,
        Ending,
        Restart,
    }
}
