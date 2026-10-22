using Microsoft.Xna.Framework;

namespace MonoGameSummer2026;

public class Transform
{
    public Vector2 _position { get; set; } = Vector2.Zero;
    public float _angle { get; set; }
    public Vector2 _scale { get; set; }  = Vector2.One;
}