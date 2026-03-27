using ThatShittyBearGame.Settings;
using Godot;
using GodotLibs;
using System;

public partial class SlideScene : Node2D
{
    [Export]
    public OverlayMenu OverlayMenu { get; set; }
    [Export]
    public Node2D BearLaunchPoint { get; set; }
    [Export]
    public Node2D SlideStartingPoint { get; set; }
    [Export]
    public RigidBody2D MainBearNode { get; set; }
    [Export]
    public Vector2 Startingimpulse { get; set; } = new Vector2(800, -1400);

    public LandSlideGenerator LandSlideGenerator { get; set; }

    private Action _endSlideCallback;
    
    public Vector2 EndPoint => LandSlideGenerator.LastPoint;
    private State _currentState = State.Initial;
    private float _totalDistance = 0;

    public override void _Ready()
    {        
        MainBearNode.ProcessMode = Node.ProcessModeEnum.Disabled;
        LandSlideGenerator = NodeHelper.GetNodeByType<LandSlideGenerator>(this);
        LandSlideGenerator.StartGeneration(SlideStartingPoint.Position);
    }

    public void StartScene(Action endSlideCallback)
    {
        _totalDistance = ValueConverter.ConvertFromToiletPaper(UserConfiguration.Instance.LevelLength);
        _endSlideCallback = endSlideCallback;
        MainBearNode.ProcessMode = Node.ProcessModeEnum.Inherit;
        MainBearNode.Position = BearLaunchPoint.Position;
        MainBearNode.Visible = true;
        OverlayMenu.StartPositionFollowing(_totalDistance);

        MainBearNode.ApplyImpulse(Startingimpulse);

        Camera2D camera = NodeHelper.GetNodeByType<Camera2D>(this);
        camera.MakeCurrent();

        var playerController = NodeHelper.GetNodeByType<PlayerController>(this);
        playerController.ActivatePlayer();
        _currentState = State.Running;
    }

    public override void _Process(double delta)
    {
        if (_currentState == State.Initial)
            return;
        if(_totalDistance < EndPoint.X)
        {
            LandSlideGenerator.StopGeneration();
            _endSlideCallback.Invoke();
        }
        float posX = MainBearNode.GlobalPosition.X - SlideStartingPoint.GlobalPosition.X;
        OverlayMenu.UpdatePosition(posX);
    }

    public enum State
    {
        Initial,
        Running
    }
}
