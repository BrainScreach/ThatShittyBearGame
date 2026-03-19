using ThatShittyBearGame.Scripts.Universal.UniversalMenuScripts;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public partial class MenuUniversalScript : Control
{
    [Export]
    public ControlScriptManager ScriptManager { get; set; }

    public bool IsRunning { get; private set; }

    private Action _endedCallback;
    public void Start(Action callback)
    {
        _endedCallback = callback;
        IsRunning = true;
        ScriptManager.Start();
    }

    public override void _Process(double delta)
    {
        if (!IsRunning)
            return;
        IsRunning = ScriptManager.Process(delta, this);
        if (!IsRunning)
            _endedCallback.Invoke();
    }
}
