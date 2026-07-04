using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Rooms;
using MegaCrit.Sts2.Core.Saves.Runs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterGold_Paladin.src.Core.Models.Commands;

namespace WaterGold_Paladin.src.Core.Models.Relics
{
    public class UthersLegacy : RelicModel
    {
        /*
         * 乌瑟尔的遗志  Uther's Legacy  （防骑）效果：1.从药水处获得的格挡减少一半，但是护甲回合结		束只少33%									    
		2.开始获得2点神圣能量
		3.血量上限+20
        */

        #region(数值)
        private const float ArmorDecayRate = 0.33f;           // 护甲衰减率33%
        private const int StartingHolyPower = 2;              // 开局圣能
        private const int MaxHpBonus = 20;                    // 生命上限加成


        #endregion

        [SavedProperty]
        public int HolyPowerGranted { get; private set; }

        [SavedProperty]
        public bool HpBonusApplied { get; private set; }

        public override RelicRarity Rarity => RelicRarity.Starter;
        public override bool HasUponPickupEffect => true;

 

        /// <summary>
        /// 获取护甲衰减率（被外部调用）
        /// </summary>
        public float GetArmorDecayRate()
        {
            return ArmorDecayRate;
        }

        /// <summary>
        /// 获取药水格挡惩罚（被药水使用逻辑调用）
        /// </summary>
        public int ModifyPotionBlock(int originalBlock)
        {
            return originalBlock / 2;
        }

        /// <summary>
        /// 获得遗物时：增加最大生命值
        /// </summary>
        public override async Task AfterObtained()
        {
            await base.AfterObtained();

            await CreatureCmd.GainMaxHp(base.Owner.Creature, MaxHpBonus);
        }

        /// <summary>
        /// 战斗开始时：获得2点神圣能量
        /// </summary>
        public override async Task AfterSideTurnStart(CombatSide side, IReadOnlyList<Creature> participants, ICombatState combatState)
        {
            if (participants.Contains(base.Owner.Creature) && base.Owner.PlayerCombatState.TurnNumber <= 1)
            {
                await PaladinCmd.GainHolyPower(2m);
            }
        }

        /// <summary>
        /// 战斗结束后重置状态
        /// </summary>
        public override Task AfterCombatEnd(CombatRoom room)
        {
            base.Status = RelicStatus.Normal;
            return Task.CompletedTask;
        }


    }
}
