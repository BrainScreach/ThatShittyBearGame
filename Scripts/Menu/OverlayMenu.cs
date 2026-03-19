using Godot;
using System;

public partial class OverlayMenu : Control
{
    [Export]
    public DistanceMeasureControl DistanceMeasure { get; set; }


    public void StartPositionFollowing(float totalDistance)
    {
        DistanceMeasure.Start(totalDistance);
        this.Show();
    }

    public void UpdatePosition(float position)
    {
        DistanceMeasure.ChangePosition(position);
    }
}
