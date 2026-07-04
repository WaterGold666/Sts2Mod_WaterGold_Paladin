using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterGold_Paladin.src.Core.Hook
{
    public static class Hook
    {


        #region(神圣能量部分)

        // 是否允许获得神圣能量（其他Mod可拦截）
        public static bool ShouldGainHolyPower(ICombatState combatState, int amount, Player player) 
        {
            // 默认允许
            return true;
        }

        // 获得神圣能量后的回调
        public static async Task AfterHolyPowerGained(ICombatState combatState, int amount, Player player)
        {
            // 默认空实现
            await Task.CompletedTask;
        }

        #endregion

    }
}
