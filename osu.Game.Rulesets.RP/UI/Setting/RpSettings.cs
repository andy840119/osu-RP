// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Platform;
using osu.Game.Configuration;
using osu.Game.Overlays.Settings;

namespace osu.Game.Rulesets.RP.UI.Setting
{
    /// <summary>
    ///     use as config the key or any setting of the osu!Rp
    /// </summary>
    public class RpSettings : SettingsSubsection
    {
        protected override string Header => "Rp!";

        [BackgroundDependencyLoader]
        private void load(OsuConfigManager config)
        {
            Children = new Drawable[]
            {
                new SettingsCheckbox
                {
                    LabelText = "Testing Setting 001",
                    //Bindable = config.GetBindable<bool>(RpSetting.SettingTesting001)
                },
                new SettingsCheckbox
                {
                    LabelText = "Testing Setting 002",
                    //Bindable = config.GetBindable<bool>(RpSetting.SettingTesting002)
                },
            };
        }
    }

    //RpConfigManager
    public class RpConfigManager : ConfigManager<RpSetting>
    {
        public RpConfigManager(Storage storage)
            : base(storage)
        {
        }

        protected override void InitialiseDefaults()
        {
            Set(RpSetting.SettingTesting001, true);
            Set(RpSetting.SettingTesting002, true);
        }
    }

    //all the setting attribute
    public enum RpSetting
    {
        SettingTesting001,
        SettingTesting002,
    }
}
