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
    //智慧祝福
    //效果描述，选择任意一名玩家，使其每回合抽牌数+1，费用1/0，自身获得4/6点护甲.
    //同时只能存在一种祝福

    public sealed class BlessingOfWisdom : CardModel
    {
        protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(4m, ValueProp.Move)];

        public BlessingOfWisdom() :base(1, CardType.Skill, CardRarity.Common, TargetType.AnyPlayer,true)
        { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            if (IsUpgraded == false)
            {
                await PowerCmd.Apply<WisdomPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
            else
            {
                await PowerCmd.Apply<GreaterWisdomPower>(choiceContext, cardPlay.Target, 1m, base.Owner.Creature, this);
            }
        }
    }
}
