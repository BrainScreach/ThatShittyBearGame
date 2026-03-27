using Godot;
using System;

public partial class ParralaxScript : Parallax2D
{
    [Export]
    public Camera2D Camera { get; set; }

    private State _state = State.MovingDown;
    private float _scrollScaleY = 0.1f;
    private float _autoscrollY = 10;


    private float tmpScrollY = -1;
    private Vector2 tmpPosition = Vector2.Zero;
    public override void _Process(double delta)
    {
        if (_state == State.MovingDown)
        {
            float l1 = this.Position.Y - ScreenOffset.Y;
            if (l1 < 730)
            {
                tmpScrollY = ScreenOffset.Y;
                tmpPosition = Position;
                _scrollScaleY = ScrollScale.Y;
                ScrollScale = new Vector2(ScrollScale.X, 0);
                Autoscroll = new Vector2(0, 10);
                this.Position = tmpPosition;
                _state = State.MovingUp;
            }
        }
        else
        {
            //if(ScreenOffset.Y > 1300)
            //{
            //ScrollScale = new Vector2(ScrollScale.X, _scrollScaleY);
            //Autoscroll = new Vector2(0, 0);
            //_state = State.MovingDown;
            //}
        }
    }

    enum State
    {
        MovingDown,
        MovingUp
    }
}
