using OpenTK;
using OpenTK.Graphics;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using osu.Framework.Timing;
using osu.Framework.Allocation;
using osu.Game.Configuration;
using osu.Framework.Graphics.Containers;
using osu.Framework.MathUtils;

namespace osu.Game.Rulesets.Karaoke.UI.Layer.ShowEffect
{

    /// <summary>
    /// show Visualisation layer
    /// </summary>
    class SnowVisualisation : Container
    {
        TextureStore texture;
        Container spriteManager = new Container();
        int HeightScaled= 450;//480;
        int WidthScaled = 512;//854
        float Ratio = 1;
        bool SixtyFramesPerSecondFrame = true;
        Vector2 CursorPosition = new Vector2(100, 100);
        bool MenuSnowValue = true;
        bool KiaiEnabled = true;
        float currentAlpha = 0;
        float FrameRatio = 1;//?
        int expireTime = 10000;//

        const int res = 1;
        int piles_count = 854 / res + 1;

        float[] piles;
        Vector2 mouseLast;

        /// <summary>
        /// public override void Initialize()
        /// </summary>
        public SnowVisualisation()
        {
            piles = new float[piles_count];

            this.Children = new Drawable[]
                {
                    spriteManager,
                };

            //flake.Additive = true;
            //flake.AlwaysDraw = true;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        

        protected override void Update()
        {

            double currentTime = this.Time.Current; 

            if (SixtyFramesPerSecondFrame)//GameBase.SixtyFramesPerSecondFrame
            {
                if (spriteManager.Children.Count > 0)
                {
                    Vector2 mouseNow = CursorPosition / Ratio;
                    if (mouseLast != Vector2.Zero && mouseLast != mouseNow)
                    {
                        spriteManager.Children.ToList().ForEach(s =>
                        {
                            if (s is SnowSpitie sp)
                            {
                                if (sp.AlwaysDraw)
                                    sp.TagNumeric += (int)((mouseNow.X - mouseLast.X) * 10);
                            }
                        });
                    }
                    mouseLast = mouseNow;

                    for (int i = 0; i < piles_count; i++)
                    {
                        if (piles[i] > 0 && piles[i] < HeightScaled)
                            piles[i] += 0.05f;
                    }
                }

                if (MenuSnowValue)
                {
                    int word = 0;
                    word = -1;

                    int left = 65535;//Utils.LowWord32(word);
                    int right = 65535;//Utils.HighWord32(word);

                    float currentAlpha = KiaiEnabled ? 0.5f : Math.Min(0.5f, Math.Max(0.1f, (left + right - 30000) / 35536f)) * 0.4f;
                    if (RNG.NextDouble() > 1 - currentAlpha)
                    {
                        SnowSpitie newFlake = new SnowSpitie()
                        {
                            Texture= texture.Get(@"Play/osu/approachcircle"),
                            //Size = new Vector2(16) * sliderTick.Scale, //make ball
                            //Masking = true,
                            //CornerRadius = Size.X / 2,
                            Origin = Anchor.Centre,
                            Position = Vector2.Zero,
                            Depth = 1,
                            AlwaysDraw = true,//as alwaysDraw ?
                            Colour = Color4.White,
                            CreateTime = currentTime,
                    };
                        newFlake.Position = new Vector2(RNG.NextSingle(WidthScaled), -50);//GameBase.WindowManager.WidthScaled
                        newFlake.Alpha = RNG.NextSingle(0.7f);
                        newFlake.Scale = new Vector2(0.1f, 0.1f);
                        newFlake.TagNumeric = RNG.Next(-500, 500);
                        newFlake.Tag = RNG.Next(-2, 2);
                        spriteManager.Add(newFlake);
                    }
                }
            }

           

            spriteManager.Children.ToList().ForEach(s =>
            {
                SnowSpitie sp = s as SnowSpitie;

                if (!sp.AlwaysDraw)
                    return;

                bool inRange = sp.Position.X >= 0 && sp.Position.X < WidthScaled;

                int pileIndex = (int)Math.Min(piles_count - 1, Math.Max(0, s.Position.X / res));

                float pileHeight = inRange ? piles[pileIndex] : 0;

                float bottom = sp.Position.Y + sp.Scale.X * (sp.DrawHeight / 1.6f / 2);

                //if touch bottom
                if (bottom >= HeightScaled || (pileHeight > 0 && pileHeight <= bottom)) 
                {
                    sp.Tag = 0;
                    sp.TagNumeric = 0;
                    sp.AlwaysDraw = false;
                    sp.FadeOut(expireTime).Expire();//60000

                    if (!inRange)
                        return;

                    piles[pileIndex] = sp.Position.Y + sp.Scale.X * (sp.DrawHeight / 1.6f / 4);
                }

                if (sp.TagNumeric != 0 || (int)sp.Tag != 0)
                {
                    sp.TagNumeric += (int)sp.Tag;
                    sp.X += sp.TagNumeric / 5000f * FrameRatio;
                    sp.Y += 1 * FrameRatio;
                    sp.Rotation += sp.TagNumeric / 10000f * FrameRatio * 0.4f;
                }

                //recycle
                if (sp.CreateTime + expireTime < currentTime)
                {
                    spriteManager.Children.ToList().Remove(s);
                }

            });

            base.Update();
        }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            texture = textures;
        }
    }

    /// <summary>
    /// show spirit
    /// </summary>
    public class SnowSpitie : Sprite
    {
        public int TagNumeric { get; set; }

        public Object Tag { get; set; }

        public bool AlwaysDraw { get; set; }

        public double CreateTime { get; set; }
    }
}
