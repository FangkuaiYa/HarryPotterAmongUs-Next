using System;
using CustomOption.CustomOption;

namespace HarryPotter.Classes
{
    class Config
    {
        private static CustomHeaderOption HPSettings;

        private static CustomToggleOption Option1;
        private static CustomToggleOption Option3;
        //private static CustomToggleOption Option4;
        private static CustomToggleOption Option5;
        private static CustomNumberOption Option9;
        private static CustomNumberOption Option10;
        private static CustomNumberOption Option11;
        private static CustomNumberOption Option12;
        
        private static Func<object, string> CooldownFormat { get; } = value => $"{value:0.0#}s";
        public static void LoadOptions()
        {
            var num = 2;

            HPSettings = new CustomHeaderOption(num++, "<#FF8503>Harry Potter Settings<#FFFFFF>");

            Option1 = new CustomToggleOption(num++, "Order of the Impostors", false);
            Option3 = new CustomToggleOption(num++, "Can Spells be Used In Vents", false);
            //Option4 = new CustomToggleOption(num++, "Show Info Popups/Tooltips", true);
            Option5 = new CustomToggleOption(num++, "Shared Voldemort Cooldowns", true);
            Option9 = new CustomNumberOption(num++, "Defensive Duelist Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            Option10 = new CustomNumberOption(num++, "Invisibility Cloak Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            Option11 = new CustomNumberOption(num++, "Time Turner Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);
            Option12 = new CustomNumberOption(num++, "Crucio Cooldown", 25f, 10f, 60f, 2.5f, CooldownFormat);

        }
        public bool OrderOfTheImp { get; private set; }
        public float MapDuration { get { return 10; } }
        public float DefensiveDuelistDuration { get { return 10; } }
        public float InvisCloakDuration { get { return 10; } }
        public float HourglassTimer { get { return 10; } }
        public float BeerDuration { get { return 10; } }
        public float CrucioDuration { get { return 10; } }
        public float DefensiveDuelistCooldown { get; private set; }
        public float InvisCloakCooldown { get; private set; }
        public float HourglassCooldown { get; private set; }
        public float CrucioCooldown { get; private set; }
        public bool SpellsInVents { get; private set; }
        public float ImperioDuration { get { return 10; } }
        //public bool ShowPopups { get; private set; }
        public bool SeparateCooldowns { get; private set; }
        public bool SimplerWatermark { get { return false; } }
        public bool SelectRoles { get { return false; } }
        public bool UseCustomRegion { get { return false; } }
        
        public void ReloadSettings()
        {
            OrderOfTheImp = Option1.Get();
            SpellsInVents = Option3.Get();
            DefensiveDuelistCooldown = Option9.Get();
            InvisCloakCooldown = Option10.Get();
            HourglassCooldown = Option11.Get();
            CrucioCooldown = Option12.Get();
            //ShowPopups = Option4.Get();
            SeparateCooldowns = !Option5.Get();
        }
    }
}
