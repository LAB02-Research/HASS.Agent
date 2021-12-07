<a href="https://github.com/LAB02-Research/HASS.Agent/">
    <img src="https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/src/HASS.Agent/HASSAgent/Resources/logo_128.png" alt="HASS.Agent logo" title="HASS.Agent" align="right" height="128" />
</a>

# HASS.Agent

[!["Buy Me A Coffee"](https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png)](https://www.buymeacoffee.com/lab02research)

HASS.Agent is a Windows-based client application for <a href="https://www.home-assistant.io" target="_blank">Home Assistant</a>, developed in .NET 4.8.

----

### Contents

 * [Why?](#why)
 * [Functionality](#functionality)
 * [Installation](#installation)
 * [Configuration](#configuration)
 * [Usage](#usage)
 * [Updating](#updating)
 * [Wishlist](#wishlist)
 * [Error Reporting](#error-reporting)
 * [Usage Summary](#usage-summary)
 * [Credits and Licensing](#credits-and-licensing)

----

### Why?

The main reason I built this is that I wanted to receive notifications, including images, on my PC and to quickly perform actions (i.e. to toggle a lamp). There weren't any software-based solutions for this, so I set out to build one myself. 

That's also the premise of this project; it's built to solve problems I encountered (or perhaps I should use the word "*nuisances*"), so it may not work for you. 
If that's the case, feel free to open a ticket so we can discuss! 

----

### Functionality

Summary of the current implementation:

* **Notifications**: receive notifications, show them using Windows builtin toast popups, and optionally attach images. 
  - *This requires the installation of the <a href="https://github.com/LAB02-Research/HASS.Agent-Notifier" target="_blank">HASS.Agent Notifier integration</a>*.

* **Quick Actions**: use a keyboard shortcut to quickly pull up a command interface, through which you can control Home Assistant entities.

* **Commands**: control your device through Home Assistant using custom- or built-in commands.

* **Sensors**: send your device's sensors to Home Assistant to monitor cpu, mem, webcam usage, wmi-polled data, etc.

* All entities are dynamically acquired from your Home Assistant instance.

* Commands and sensors are automatically added to your Home Assistant instance.

Notification examples:

![Image-based toast notification](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_toast_image.png)  ![Text-based toast notification](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_toast_text.png)

This is the Quick Action window you'll see when using the hotkey. This window automatically resizes to the amount of buttons you've added:

![Quick Actions](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_quickactions.png)

The sensors configuration screen looks like this:

![Sensors](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_sensors.png)

----

### Installation

The agent itself comes in a .zip, that you can place anywhere you want. After launching, you'll see the configuration screen. In there, you get the option to install HASS.Agent as a run-on-boot scheduled task. This way, it'll launch after you login, and you won't have to accept UAC popups. Afterwards, HASS.Agent will offer to restart using the new task.

If you're not comfortable with using scheduled tasks, you can always manually add a shortcut to your startup folder.

To use notifications, you'll need to install the <a href="https://github.com/LAB02-Research/HASS.Agent-Notifier" target="_blank">HASS.Agent Notifier integration</a>. This can be done through <a href="https://hacs.xyz" target="_blank">HACS</a> or manually. 

You'll also need to open the configured port in the firewall of the receiving devices (default `5115`). To do so, you can run this command in an elevated prompt:

`netsh advfirewall firewall add rule name="HASS.Agent Notifier" dir=in action=allow protocol=TCP localport=5115`

----

### Configuration

![Configuration screen](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_configuration.png)

Configuring HASS.Agent is split into five parts:

#### 1. Notifications

Make sure the integration has been installed and configured in Home Assistant, and actually works (I used a test automation). In the configuration screen, check the '*accept notifications*' box and change the default port if needed.

Afterwards, open the configured port in your firewall. Ideally only allow your Home Assistant IP.

#### 2. Startup

You can use the '*create launch-on-login scheduled task*' to allow HASS.Agent to start when you login to your device. 

#### 3. Home Assistant API config

To use quick actions, you have to configure your instance's API. Normally the default URI should work, unless you've changed the port or mdns name. You can get a long-lived API token following <a href="https://www.home-assistant.io/docs/authentication/" target="_blank">this doc</a>.

#### 4. MQTT config

Enter your MQTT broker configuration. This is only required if you want to use commands (triggered from Home Assistant) or sensors (sent from your device).

#### 5. Hotkey config

This is optional, and can be used to pull up the Quick Actions window at any time.

----

### Usage

HASS.Agent resides in the system tray. Make sure it's always visible and not hidden in the overflow, otherwise notifications may not get shown. As a tip, you could drag the icon right next to your clock.

You can double-click to open the Home screen:

![Main window](https://raw.githubusercontent.com/LAB02-Research/HASS.Agent/main/Images/hass_agent_main_window.png)

From here, you can easily use & configure the various parts of HASS.Agent:

#### 1. Configuration

Shows the various application configuration options (as discussed above).

#### 2. Quick Actions

Manage your quick action buttons. Use the '*add new*' button to create your first action. All entities are dynamically acquired from your Home Aassistant instance. If they won't show up, make sure you've configured 'HASS api' in the configuration screen. Use the 'preview' button to check if it's working for you.

#### 3. Local Sensors

Manage which sensors you want to publish to your Home Assistant instance. There are some ready-to-use sensors available, but you can also use your own WMI query.
*This requires MQTT to be configured*.

**Note: WMI can be a pain, and also make sure you don't update your queries too often. Keep an eye on your CPU load.**

#### 4. Commands

Manage which commands should be accepted from your Home Assistant instance. Aside from the builtin commands, you can use your own custom command (you can test your command by typing it into a console), or a key command which will emulate key presses. *This requires MQTT to be configured.*

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

----

### Updating

You can check for new updates from the main window or rightclicking the systray icon and selecting 'check for updates'. If there's an update, you will be offered to download the .zip package from GitHub.

Tip: if you're using a scheduled task to run HASS.Agent, you can just launch the .exe and HASS.Agent will offer to restart using the task. That way you don't have to open the task scheduler.

----

### Wishlist

List of things I want to add somewhere down the road:

 * **Notifications**: ability to add commands
 * **Notifications**: add 'critical' type to attract more attention
 * **Quick Actions**: show current state in window
 * **Quick Actions**: ability to change button size (small/medium/large)
 * **Quick Actions**: ability to define custom mdi icons, and/or fetch icon from Home Assistant
 * **Quick Actions**: add pages as tabs instead of one form, i.e. one tab with 'lights', one tab with 'switches'
 * **Sensors**: add explanation when adding sensors, currently only name is shown
 * **Sensors**: implement library plugin system for more powerful custom sensors
 * **Commands**: add explanation when adding commands, currently only name is shown
 * **Updater**: give HASS.Agent the option to update itself

If you have any other wishes, feel free to submit a ticket.

----

### Error Reporting

This type of application is prone to errors (due to fetching data from WMI, systemwide keybindings, etc). To manage exceptions, I use the excellent <a href="https://coderr.io" target="_blank">Coderr</a> platform. However, this does mean that exception information will be sent to their servers. This is **disabled** by default. 

If you'd like to help out, please set `EnableCoderrExceptionReporting` to `True` in **HASS.Agent.exe.config**. 

If you're experiencing bugs, please set `EnableExtendedLogging` to `True` in **HASS.Agent.exe.config**. Restart HASS.Agent and wait for the bug to occur. Afterwards, please attach the relevant logfile from the **Logs** subfolder in your ticket. Note that if you only enable this option, nothing will get sent to Coderr.

----

### Usage Summary

Checklist to start using HASS.Agent:

- Install and configure <a href="https://github.com/LAB02-Research/HASS.Agent-Notifier" target="_blank">HASS.Agent Notifier integration</a> if you want notifications
- Open port 5115 (*default*) in your pc's firewall
- Download & extract the <a href="https://github.com/LAB02-Research/HASS.Agent/releases/latest">latest .zip release</a>
- Launch HASS.Agent.exe
- Configure the parts you'll be using
- Optionally set HASS.Agent to run as a scheduled task
- Start adding Quick Actions, commands & sensors!

Stuck? <a href="https://github.com/LAB02-Research/HASS.Agent/issues" target="_blank">Create a ticket</a>.

---

### Credits and Licensing

First: thanks to the entire team that's developing <a href="https://www.home-assistant.io" target="_blank">Home Assistant</a> - such an amazing platform!

Second: I learned a lot from sleevezipper's <a href="https://github.com/sleevezipper/hass-workstation-service" target="_blank">HASS Workstation Service</a>. Without it, the commands & sensors wouldn't have been so easy to implement. Thank you for sharing your code & hard work!

And a big thank you to all other packages:

<a href="https://github.com/qJake/HADotNet" target="_blank">HADotNet</a>, <a href="https://github.com/morphx666/CoreAudio" target="_blank">CoreAudio</a>, <a href="https://scottoffen.github.io/grapevine/" target="_blank">Grapevine</a>, <a href="https://github.com/Willy-Kimura/HotkeyListener" target="_blank">HotkeyListener</a>, <a href="https://github.com/LibreHardwareMonitor/LibreHardwareMonitor" target="_blank">LibreHardwareMonitor</a>, <a href="https://github.com/CommunityToolkit/WindowsCommunityToolkit" target="_blank">Microsoft.Toolkit.Uwp.Notifications</a>, <a href="https://github.com/chkr1011/MQTTnet" target="_blank">MQTTnet</a>, <a href="https://www.newtonsoft.com/json" target="_blank">Newtonsoft.Json</a>, <a href="https://github.com/serilog/serilog" target="_blank">Serilog</a>, <a href="https://www.syncfusion.com/" target="_blank">Syncfusion</a>, <a href="https://github.com/dahall/taskscheduler" target="_blank">TaskScheduler</a>, <a href="https://github.com/octokit/octokit.net" target="_blank">Octokit</a> and <a href="https://coderr.io" target="_blank">Coderr</a>.

Please consult their individual licensing if you plan to use any of their code.

HASS.Agent and HASS.Agent Notifier are released under the <a href="https://opensource.org/licenses/MIT" target="_blank">MIT license</a>.
