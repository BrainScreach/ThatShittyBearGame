using Godot;
using System;

public partial class MainMenu : Control
{
    [Export]
    public MenuUniversalScript SteamMemeScript { get; set; }

    public const string YouTubeURL = "https://www.youtube.com/watch?v=dQw4w9WgXcQ&list=RDdQw4w9WgXcQ&start_radio=1&pp=ygUJcmljayByb2xsoAcB"; 

    [Signal]
    public delegate void StartButtonClickedEventHandler();
    [Signal]
    public delegate void OptionsButtonClickedEventHandler();

    private State _currentState = State.Generic;

    public void _on_start_game_button_pressed()
    {
        if(_currentState != State.Generic)
            return;

        EmitSignal("StartButtonClicked");
    }
    public void _on_options_button_pressed()
    {
        if (_currentState != State.Generic)
            return;
        EmitSignal("OptionsButtonClicked");
    }
    public void _on_quit_button_pressed()
    {
        if (_currentState != State.Generic)
            return;
        this.GetTree().Quit();
    }

    public void _on_steam_icon_pressed()
    {
        if (_currentState != State.Generic)
            return;
        SteamMemeScript.Start(() => _currentState = State.Generic);
        _currentState = State.PlayingMeme;
    }

    public void _on_x_icon_pressed()
    {
        if (_currentState != State.Generic)
            return;
        OS.ShellOpen(YouTubeURL);
    }

    public enum State
    {
        Generic,
        PlayingMeme
    }
}
