using ThatShittyBearGame.Settings;
using Godot;
using GodotLibs;
using System;

public partial class OptionsMenu : Control
{
    private UserConfiguration Config => UserConfiguration.Instance;

    [Export]
    internal HSlider RideLengthSlider { get; set; }

    [Signal]
    public delegate void OptionsButtonCloseClickedEventHandler();

    public override void _Ready()
    {
        RideLengthSlider.Value = Config.LevelLength;
    }

    public void _on_button_pressed()
    {
        Config.LevelLength = (float)RideLengthSlider.Value;
        Config.Save();
        EmitSignal("OptionsButtonCloseClicked");
    }
}