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

namespace WaterGold_Paladin.src.Core.Models.Cards
{
    public sealed class DefendPaladin : CardModel
    {
        protected override List<DynamicVar> CanonicalVars => [new BlockVar(5m, ValueProp.Move)];

        public DefendPaladin() 
            :base(1,CardType.Skill,CardRarity.Basic,TargetType.Self,false)        
        { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            await CreatureCmd.GainBlock(base.Owner.Creature, base.DynamicVars.Block, cardPlay);
        }

        protected override void OnUpgrade()
        {
            base.DynamicVars.Block.UpgradeValueBy(8m);
        }

    }
}
