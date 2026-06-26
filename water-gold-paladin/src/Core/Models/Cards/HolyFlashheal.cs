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
    public sealed class HolyFlashheal : CardModel
    {

        protected override List<DynamicVar> CanonicalVars => [new HealVar(3m)];

        public HolyFlashheal()
            :base(1,CardType.Skill,CardRarity.Basic,TargetType.AnyPlayer,true)
        { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            await 
        }
    }
}
