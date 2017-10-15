// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.RP.Objects;
using osu.Game.Rulesets.RP.Objects.Drawables.Play;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.RP.SkinManager
{
    /// <summary>
    ///     manage all the texture path.
    /// </summary>
    public static class RpTexturePathManager
    {
        /// <summary>
        ///     RP指標
        /// </summary>
        public static string RPPointer = RP_OBJECT_FOLDER + @"Common/" + @"RP-Pointer@2x_remove";

        private const string RP_HIT_EFFECT_FOLDER = @"Play/RP/HitEffect/";
        private const string RP_LOAD_EFFECT_FOLDER = @"Play/RP/LoadEffect/";
        private const string RP_OBJECT_FOLDER = @"Play/RP/RPObject/";
        private const string RP_NUMBER_FOLDER = @"Play/RP/Number/";
        private const string RP_SCORE_FOLDER = @"Play/RP/Score/";
        private const string RP_KEYCOUNTER_FOLDER = @"Play/RP/KeyCounter/";
        private const string RP_CONTAINER_FOLDER = RP_OBJECT_FOLDER + @"Common/Normal/Container/";

        private const string RP_CONFIG_FOLDER = @"Play/RP/Config/";

        private const string JPG_FORMAT = @".jpg";
        private const string PNG_FORMAT = @".png";

        /// <summary>
        ///     取得數字
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string GetNumber(int number)
        {
            return "";
        }

        /// <summary>
        ///     按鈕要用的icon
        /// </summary>
        /// <returns></returns>
        public static string GetKeyLayoutButtonIcon(Shape Type)
        {
            return RP_KEYCOUNTER_FOLDER + Type;
        }

        /// <summary>
        ///     RP物件聲音
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetRPHitSound(BaseRpHitableObject baseHitObject)
        {
            return "";
        }

        public static string GetRPHitEffect(HitResult result, string resource)
        {
            return RP_HIT_EFFECT_FOLDER + GetStringFromHitResult(result) + @"/" + resource;
        }

        public static string GetStringFromHitResult(HitResult result)
        {
            switch (result)
            {
                case HitResult.Meh:
                    return "Sad";
                case HitResult.Ok:
                    return "Sad";
                case HitResult.Good:
                    return "Safe";
                case HitResult.Great:
                    return "Fine";
                case HitResult.Perfect:
                    return "Cool";
                default:
                    return "Sad";
            }
        }

        public static string GetDecisionLineTexture()
        {
            return RP_CONTAINER_FOLDER + "DecisionLine";
        }


        public static string GetBeatLineTexture()
        {
            return RP_CONTAINER_FOLDER + "DecisionLine";
        }

        public static string GetRectangleTexture()
        {
            return RP_CONTAINER_FOLDER + "Background";
        }

        /// <summary>
        ///     打擊特效
        /// </summary>
        /// <returns></returns>
        public static string GetRPLoadEffect()
        {
            return RP_LOAD_EFFECT_FOLDER + @"Load";
        }

        /// <summary>
        ///     取得一個Note的開頭物件
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetStartObjectImageNameByType(ObjectType type, Special special, Direction direction)
        {
            string path = GetObjectImagePathByType(type, special, false) + GetImageNameByDirection(direction);
            return path;
        }

        /// <summary>
        ///     取得一個Note的結尾物件
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetEndObjectImageNameByType(BaseRpHitableObject baseHitObject)
        {
            return GetObjectImagePathByType(baseHitObject, true) + GetImageNameByType(baseHitObject);
        }

        /// <summary>
        ///     取得 開始物件的遮罩
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetStartObjectMaskByType(BaseRpHitableObject baseHitObject)
        {
            return GetObjectImagePathByType(baseHitObject, false) + "Mask";
        }

        /// <summary>
        ///     取得 結束物件的遮罩
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetEndObjectMaskByType(BaseRpHitableObject baseHitObject)
        {
            return GetObjectImagePathByType(baseHitObject, true) + "Mask";
        }

        /// <summary>
        ///     取得 開始物件的遮罩
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetStartObjectBackgroundByType(BaseRpHitableObject baseHitObject)
        {
            var str = GetObjectImagePathByType(baseHitObject, false) + "background-" + GetImageNameByType(baseHitObject);
            return str;
        }

        /// <summary>
        ///     取得 結束物件的遮罩
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        public static string GetEndObjectBackgroundByType(BaseRpHitableObject baseHitObject)
        {
            return GetObjectImagePathByType(baseHitObject, true) + "background-" + GetImageNameByType(baseHitObject);
        }

        /// <summary>
        ///     根據物件取得對應的顏色
        ///     會在之後實作
        /// </summary>
        /// <returns></returns>
        public static Color4 GetColor(BaseRpHitableObject baseHitObject)
        {
            var colour = new Color4(255, 255, 255, 255);
            return colour;
        }

        /// <summary>
        ///     根據型態取得物件圖片路徑
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        private static string GetObjectImagePathByType(BaseRpHitableObject baseHitObject, bool end = false)
        {
            var fileName = "";

            //物件是開頭還是尾巴
            if (end)
                fileName = @"End/" + fileName;
            else
                fileName = @"Start/" + fileName;

            //根據模式去命名資料夾
            fileName = baseHitObject.ObjectType + @"/" + fileName;


            //如果是黃金模式(家分模式)
            fileName = GetObjectImagePathBySpecial(baseHitObject.Special) + fileName;

            //不同落下模式
            //if (baseHitObject.ApproachType == ApproachType.ApproachCircle)
            fileName = @"Circle/" + fileName;
            //else
            //    fileName = @"Square/" + fileName;

            return RP_OBJECT_FOLDER + fileName;
        }

        /// <summary>
        ///     根據型態取得物件圖片路徑
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <returns></returns>
        private static string GetObjectImagePathByType(ObjectType type, Special special, bool end = false)
        {
            var fileName = "";

            //物件是開頭還是尾巴
            if (end)
                fileName = @"End/" + fileName;
            else
                fileName = @"Start/" + fileName;

            //根據模式去命名資料夾
            fileName = GetPathByObjectType(type) + fileName;


            //如果是黃金模式(家分模式)
            fileName = GetObjectImagePathBySpecial(special) + fileName;

            //不同落下模式
            //if (baseHitObject.ApproachType == ApproachType.ApproachCircle)
            fileName = @"Circle/" + fileName;
            //else
            //    fileName = @"Square/" + fileName;

            return RP_OBJECT_FOLDER + fileName;
        }

        private static string GetObjectImagePathBySpecial(Special special)
        {
            if (special == Special.Normal)
                return @"Normal/";
            else
                return @"Special/";
        }

        private static string GetPathByObjectType(ObjectType type)
        {
            switch (type)
            {
                case ObjectType.Undefined:
                    return @"Undefined/";
                case ObjectType.Hit:
                    return @"Hit/";
                case ObjectType.Hold:
                    return @"Hold/";
                case ObjectType.ContainerGroup:
                    return @"ContainerGroup/";
                case ObjectType.ContainerLine:
                    return @"ContainerLine/";
                case ObjectType.ContainerHold:
                    return @"ContainerHold/";
            }
            return "";
        }

        /// <summary>
        ///     圖片名稱
        /// </summary>
        /// <param name="baseHitObject"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        private static string GetImageNameByType(BaseRpHitableObject baseHitObject)
        {
            string fileName = null;

            if (baseHitObject as RpHitObject != null)
            {
                switch ((baseHitObject as RpHitObject).Direction)
                {
                    case Direction.Up:
                        fileName = @"Up";
                        break;
                    case Direction.Down:
                        fileName = @"Down";
                        break;
                    case Direction.Left:
                        fileName = @"Left";
                        break;
                    case Direction.Right:
                        fileName = @"Right";
                        break;
                    default:
                        return @"RP_Unknown";
                }
            }
            else
            {
                switch (baseHitObject.Shape)
                {
                    case Shape.ContainerPress:
                        fileName = @"Left";
                        break;
                    default:
                        return @"RP_Unknown";
                }
            }
            return fileName;
        }

        private static string GetImageNameByDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return @"Up";
                case Direction.Down:
                    return @"Down";
                case Direction.Left:
                    return @"Left";
                case Direction.Right:
                    return @"Right";
                default:
                    return @"RP_Unknown";
            }
        }
    }
}
