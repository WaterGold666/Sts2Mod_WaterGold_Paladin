using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterGold_Paladin.src.Core.Models.Powers
{
    public sealed class MightPower : PowerModel
    {

        public override PowerType Type => PowerType.Buff;

        // 效果堆叠类型
        public override PowerStackType StackType => PowerStackType.Single;

        // 允许?层数为负数
        public override bool AllowNegative => false;

        public override
    }
}
