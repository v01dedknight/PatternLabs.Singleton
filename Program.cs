using System;

namespace PatternLabs.Singleton {
  class Program {
    static void Main(string[] args) {
      Console.Title = "PatternLabs: Singleton Demo";
      Console.WriteLine("Запуск демонстрации Singleton (.NET Framework 4.7.2)...\n");

      // Getting the singleton instance and showing initial settings
      Console.WriteLine("Шаг 1: Обращение к конфигурации из Модуля А");
      ConfigurationManager config1 = ConfigurationManager.Instance;
      config1.PrintAllSettings();

      // Change a setting in Module A and show that it affects the same instance
      Console.WriteLine("\nШаг 2: Изменение настройки в Модуле А (смена темы на Light)...");
      config1.SetSetting("Theme", "Light");

      // Show that the change is reflected when accessed from Module B, proving that both modules share the same instance
      Console.WriteLine("\nШаг 3: Обращение к конфигурации из Модуля B");
      ConfigurationManager config2 = ConfigurationManager.Instance;
      Console.WriteLine($"Текущая тема, прочитанная модулем B: {config2.GetSetting("Theme")}");

      // Strict proof of Singleton pattern pattern compliance (reference validation)
      Console.WriteLine("\nШаг 4: Проверка идентичности объектов в памяти");
      if (ReferenceEquals(config1, config2)) {
        Console.WriteLine(">> УСПЕХ: config1 и config2 ссылаются на один и тот же объект.");
        Console.WriteLine(">> Паттерн Singleton работает корректно.");
      }

      Console.WriteLine("\nНажмите Enter для выхода...");
      Console.ReadLine();
    }
  }
}