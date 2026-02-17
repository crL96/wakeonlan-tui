using System.Text.Json;
using wakeonlan_tui.Models;

namespace wakeonlan_tui.Data
{
    public static class FileHandler
    {
        private static string _filePath = @".\devices.json";

        public static async Task AddNewDevice(Device device)
        {
            List<Device> devices = await GetAllDevices();
            if (devices.Find(d => d.Name == device.Name) != null)
            {
                throw new Exception("Device name already in use");
            }
            devices.Add(device);
            string json = JsonSerializer.Serialize(devices);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public static async Task<List<Device>> GetAllDevices()
        {
            //If file doesn't exist, return empty list
            try
            {
                string json = await File.ReadAllTextAsync(_filePath);
                var list = JsonSerializer.Deserialize<List<Device>>(json);
                if (list == null) return [];
                return list;
            }
            catch (FileNotFoundException)
            {
                return [];
            }
        }

        public static async Task DeleteDevice(string name)
        {
            List<Device> devices = await GetAllDevices();
            var updatedList = devices.Where(d => d.Name != name);
            string json = JsonSerializer.Serialize(updatedList);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}