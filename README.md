<<<<<<< HEAD
# osu-RP  
[Notification]   
Because I need to concentrate on preparing Japanese examination(N2),    
So i decide stop developing this project for 2.5 monthes.   
.   
See you in July : )   
.
[introduce]   
the new gameMode in osu!laser : )   
.   
this gameMode is not official project, but maybe can play by adding additional plugin in osu!laser.   
.   
[HowToPlay]   
1.Clone this project.   
2.Open in VisualStudio or Mono.   
3.Add "Resources.AddStore(new DllResourceStore("osu.Game.Modes.RP.dll"));" into osu.Framework/Game.cs after line:109    
if you not add it ,there are no texture while playing RP GameMode.   
4.Compile it and enjoy it : )   
.   
https://github.com/andy840119/osu-RP_resource   
resource of texture and sample is in here   
.   
this is the blog of this project's progress.  
the progress will be report in there if I remember : )   
https://rp7310.wordpress.com/   
.   
and it is the idea of this gameMode's name    
it's not so bad but not so good,and it's hard for me to come out for a better name.   
https://zh.wikipedia.org/wiki/RP   
.   
this project cannot use in commercial.   
.   
and this is README's editor,just let me to edit this file more convenient   
README.md 的編輯器用這個，貼在這邊比方便之後找   
http://dillinger.io/   
還有換行季記得要空兩個空格以上     
=======
# osu! [![Build status](https://ci.appveyor.com/api/projects/status/u2p01nx7l6og8buh?svg=true)](https://ci.appveyor.com/project/peppy/osu)  [![CodeFactor](https://www.codefactor.io/repository/github/ppy/osu/badge)](https://www.codefactor.io/repository/github/ppy/osu) [![dev chat](https://discordapp.com/api/guilds/188630481301012481/widget.png?style=shield)](https://discord.gg/ppy)

Rhythm is just a *click* away. The future of [osu!](https://osu.ppy.sh) and the beginning of an open era!

# Status

This is still heavily under development and is not intended for end-user use. This repository is intended for developer collaboration. You're welcome to try and use it but please do not submit bug reports without a patch. Please do not ask for help building or using this software.

# Requirements

- A desktop platform which can compile .NET 4.5 (tested on macOS, linux and windows). We recommend using [Visual Studio Code](https://code.visualstudio.com/) (all platforms) or [Visual Studio Community Edition](https://www.visualstudio.com/) (windows only), both of which are free.
- Make sure you initialise and keep submodules up-to-date.

# Contributing

We welcome all contributions, but keep in mind that we already have a lot of the UI designed. If you wish to work on something with the intention on having it included in the official distribution, please open an issue for discussion and we will give you what you need from a design perspective to proceed. If you want to make *changes* to the design, we recommend you open an issue with your intentions before spending too much time, to ensure no effort is wasted.

Please make sure you are familiar with the [development and testing](https://github.com/ppy/osu-framework/wiki/Development-and-Testing) procedure we have set up. New component development, and where possible, bug fixing and debugging existing components **should always be done under VisualTests**.

Contributions can be made via pull requests to this repository. We hope to credit and reward larger contributions via a [bounty system](https://www.bountysource.com/teams/ppy). If you're unsure of what you can help with, check out the [list of open issues](https://github.com/ppy/osu/issues).

Note that while we already have certain standards in place, nothing is set in stone. If you have an issue with the way code is structured; with any libraries we are using; with any processes involved with contributing, *please* bring it up. I welcome all feedback so we can make contributing to this project as pain-free as possible.

# Licence

The osu! client code and framework are licensed under the [MIT licence](https://opensource.org/licenses/MIT). Please see [the licence file](LICENCE) for more information. [tl;dr](https://tldrlegal.com/license/mit-license) you can do whatever you want as long as you include the original copyright and license notice in any copy of the software/source.

Please note that this *does not cover* the usage of the "osu!" or "ppy" branding in any software, resources, advertising or promotion, as this is protected by trademark law.

Please also note that game resources are covered by a separate licence. Please see the [ppy/osu-resources](https://github.com/ppy/osu-resources) repository for clarifications.
>>>>>>> 37c0772537ec141bbe55fc6a2e2da545509ecd9d
