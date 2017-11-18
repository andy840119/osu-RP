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
using osu.Framework.Graphics.Shapes;

namespace osu.Game.Rulesets.Karaoke.UI.Layer.ShowEffect
{

    /// <summary>
    /// show Visualisation layer
    /// </summary>
    public class SnowVisualisationLayer : Container
    {
        private TextureStore texture;

        public bool MenuSnowValue { get; set; } = true;
        public int SnowExpireTime { get; set; } = 10000;
        public Vector2 CursorPosition { get; set; } = new Vector2(100, 100);
        public float CursorAffectRatio { get; set; } = 1;
        public bool IsKiai { get; set; } = false;
        public bool Active { get; set; } = true;
        public float Speed { get; set; } = 1;
        public String TexturePath { get; set; } = @"Play/Karaoke/Layer/Snow/Snow";
        private Container snowContainer = new Container();

        private int piles_count = 854 + 1;
        private float[] piles;
        private Vector2 lastCursorPosition;

        /// <summary>
        /// initialize
        /// </summary>
        public SnowVisualisationLayer()
        {
            piles = new float[piles_count];
            Width = 512;
            Height = 450;

            this.Children = new Drawable[]
            {
                snowContainer,
            };
        }

        /// <summary>
        /// dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            snowContainer.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// update
        /// </summary>
        protected override void Update()
        {

            double currentTime = this.Time.Current; 

            if (Active)//GameBase.SixtyFramesPerSecondFrame
            {
                if (snowContainer.Children.Count > 0)
                {
                    Vector2 mouseNow = CursorPosition / CursorAffectRatio;
                    if (lastCursorPosition != Vector2.Zero && lastCursorPosition != mouseNow)
                    {
                        snowContainer.Children.ToList().ForEach(s =>
                        {
                            if (s is SnowSpitie sp)
                            {
                                if (sp.AlwaysDraw)
                                    sp.TagNumeric += (int)((mouseNow.X - lastCursorPosition.X) * 10);
                            }
                        });
                    }
                    lastCursorPosition = mouseNow;

                    for (int i = 0; i < piles_count; i++)
                    {
                        if (piles[i] > 0 && piles[i] < Height)
                            piles[i] += 0.05f;
                    }
                }

                if (MenuSnowValue)
                {
                    int word = 0;
                    word = -1;

                    int left = 65535;//Utils.LowWord32(word);
                    int right = 65535;//Utils.HighWord32(word);

                    float currentAlpha = IsKiai ? 0.5f : Math.Min(0.5f, Math.Max(0.1f, (left + right - 30000) / 35536f)) * 0.4f;
                    if (RNG.NextDouble() > 1 - currentAlpha)
                    {
                        SnowSpitie newFlake = new SnowSpitie()
                        {
                            Texture= texture.Get(@"Play/Karaoke/Layer/Snow/Snow"),//64*64
                            Origin = Anchor.Centre,
                            Anchor = Anchor.Centre,
                            Colour = Color4.White,
                            Position = Vector2.Zero,
                            Depth = 1,
                            AlwaysDraw = true,//as alwaysDraw ?
                            CreateTime = currentTime,
                            Scale= new Vector2(0.3f, 0.3f),
                        };
                        newFlake.Position = new Vector2(RNG.NextSingle(Width), -50);//GameBase.WindowManager.WidthScaled
                        newFlake.Alpha = RNG.NextSingle(0.7f);
                        newFlake.TagNumeric = RNG.Next(-500, 500);
                        newFlake.Tag = RNG.Next(-2, 2);
                        snowContainer.Add(newFlake);
                    }
                }
            }

            snowContainer.Children.ToList().ForEach(s =>
            {
                SnowSpitie sp = s as SnowSpitie;

                if (!sp.AlwaysDraw)
                    return;

                bool inRange = sp.Position.X >= 0 && sp.Position.X < Width;

                int pileIndex = (int)Math.Min(piles_count - 1, Math.Max(0, s.Position.X ));

                float pileHeight = inRange ? piles[pileIndex] : 0;

                float bottom = sp.Position.Y + sp.Scale.X * (sp.DrawHeight / 1.6f / 2);

                //if touch bottom
                if (bottom >= Height || (pileHeight > 0 && pileHeight <= bottom)) 
                {
                    sp.Tag = 0;
                    sp.TagNumeric = 0;
                    sp.AlwaysDraw = false;
                    sp.FadeOut(SnowExpireTime).Expire();//60000

                    if (!inRange)
                        return;

                    piles[pileIndex] = sp.Position.Y + sp.Scale.X * (sp.DrawHeight / 1.6f / 4);
                }

                if (sp.TagNumeric != 0 || (int)sp.Tag != 0)
                {
                    sp.TagNumeric += (int)sp.Tag;
                    sp.X += sp.TagNumeric / 5000f * Speed;
                    sp.Y += 1 * Speed;
                    sp.Rotation += sp.TagNumeric / 10000f * Speed * 0.4f;
                }

                //recycle
                if (sp.CreateTime + SnowExpireTime < currentTime)
                {
                    snowContainer.Children.ToList().Remove(s);
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
