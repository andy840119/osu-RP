﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu.Game.Rulesets.Karaoke.Tools.Translator
{
    /// <summary>
    /// translate language code
    /// google : 
    /// https://cloud.google.com/translate/docs/languages
    /// </summary>
    public enum TranslateCode
    {
        [Description("Afrikaans")]//language name in english
        Afrikaans,//   af
        [Description("Albanian")]
        Albanian,//    sq
        Amharic,// am
        Arabic,//  ar
        Armenian,//    hy
        Azeerbaijani,//    az
        Basque,//  eu
        Belarusian,//  be
        Bengali,// bn
        Bosnian,// bs
        Bulgarian,//   bg
        Catalan,// ca
        Cebuano,// ceb (ISO-639-2)
        Chinese_Simplified,// (Simplified)	zh-CN (BCP-47)
        Chinese_Traditional,// (Traditional)	zh-TW (BCP-47)
        Corsican,//    co
        Croatian,//    hr
        Czech,//   cs
        Danish,//  da
        Dutch,//   nl
        English,// en
        Esperanto,//   eo
        Estonian,//    et
        Finnish,// fi
        French,//  fr
        Frisian,// fy
        Galician,//    gl
        Georgian,//    ka
        German,//  de
        Greek,//   el
        Gujarati,//    gu
        Haitian,// Creole  ht
        Hausa,//   ha
        Hawaiian,//    haw (ISO-639-2)
        Hebrew,//  iw
        Hindi,//   hi
        Hmong,//   hmn (ISO-639-2)
        Hungarian,//   hu
        Icelandic,//	is
        Igbo,//    ig
        Indonesian,//  id
        Irish,//   ga
        Italian,// it
        Japanese,//    ja
        Javanese,//    jw
        Kannada,// kn
        Kazakh,//  kk
        Khmer,//   km
        Korean,//  ko
        Kurdish,// ku
        Kyrgyz,//  ky
        Lao,// lo
        Latin,//   la
        Latvian,// lv
        Lithuanian,//  lt
        Luxembourgish,//   lb
        Macedonian,//  mk
        Malagasy,//    mg
        Malay,//   ms
        Malayalam,//   ml
        Maltese,// mt
        Maori,//   mi
        Marathi,// mr
        Mongolian,//   mn
        Myanmar,// (Burmese)	my
        Nepali,//  ne
        Norwegian,//   no
        Nyanja,// (Chichewa)	ny
        Pashto,//  ps
        Persian,// fa
        Polish,//  pl
        Portuguese,// (Portugal, Brazil)	pt
        Punjabi,// pa
        Romanian,//    ro
        Russian,// ru
        Samoan,//  sm
        Scots,// Gaelic    gd
        Serbian,// sr
        Sesotho,// st
        Shona,//   sn
        Sindhi,// sd
        Sinhala,// (Sinhalese)	si
        Slovak,// sk
        Slovenian,// sl
        Somali,// so
        Spanish,// es
        Sundanese,// su
        Swahili,// sw
        Swedish,// sv
        Tagalog,// (Filipino)	tl
        Tajik,// tg
        Tamil,// ta
        Telugu,// te
        Thai,// th
        Turkish,// tr
        Ukrainian,// uk
        Urdu,// ur
        Uzbek,// uz
        Vietnamese,// vi
        Welsh,// cy
        Xhosa,// xh
        Yiddish,// yi
        Yoruba,// yo
        Zulu,//  zu
    }
}
