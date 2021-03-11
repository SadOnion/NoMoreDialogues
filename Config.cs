using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace NoMoreDialogues
{
    class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        [Label("Nurse Quick Heal")]
        [DefaultValue(true)]
        public bool nurseQuickHeal;

        public override void OnChanged()
        {
            NoMoreDialogues.nurseQuickHeal = nurseQuickHeal;
        }
    }
}
