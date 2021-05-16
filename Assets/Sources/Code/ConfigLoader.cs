using Sources.Code.Chat;
using UnityEngine;

namespace Sources.Code
{
    public static class ConfigLoader
    {
        private static ChatConfiguration _currentSettings;
        
        public static ChatConfiguration GetConfig()
        {
            if (_currentSettings != null) return _currentSettings;
            var gameSettings = Resources.Load<ChatConfiguration>("ChatConfig");
            _currentSettings = Object.Instantiate(gameSettings);
            return _currentSettings;
        }
    }
}
