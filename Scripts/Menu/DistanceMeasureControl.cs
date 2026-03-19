using Godot;
using System;

public partial class DistanceMeasureControl : Control
{
    [Export]
    public Control Marker { get; set; }

    private float _currentPosition = 0;
    private float _totalDistance = 0;
    private float _sizeToMove = 0;

    public void Start(float totalDistance)
    {
        _currentPosition = 0;
        _totalDistance = totalDistance;
        _sizeToMove = Size.X - Marker.Size.X;
        Marker.SetPosition(new Vector2(_currentPosition, Marker.Position.Y));
    }

    public void ChangePosition(float position)
    {
        _currentPosition = Math.Min(position * _sizeToMove / _totalDistance, _sizeToMove);        
        Marker.SetPosition(new Vector2(_currentPosition, Marker.Position.Y));
    }
}
