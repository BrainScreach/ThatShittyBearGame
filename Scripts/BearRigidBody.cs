using ThatShittyBearGame.Scripts;
using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class BearRigidBody : RigidBody2D, IPlayer
{
    [Export]
    public Node2D SpriteNode { get; set; }
    [Export]
    public Node2D ShitStainLayer { get; set; }

    [Export]
    public LongSoundPlayer ShitSound { get; set; }

    [Export]
    public Exhaust Exhaust { get; set; }

    [Export]
    public PackedScene ShitStainer { get; set; }
    [Export]
    public StainGenerator StainGenerator { get; set; }

    private Vector2 _shitVector = Vector2.Zero;

    public void _on_visibility_changed()
    {
        SpriteNode.Visible = this.Visible;
    }

    public override void _PhysicsProcess(double delta)
    {
        if(_shitVector != Vector2.Zero)
        {
            this.ApplyCentralForce(_shitVector);
        }
    }


    public void ShitActivate()
    {
        ShitSound.Play();
        Exhaust.Activate();
    }

    public void ShitForce(Vector2 shitVector)
    {
        _shitVector = shitVector;
    }

    public void ShitDeactivate()
    {
        _shitVector = Vector2.Zero;
        ShitSound.Stop();
        Exhaust.Deactivate();
    }

    public void GenerateShitParticle()
    {
        Vector2 mousePos = GetGlobalMousePosition();  
        Vector2 direction = (mousePos - this.Position).Normalized();
        //float rnd = (GD.Randf() - 0.5f) / 3;
        //Vector2 rndDirection = new Vector2(direction.X - rnd, direction.Y + rnd);
        var shitStainer = ShitStainer.Instantiate<ShitStainer>();
        shitStainer.GlobalPosition = Exhaust.GlobalPosition;
        ShitStainLayer.AddChild(shitStainer);
        shitStainer.Launch(direction);
        StainGenerator.SubscribeCollision(shitStainer);
    }
}
