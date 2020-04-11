using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Gamepad;

namespace NoMoreDialogues
{
    static class NMDHelper
    {
        public static void OpenCraftingMenu()
        {
            Main.playerInventory = true;
			Main.npcChatText = "";
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
			Main.InGuideCraftMenu = true;
			UILinkPointNavigator.GoToDefaultPage(0);
        }
		public static int CalculatePriceForHeal()
		{
			int health = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLife;
			int num27 = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLife;
			for (int k = 0; k < Player.MaxBuffs; k++)
				{
					int num6 = Main.player[Main.myPlayer].buffType[k];
					if (Main.debuff[num6] && Main.player[Main.myPlayer].buffTime[k] > 5 && BuffLoader.CanBeCleared(num6))
					{
						num27 += 1000;
					}
				}
			int num23 = num27;
			PlayerHooks.ModifyNursePrice(Main.player[Main.myPlayer], Main.npc[Main.player[Main.myPlayer].talkNPC], health, true, ref num23);
			if (num23 > 0)
			{
				num23 = (int)((double)num23 * 0.75);
				if (num23 < 1)
				{
					num23 = 1;
				}
			}
			return num23;
		}
        public static void Heal()
        {
            int num27 = CalculatePriceForHeal();
			int health = Main.player[Main.myPlayer].statLifeMax2 - Main.player[Main.myPlayer].statLife;
			if(health == 0) return;

		    if (Main.player[Main.myPlayer].BuyItem(num27, -1))
			{
				AchievementsHelper.HandleNurseService(num27);
				Main.PlaySound(SoundID.Item4, -1, -1);
				Main.player[Main.myPlayer].HealEffect(health, true);
				
				Main.player[Main.myPlayer].statLife += health;
				if (true)
				{
					for (int i = 0; i < Player.MaxBuffs; i++)
					{
						int num9 = Main.player[Main.myPlayer].buffType[i];
						if (Main.debuff[num9] && Main.player[Main.myPlayer].buffTime[i] > 0 && BuffLoader.CanBeCleared(num9))
						{
							Main.player[Main.myPlayer].DelBuff(i);
							i = -1;
						}
					}
				}
				PlayerHooks.PostNurseHeal(Main.player[Main.myPlayer], Main.npc[Main.player[Main.myPlayer].talkNPC], health, true, num27);
			}
			
        }
		public static void OpenShop(int shopID)
		{
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = shopID;
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
		}
		public static void CollectTax()
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
