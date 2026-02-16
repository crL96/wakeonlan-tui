using wakeonlan_tui.Services;

namespace wakeonlan_tui
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NetworkService.WakeDevice("A1-B2-C3-D4-E5-F6");
        }
    }
}
