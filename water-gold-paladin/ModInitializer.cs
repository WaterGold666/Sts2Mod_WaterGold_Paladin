using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using System;
using WaterGold_Paladin.src.Core.Models.CardPools;
using WaterGold_Paladin.src.Core.Models.Cards;
using WaterGold_Paladin.src.Core.Models.Relics;

namespace WaterGold_Paladin
{
    // 通用 ModInitializer
    [ModInitializer(nameof(Initialize))]
    public static class ModInitializer
    {
        public static void Initialize()
        {

            try
            {
                {
                    // 1. 初始化 Harmony（避免与其他模组冲突。）
                    var harmony = new Harmony(id: "Paladin.WaterGold");
                    harmony.PatchAll();
                }

                // 2. 在这里添加你的注册逻辑（卡牌、遗物、药水等）
                //ModHelper.AddModelToPool(typeof( t),typeof("Strike"));
                //ModHelper.AddModelToPool(typeof( 卡牌池 ), typeof( 卡牌名字 ));
                //ModHelper.AddModelToPool(typeof( 遗物池 ), typeof( 遗物名字 ));
                //ModHelper.AddModelToPool(typeof( 药水池 ), typeof( 药水名字 ));

                //遗物
                ModHelper.AddModelToPool(typeof(PaladinRelicPool), typeof(UthersLegacy));
                //ModHelper.AddModelToPool(typeof(PaladinRelicPool), typeof());

                //卡牌
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(BlessingOfKing));         //王者祝福
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(BlessingOfMight));         //力量祝福
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(BlessingOfSanctuary));     //庇护祝福
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(BlessingOfWisdom));        //智慧祝福
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(DefendPaladin));           //防御
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(HolyFlashheal));           //圣光闪现
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(Judgment));                //审判
                ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof(StrikePaladin));           //打击

                //ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof());
                //ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof());
                //ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof());
                //ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof());
                //ModHelper.AddModelToPool(typeof(PaladinCardPool), typeof());

                //药水
                //ModHelper.AddModelToPool(typeof(PaladinPotionPool), typeof());


            }
            catch (Exception e) 
            {
                Log.Error("WaterGold_Paladin - 加载失败");
                Log.Error(e.Message);
                return;
            }

            Log.Info("WaterGold_Paladin - 加载成功!");

        }
    }
}
