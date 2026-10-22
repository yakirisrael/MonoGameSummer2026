using Microsoft.Xna.Framework;

namespace MonoGameSummer2026;

public class Animation : Sprite
{

    public int samples = 60;
    
    double totalTime = 0;

    private int x = 0;
    private int y = 0;
    
    bool looping = true;
    
    bool isAnimating = false;
    public Animation(string SpriteName) : base(SpriteName)
    {
    }

    public void PauseAnimation()
    {
        isAnimating = false;
    }
    
    public void ResumeAnimation()
    {
        isAnimating = true;
    }

    public void StopAnimation()
    {
        Reset();
    }
    
    public void PlayAnimation(bool isLooping = true, int samples = 60)
    {
        this.looping = isLooping;
        this.samples = samples;
        
        Reset();
        isAnimating = true;
    }

    void Reset()
    {
        x = y = 0;
        totalTime = 0;
    }

    bool CanMoveToNextFrame(GameTime gameTime)
    {
        if (!isAnimating) return false;
        
        double deltaSeconds = gameTime.ElapsedGameTime.TotalSeconds;
        
        // samples - number of frames in 1 second
        // 1/samples = fps = the time for 1 frame, then switch to next frame
        
        totalTime += deltaSeconds;
        float fps = 1.0f / samples;
        return (totalTime >= fps);

    }

    void MoveFrame()
    {
        totalTime = 0;
        x++;
        if (x == _spritesheet.columns)
        {
            x = 0;
            y++;

            if (y == _spritesheet.rows)
            {
                if (looping)
                {
                    y = 0;
                    x = 0;
                }
                else
                {
                    x = _spritesheet.columns - 1;
                    y = _spritesheet.rows - 1;
                }

            }
        }

        _sourceRectangle = _spritesheet[x, y];
    }


    public override void Update(GameTime gameTime)
    {
        
        if (CanMoveToNextFrame(gameTime))
        {
            // Switch to next frame
            MoveFrame();
        }
        
        // next lecture - I will explain why it needs to be the last thing here
        base.Update(gameTime);
    }
    
}