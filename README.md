
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/LAB02-Research/HASS.Agent)](https://github.com/LAB02-Research/HASS.Agent/releases/)
[![license](https://img.shields.io/badge/license-MIT-blue)](#license)
[![OS - Windows](https://img.shields.io/badge/OS-Windows-blue?logo=windows&logoColor=white)](https://www.microsoft.com/ "Go to Microsoft homepage")
[![dotnet](https://img.shields.io/badge/.NET-6.0-blue)](https://img.shields.io/badge/.NET-6.0-blue)
![GitHub all releases](https://img.shields.io/github/downloads/LAB02-Research/HASS.Agent/total?color=blue)
![GitHub latest](https://img.shields.io/github/downloads/LAB02-Research/HASS.Agent/latest/total?color=blue)
[![Discord](https://img.shields.io/badge/dynamic/json?color=blue&label=Discord&logo=discord&logoColor=white&query=presence_count&suffix=%20Online&url=https://discordapp.com/api/guilds/932957721622360074/widget.json)](https://discord.gg/nMvqzwrVBU)
[![Documentation Status](https://readthedocs.org/projects/hassagent/badge/?version=latest)](https://hassagent.readthedocs.io/en/latest/?badge=latest)

<a href="https://github.com/LAB02-Research/HASS.Agent/">
    <img src="https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/logo_128.png" alt="HASS.Agent logo" title="HASS.Agent" align="right" height="128" /></a>

# HASS.Agent

HASS.Agent is a Windows-based client (*companion*) application for [Home Assistant](https://www.home-assistant.io), developed in .NET 6.

Click [here](https://github.com/LAB02-Research/HASS.Agent/releases/latest/download/HASS.Agent.Installer.exe) to download the latest installer.

----

### C# or Python developer? Please read this: [lab02-research.org/2023-04-01-help-wanted](https://lab02-research.org/2023-04-01-help-wanted/)

### HASS.Agent is in need of your help! :heart:

----

Agora o HASS.Agent está em português do Brasil para brasileiros e usuários de língua portuguesa!

Clique [aqui](https://github.com/LAB02-Research/HASS.Agent/releases/tag/b2022.4.2) para baixar o instalador mais recente com a tradução! Obrigado [@LeandroIssa](https://github.com/LeandroIssa) :)

----

HASS.Agent is **completely free**, and will always stay that way without restrictions. 

However, developing and maintaining this tool (and everything that surrounds it) takes up a lot of time. Like most developers, I run on caffeïne - so a cup of coffee is always very much appreciated! 

| [![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/lab02research) |  [!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research) | [![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donate_LG.gif)](https://www.paypal.com/donate/?hosted_button_id=5YL6UP94AQSPC) |
|:---:|---|---|

----

### Contents

 * [Sponsors](#sponsors)
 * [Why?](#why)
 * [Functionality](#functionality)
 * [Screenshots](#screenshots)
 * [Installation](#installation)
 * [Help and Documentation](#help-and-documentation)
 * [Articles](#articles)
 * [What it's not](#what-its-not)
 * [Issue Tracker](#issue-tracker)
 * [Helping Out](#helping-out)
 * [Wishlist](#wishlist)
 * [Credits and Licensing](#credits-and-licensing)
 * [Legacy](#legacy)

----

### Sponsors

I'd like to thank everyone that's been [donating](https://www.buymeacoffee.com/lab02research)! It's not always easy to pick up work for HASS.Agent (next to a full time job), but people taking the time to donate really motivates a lot. It says that you enjoy the work I've been putting in, and makes the trouble worthwhile :)

A big big thank you to the [monthly sponsors](https://github.com/sponsors/LAB02-Admin), you absolutely rock :heart:

<a href="https://github.com/jdiegmueller/"><img src="https://github.com/jdiegmueller.png" width="60" height="60"></a>
<a href="https://github.com/ewonais/"><img src="https://github.com/ewonais.png" width="60" height="60"></a>
<a href="https://github.com/thornzero/"><img src="https://github.com/thornzero.png" width="60" height="60"></a>
<a href="https://github.com/dannytsang/"><img src="https://github.com/dannytsang.png" width="60" height="60"></a>

----

### Why?

The main reason I built this is that I wanted to receive notifications on my PC, including images, and to quickly perform actions (e.g. to toggle a lamp). There weren't any software-based solutions for this, so I set out to build one myself. 

----

### Functionality

Summary of the core functions:

* **Notifications**: receive notifications, show them using Windows builtin toast popups, and optionally attach images. Supports *actionable notifications*: add buttons so you can easily interact with Home Assistant, without having to open anything.
  - *This requires the installation of the [HASS.Agent integration](https://github.com/LAB02-Research/HASS.Agent-Integration)*.

* **Media Player**: use HASS.Agent as a mediaplayer device: see and control what's playing and send text-to-speech.
  - *This requires the installation of the [HASS.Agent integration](https://github.com/LAB02-Research/HASS.Agent-Integration)*.

* **Quick Actions**: use a keyboard shortcut to quickly pull up a command interface, through which you can control Home Assistant entities - or, assign a keyboard shortcut to individual Quick Actions for even faster triggering.

* **Commands** (currently **24**): control your PC (or other Windows based device) through Home Assistant using custom- or built-in commands.

* **Sensors** (currently **37**): send your PC's sensors to Home Assistant to monitor every aspect of your device.

* **WebView**: quickly show any website, anywhere - no browser required, for instance a HA dashboard.

* **Satellite Service**: use the service to collect sensordata and execute commands, even when you're not logged in. 

* All entities are dynamically acquired from your Home Assistant instance.

* Commands and sensors are automatically added to your Home Assistant instance.

----

### Screenshots

Notification examples:

![image](https://user-images.githubusercontent.com/81011038/199956334-642def7d-4cb4-46f3-a73b-25c76e5bd02c.png)  ![Text-based toast notification](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_toast_text.png)  


WebView example, showing a dashboard when right-clicking the tray icon:

![WebView](https://user-images.githubusercontent.com/81011038/174068053-971adb8b-f552-43bc-a39b-6c6c4a3bda9c.png)

This is the Quick Action window you'll see when using the hotkey. This window automatically resizes to the amount of buttons you've added:

![Quick Actions](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_quickactions.png)

You can easily configure a new Quick Action, HASS.Agent will fetch your entities for you:

![New Quick Actions](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_new_quickaction.png)

The sensors configuration screen:

![Sensors](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_sensors.png)
    
Adding a new sensor is just as easy:

![Sensors](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_new_sensor.png)

Easily manage the satellite service through HASS.Agent:

![Service](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/images/hass_agent_satellite_service.png)

You'll be guided through the configuration options during onboarding:

![Onboarding](https://user-images.githubusercontent.com/81011038/198251220-d15b4b3b-264e-44bc-b52f-5c404f9efb1f.png)
    
For more, check [the screenshots page](https://hassagent.readthedocs.io/en/latest/screenshots/) in the docs.
    
----

### Installation

Installing HASS.Agent is easy; just [download the latest installer](https://github.com/LAB02-Research/HASS.Agent/releases/latest/download/HASS.Agent.Installer.exe), run it and you're done! The installer is signed and won't download or do weird stuff - it just places everything where it should, and launches with the right parameter. 

After installing, the onboarding process will help you get everything configured, step by step. If you want an introduction into HASS.Agent, be sure to read the [introduction docs](https://hassagent.readthedocs.io/en/latest/introduction/).

[Click here to download the latest installer](https://github.com/LAB02-Research/HASS.Agent/releases/latest/download/HASS.Agent.Installer.exe)

If you want to install manually, there are .zip packages available for every release. Read the [manual](https://hassagent.readthedocs.io/en/latest/installation/#2-manual) for more info.

----

### Help and Documentation

Stuck while installing or using HASS.Agent, need some help integrating the sensors/commands or have a great idea for the next version? There are a few channels through which you can reach out:

* [Github Tickets](https://github.com/LAB02-Research/HASS.Agent): Report bugs, feature requests, ideas, tips, ..

* [Documentation](https://hassagent.readthedocs.io/): Installation, configuration and usage documentation, as well as examples.

* [LAB02 Research Site](https://lab02-research.org/): Release info, development backstories, misc. posts.

* [Discord](https://discord.gg/nMvqzwrVBU): Get help with setting up and using HASS.Agent, report bugs or just talk about whatever.

* [Home Assistant forum](https://community.home-assistant.io/t/hass-agent-a-new-windows-based-client-to-receive-notifications-perform-quick-actions-and-much-more/369094): Bit of everything, with the addition that other HA users can help as well.

Starting from zero, and want to learn what HASS.Agent's about and how to start? Be sure to check the [introduction article](https://hassagent.readthedocs.io/en/latest/introduction/), and optionally the [command basics](https://hassagent.readthedocs.io/en/latest/commands/command-basics/).

EverythingSmartHome's youtube video is a great guide as well: [Control Your Windows PC With Home Assistant!](https://www.youtube.com/watch?v=B4SnJPVbSXc)

If you want to help with the development of HASS.Agent, check out the [Helping Out](#helping-out) section for (translating) info.

----

### Articles

Liam Alexander Colman from [Home Assistant Guide](https://home-assistant-guide.com) was kind enough to write an article about HASS.Agent: [Integrate Home Assistant with Windows using HASS.Agent](https://home-assistant-guide.com/2022/04/20/integrate-home-assistant-with-windows-using-hass-agent/). The website's full of useful articles, worth having a look :)

Youtuber EverythingSmartHome made a great video about HASS.Agent: [Control Your Windows PC With Home Assistant!](https://www.youtube.com/watch?v=B4SnJPVbSXc). I recommend having a look at his other videos as well, great stuff!

----

### What it's not

A Linux/macOS client! 

This question comes up a lot, understandably. However it's currently focussed on being a Windows-based client. Even though .NET 6 allows for Linux/macOS development, it's not as easy as pressing a button. The interface would have to be redesigned from the ground up, sensors and commands would need multiple codebases for each OS, testing would take way more time, every OS handles notifications differently, etc.

Since this is a sparetime project, next to a fulltime job, it's just not realistic. I'd love to tinker with it in the future, perhaps as a testcase for Microsoft's new MAUI platform, but it won't happen anytime soon. By focussing on Windows, I can make sure it really excels there instead of being meh everywhere.

You can use the [official companion app](https://apps.apple.com/us/app/home-assistant/id1099568401) for macOS, or [IoPC](https://github.com/maksimkurb/IoPC) which runs on Linux. Note: I haven't tested either.

----

### Issue Tracker

To centrally manage all issues (community provided, [GitHub tickets](https://github.com/LAB02-Research/HASS.Agent/issues), and things I come up with), the HASS.Agent project uses JetBrain's YouTrack platform.

There you can see all open issues (bugs, cosmetics, nice-to-haves, etc), and which issues are currently worked on. It's read-only, please use [GitHub](https://github.com/LAB02-Research/HASS.Agent/issues) to post tickets because that's where users will look first :)

[HASS.Agent YouTrack Dashboard](https://lab02research.youtrack.cloud)

----

### Helping Out

The best way to help out is to test as much as you can (or even join the beta program), and report any weird or failing behavior by [opening a ticket](https://github.com/LAB02-Research/HASS.Agent/issues). 

Same goes for sharing ideas for new (or improved) functionality! If you want, you can [join on Discord](https://discord.gg/nMvqzwrVBU) to discuss your ideas.

Another great way is to help translating HASS.Agent. It's easy thanks to POEditor - no coding knowledge required, everything's done online. For more info, check out the [translating documentation](https://hassagent.readthedocs.io/en/latest/translating/). You can work on an existing language, or suggest a new one.

If you want to tinker with the source code, awesome, please start by reading the [dev docs](https://hassagent.readthedocs.io/en/latest/development/introduction).

----

### Wishlist

The wishlist has moved to the [HASS.Agent YouTrack Dashboard](https://lab02research.youtrack.cloud). You can see all open ideas (and issues) on the right column, and the ones that are actively worked on for the next release on the left. If your idea isn't on there yet, please [create a ticket](https://github.com/LAB02-Research/HASS.Agent/issues) or [discuss on Discord](https://discord.gg/nMvqzwrVBU).

----

### Credits and Licensing

First: thanks to the entire team that's developing [Home Assistant](https://www.home-assistant.io) - such an amazing platform!

Second: I learned a lot from sleevezipper's [HASS Workstation Service](https://github.com/sleevezipper/hass-workstation-service). Thank you for sharing your hard work. Thanks to [POEditor](https://poeditor.com) for providing a free opensource license for their excellent translation platform!

And a big thank you to all other packages:

[CoreAudio](https://github.com/morphx666/CoreAudio), [HotkeyListener](https://github.com/Willy-Kimura/HotkeyListener), [MQTTnet](https://github.com/chkr1011/MQTTnet), [Syncfusion](https://www.syncfusion.com), [Octokit](https://github.com/octokit/octokit.net), [Cassia](https://www.nuget.org/packages/Cassia.NetStandard/), [Grapevine](https://scottoffen.github.io/grapevine), [LibreHardwareMonitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor), [Newtonsoft.Json](https://www.newtonsoft.com/json), [Serilog](https://github.com/serilog/serilog), [CliWrap](https://github.com/Tyrrrz/CliWrap), [HADotNet](https://github.com/qJake/HADotNet), [Microsoft.Toolkit.Uwp.Notifications](https://github.com/CommunityToolkit/WindowsCommunityToolkit), [GrpcDotNetNamedPipes](https://github.com/cyanfish/grpc-dotnet-namedpipes), [gRPC](https://github.com/grpc/grpc), [ByteSize](https://github.com/omar/ByteSize).

Please consult their individual licensing if you plan to use any of their code.

Everything on the HASS.Agent platform is released under the [MIT license](https://opensource.org/licenses/MIT).

---

### Legacy

HASS.Agent is a .NET 6 application. If for some reason you can't install .NET 6, you can use the last .NET Framework 4.8 version:

[v2022.3.8](https://github.com/LAB02-Research/HASS.Agent/releases/tag/v2022.3.8)

It's pretty feature complete if you just want commands, sensors, quickactions and notifications. 

You'll need to have .NET Framework 4.8 installed on your PC, which you can [download here](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-web-installer).

If you find any bugs, feel free to [create a ticket](https://github.com/LAB02-Research/HASS.Agent/issues) and I'll try to patch it.
