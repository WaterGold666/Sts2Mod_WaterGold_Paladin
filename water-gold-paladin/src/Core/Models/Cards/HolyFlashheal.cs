using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WaterGold_Paladin.src.Core.Models.Cards
{   
    //圣光闪现
    //费用1，技能牌，基础

    /*选择任意一名玩家，回复1/2HP，自身获得4/6点护盾  --防骑
                                  选择任意一名玩家，回复2/4HP  --惩戒骑
                                  选择任意一名玩家，回复4/6HP --奶骑
    */
    
    public sealed class HolyFlashheal : CardModel
    {

        #region(数值)
        // 防骑（Protection）
        private const decimal PROT_HEAL_BASE = 1m;
        private const decimal PROT_BLOCK_BASE = 4m;
        private const decimal PROT_HEAL_UPG = 2m;
        private const decimal PROT_BLOCK_UPG = 6m;

        // 惩戒骑（Retribution）
        private const decimal RET_HEAL_BASE = 2m;
        private const decimal RET_HEAL_UPG = 4m;

        // 奶骑（Holy）
        private const decimal HOLY_HEAL_BASE = 4m;
        private const decimal HOLY_HEAL_UPG = 6m;
        #endregion


        protected override List<DynamicVar> CanonicalVars => [new HealVar(HOLY_HEAL_UPG)];

        public HolyFlashheal()
            :base(1,CardType.Skill,CardRarity.Basic,TargetType.AnyPlayer,true)
        { 
        }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            var target = cardPlay.Target;
            if()
            await CreatureCmd.Heal(target, base.DynamicVars.Heal.BaseValue);

        }

        protected override void OnUpgrade()
        {
            if
            base.DynamicVars.Heal.UpgradeValueBy();
        }
    }
}
