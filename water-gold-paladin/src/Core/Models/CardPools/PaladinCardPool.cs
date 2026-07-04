using Godot;
using MegaCrit.Sts2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterGold_Paladin.src.Core.Models.Cards;

namespace WaterGold_Paladin.src.Core.Models.CardPools
{
    internal class PaladinCardPool : CardPoolModel
    {
        public override string Title => "Paladin";
        public override string EnergyColorName => "Paladin";
        public override string CardFrameMaterialPath => "card_frame_yellow";
        public override Color DeckEntryCardColor => new Color("#f6a67e");
        public override Color EnergyOutlineColor => new Color("#ffc037");
        public override bool IsColorless => false;

        protected override CardModel[] GenerateAllCards()
        {
            return new CardModel[]
            {
                ModelDb.Card<StrikePaladin>(),
                ModelDb.Card<DefendPaladin>(),
                ModelDb.Card<BlessingOfKing>(),
                ModelDb.Card<BlessingOfMight>(),
                ModelDb.Card<BlessingOfSanctuary>(),

            };
        }

    }
}
