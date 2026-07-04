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
using WaterGold_Paladin.src.Core.Models.Commands;

namespace WaterGold_Paladin.src.Core.Models.Cards
{
    sealed class Judgment : CardModel
    {
        protected override List<DynamicVar> CanonicalVars => [new DamageVar(6m, ValueProp.Move)];
        int GainHolyPowerNumber = 1;


        public Judgment() : base(1,CardType.Attack,CardRarity.Common,TargetType.AnyEnemy,true) 
        { }

        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            await DamageCmd.Attack(base.DynamicVars.Damage.BaseValue).FromCard(this).Targeting(cardPlay.Target).WithHitFx("vfx/vfx_attack_slash").Execute(choiceContext);
            await PaladinCmd.GainHolyPower(GainHolyPowerNumber, base.Owner);

        }

        protected override void OnUpgrade()
        {
            // 升级后，伤害值增加3点 (从6变为9)
            base.DynamicVars.Damage.UpgradeValueBy(9m);
        }

    }
}
