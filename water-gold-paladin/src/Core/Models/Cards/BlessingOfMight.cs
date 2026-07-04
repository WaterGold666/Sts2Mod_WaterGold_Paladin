using BaseLib.Extensions;
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

    //力量祝福
    //效果描述，选择任意一名玩家，使其获得2/4层力量，费用1/0，自身获得3/6点护甲.
    //同时只能存在一种祝福

    public sealed class BlessingOfMight : CardModel
    {
        protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(3m, ValueProp.Move)];

        public BlessingOfMight() : base(1, CardType.Skill, CardRarity.Common, TargetType.AnyPlayer, true)
            { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {

            if (IsUpgraded == false) {
                await PowerCmd.Apply<MightPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
            else 
            {
                await PowerCmd.Apply<GreaterMightPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
        }

        protected override void OnUpgrade()
        {
            base.EnergyCost.UpgradeBy(-1);
            base.DynamicVars.Block.UpgradeValueBy(3m);
        }
    }
}
