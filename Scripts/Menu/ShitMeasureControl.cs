using Godot;
using System;

public partial class ShitMeasureControl : TextureRect
{
    [Export]
    public Label QuantityLabel { get; set; }
    [Export]
    public Control ShitMeter { get; set; }
    [Export]
    public float MaxOffset { get; set; }    

    public void SetLevel(float value, float MaxValue)
    {
        QuantityLabel.Text = Math.Round(value).ToString();
        if (value == 0)
            SetShitLevels(MaxOffset);
        else
            SetShitLevels(MaxOffset - (value/MaxValue) * MaxOffset);
    }

    private void SetShitLevels(float position)
    {
        ShitMeter.SetDeferred(Control.PropertyName.Position, new Vector2(0, position));
    }
}
