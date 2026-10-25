using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameSummer2026;

public class Enemy : Animation
{
    public Collider collider { get; set; }

    public Enemy() : base("GreenBird")
    {
        _transform._position =  new Vector2(500, 200);
        _transform._angle = 0;
        _transform._scale = new Vector2(0.2f, 0.2f);

        _color = Color.White;
        
        collider = SceneManager.Create<Collider>();
        collider.Parent = this;
        //  IsTrigger = true will trigger
        //  IsTrigger = false will block
        collider.isTrigger = true;
        
        PlayAnimation(true, 60);
    }
}