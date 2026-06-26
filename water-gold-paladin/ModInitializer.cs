using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;

namespace WaterGold_Paladin
{
    // 通用 ModInitializer
    [ModInitializer(nameof(Initialize))]
    public static class ModInitializer
    {
        public static void Initialize()
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

            Log.Info("WaterGold_Paladin - 加载成功!");

        }
    }
}
