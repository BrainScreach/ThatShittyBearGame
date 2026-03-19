using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Scripts.Universal
{
    public partial class CameraMoveScript : Camera2D
    {
        private State _state = State.Idle;
        private Vector2 _targetPosition;
        private int _speed;

        public override void _Process(double delta)
        {
            switch(_state)
            {
                case State.Idle:
                    break;
                case State.Moving:
                    if(this.Position == _targetPosition)
                    {
                        _state = State.Idle;
                    }
                    else
                    {
                        this.Position = this.Position.MoveToward(_targetPosition, (float)delta * _speed);
                    }
                    break;
            }
        }

        public void MoveCamera(Vector2 targetPosition, int speed)
        {
            _targetPosition = targetPosition;
            _state = State.Moving;
            _speed = speed;
        }

        private enum State
        {
            Idle,
            Moving
        }
    }
}
