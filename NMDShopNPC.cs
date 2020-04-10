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
    class NMDShopNPC: GlobalNPC
    {
		private static Dictionary<int,ShopID> npcs = new Dictionary<int, ShopID>()
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
			[NPCID.PartyGirl] = ShopID.PartyGirl

		};
        public override void PostAI(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
			int talkNPC = player.talkNPC;
			if(talkNPC != -1)
			{
				if (npcs.ContainsKey(npc.type))
				{
					int thisNPCShop = (int)npcs[npc.type];
					if(Main.npc[talkNPC].type == npc.type && Main.npcShop != thisNPCShop)
					{
					
						OpenShop(thisNPCShop);
					}
				}

			}
            base.AI(npc);
        }

		public void OpenShop(int shopID)
		{
			Main.playerInventory = true;
			Main.npcChatText = "";
			Main.npcShop = shopID;
			Main.PlaySound(12, -1, -1, 1, 1f, 0f);
		}
		
    }
	public enum ShopID
	{
		Merchant=1,
		ArmsDealer=2,
		Mechanic=8,
		Santa=9,
		Stylist=18,
		Traveling=19,
		SkeletonMerchant=20,
		Dryad=3,
		Demolitionist=4,
		Clothier=5,
		Wizard=7,
		Truffle=10,
		Steampunker=11,
		DyeTrader=12,
		PartyGirl=13,
		Cyborg=14,
		Painter=15,
		WitchDoctor=16,
		Pirate=17,
		Tavernkeep=21
	}
}
