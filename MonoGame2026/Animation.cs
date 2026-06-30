using Microsoft.Xna.Framework;

namespace MonoGame2026;

public class Animation : Sprite
{
    double totalTime;
    private int fps = 60;
    bool isLooping = true;
    bool isAnimating = false;
    
    private int x = 0;
    private int y = 0;
    
    public Animation(string spriteName) : base(spriteName)
    {
    }

    public override void Start()
    {
        base.Start();
    }

    public void Play(int fps = 60)
    {
        isAnimating = true;
        this.fps = fps;
    
        Reset();
    }

    public void Reset()
    {
        x = 0;
        y = 0;

        totalTime = 0;
    }

    bool ShouldMoveToNextFrame(GameTime gameTime)
    {
        if (!isAnimating)  return false;
        
        double deltaTime = gameTime.ElapsedGameTime.TotalSeconds;

        totalTime += deltaTime;

        if (totalTime >= 1.0f / fps)
        {
            return true;
        }

        return false;
    }

    public override void Update(GameTime gameTime)
    {
        if (ShouldMoveToNextFrame(gameTime))
        {
            totalTime = 0.0f;
            x++;
            if (x == spritesheet.columns)
            {
                // next line
                x = 0;
                y++;
                if (y == spritesheet.rows)
                {
                    if (isLooping)
                    {
                        x = 0;
                        y = 0;
                    }
                    else
                    {
                        x = spritesheet.columns - 1;
                        y  = spritesheet.rows - 1;
                    }
                }
            }
        }

        _sourceRect = spritesheet[x, y];

        base.Update(gameTime);
    }

}