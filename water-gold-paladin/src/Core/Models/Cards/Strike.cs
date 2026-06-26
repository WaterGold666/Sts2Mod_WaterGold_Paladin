using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Events;
using MegaCrit.Sts2.Core.ValueProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterGold_Paladin.src.Core.Models.Cards
{
    //打击
    //费用1，攻击牌，普通，任意敌人，可显示于lib
    


    // 卡牌类必须继承 CardModel，并标记为 sealed
    public sealed class Strike : CardModel
    {
        // 1. 定义卡牌的动态变量 (这里是伤害)
        //    这个列表定义了卡牌上会显示和变动的数值
        protected override List<DynamicVar> CanonicalVars => [new DamageVar(6m, ValueProp.Move)];


        // 2. 构造函数: 设置卡牌的基础属性
        //    参数依次为：费用, 类型, 稀有度, 目标类型
        public Strike() 
            : base(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy, true) 
        { }

        // 3. 实现 OnPlay 回调: 打出卡牌时触发的效果
        protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
        {
            // 使用 DamageCmd 执行攻击
            // .Attack() 指定基础伤害值，从 DynamicVars 中获取
            // .FromCard(this) 指定伤害来源是这张卡
            // .Targeting(cardPlay.Target) 指定攻击目标为玩家选择的目标
            // .WithHitFx() 指定攻击特效 (可选)
            // .Execute() 执行攻击
            await DamageCmd
                .Attack(base.DynamicVars.Damage.BaseValue).FromCard(this).Targeting(cardPlay.Target).WithHitFx("vfx/vfx_attack_slash").Execute(choiceContext);
        }

        // 4. 实现 OnUpgrade 回调: 卡牌升级时触发的效果
        protected override void OnUpgrade()
        {
            // 升级后，伤害值增加3点 (从6变为9)
            base.DynamicVars.Damage.UpgradeValueBy(9m);
        }
    }
}
        



