using System.Net.NetworkInformation;
using System.Net;
using System.Text.RegularExpressions;

namespace wakeonlan_tui.Services;

public static class NetworkService
{
    public static void WakeDevice(string macAddress)
    {
        if (!IsValidMacAddress(macAddress)) throw new Exception("Invalid MAC address");
        PhysicalAddress.Parse(macAddress).SendWolAsync();
    }

    public static bool IsValidMacAddress(string macAddress)
    {
        if (macAddress == null) return false;

        string pattern = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

        return regex.IsMatch(macAddress.Trim());
    }
}
