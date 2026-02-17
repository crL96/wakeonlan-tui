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
            case "delete":
                await Delete();
                return;
            default:
                Device selected = await GetUserSelection("Select which device to wake:");
                NetworkService.WakeDevice(selected.MacAddress);
                Console.WriteLine($"Waking {selected.Name}");
                return;
        }

    }

    public static async Task<Device> GetUserSelection(string prompt)
    {
        List<Device> devices = await FileHandler.GetAllDevices();
        var selection = AnsiConsole.Prompt(
            new SelectionPrompt<Device>()
                .Title(prompt)
                .AddChoices(devices)
                .UseConverter((device) => device.Name)
        );
        return selection;
    }

    public static async Task AddNew()
    {
        try
        {
            Console.WriteLine("Add a new device:");
            string name = AnsiConsole.Ask<string>("Name:");
            string macAddress = AnsiConsole.Ask<string>("MAC Address:").ToUpper();
            await FileHandler.AddNewDevice(new(name, macAddress));
            Console.WriteLine($"{name} added to devices");
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }
    }

    public static async Task Delete()
    {
        var selection = await GetUserSelection("Select a device to delete:");
        await FileHandler.DeleteDevice(selection.Name);
        Console.WriteLine($"{selection.Name} was deleted.");
    }
}
