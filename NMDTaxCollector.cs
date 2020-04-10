using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NoMoreDialogues
{
    class NMDTaxCollector : GlobalNPC
    {
        public override void PostAI(NPC npc)
        {
			Player player = Main.player[Main.myPlayer];
			int talkNPC = player.talkNPC;
			if(talkNPC != -1)
			{
				if(Main.npc[talkNPC].type == NPCID.TaxCollector)
				{
					CollectTax();
					player.talkNPC=-1;
				}

			}
            base.PostAI(npc);
        }
        public void CollectTax()
        {
            if (Main.player[Main.myPlayer].taxMoney > 0)
			{
				int j = Main.player[Main.myPlayer].taxMoney;
				while (j > 0)
				{
					if (j > 1000000)
					{
						int num13 = j / 1000000;
						j -= 1000000 * num13;
						int number7 = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 74, num13, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, null, number7, 1f, 0f, 0f, 0, 0, 0);
						}
					}
					else if (j > 10000)
					{
						int num12 = j / 10000;
						j -= 10000 * num12;
						int number6 = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 73, num12, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, null, number6, 1f, 0f, 0f, 0, 0, 0);
						}
					}
					else if (j > 100)
					{
						int num11 = j / 100;
						j -= 100 * num11;
						int number5 = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 72, num11, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, null, number5, 1f, 0f, 0f, 0, 0, 0);
						}
					}
					else
					{
						int num10 = j;
						if (num10 < 1)
						{
							num10 = 1;
						}
						j -= num10;
						int number4 = Item.NewItem((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 71, num10, false, 0, false, false);
						if (Main.netMode == 1)
						{
							NetMessage.SendData(21, -1, -1, null, number4, 1f, 0f, 0f, 0, 0, 0);
						}
					}
				}
				Main.player[Main.myPlayer].taxMoney = 0;
			}
			else
			{
				Main.npcChatText = "";
			}
        }
    }
}
