# Adhany Desktop

## Overview

The Adhany Desktop is a Windows application designed to provide daily prayer times and notifications for Muslims residing in Canada and Saudi Arabia. This application allows users to set their location and receive timely notifications for each of the five daily prayers, accompanied by the beautiful Adhan sound.

## Table of Contents

- [Features](#features)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Known Limitations](#known-limitations)
- [Future Development](#future-development)
- [Contact](#contact)
- [License](#license)

## Features

- **Prayer Times**: Display today's prayer times and the corresponding Hijri date.
- **Prayer Notifications**: Receive notifications when it's time for prayer, accompanied by various Adhan sounds (with more to be added).
- **Location Settings**: Set your location by choosing a country and city.
- **Background Operation**: Once the location is set, the application runs in the background to ensure timely notifications.

## Getting Started

### Prerequisites

You will need to have .NET 7.0.x installed on your machine for the app to be able to run. The application installer will automatically downoald and intall it, 
or you can download it from [here](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-7.0.13-windows-x64-installer?cid=getdotnetcore)

This application runs on Windows 10 and 11 

### Installation

- Download the lates version of the application ZIP file from the [releases page](https://github.com/Majeed-ch/AdhanyDesktop/releases)
- Extract the ZIP file content to your local drive. Please keep these files for the app to run properly.
- In the extracted folder, run the "setup.exe" file.
- If prompted, accept to install .NET Desktop Runtime 7.0.13
- Trust and install the application when promted
- A shortcut to the application will be added to your Desktop.
-   <img src="https://github.com/Majeed-ch/AdhanyDesktop/assets/100393010/553ec8b0-0aa6-4629-bc97-5949a65e0dfa" width="400" />
-   <img src="https://github.com/Majeed-ch/AdhanyDesktop/assets/100393010/14816a0b-b824-4ae0-ba80-185e9251f71e" width="400" />

## Usage
The application features a user-friendly interface that allows you to configure options and view prayer times based on your selections.

Using the app is straightforward:

1- **City and Notification Preferences:**
  - Select your country (Canada or Saudi Arabia).
  - The city dropdown list will dynamically populate with cities from the chosen country.
  - Choose your city from the list, or simply type the city name to quickly locate it.
  - If you're familiar with the calculation method, you can select it; otherwise, leave it as "Auto." For more information on Calculation Methods, please refer to [this page](http://praytimes.org/wiki/Calculation_Methods).

2- **Notification Types:**
  - Select one of two notification types:
    - "Full Adhan" by Al-Deghreri
    - "Takbeer" for the first two Takbeerat by Al-Afasy

3- **Saving Settings:**
  - Click the "Save" button to store your preferences.
  - The application will display the prayer times for the day.
  - When it's time for prayer, the app will notify you.

4- **Minimizing to System Tray:**
  - You can minimize the application, and it will continue running in the background.
  - Click on the notification icon in the system tray to dismiss the notification sound.

### Note:
The application does not run automatically on system/device startup. If you wish to have the application start on system startup, you can do so by adding a shortcut to the Windows Startup folder. Here's how:
  - Press Win + R to open the Run dialog.
  - Type `shell:startup` and press Enter. This will open the Windows Startup folder.
  - Copy the shortcut form the desktop to the this folder.
This will allow the application to launch automatically when your system starts.
    
<img src="https://github.com/Majeed-ch/AdhanyDesktop/assets/100393010/a5f0ea82-3715-446f-ba35-fa7bbf8043d1" width="400" />
<img src="https://github.com/Majeed-ch/AdhanyDesktop/assets/100393010/6dc335f6-294e-4efa-a387-6ccc7fc5eed4" width="400" />
<img src="https://github.com/Majeed-ch/AdhanyDesktop/assets/100393010/e79eef97-7efd-4abf-9329-529d0239266c" width="400" />


## Known Limitations

- **Internet Connectivity**: The application requires an internet connection at least once a day to update prayer times, or when selecting a new city.
- **Limited Country Support**: Currently, the application only supports two countries, Canada and Saudi Arabia, and is available in only English.

## Future Development

I have plans to enhance the applicaion with the following features:

- **Additional Adhan Sounds**: I will add more Adhan sounds, allowing users to select their preferred sound.
- **Arabic Language Support**: I aim to include support for the Arabic language to cater to a broader audience.
- **Reduced Internet Dependency**: I plan to minimize the reliance on internet connectivity, limiting its requirement to only when saving new settings.
- **Control notification volume**: The notification sound (Adhan) has the system volume, I aim to make it customizable to reduse surprising load sound.

## Contact

I appreciate your feedback and contributions. If you encounter any issues or have suggestions for improvements, please feel free to reach out to me through one of the following methods:

- [GitHub Issues](https://github.com/Majeed-ch/AdhanyDesktop/issues): Report issues or request features through our GitHub repository.
- [Email]: Send me an email at [amazed300@gmail.com].

## License
[MIT License](https://github.com/Majeed-ch/AdhanyDesktop/blob/master/LICENSE.txt)
