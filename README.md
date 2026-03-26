# Wake-on-LAN TUI Tool

## Description

A terminal-based Wake-on-LAN (WoL) utility built with .NET and C#.

This application provides a fast, keyboard-driven interface for waking devices on a network without relying on a graphical user interface. It is designed for efficiency and minimalism, enabling quick access to frequently used machines through an interactive terminal list.

Devices can be stored and managed within the application, allowing seamless switching and execution of Wake-on-LAN 
requests with minimal input.

![wakeonlan-tui](https://github.com/user-attachments/assets/18415574-3acb-408f-b365-6eb7dff9b9df)

## Getting Started

### Prebuilt Binaries

Precompiled binaries are available for the following platforms:

- Linux (x64, ARM64)
- Windows (x64, ARM64)
- macOS (x64, ARM64)

Download the appropriate version from the [Releases](../../releases) section of this repository.

### Usage

The application can be run in different modes depending on the provided arguments:

#### Launch Interactive TUI

Start the application without arguments to open the interactive device list:

```terminal
wakeonlan-tui
```

From here, you can navigate using your keyboard and wake selected devices. If no devices exists, you will be prompted to add one.

#### Add a Device

Add a new device to the stored list:

```terminal
wakeonlan-tui add
```

You will be prompted to enter the required device information.

#### Delete a Device

Remove an existing device from the list:

```terminal
wakeonlan-tui delete
```

You will be prompted to select which device to delete.

### Adding to PATH

To run `wakeonlan-tui` from anywhere in your terminal, you can add the executable to your system's `PATH`.

If you dont wish to do so, you can always navigate to the executable's directory and run it from there.

#### Linux / macOS

Move or place the executable in a directory that is already in your PATH, for example: /usr/local/bin

```bash
sudo mv wakeonlan-tui /usr/local/bin/
sudo chmod +x /usr/local/bin/wakeonlan-tui
```

Or place it anywhere you like and add that directory to your PATH

#### Windows

Follow this guide: [How to Add Executables to your PATH in Windows](https://medium.com/@kevinmarkvi/how-to-add-executables-to-your-path-in-windows-5ffa4ce61a53)

### Run and build locally

#### Prerequisites

- .NET SDK

#### Installation

1. Clone the repository

2. Navigate to the project directory:

```terminal
cd wakeonlan-tui
```

3. Build or run the project:

```terminal
dotnet build
dotnet run
```

## Technologies Used

Language: C#

Framework: .NET

## Notes

- Wake-on-LAN must be enabled on the target device (BIOS/UEFI and network adapter).

- Network configuration must allow WoL packets to reach the target machine.
