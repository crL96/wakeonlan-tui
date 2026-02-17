using Spectre.Console;
using wakeonlan_tui.Data;
using wakeonlan_tui.Models;
using wakeonlan_tui.Services;

namespace wakeonlan_tui.UI;

public class ConsoleUI
{
    public static async Task Run()
    {
        Device selected = await GetUserSelection();
        NetworkService.WakeDevice(selected.MacAddress);
        Console.WriteLine($"Waking {selected.Name}");
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
}
