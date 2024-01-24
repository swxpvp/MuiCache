using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<string> ReadRegistryKeyNames(RegistryKey hive, string subkey)
    {
        List<string> names = new List<string>();
        using (RegistryKey key = hive.OpenSubKey(subkey))
        {
            if (key != null)
            {
                names.AddRange(key.GetValueNames());
            }
        }
        return names;
    }

    static void Main()
    {
        RegistryKey hive = Registry.ClassesRoot;
        string subkey = @"Local Settings\Software\Microsoft\Windows\Shell\MuiCache";

        List<string> registryNames = ReadRegistryKeyNames(hive, subkey);

        if (registryNames.Any())
        {
            registryNames.Sort(); // Sort the names alphabetically
            Console.WriteLine($"{subkey}:");

            foreach (string name in registryNames)
            {
                Console.WriteLine($"[+] {name}");
            }
        }
        else
        {
            Console.WriteLine($"Registry key {subkey} not found.");
        }

        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine(); // Wait for user input before closing
    }
}
