using ThatShittyBearGame.Helpers;
using ThatShittyBearGame.Scripts;
using ThatShittyBearGame.Scripts.Intro;
using Godot;
using GodotLibs;
using System;

public partial class ToiletScript : Node2D, IScriptActor
{
    [Export]
    public AnimatedSprite2D ToiletAnim { get; set; }
    [Export]
    public AnimatedSprite2D ExplosionAnim { get; set; }
    [Export]
    public AudioStreamPlayer2D SoundDoor { get; set; }
    [Export]
    public AudioStreamPlayer2D SoundScream { get; set; }
    [Export]
    public AudioStreamPlayer2D SoundRumble { get; set; }
    [Export]
    public AudioStreamPlayer2D SoundExplosion { get; set; }
    [Export]
    public float ScriptTime { get; set; } = 5;
    [Export]
    public float ScreamTime { get; set; } = 2;

    public bool InProgress { get; private set; } = false;

    private bool _doScream = true;
    private bool _doInitial = true;
    private Action _scriptEndCallback;
    private double _scriptTime = 0;
    private float _lastOffsetUpdate = 0;

    public override void _Process(double delta)
    {
        if (!InProgress)
            return;
        if(_doInitial)
        {
            _doInitial = false;
            ToiletAnim.Play("closed");
            SoundDoor.Play();
            SoundRumble.Play();
        }
        _scriptTime += delta;
        SoundRumble.VolumeDb += (float)delta * 8;
        var upd = Math.Round(_scriptTime, 1);
        if (upd != _lastOffsetUpdate)
        {
            _lastOffsetUpdate = (float)upd;
            var val = _lastOffsetUpdate * 20;
            ToiletAnim.Offset = RandomHelper.CreateRandomDirectionVector() * val;
        }
        if(_doScream && upd > ScreamTime)
        {
            _doScream = false;
            SoundScream.Play();
        }

        if(_scriptTime > ScriptTime)
        {
            SoundExplosion.Play();
            ExplosionAnim.Visible = true;
            ExplosionAnim.Play("gif");
            SoundRumble.Stop();
            ToiletAnim.Offset = Vector2.Zero;
            InProgress = false;
            _scriptEndCallback?.Invoke();
        }
    }

    public void StartActorScript(string scriptName, Action scriptEndCallback)
    {
        _scriptEndCallback = scriptEndCallback;
        NodeHelper.GetNodeByType<Area2D>(this).SetDeferred(nameof(Area2D.Monitorable), false);
        InProgress = true;
    }
}
