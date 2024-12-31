using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace laba66
{

class Program
{
    static void Main(string[] args)
    {
        // Проверяем аргументы командной строки
        if (args.Length == 0 || !Directory.Exists(args[0]))
        {
            Console.WriteLine("Укажите путь к директории.");
            return;
        }

        string directoryPath = args[0];
        string savedCrcFilePath = Path.Combine(directoryPath, "crc.txt");

        // Расчитываем CRC для всех файлов в директории
        Dictionary<string, long> filesWithCrcs = CalculateCrcForAllFiles(directoryPath);

        // Сохраняем результаты в файл
        SaveCrcToFile(filesWithCrcs, savedCrcFilePath);

        // Проверяем целостность файлов
        CheckIntegrity(directoryPath, savedCrcFilePath);
    }

    private static Dictionary<string, long> CalculateCrcForAllFiles(string directoryPath)
    {
        var result = new Dictionary<string, long>();

        try
        {
            foreach (string filePath in Directory.EnumerateFiles(directoryPath))
            {
                long crcValue = CalculateCrc(filePath);
                result.Add(filePath, crcValue);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файлов: {ex.Message}");
        }

        return result;
    }

        private static long CalculateCrc(string filePath)
        {
            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var crc32 = new Crc32())
                {
                    byte[] hash = crc32.ComputeHash(stream);
                    return BitConverter.ToInt64(hash, 0);
                }
            }
        }


        private static void SaveCrcToFile(Dictionary<string, long> filesWithCrcs, string outputFilePath)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var kvp in filesWithCrcs)
        {
            sb.AppendLine($"{kvp.Key}|{kvp.Value}");
        }

        File.WriteAllText(outputFilePath, sb.ToString());
    }

    private static Dictionary<string, long> LoadCrcFromFile(string inputFilePath)
    {
        var result = new Dictionary<string, long>();

        if (!File.Exists(inputFilePath)) return result;

        string[] lines = File.ReadAllLines(inputFilePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length != 2) continue;

            string fileName = parts[0].Trim();
            long crcValue;
            if (long.TryParse(parts[1], out crcValue))
            {
                result.Add(fileName, crcValue);
            }
        }

        return result;
    }

    private static void CheckIntegrity(string directoryPath, string savedCrcFilePath)
    {
        Dictionary<string, long> currentCrcs = CalculateCrcForAllFiles(directoryPath);
        Dictionary<string, long> savedCrcs = LoadCrcFromFile(savedCrcFilePath);

        StringBuilder report = new StringBuilder();

        foreach (var kvp in currentCrcs)
        {
            string filePath = kvp.Key;
            long currentCrc = kvp.Value;

            if (savedCrcs.ContainsKey(filePath))
            {
                long savedCrc = savedCrcs[filePath];
                bool isValid = currentCrc == savedCrc;
                report.AppendLine($"{filePath} : {(isValid ? "Целостность подтверждена" : "Файл изменен")}");
            }
            else
            {
                report.AppendLine($"{filePath} : Файл отсутствует в списке");
            }
        }

        Console.WriteLine(report.ToString());
    }
}
}