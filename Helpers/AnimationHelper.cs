using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Helpers
{
    public static class AnimationHelper
    {
        public static void PlayRandomAnimation(AnimatedSprite2D sprite)
        {
            var sprites = sprite.SpriteFrames.GetAnimationNames();
            sprite.Play(sprites[GD.RandRange(0, sprites.Length - 1)]);
        }
    }
}
