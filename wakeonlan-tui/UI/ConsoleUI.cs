using Spectre.Console;
using wakeonlan_tui.Data;
using wakeonlan_tui.Models;
using wakeonlan_tui.Services;

namespace wakeonlan_tui.UI;

public class ConsoleUI
{
    public static async Task Run(string mode = "")
    {
        switch (mode)
        {
            case "add":
                await AddNew();
                return;
            default:
                Device selected = await GetUserSelection();
                NetworkService.WakeDevice(selected.MacAddress);
                Console.WriteLine($"Waking {selected.Name}");
                return;
        }

    }

    public static async Task<Device> GetUserSelection()
    {
        List<Device> devices = await FileHandler.GetAllDevices();
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<Device>()
                .Title("Select which device to wake:")
                .AddChoices(devices)
                .UseConverter((device) => device.Name)
        );
        return selection;
    }

    public static async Task AddNew()
    {
        Console.WriteLine("Add a new device:");
        string name = AnsiConsole.Ask<string>("Name:");
        string macAddress = AnsiConsole.Ask<string>("MAC Address:").ToUpper();
        await FileHandler.AddNewDevice(new(name, macAddress));
        Console.WriteLine($"{name} added to devices");
    }
}
