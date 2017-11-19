// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

namespace osu.Game.Rulesets.RP.UI.GamePlay.KeyCounter
{
    /// <summary>
    ///     RP專用計數器裡面的其中一個按鍵
    /// </summary>
    //internal class RpKeyCounterKeyboard : KeyCounterKeyboard
    //{
    //    private readonly SingleKeyLayout _layout;

    //    //
    //    private readonly RpKeyLayoutConfig.SingleKey _singlekey;

    //    //顯示按鈕
    //    private Sprite _buttonIconSprite;

    //    //顯示按鍵名稱
    //    private SpriteText _textSprite;

    //    /// <summary>
    //    ///     建構
    //    /// </summary>
    //    /// <param name="name"></param>
    //    public RpKeyCounterKeyboard(string name, RpKeyLayoutConfig.SingleKey singlekey, SingleKeyLayout layout)
    //        : base(singlekey.Key)
    //    {
    //        _singlekey = singlekey;
    //        _layout = layout;
    //        IsCounting = true;
    //    }

    //    [BackgroundDependencyLoader]
    //    private void load(TextureStore textures)
    //    {
    //        Children = new Drawable[]
    //        {
    //            buttonSprite = new Sprite
    //            {
    //                Texture = textures.Get(@"KeyCounter/key-up"),
    //                Anchor = Anchor.Centre,
    //                Origin = Anchor.Centre
    //            },
    //            glowSprite = new Sprite
    //            {
    //                Texture = textures.Get(@"KeyCounter/key-glow"),
    //                Anchor = Anchor.Centre,
    //                Origin = Anchor.Centre,
    //                Alpha = 0
    //            },
    //            textLayer = new Container
    //            {
    //                Anchor = Anchor.Centre,
    //                Origin = Anchor.Centre,
    //                RelativeSizeAxes = Axes.Both,
    //                Children = new Drawable[]
    //                {
    //                    _textSprite = new SpriteText
    //                    {
    //                        Text = Name,
    //                        Anchor = Anchor.Centre,
    //                        Origin = Anchor.Centre,
    //                        RelativePositionAxes = Axes.Both,
    //                        Position = new Vector2(0, -0.25f),
    //                        Colour = KeyUpTextColor
    //                    },
    //                    countSpriteText = new SpriteText
    //                    {
    //                        Text = Count.ToString(@"#,0"),
    //                        Anchor = Anchor.Centre,
    //                        Origin = Anchor.Centre,
    //                        RelativePositionAxes = Axes.Both,
    //                        Position = new Vector2(0, 0.25f),
    //                        Colour = KeyUpTextColor
    //                    },
    //                    _buttonIconSprite = new Sprite
    //                    {
    //                        Texture = textures.Get(RpTexturePathManager.GetKeyLayoutButtonIcon(_singlekey.Type)),
    //                        Colour = RpTextureColorManager.GetCoopHitObjectColor(_singlekey.Coop),
    //                        Anchor = Anchor.Centre,
    //                        Origin = Anchor.Centre,
    //                        Alpha = 1,
    //                        Scale = new Vector2(0.25f),
    //                        Position = new Vector2(0, -0.25f)
    //                    }
    //                }
    //            }
    //        };

    //        //KeyCounter Text Color
    //        //KeyDownTextColor = RpTextureColorManager.GetCoopLayoutColor(_singlekey.Coop);
    //        //KeyCounter border color
    //        buttonSprite.Colour = RpTextureColorManager.GetCoopLayoutColor(_singlekey.Coop);
    //        //KeyCounter inside color
    //        glowSprite.Colour = RpTextureColorManager.GetCoopLayoutColor(_singlekey.Coop);


    //        //Set this manually because an element with Alpha=0 won't take it size to AutoSizeContainer,
    //        //so the size can be changing between buttonSprite and glowSprite.
    //        Height = buttonSprite.DrawHeight;
    //        Width = buttonSprite.DrawWidth;

    //        var fixPosition = new Vector2(0, -10f);
    //        var upperPosition = new Vector2(0, -0.25f);
    //        var lowerPosition = new Vector2(0, 0.25f);
    //        switch (_layout)
    //        {
    //            case SingleKeyLayout.KeyIcon_Code:
    //                _buttonIconSprite.Position = upperPosition + fixPosition;
    //                _textSprite.Position = lowerPosition;
    //                countSpriteText.Alpha = 0;
    //                break;
    //            case SingleKeyLayout.keyCount_Code:
    //                _textSprite.Position = upperPosition;
    //                countSpriteText.Position = lowerPosition;
    //                _buttonIconSprite.Alpha = 0;
    //                break;
    //            case SingleKeyLayout.KeyIcon_Count:
    //                _buttonIconSprite.Position = upperPosition + fixPosition;
    //                countSpriteText.Position = lowerPosition;
    //                _textSprite.Alpha = 0;
    //                break;
    //        }
    //    }

    //    public enum SingleKeyLayout
    //    {
    //        KeyIcon = 1,
    //        keyCode = 2,
    //        keyCount = 4,
    //        KeyIcon_Code = KeyIcon | keyCode,
    //        keyCount_Code = keyCode | keyCount,
    //        KeyIcon_Count = KeyIcon | keyCount
    //    }
    //}
}
