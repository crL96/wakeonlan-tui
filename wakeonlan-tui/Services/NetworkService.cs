using System.Net.NetworkInformation;
using System.Net;

namespace wakeonlan_tui.Services;

public static class NetworkService
{
    public static void WakeDevice(string macAddress)
    {
        PhysicalAddress.Parse(macAddress).SendWolAsync();
    }
}
