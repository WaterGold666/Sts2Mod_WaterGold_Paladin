using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterGold_Paladin.src.Core.Models.Cards;

namespace WaterGold_Paladin.src.Core.Models.Powers
{
    public class BlessingManager
    {
        public static async Task ClearBlessing(Creature target) 
        {
            await PowerCmd.Remove<KingPower>(target);
            await PowerCmd.Remove<GreaterKingPower>(target);

            await PowerCmd.Remove<WisdomPower>(target);
            await PowerCmd.Remove<GreaterWisdomPower>(target);

            await PowerCmd.Remove<SanctuaryPower>(target);
            await PowerCmd.Remove<GreaterSanctuaryPower>(target);

            await PowerCmd.Remove<MightPower>(target);
            await PowerCmd.Remove<GreaterMightPower>(target);
        }

    }
}
