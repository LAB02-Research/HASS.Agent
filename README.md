
[![GitHub release (latest by date)](https://img.shields.io/github/v/release/LAB02-Research/HASS.Agent)](https://github.com/LAB02-Research/HASS.Agent/releases/)
[![License](https://img.shields.io/badge/License-MIT-blue)](#license)
[![OS - Windows](https://img.shields.io/badge/OS-Windows-blue?logo=windows&logoColor=white)](https://www.microsoft.com/ "Go to Microsoft homepage")
![GitHub all releases](https://img.shields.io/github/downloads/LAB02-Research/HASS.Agent/total?color=blue)
![GitHub latest](https://img.shields.io/github/downloads/LAB02-Research/HASS.Agent/latest/total?color=blue)
[![Discord](https://img.shields.io/badge/dynamic/json?color=blue&label=Discord&logo=discord&logoColor=white&query=presence_count&suffix=%20Online&url=https://discordapp.com/api/guilds/932957721622360074/widget.json)](https://discord.gg/nMvqzwrVBU)

<a href="https://github.com/LAB02-Research/HASS.Agent/">
    <img src="https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/src/HASS.Agent/HASSAgent/Resources/logo_128.png" alt="HASS.Agent logo" title="HASS.Agent" align="right" height="128" /></a>

# HASS.Agent

HASS.Agent is a Windows-based client application for [Home Assistant](https://www.home-assistant.io), developed in .NET 6.

Click [here](https://github.com/LAB02-Research/HASS.Agent/releases/latest/download/HASS.Agent.Installer.exe) to download the latest installer.

----

Developing this tool takes up quite a bit of time. It's completely free, and it'll stay that way without restrictions.<br/>
However, like most developers, I run on caffeïne - so a cup of coffee is always very much appreciated! 

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research)

----

### Contents

 * [Why?](#why)
 * [Help and Documentation](#help-and-documentation)
 * [Functionality](#functionality)
 * [What it's not](#what-its-not)
 * [Screenshots](#screenshots)
 * [Installation](#installation)
 * [Configuration](#configuration)
 * [Usage](#usage)
 * [Updating](#updating)
 * [Wishlist](#wishlist)
 * [Usage Summary](#usage-summary)
 * [Credits and Licensing](#credits-and-licensing)

----

### Why?

The main reason I built this is that I wanted to receive notifications, including images, on my PC and to quickly perform actions (i.e. to toggle a lamp). There weren't any software-based solutions for this, so I set out to build one myself. 

That's also the premise of this project; it's built to solve problems I encountered (or perhaps I should use the word "*nuisances*"), so it may not work for you. 
If that's the case, feel free to open a ticket so we can discuss! 

----

### Help and Documentation

Stuck while using HASS.Agent, need some help integrating the sensors/commands or have a great idea for the next version?

There are a few channels through which you can reach us:

[Github Tickets](https://github.com/LAB02-Research/HASS.Agent): Report bugs, feature requests, ideas, tips, ..

[Wiki](https://github.com/LAB02-Research/HASS.Agent/wiki): Installation, configuration and usage documentation, as well as examples.

[Discord](https://discord.gg/nMvqzwrVBU): Get help with setting up and using HASS.Agent, report bugs or just talk about whatever.

[Home Assistant forum](https://community.home-assistant.io/t/hass-agent-a-new-windows-based-client-to-receive-notifications-perform-quick-actions-and-much-more/369094): Bit of everything, with the addition that other HA users can help as well.

----

### Functionality

Summary of the core functions:

* **Notifications**: receive notifications, show them using Windows builtin toast popups, and optionally attach images. 
  - *This requires the installation of the [HASS.Agent Notifier integration](https://github.com/LAB02-Research/HASS.Agent-Notifier)*.

* **Quick Actions**: use a keyboard shortcut to quickly pull up a command interface, through which you can control Home Assistant entities - or, assign a keyboard shortcut to individual Quick Actions for even faster triggering.

* **Commands**: control your PC (or other Windows based device) through Home Assistant using custom- or built-in commands.

* **Sensors**: send your PC's sensors to Home Assistant to monitor cpu, mem, webcam usage, wmi- and performance counter data, etc.

* **Satellite Service**: use the service to collect sensordata and execute commands, even when you're not logged in. 

* All entities are dynamically acquired from your Home Assistant instance.

* Commands and sensors are automatically added to your Home Assistant instance.

----

### What it's not

A Linux/macOS client! 

This question comes up a lot, understandably. However it's currently focussed on being a Windows-based client. Even though .NET 6 allows for Linux/macOS development, it's not as easy as pressing a button. The interface would have to be redesigned from the ground up, sensors and commands would need multiple codebases for each OS, testing would take way more time, every OS handles notifications differently, etc.

Since this is a sparetime project, next to a fulltime job, it's just not realistic. I'd love to tinker with it in the future, perhaps as a testcase for Microsoft's new MAUI platform, but it won't happen anytime soon. By focussing on Windows, I can make sure it really excels there instead of being meh everywhere.

You can try this [companion app](https://www.home-assistant.io/blog/2020/09/18/mac-companion/) for macOS, or sleevezipper's [HASS Workstation Service](https://github.com/sleevezipper/hass-workstation-service) which runs on Linux. Note: I haven't tested either.

----

### Screenshots

Notification examples:

![Image-based toast notification](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_toast_image.png)  ![Text-based toast notification](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_toast_text.png)

This is the Quick Action window you'll see when using the hotkey. This window automatically resizes to the amount of buttons you've added:

![Quick Actions](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_quickactions.png)

You can easily configure a new Quick Action, HASS.Agent will fetch your entities for you:

![New Quick Actions](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_new_quickaction.png)

The sensors configuration screen:

![Sensors](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_sensors.png)
    
Adding a new sensor is just as easy:

![Sensors](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_new_sensor.png)

Easily manage the satellite service through HASS.Agent:

![Service](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_satellite_service.png)

You'll be guided through the configuration options during onboarding:

![Onboarding Task](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_onboarding_startup.png)
    
----

### Installation

You have the option to download an installer or a .zip package. The installer is the easier and recommended option: it'll help you install .NET 6 if you don't have it yet, install the service and launch HASS.Agent. However, because the installer requires elevated rights, you can use the .zip package to install HASS.Agent on other accounts on the same PC (since the service only needs to be installed once).

HASS.Agent uses an entry in your user account's registry to launch on login. You'll be offered to enable this during onboarding, but you can always disable/enable using the Configuration window.

To use notifications, you'll need to install the [HASS.Agent Notifier integration](https://github.com/LAB02-Research/HASS.Agent-Notifier). This can be done through [HACS](https://hacs.xyz) or manually. 

You'll also need to open the configured port in the firewall of the receiving PC (default `5115`). During the onboarding process (or when using the Configuration window), HASS.Agent will offer to do it for you. You can always execute these steps later on through the configuration window:

![Configuration screen](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_notifications_portreservation.png)

----

### Configuration

When you first launch HASS.Agent, you'll be taken to the onboarding process. This will guide you through configuring step-by-step, and HASS.Agent will offer to perform some tasks for you. 

If you don't want this, or if you want to change something later on, you can use the configuration screen: 

![Configuration screen](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_configuration.png)

Configuring HASS.Agent is split into different pages:

#### 1. General

Miscellaneous HASS.Agent related settings. 

The `device name` is how your PC advertises itself in Home Assistant. When you change it, all your sensors and command will be removed from Home Assistant, and then reregistered under the new name. Don't worry though, all your automations and scripts will keep working as their IDs don't change.

#### 2. External Tools

Some commands have the ability to invoke external tools; other applications installed on your PC. You can define them here. 

When you don't configure a browser, HASS.Agent will use your default one. If you want, you can specify your own here. As an added bonus, you can set it to launch incognito (HASS.Agent will recognize most browsers for you, and set the required arguments). 

The `custom executor` can be used if you run a lot of Python scripts for instance. That way, you don't have to link the Python binary for every command you configure. Neat!

#### 3. Home Assistant API config

To use quick actions, you have to configure your instance's API. Usually the default URI should work, unless you've changed the port or mdns name. You can get a long-lived API token following [this doc](https://www.home-assistant.io/docs/authentication/).

#### 4. HotKey

This is optional, and can be used to pull up the Quick Actions window at any time.

#### 5. Local Storage

Manage how local storage is handled. By default HASS.Agent will clear cache older than 7 days.

#### 6. Logging

If you encounter problems while using HASS.Agent, please activate the `enable extended logging` switch. HASS.Agent will restart when you store the configuration, and afterwards try to recreate your problem. Then open this tab again and click `open logs folder`. 

Please attach the latest log when submitting a ticket, or you can mail it to lab02research@outlook.com if you want it handled confidentially (or just because it's easy).

Remember to turn extended logging off afterwards, as it'll clog your disk!

#### 7. MQTT

Enter your MQTT broker configuration. This is only required if you want to use commands (triggered from Home Assistant) or sensors (sent from your PC).

#### 8. Notifications

Make sure the integration has been installed and configured in Home Assistant, and actually works (there are test scripts available in the [wiki](https://github.com/LAB02-Research/HASS.Agent/wiki/Notification-Usage-&-Examples)). In the configuration screen, check the `accept notifications` box and change the default port if needed.

After changing the port (or enabling/disabling), HASS.Agent will perform the port binding and create/modify the firewall rule as soon as you save your changes. This requires elevation, so you'll be shown an UAC prompt.

Sometimes Windows won't allow you to enable notifications for HASS.Agent. This can happen if HASS.Agent hasn't shown a notification yet. To make sure it technically works, click the `show test notification` button in this tab. You'll be presented with a locally generated notification (or not, of course).

#### 9. Satellite Service

This tab provides you with options to manage the technical aspect of the satellite service, like stop/start/disable/reinstall. Usually you won't have to use this. 

If the satellite service doesn't work as expected, please use the `open service logs folder` to locate its logs, and attach the latest one when sending a bug report.

#### 10. Startup

Gives the option to enable/disable running HASS.Agent when you login. 

#### 11. Updates

If you want, HASS.Agent can check for updates in the background. This works by checking the latest release on GitHub. When a new release is found, you'll be notified and given the option to install the update.

You can opt-in on beta updates here. They are generally quite stable, and are mostly used to release new features faster than the regular updates. The regular channel is used roughly once a month, the prevent update fatigue.

To make updating easier, you can enable `offer to download and launch the installer for me`. When enabled, you still have the last say in whether an update will be installed, but you won't have to do anything else. The update is downloaded from github.com, and its cryptographic signature is checked before being executed.

----

### Usage

HASS.Agent resides in the system tray. Make sure it's always visible and not hidden in the overflow, otherwise notifications may not get shown. As a tip, you could drag the icon right next to your clock.

You can double-click to open the Home screen:

![Main window](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_main_window.png)

From here, you can easily use & configure the various parts of HASS.Agent:

#### 1. Configuration

Shows the various application configuration options (as discussed above).

#### 2. Quick Actions

Manage your quick action buttons. Use the `add new` button to create your first action. All entities are dynamically acquired from your Home Aassistant instance. If they won't show up, make sure you've configured 'HASS api' in the configuration screen. Use the 'preview' button to check if it's working for you.

#### 3. Satellite Service

From here, you can configure the service's inner workings (MQTT, commands, sensors ..). 

Use the `copy from hass.agent` button on the `MQTT` tab to easily copy your MQTT configuration (the service will use its own client ID). Remember to click `send and activate config` afterwards!

#### 4. Local Sensors

Manage which sensors you want to publish to your Home Assistant instance. There are some ready-to-use sensors available, but you can also use your own WMI query.
*This requires MQTT to be configured*.

Most sensors are single value, but some are **multi-value sensors**. These sensors are configured as one entity, but will create multiple entities in Home Assistant. For instance, the `storage` multi-value sensor will create label, total size (MB), available space (MB), used space (MB) and file system entities for all present non-removable disks. When adding a new sensor, the columns will tell you their types.

**Note: WMI can be a pain, and also make sure you don't update your queries too often. Keep an eye on your CPU load.**

#### 5. Commands

Manage which commands should be accepted from your Home Assistant instance. Aside from the builtin commands, you can use your own custom command (you can test your command by typing it into a console), or a key command which will emulate key presses. *This requires MQTT to be configured.*

Example configuration of a shutdown command in Home Assistant, used in combination with <a href="https://www.home-assistant.io/integrations/wake_on_lan/" target="_blank">wake-on-lan</a>:

```yaml
- platform: wake_on_lan
  name: "TEST_W10_x64_01"
  mac: "00-00-00-00-00-00"
  host: 10.0.0.5
  broadcast_address: 10.0.0.255
  turn_off:
    service: switch.turn_on
    data:
      entity_id: switch.test_w10_x64_01_cmd_shutdown
```

----

### Updating

Apart from the automatic update checker, you can check for new updates from the main window or rightclicking the systray icon and selecting 'check for updates'. If there's an update, HASS.Agent can download and install it for you.

![Update window](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_update.png)

If you're using the installer, it'll launch HASS.Agent for you when it's done. But if you've updated manually, just doubleclick `HASS.Agent.exe`.

----

### Wishlist

List of things I want to add somewhere down the road (basically a personal to-do notepad):

 * **Notifications**: add 'critical' type to attract more attention
 * **Notifications**: history window
 * **Notifications**: show a videostream for x seconds with size y (small/normal/fullscreen) on position z (bottom right, center screen, etc)
 * **Notifications**: use websockets so the integration/port reservations/firewall rules aren't needed
 * **Notifications**: broadcast to all HASS.Agents on a subnet
 * **Quick Actions**: show current state in window
 * **Quick Actions**: ability to change button size (small/medium/large)
 * **Quick Actions**: ability to define mdi icons, and/or fetch the entity-specified icon from Home Assistant
 * **Quick Actions**: add pages as tabs instead of one form, i.e. one tab with 'lights', one tab with 'switches'
 * **General**: a built-in way to show a Home Assistant dashboard
 * **General**: internal mDNS client/server to drop the need for IPs

More community provided ideas can be found in the [issue list](https://github.com/LAB02-Research/HASS.Agent/issues). If your idea hasn't been mentioned yet, please [create a ticket](https://github.com/LAB02-Research/HASS.Agent/issues) or [discuss on Discord](https://discord.gg/nMvqzwrVBU).

----

### Usage Summary

Checklist to start using HASS.Agent:

- Install and configure [HASS.Agent Notifier integration](https://github.com/LAB02-Research/HASS.Agent-Notifier) if you want notifications
- Download & run the [latest release's installer](https://github.com/LAB02-Research/HASS.Agent/releases/latest)
- HASS.Agent will launch and show you the onboarding process
- Configure the parts you'll be using
- HASS.Agent will restart to activate your configuration
- Start adding Quick Actions, commands & sensors!

Stuck? [Check the wiki](https://github.com/LAB02-Research/HASS.Agent/wiki), [create a ticket](https://github.com/LAB02-Research/HASS.Agent/issues) or [join on Discord](https://discord.gg/nMvqzwrVBU).

---

### Credits and Licensing

First: thanks to the entire team that's developing [Home Assistant](https://www.home-assistant.io) - such an amazing platform!

Second: I learned a lot from sleevezipper's [HASS Workstation Service](https://github.com/sleevezipper/hass-workstation-service). Thank you for sharing your hard work!

And a big thank you to all other packages:

[CoreAudio](https://github.com/morphx666/CoreAudio), [HotkeyListener](https://github.com/Willy-Kimura/HotkeyListener), [MQTTnet](https://github.com/chkr1011/MQTTnet), [Syncfusion](https://www.syncfusion.com), [Octokit](https://github.com/octokit/octokit.net), [Cassia](https://www.nuget.org/packages/Cassia.NetStandard/), [Grapevine](https://scottoffen.github.io/grapevine), [LibreHardwareMonitor](https://github.com/LibreHardwareMonitor/LibreHardwareMonitor), [Newtonsoft.Json](https://www.newtonsoft.com/json), [Serilog](https://github.com/serilog/serilog), [CliWrap](https://github.com/Tyrrrz/CliWrap), [HADotNet](https://github.com/qJake/HADotNet), [Microsoft.Toolkit.Uwp.Notifications](https://github.com/CommunityToolkit/WindowsCommunityToolkit), [GrpcDotNetNamedPipes](https://github.com/cyanfish/grpc-dotnet-namedpipes), [gRPC](https://github.com/grpc/grpc), [ByteSize](https://github.com/omar/ByteSize).

Please consult their individual licensing if you plan to use any of their code.

HASS.Agent and HASS.Agent Notifier are released under the [MIT license](https://opensource.org/licenses/MIT).
