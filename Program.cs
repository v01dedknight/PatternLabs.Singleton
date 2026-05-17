using System;

namespace PatternLabs.Singleton {
  class Program {
    static void Main() {
      Console.Title = "PatternLabs: Singleton Demo";
      Console.WriteLine("Launch Demonstration Singleton (.NET Framework 4.7.2)...\n");

      // Accessing the configuration for the first time (Module A simulation)
      Console.WriteLine("Step 1: Accessing the configuration from Module A");
      ConfigurationManager config1 = ConfigurationManager.Instance;

      // Метод GetSettingsReport формирует строку, а Console.WriteLine в UI-слое её выводит
      Console.WriteLine(config1.GetSettingsReport());

      // Modifying state from one part of the application
      Console.WriteLine("\nStep 2: Changing a setting in Module A (switching the theme to Light)...");
      config1.SetSetting("Theme", "Light");

      // Verifying that changes are reflected in another simulated module
      Console.WriteLine("\nStep 3: Accessing the configuration from Module B");
      ConfigurationManager config2 = ConfigurationManager.Instance;
      Console.WriteLine($"Current theme read by Module B: {config2.GetSetting("Theme")}");

      // Strict proof of Singleton pattern compliance (reference validation)
      Console.WriteLine("\nStep 4: Checking object identity in memory");
      if (ReferenceEquals(config1, config2)) {
        Console.WriteLine(">> SUCCESS: config1 and config2 refer to the same object.");
        Console.WriteLine(">> Singleton pattern is working correctly.");
      }

      Console.WriteLine("\nPress Enter to exit...");
      Console.ReadLine();
    }
  }
}