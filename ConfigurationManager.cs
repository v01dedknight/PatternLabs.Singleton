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
      _settings = new Dictionary<string, string>();

      // Load default configuration values
      _settings["AppName"] = "PatternLabs System";
      _settings["Version"] = "1.0.0";
      _settings["Theme"] = "Dark Fantasy";
      _settings["MaxConnections"] = "100";
    }

    // Public static property to access the single instance
    public static ConfigurationManager Instance => _instance.Value;
  }
}