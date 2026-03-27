using Godot;
using System;
using ThatShittyBearGame.Scripts;

public partial class PlayerController : Node2D
{
    [Export]
    public BearRigidBody MainPlayer { get; set; }
    [Export]
    public OverlayMenu ShitMeasure { get; set; }
    [Export]
    public float ShitForce { get; set; }

    [Export]
    public float ShitParticleGeneration { get; set; } = 0.15f;

    [Export]
    public float MaxShitCount { get; set; } = 80;
    [Export]
    public float ShitPerSecond { get; set; } = 20;
    [Export]
    public float RechargeSpeed { get; set; } = 30;
    [Export]
    public float RechargeTimeOut { get; set; } = 1;

    private float _shitValue = 0;
    private float ShitValue
    {
        get => _shitValue;
        set
        {
            if (_shitValue != value)
            {
                _shitValue = value;
                ShitMeasure.SetLevel(value, MaxShitCount);
            }
        }
    }

    private double _rechargeTimer = 0;
    private State _state = State.Idle;
    private float _shitParticleTimer = 0f;

    public void ActivatePlayer()
    {
        ShitValue = MaxShitCount;
        _state = State.Active;
    }

    public void DeactivatePlayer()
    {
        //TODO shut down any active actions like shitting
        _state = State.Idle;
        MainPlayer.ShitDeactivate();
    }


    public override void _Process(double delta)
    {
        if (_state == State.Idle)
            return;
        DoShitting(delta);
        if (_state == State.Shitting)
        {
            _shitParticleTimer += (float)delta;
            if (_shitParticleTimer >= ShitParticleGeneration)
            {
                MainPlayer.GenerateShitParticle();
                _shitParticleTimer = 0;
            }
        }
    }

    private void DoShitting(double delta)
    {
        if (Input.IsActionJustPressed(ActionNames.SHIT_ACTION))
        {
            MainPlayer.ShitActivate();
            _state = State.Shitting;
            _rechargeTimer = 0;
        }        
        else if (Input.IsActionJustReleased(ActionNames.SHIT_ACTION))
        {
            MainPlayer.ShitDeactivate();
            _state = State.Active;
            _shitParticleTimer = 0;
            _rechargeTimer = 0;
        }

        if (_state == State.Shitting)
        {
            if (ShitValue > 0)
            {
                Vector2 mousePos = GetGlobalMousePosition();
                Vector2 direction = (mousePos - MainPlayer.Position).Normalized() * -1;
                var vv = direction * ShitForce;
                MainPlayer.ShitForce(direction * ShitForce);
                ShitValue = Math.Max(0, ShitValue - (float)(ShitPerSecond * delta));
            }
            else
            {
                MainPlayer.ShitDeactivate();
            }
        }
        if(_state == State.Active)
        {
            if (ShitValue < MaxShitCount)
                Recharge(delta);
        }
    }

    private void Recharge(double delta)
    {
        if(_rechargeTimer < RechargeTimeOut)
            _rechargeTimer += delta;
        else
            ShitValue = (float)Math.Min(MaxShitCount, ShitValue + RechargeSpeed * delta);

    }

    enum State
    {
        Idle,        
        Active,
        Shitting
    }
}
