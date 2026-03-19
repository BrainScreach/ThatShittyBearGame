using ThatShittyBearGame.Scripts.Enemy;
using Godot;
using System;
using System.Collections.Generic;

public partial class LandSlideGenerator : Node2D
{
    [Export]
    public Camera2D Camera { get; set; }
    [Export]
    public PackedScene MineNode { get; set; }
    [Export]
    public PackedScene EnemyNode { get; set; }

    [Export]
    public Color LandColor { get; set; }
    [Export]
    public Color LandColor2 { get; set; }

    [Export]
    public float Width { get; set; }
    [Export]
    public float WidthOscilation { get; set; }

    [Export]
    public float Height { get; set; }
    [Export]
    public float HeightOscilation { get; set; }

    private Vector2 _lastPoint;
    public Vector2 LastPoint => _lastPoint;
    private bool _generating = false;
    private float _generateDistance = 4000;
    private bool InvColor = true;
    Dictionary<bool, Color[]> VertColors = new Dictionary<bool, Color[]>();

    public override void _Ready()
    {
        base._Ready();
        Vector2 center = Camera.GetScreenCenterPosition();
        GD.Print("Center: " + center);
        var view = GetViewportRect();
        GD.Print("View: " + view);
        VertColors = new Dictionary<bool, Color[]>()
        {
            { true, new Color[] { LandColor, LandColor2, LandColor2, LandColor } },
            { false, new Color[] { LandColor2, LandColor, LandColor, LandColor2 } },
        };
    }

    public void StartGeneration(Vector2 startPosition)
    {
        _generating = true;
        _lastPoint = startPosition;
        CreateAddLand(_lastPoint);
    }
    public void StopGeneration()
    {
        _generating = false;
    }

    public override void _Process(double delta)
    {
        if (!_generating)
            return;
        if (ShouldGenerate())
        {
            Vector2 start = _lastPoint;
            CreateAddLand(_lastPoint);
            CreateMine(start, _lastPoint);
            CreateEnemy(start, _lastPoint);
        }
        base._Process(delta);
    }

    private bool ShouldGenerate()
    {
        var center = Camera.GetScreenCenterPosition();
        if (center.X > _lastPoint.X)
            return true;
        return center.DistanceTo(_lastPoint) < _generateDistance;
    }

    private void CreateEnemy(Vector2 start, Vector2 lastPoint)
    {
        var count = GD.RandRange(0, 10);
        if(count > 2)
        {
            var enemy = EnemyNode.Instantiate<EnemyHedgehog>();
            var randF = GD.Randf();
            enemy.Position = start.Lerp(lastPoint, randF);
            this.AddChild(enemy);
        }   
    }

    public void CreateMine(Vector2 start, Vector2 end)
    {
        var count = GD.RandRange(1, 3);
        for (int i = 0; i < count; i++)
        {
            var mine = MineNode.Instantiate<Mine>();
            var randF = GD.Randf();
            mine.Position = start.Lerp(end, randF);
            this.AddChild(mine);
        }
    }

    public void CreateAddLand(Vector2 lastPoint)
    {
        var vectors = CreateArray(_lastPoint);
        var polygon = CreatePolygon(vectors);
        var staticBody = CreateRigidBody(vectors);
        polygon.AddChild(staticBody);

        this.AddChild(polygon);
    }

    public StaticBody2D CreateRigidBody(Vector2[] vectors)
    {
        var body = new StaticBody2D();       
        var collisionShape = new CollisionShape2D();
        var shape = new ConvexPolygonShape2D();
        shape.Points = vectors;
        collisionShape.Shape = shape;
        body.AddChild(collisionShape);
        return body;
    }

    private Polygon2D CreatePolygon(Vector2[] vectors)
    {
        var polygon = new Polygon2D()
        {
            Polygon = vectors,
            UV = vectors,
            VertexColors = VertColors[InvColor]
        };
        InvColor = !InvColor;
        return polygon;
    }

    private Vector2[] CreateArray(Vector2 lastPoint)
    {       
        var result = new Vector2[4];        
        result[0] = lastPoint;
        var nextPoint = new Vector2(lastPoint.X + Width + (float)GD.RandRange(0, WidthOscilation), lastPoint.Y + Height + (float)GD.RandRange(0, HeightOscilation));
        result[1] = nextPoint;
        result[2] = new Vector2(nextPoint.X, nextPoint.Y + 2000);
        result[3] = new Vector2(lastPoint.X, nextPoint.Y + 2000);
        _lastPoint = nextPoint;
        return result;
    }
}
