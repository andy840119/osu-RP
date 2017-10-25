// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Parameter;
using osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.Parameter;

namespace osu.Game.Rulesets.RP.Beatmaps.OtherBeatmap.HitObjectGegenerator.Position
{
    public class PositionGenerator
    {
        internal void ProcessPosition(ConvertParameter single)
        {
            //同一群絁E�E�E皁E�E��E�件位置
            foreach (var singleTupleHitObjects in single.HitObjectConvertParameter.ListSingleHitObjectConvertParameter)
                if (single.ContainerConvertParameter.LayoutNumber == 1) //如果layout只有一個就沒什麼好決定亁E
                {
                    singleTupleHitObjects.ListBaseHitObject[0].ParentObject = single.ContainerConvertParameter.ListObjectContainer[0].ListContainObject[0];
                    //singleTupleHitObjects.ListBaseHitObject[0].RelativeContainerLineGroupIndex = 0;
                    //singleTupleHitObjects.ListBaseHitObject[0].RelativeContainerLineIndex = 0;
                }
                else //兩個以上layout
                {
                    for (var i = 0; i < singleTupleHitObjects.ListBaseHitObject.Count; i++)
                    {
                        //目前在哪一個container 裡面皁E哪個index裡面
                        var layoutindex = GetRandomValue(singleTupleHitObjects, i) % single.ContainerConvertParameter.LayoutNumber;

                        var remain = layoutindex;

                        //取得container位置和對應皁Eayoutindex
                        for (var j = 0; j < single.ContainerConvertParameter.ContainerNumber; j++)
                        {
                            var layoutNumberinSingleContainer = single.ContainerConvertParameter.ListObjectContainer[i].ListContainObject.Count;
                            if (remain < layoutNumberinSingleContainer)
                            {
                                singleTupleHitObjects.ListBaseHitObject[0].ParentObject = single.ContainerConvertParameter.ListObjectContainer[j].ListContainObject[remain];
                                //singleTupleHitObjects.ListBaseHitObject[i].RelativeContainerLineGroupIndex = j;
                                //singleTupleHitObjects.ListBaseHitObject[i].RelativeContainerLineIndex = remain;
                            }
                            remain = remain - j;
                        }
                    }
                }
        }

        //產生亂數�E�E�E�數字不要E�E��E�褁E�E��E�允E
        private int GetRandomValue(SingleHitObjectConvertParameter singleTupleHitObjects, int index)
        {
            //getTheTotal
            var totalHitObject = singleTupleHitObjects.ListBaseHitObject.Count;
            return (int)singleTupleHitObjects.StartTime + index * (totalHitObject - 1);
        }
    }
}
