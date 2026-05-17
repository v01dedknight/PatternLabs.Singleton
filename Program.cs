using System;

namespace PatternLabs.Singleton {
  class Program {
    static void Main(string[] args) {
      Console.Title = "PatternLabs: Singleton Demo";
      Console.WriteLine("Запуск демонстрации Singleton (.NET Framework 4.7.2)...\n");

      // Accessing the configuration for the first time (Module A simulation)
      Console.WriteLine("Шаг 1: Обращение к конфигурации из Модуля А");
      ConfigurationManager config1 = ConfigurationManager.Instance;
      config1.PrintAllSettings();

      // Modifying state from one part of the application
      Console.WriteLine("\nШаг 2: Изменение настройки в Модуле А (смена темы на Light)...");
      config1.SetSetting("Theme", "Light");

      // Verifying that changes are reflected in another simulated module
      Console.WriteLine("\nШаг 3: Обращение к конфигурации из Модуля B");
      ConfigurationManager config2 = ConfigurationManager.Instance;
      Console.WriteLine($"Текущая тема, прочитанная модулем B: {config2.GetSetting("Theme")}");

      // Temporary holding console
      Console.ReadLine();
    }
  }
}