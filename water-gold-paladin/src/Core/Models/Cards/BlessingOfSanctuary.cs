using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterGold_Paladin.src.Core.Models.Powers;

namespace WaterGold_Paladin.src.Core.Models.Cards
{
    //庇护祝福
    //效果描述，选择任意一名玩家，使其获得2/4层灵巧，费用1/0，自身获得5/8点护甲.
    //同时只能存在一种祝福

    public sealed class BlessingOfSanctuary : CardModel
    {
        protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(5m, ValueProp.Move)];

        public BlessingOfSanctuary() 
            :base(1, CardType.Power, CardRarity.Common, TargetType.AnyPlayer, true ) 
        { }



        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            if (IsUpgraded == false)
            {
                await PowerCmd.Apply<SanctuaryPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
            else
            {
                await PowerCmd.Apply<GreaterSanctuaryPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
        }

        protected override void OnUpgrade()
        {
            base.EnergyCost.UpgradeBy(-1);
            base.DynamicVars.Block.UpgradeValueBy(3m);
        }
    }
}
