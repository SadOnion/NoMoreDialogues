using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Gamepad;

namespace NoMoreDialogues
{
    class NMDGuide : GlobalNPC
    {
        public override void PostAI(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
			int talkNPC = player.talkNPC;
			if(talkNPC != -1)
			{
				if(Main.npc[talkNPC].type == NPCID.Guide && Main.InGuideCraftMenu==false)
				{
					OpenCraftingMenu();
				}

			}
            base.PostAI(npc);
        }
        public void OpenCraftingMenu()
        {
            Main.playerInventory = true;
			Main.npcChatText = "";
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			Main.InGuideCraftMenu = true;
			UILinkPointNavigator.GoToDefaultPage(0);
        }
    }
}
