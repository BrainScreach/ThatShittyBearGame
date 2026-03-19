using ThatShittyBearGame.ResourceCode;
using Godot;
using System;

public partial class DialogBox : Control
{
    [Export]
    public Label CharacterName { get; set; }
    [Export]
    public Label DialogText { get; set; }
    [Export]
    public Timer TextTimer { get; set; }
    [Export]
    public Timer AppearTimer { get; set; }
    [Export]
    public byte AlphaStep { get; set; } = 5;
    [Export]
    public AudioStreamPlayer2D SoundPlayer { get; set; }

    private byte _currentAlpha = 0;

    private int letterIndex = 0;
    private string _dialogText = string.Empty;    

    public DialogState State { get; private set; } = DialogState.Inactive;
    private Action _actionEndedCallback;

    public override void _Ready()
    {
        base._Ready();
        TextTimer.Timeout += OnTextTimerTimeout;
        AppearTimer.Timeout += AppearTimer_Timeout;
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        switch(State)
        {
            case DialogState.WaitingForInput:
                if (Input.IsAnythingPressed())
                {
                    State = DialogState.Closing;
                    this.Visible = false;
                    _actionEndedCallback?.Invoke();
                }
                break;
            default:
                break;
        }
    }

    private void AppearTimer_Timeout()
    {
        _currentAlpha += AlphaStep;
        if(_currentAlpha >= 255)
        {
            _currentAlpha = 255;
            AppearTimer.Stop();
            StartDialogText();
            return;
        }
        this.Modulate = Color.Color8(255, 255, 255, _currentAlpha);
    }

    private void StartDialogText()
    {
        this.Modulate = Color.Color8(255, 255, 255);
        State = DialogState.TextPrinting;
        letterIndex = 0;
        TextTimer.Start();
    }

    public void ShowDialog(DialogLine dialogLine, Action actionEndedCallback)
    {
        _actionEndedCallback = actionEndedCallback;
        State = DialogState.Appearing;
        DialogText.Text = string.Empty;
        _currentAlpha = 0;
        letterIndex = 0;
        this.Modulate = new Color(255, 255, 255, 0);
        this.Visible = true;
        AppearTimer.Start();
        CharacterName.Text = dialogLine.ActorName;
        _dialogText = dialogLine.Line;
    }

    private void OnTextTimerTimeout()
    {
        PlaySound(_dialogText[letterIndex]);
        ++letterIndex;
        if (letterIndex >= _dialogText.Length)
        {
            TextTimer.Paused = true;
            TextTimer.Stop();            
            SoundPlayer.Stop();
            State = DialogState.WaitingForInput;
            letterIndex = _dialogText.Length;
        }
        DialogText.Text = _dialogText.Substring(0, letterIndex);
    }

    private void PlaySound(char v)
    {
        if(v == ' ')
            return;
        SoundPlayer.Play();       
    }

    public enum DialogState
    {
        Inactive,
        Appearing,
        TextPrinting,
        WaitingForInput,
        Closing
    }
}
