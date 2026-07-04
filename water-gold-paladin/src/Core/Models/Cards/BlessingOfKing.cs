using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterGold_Paladin.src.Core.Models.Powers;

namespace WaterGold_Paladin.src.Core.Models.Cards
{
    //王者祝福
    //效果描述，选择任意一名玩家，使其获得1/2层力量，1/2层灵巧，4/6层覆甲，自身获得4/7点护甲
    //同时只能存在一种祝福

    

    public sealed class BlessingOfKing : CardModel
    {
        protected override List<DynamicVar> CanonicalVars => [new BlockVar(4m, ValueProp.Move), new PowerVar<StrengthPower>(1m), new PowerVar<DexterityPower>(1m), new PowerVar<PlatingPower>(4m),];

        public BlessingOfKing() :base(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyPlayer, true)
            { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, cardPlay);

            if (this.IsUpgraded == false)
            {
                //清理所有祝福，然后添加祝福
                await BlessingManager.ClearBlessing(cardPlay.Target);
                await PowerCmd.Apply<KingPower>(choiceContext, cardPlay.Target, base.DynamicVars["KingPower"].BaseValue, base.Owner.Creature, this);



            }
            else 
            {
                await BlessingManager.ClearBlessing(cardPlay.Target);
                await PowerCmd.Apply<GreaterKingPower>(choiceContext, cardPlay.Target, base.DynamicVars["KingPower"].BaseValue, base.Owner.Creature, this);
            }

            /*
            await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, cardPlay);
            await PowerCmd.Apply<StrengthPower>(choiceContext, cardPlay.Target, base.DynamicVars["StrengthPower"].BaseValue, base.Owner.Creature, this);
            await PowerCmd.Apply<DexterityPower>(choiceContext, cardPlay.Target, base.DynamicVars["DexterityPower"].BaseValue, base.Owner.Creature, this);
            await PowerCmd.Apply<PlatingPower>(choiceContext, cardPlay.Target, base.DynamicVars["PlatingPower"].BaseValue, base.Owner.Creature, this);
            */
        }

        protected override void OnUpgrade()
        {
            base.EnergyCost.UpgradeBy(-1);
            base.DynamicVars.Block.UpgradeValueBy(3m);
            base.DynamicVars["StrengthPower"].UpgradeValueBy(1m);
            base.DynamicVars["DexterityPower"].UpgradeValueBy(1m);
            base.DynamicVars["PlatingPower"].UpgradeValueBy(2m);
        }
    }
}
