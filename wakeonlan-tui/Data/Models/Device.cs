namespace wakeonlan_tui.Data.Models;

public class Device
{
    public string Name { get; set; }
    public string MacAddress { get; set; }

    public Device(string name, string macAddress)
    {
        Name = name;
        MacAddress = macAddress;
    }
}
