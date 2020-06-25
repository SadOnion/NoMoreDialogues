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
    class NMDNPC : GlobalNPC
    {
		private static readonly Dictionary<int, ShopID> npcs = new Dictionary<int, ShopID>()
		{
			[NPCID.Merchant] = ShopID.Merchant,
			[NPCID.Demolitionist] = ShopID.Demolitionist,
			[NPCID.ArmsDealer] = ShopID.ArmsDealer,
			[NPCID.Cyborg] = ShopID.Cyborg,
			[NPCID.Clothier] = ShopID.Clothier,
			[NPCID.Mechanic] = ShopID.Mechanic,
			[NPCID.Painter] = ShopID.Painter,
			[NPCID.SkeletonMerchant] = ShopID.SkeletonMerchant,
			[NPCID.TravellingMerchant] = ShopID.Traveling,
			[NPCID.Truffle] = ShopID.Truffle,
			[NPCID.Wizard] = ShopID.Wizard,
			[NPCID.WitchDoctor] = ShopID.WitchDoctor,
			[NPCID.Steampunker] = ShopID.Steampunker,
			[NPCID.Pirate] = ShopID.Pirate,
			[NPCID.PartyGirl] = ShopID.PartyGirl,
			[NPCID.Dryad] = ShopID.Dryad,
			[NPCID.DyeTrader] = ShopID.DyeTrader,
			[NPCID.SantaClaus] = ShopID.Santa,
			[NPCID.DD2Bartender] = ShopID.Tavernkeep

		};
        public override void PostAI(NPC npc)
        {
			if (npc.townNPC)
			{
				Player player = Main.player[Main.myPlayer];
				int talkNPC = player.talkNPC;

				if(talkNPC != -1)
				{

					if(Main.npc[talkNPC].type == NPCID.Guide && Main.InGuideCraftMenu==false)
					{
						NMDHelper.OpenCraftingMenu();
					}
				    if(Main.npc[talkNPC].type == NPCID.Nurse)
					{
						NMDHelper.Heal();
						//player.talkNPC=-1;
					}
					if (npcs.ContainsKey(Main.npc[talkNPC].type))
					{
						int shopId=(int)npcs[Main.npc[talkNPC].type];
						if(Main.npcShop != shopId)
						{
							NMDHelper.OpenShop(shopId);
						}
					}
					if(Main.npc[talkNPC].type == NPCID.TaxCollector)
					{
						NMDHelper.CollectTax();
						//player.talkNPC=-1;
					}

					if(npc.modNPC != null)
					{
						if(Main.npcShop != 22)
						{
							if(Main.npc[talkNPC].type == npc.type)
							{
								
								NPCLoader.OnChatButtonClicked(true);
								player.talkNPC = talkNPC;
								string chat = "";
								NPCLoader.GetChat(npc,ref chat);
								Main.npcChatText = chat;
							}
							
						}
					}
					
				}
			}
            base.PostAI(npc);
        }

    }
	public enum ShopID
	{
		Merchant=1,
		ArmsDealer=2,
		Dryad=3,
		Demolitionist=4,
		Clothier=5,
		Goblin=6,
		Wizard=7,
		Mechanic=8,
		Santa=9,
		Truffle=10,
		Steampunker=11,
		DyeTrader=12,
		PartyGirl=13,
		Cyborg=14,
		Painter=15,
		WitchDoctor=16,
		Pirate=17,
		Stylist=18,
		Traveling=19,
		SkeletonMerchant=20,
		Tavernkeep=21
	}
}
