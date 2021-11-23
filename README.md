# HASS.Agent

HASS.Agent is a Windows-based client application for <a href="https://www.home-assistant.io" target="_blank">Home Assistant</a>, developed in .NET 4.8.

Contents
========

 * [Why?](#why)
 * [Functionality](#functionality)
 * [Credits](#credits)
 * [Installation](#installation)
 * [Configuration](#configuration)
 * [Usage](#usage)
 * [Updating](#updating)
 * [Wishlist](#wishlist)
 * [Error Reporting](#error-reporting)

## Why?
---

The main reason I built this was that I wanted to receive notifications with images on my PC, and to quickly perform actions (ie. toggle a lamp). There currently weren't any software-based solutions
to this, so I set out to built it myself. 

That's also the premise of this project; it's built to solve 'problems' (nuicanses is perhaps a better word) I encountered, and may work for you. 
In that case, feel free to open a ticket so we can discuss! 

## Functionality
---

Summary of the current implementation:

* **Notifications**: receive notifications, show them using Windows builtin toast popups, attach images - this requires the installation of the <a href="https://github.com/LAB02-Research/HASS.Agent.Notifier">HASS.Agent Notifier integration</a>
* **Quick Actions**: use a keyboard shortcut to quickly pull up a command interface, through which you can control Home Assistant entities
* **Commands**: control your device through Home Assistant using custom- or builtin commands
* **Sensors**: send your device's sensors to Home Assistant to monitor cpu, mem, webcame usage, wmi-polled data, etc .. 

## Credits
---

I want to put the credits this far up on the readme page, because I'm standing on the shoulders of giants :)

For starters; thanks to the entire team that's developing <a href="https://www.home-assistant.io" target="_blank">Home Assistant</a> - such an amazing platform!

Second; I learned a lot from sleevezipper's <a href="https://github.com/sleevezipper/hass-workstation-service" target="_blank">HASS Workstation Service</a>. Without it, the
commands & sensors wouldn't have been so easy to implement. Thank you for sharing your code & hard work!

Third; thanks to qJake's <a href="https://github.com/qJake/HADotNet" target="_blank">HADotNet</a> library, which made developing the quick actions binding to Home Assistant a breeze.

And a big thank you to all other packages:

<a href="https://github.com/morphx666/CoreAudio" target="_blank">CoreAudio</a>, <a href="https://scottoffen.github.io/grapevine/" target="_blank">Grapevine</a>, <a href="https://github.com/Willy-Kimura/HotkeyListener" target="_blank">HotkeyListener</a>, <a href="https://github.com/LibreHardwareMonitor/LibreHardwareMonitor" target="_blank">LibreHardwareMonitor</a>, <a href="https://github.com/CommunityToolkit/WindowsCommunityToolkit" target="_blank">Microsoft.Toolkit.Uwp.Notifications</a>, <a href="https://github.com/chkr1011/MQTTnet" target="_blank">MQTTnet</a>, <a href="https://www.newtonsoft.com/json" target="_blank">Newtonsoft.Json</a>, <a href="https://github.com/serilog/serilog" target="_blank">Serilog</a>, <a href=""https://www.syncfusion.com/" target="_blank">Syncfusion</a>, <a href="https://github.com/dahall/taskscheduler" target="_blank">TaskScheduler</a> and <a href=""https://coderr.io" target="_blank">Coderr</a>.

Please consult their individual licensing if you plan to use any of the code.

## Installation
---

The agent itself comes as a .zip, that you can place anywhere you want. After launching, you'll see the configuration screen. In there, you get the option to install HASS.Agent as a run-on-boot scheduled
task. This way, it'll launch after you login, and you won't have to accept UAC popups. If you're not comfortable with this setup, you can always manually add a shortcut to your startup folder.

If you want to use notifications, you'll need to install the <a href="https://github.com/LAB02-Research/HASS.Agent.Notifier" target="_blank">HASS.Agent Notifier integration</a>. This can be done through HACS or manually. You'll also need to open the
configured port in the firewall of the receiving devices (default 5115). 

## Configuration
---

Configuring HASS.Agent is split into five parts:

### 1. Notifications

Make sure the integration has been installed and configured in Home Assistant, and actually works (I use a test automation). In the configuration screen, check the 'accept notifications' box and 
optionally change the default port:

<todo: image>

Afterwards, open the configured port in your firewall. Ideally only allow your Home Assistant IP through.

### 2. Startup

You can use the 'create launch-on-login scheduled task' to allow HASS.Agent to start when you login to your device. 

### 3. Home Assistant API config

To use quick actions, you have to configure your instance's API. Normally the default URI should work, unless you've changed the port or mdns name. You can get a long-live API token following <a href="https://www.home-assistant.io/docs/authentication/" target="_blank">this doc</a>.

### 4. MQTT config

Enter your MQTT broker configuration. Only required if you want to use commands (sent from Home Assistant) or sensors (sent from your device).

### 5. Hotkey config

Optionally, can be used to pull up the quick-actions window.

## Usage
---

From the home screen, you can easily use & configure the various parts of HASS.Agent:

### 1. Configuration

Shows the various application configuration options (as discussed above).

### 2. Quick Actions

Manage your quick action buttons. Use the 'add new' button to create your first action. All entities are dynamically fetched from your Home Aassistant instance. If they won't show up, make sure you've
configured 'HASS api' in the configuration screen. Use the 'preview' button to check if it's working for you.

### 3. Local Sensors

Manage which sensors you want to publish to your Home Assistant instance. There are some ready-to-use sensors available, or you can use your own WMI query.
Requires MQTT to be configured.

**Note: WMI can be a pain, and make sure you don't update your queries too often. Keep an eye on your CPU load.**

### 4. Commands

Manage which commands should be accepted from your Home Assistant instance. Aside from the builtin commands, you can use your own custom command (you can test your command by typing it into a console),
or a key command which will emulate key presses. Requires MQTT to be configured.

**Note: your commands will be run with elevated privileges!**

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

## Updating
---

Currently, HASS.Agent doesn't have an updater. It'll be implemented in a coming version. For now, check this page periodically :)

## Wishlist
---

List of things I want to add somewhere down the road:

 * Notifications: ability to add commands
 * Notifications: add 'critical' type to attract more attention
 * Quick Actions: show current state in window
 * Quick Actions: ability to change buton size (small/medium/large)
 * Quick Actions: ability to define custom mdi icons, or fetch icon from Home Assistant
 * Quick Actions: add pages as tabs intead of one form, ie. one tab with 'lights', one tab with 'switches'
 * Sensors: add explanation when adding sensors, currently only name is shown
 * Sensors: implement library plugin system for more powerful custom sensors
 * Commands: add explanation when adding commands, currently only name is shown

If you have any other wishes, feel free to submit a ticket.

## Error Reporting
---

This type of application is quite error prone (fetching data from WMI, systemwide keybindings, etc). To manage exceptions, I use the excellent Coderr platform. However, this does mean that exception info
will be sent to their servers. This is **disabled** by default. 

If you want to help out, please set EnableCoderrExceptionReporting to **True** in HASS.Agent.exe.config. 

If you're experiencing bugs, please set EnableExtendedLogging to **True** in HASS.Agent.exe.config. Restart HASS.Agent and wait for the bug to occur. Afterwards, please attach the relevant logfile
from the 'Logs' subfolder in your ticket.
