using Godot;
using System;

public partial class OverlayMenu : Control
{
    [Export]
    public DistanceMeasureControl DistanceMeasure { get; set; }
    [Export]
    public ShitMeasureControl ShitMeasure { get; set; }


    public void StartPositionFollowing(float totalDistance)
    {
        DistanceMeasure.Start(totalDistance);
        this.Show();
    }

    public void UpdatePosition(float position)
    {
        DistanceMeasure.ChangePosition(position);
    }
       
    public void SetLevel(float value, float MaxValue)
    {
        ShitMeasure?.SetLevel(value, MaxValue);
    }
}
