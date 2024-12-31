using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Management;
using System.Text.Json;

namespace Consolelb5
{
    class Program
    {
        class PcConfiguration
        {
            public string SerialOfDisk { get; set; }
            public string SerialOfMotherboard { get; set; }
            public string SerialOfUsb { get; set; }
        }

        static void Main()
        {
            string configFilePath = "Z:/config.json";

            if (!File.Exists(configFilePath))
            {
                CreateConfigFile(configFilePath);
            }

            PcConfiguration config = LoadConfig(configFilePath);

            if (CheckHardwareСharacteristic(config))
            {
                Console.WriteLine("Все хорошо");
            }
            else
            {
                Console.WriteLine("Запрет");
            }

            Console.ReadLine();
        }

        static void CreateConfigFile(string filePath)
        {
            Console.WriteLine("Создание файла конфигурации...");

            string serialOfDisk = GetSerialOfDisk();
            string serialOfMotherboard = GetSerialOfMotherboard();
            string serialOfUsb = GetSerialOfUsb();

            PcConfiguration config = new PcConfiguration
            {
                SerialOfDisk = serialOfDisk,
                SerialOfMotherboard = serialOfMotherboard,
                SerialOfUsb = serialOfUsb
            };

            string jsonConfig = JsonSerializer.Serialize(config);
            File.WriteAllText(filePath, jsonConfig);

            Console.WriteLine("Файл конфигурации успешно создан.");
        }

        static PcConfiguration LoadConfig(string filePath)
        {
            string jsonConfig = File.ReadAllText(filePath);
            PcConfiguration config = JsonSerializer.Deserialize<PcConfiguration>(jsonConfig);

            return config;
        }

        static string GetSerialOfDisk()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            ManagementObjectCollection collection = searcher.Get();
            string serial = "";

            foreach (ManagementObject obj in collection)
            {
                serial = obj["SerialNumber"].ToString().Trim();
                break;
            }

            return serial;
        }


        static string GetSerialOfMotherboard()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
            ManagementObjectCollection collection = searcher.Get();
            string serial = "";

            foreach (ManagementObject obj in collection)
            {
                serial = obj["SerialNumber"].ToString().Trim();
                break;
            }

            return serial;
        }

        static string GetSerialOfUsb()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            ManagementObjectCollection collection = searcher.Get();
            string serial = "";

            foreach (ManagementObject obj in collection)
            {
                serial = obj["SerialNumber"].ToString().Trim();
                break;
            }

            return serial;
        }

        static bool CheckHardwareСharacteristic(PcConfiguration config)
        {
            return GetSerialOfDisk() == config.SerialOfDisk &&
                   GetSerialOfMotherboard() == config.SerialOfMotherboard &&
                   GetSerialOfUsb() == config.SerialOfUsb;
        }
    }
}


