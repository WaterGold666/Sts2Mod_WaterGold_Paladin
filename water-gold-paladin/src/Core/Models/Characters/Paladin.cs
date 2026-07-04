using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Monsters;
using System.Collections.Generic;
using WaterGold_Paladin.src.Core.Models.CardPools;
using WaterGold_Paladin.src.Core.Models.Cards;
using WaterGold_Paladin.src.Core.Models.Enum;

namespace WaterGold_Paladin.src.Core.Models.Characters
{
    public class Paladin : CharacterModel
    {
        public static SpecEnum SelectedSpecialization { get; set; } = SpecEnum.Protection;

        // 专精名称映射（用于UI显示）
        public static string GetSpecializationDisplayName(SpecEnum spec)
        {
            return spec switch
            {
                SpecEnum.Protection => "防护",
                SpecEnum.Retribution => "惩戒",
                SpecEnum.Holy => "神圣",
                _ => "防护"
            };
        }

        // ========== 角色基础属性 ==========
        public override CharacterGender Gender => CharacterGender.Masculine;
        protected override CharacterModel? UnlocksAfterRunAs => null;
        public override Color NameColor => new Color("F0C040"); // 圣光金色
        public override int StartingHp => 75;
        public override int StartingGold => 99;

        // ========== 卡牌/药水/遗物池 ==========
        public override CardPoolModel CardPool => ModelDb.CardPool<PaladinCardPool>();
        public override PotionPoolModel PotionPool => ModelDb.PotionPool<PaladinPotionPool>();
        public override RelicPoolModel RelicPool => ModelDb.RelicPool<PaladinRelicPool>();


        // ========== 初始卡组 ==========
        public override IEnumerable<CardModel> StartingDeck => new CardModel[]
        {
        
        //两张打击，一张十字军打击，一张审判
        //三张防御，一张圣盾，一张庇护祝福
        ModelDb.Card<StrikePaladin>(),
        ModelDb.Card<StrikePaladin>(),
        ModelDb.Card<Judgment>(),
        ModelDb.Card<CrusaderStrike>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DefendPaladin>(),
        ModelDb.Card<DivineShield>(),
        ModelDb.Card<ShieldOfTheRighteous>(),
        ModelDb.Card<BlessingOfSanctuary>(),

        };






    }
}
