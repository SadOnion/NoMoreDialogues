using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Achievements;

namespace NoMoreDialogues
{
    class NMDNurse : GlobalNPC
    {
        
        public override void PostAI(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
			int talkNPC = player.talkNPC;
			if(talkNPC != -1)
			{
				if(Main.npc[talkNPC].type == NPCID.Nurse)
				{
					Heal();
					player.talkNPC=-1;
				}

			}
			base.PostAI(npc);
        }
        public void Heal()
        {
            int num27 = Item.silver*10;
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
    }
    
}
