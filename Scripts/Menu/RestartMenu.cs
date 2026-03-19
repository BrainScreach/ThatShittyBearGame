using Godot;
using System;
using System.Diagnostics;

public partial class RestartMenu : Control
{
    [Signal]
    public delegate void RestartClickedEventHandler();

    public void _on_texture_button_pressed()
    {      
        EmitSignal("RestartClicked");
    }

}
