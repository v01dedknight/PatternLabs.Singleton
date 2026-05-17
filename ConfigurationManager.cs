using System;
using System.Collections.Generic;

namespace PatternLabs.Singleton {
  /// <summary>
  /// ConfigurationManager class implementing the Singleton pattern.
  /// Provides a single source of truth for application settings.
  /// </summary>
  public sealed class ConfigurationManager {
    // Thread-safe lazy initialization handled by the .NET Runtime
    private static readonly Lazy<ConfigurationManager> _instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());

    // Internal storage for configuration key-value pairs
    private readonly Dictionary<string, string> _settings;

    // Private constructor prevents instantiation from outside the class
    private ConfigurationManager() {
      _settings = new Dictionary<string, string> {
        { "AppName", "PatternLabs System" },
        { "Version", "1.0.0" },
        { "Theme", "Dark Fantasy" },
        { "MaxConnections", "100" }
      };
    }

    // Public static property to access the single instance
    public static ConfigurationManager Instance => _instance.Value;

    /// <summary>
    /// Retrieves a setting value by its configuration key.
    /// </summary>
    public string GetSetting(string key) {
      // Try to get the value from the settings dictionary, return a default message if not found
      return _settings.TryGetValue(key, out string value) ? value : "Setting not found";
    }

    /// <summary>
    /// Updates or creates a configuration setting.
    /// </summary>
    public void SetSetting(string key, string value) {
      _settings[key] = value;
    }

    /// <summary>
    /// Outputs all current settings to the console application.
    /// </summary>
    public void PrintAllSettings() {
      Console.WriteLine("=== Current System Configuration ===");
      foreach (KeyValuePair<string, string> setting in _settings) {
        Console.WriteLine($"[{setting.Key}] : {setting.Value}");
      }
      Console.WriteLine("====================================");
    }
  }
}