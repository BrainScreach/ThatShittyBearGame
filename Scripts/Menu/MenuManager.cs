using Godot;
using System;

public partial class MenuManager : Control
{
    [Export]
    public MainMenu MainMenu { get; set; }
    [Export]
    public Control RestartMenu { get; set; }
    [Export]
    public Control DialogMenu { get; set; }
    [Export]
    public Control OptionsMenu { get; set; }
    [Export]
    public Control OverlayMenu { get; set; }

    public override void _Ready()
    {
        this.Position = Vector2.Zero;
        MainMenu.Hide();
        RestartMenu.Hide();
        DialogMenu.Hide();
        OptionsMenu.Hide();
        OverlayMenu.Hide();
    }

    public void _on_main_menu_options_button_clicked() => ShowOptionsMenu();

    public void _on_options_menu_options_button_close_clicked() => ShowMainMenu();

    public void ShowMainMenu()
    {
        RestartMenu.Hide();
        OptionsMenu.Hide();
        OverlayMenu.Hide();
        MainMenu.Show();
    }

    public void ShowRestartMenu()
    {
        MainMenu.Hide();
        OptionsMenu.Hide();
        OverlayMenu.Hide();
        RestartMenu.Show();
    }

    public void ShowDialogMenu()
    {
        MainMenu.Hide();
        RestartMenu.Hide();
        OptionsMenu.Hide();
        DialogMenu.Show();
    }

    public void ShowOptionsMenu()
    {
        MainMenu.Hide();
        OptionsMenu.Show();
    }

    public void HideAll()
    {
        MainMenu.Hide();
        RestartMenu.Hide();
        OptionsMenu.Hide();
        DialogMenu.Hide();
    }
}
