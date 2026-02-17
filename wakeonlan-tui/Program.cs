using wakeonlan_tui.UI;

namespace wakeonlan_tui
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                await ConsoleUI.Run();
                return;
            }
            if (!(args[0]?.ToLower() == "add" || args[0]?.ToLower() == "delete"))
            {
                Console.WriteLine("Invalid argument. Valid arguments are 'add', 'delete' or no argument");
                return;
            }
            await ConsoleUI.Run(args[0].ToLower());
        }
    }
}
