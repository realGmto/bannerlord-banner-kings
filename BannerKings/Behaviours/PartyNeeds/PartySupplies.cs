﻿using BannerKings.Managers.Items;
using BannerKings.Models.BKModels;
using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.SaveSystem;

namespace BannerKings.Behaviours.PartyNeeds
{
    public class PartySupplies
    {
        private List<ItemCategory> alcoholCategories;

        private List<ItemCategory> animalProductsCategories;

        private List<ItemCategory> toolsCategories;

        private List<ItemCategory> horseCategories;

        private List<ItemCategory> ammoCategories;

        private List<ItemCategory> weaponCategories;

        private List<ItemCategory> shieldCategories;

        private List<ItemCategory> clothCategories;

        private List<ItemCategory> woodCategories;

        public PartySupplies(MobileParty party)
        {
            Party = party;
            AutoBuying = party == MobileParty.MainParty ? false : true;
            
            PostInitialize();
        }

        public void PostInitialize()
        {
            DaysOfProvision = 10;
            alcoholCategories = new List<ItemCategory>(3)
            {
                DefaultItemCategories.Wine,
                DefaultItemCategories.Beer,
                BKItemCategories.Instance.Mead
            };

            animalProductsCategories = new List<ItemCategory>(3)
            {
                DefaultItemCategories.Meat,
                DefaultItemCategories.Cheese,
                DefaultItemCategories.Butter,
                DefaultItemCategories.Fish
            };

            toolsCategories = new List<ItemCategory>(1)
            {
                DefaultItemCategories.Tools
            };

            horseCategories = new List<ItemCategory>(1)
            {
                DefaultItemCategories.Horse
            };

            ammoCategories = new List<ItemCategory>(1)
            {
                DefaultItemCategories.Arrows
            };

            weaponCategories = new List<ItemCategory>(5)
            {
                DefaultItemCategories.MeleeWeapons1,
                DefaultItemCategories.MeleeWeapons2,
                DefaultItemCategories.MeleeWeapons3,
                DefaultItemCategories.MeleeWeapons4,
                DefaultItemCategories.MeleeWeapons5,
            };

            shieldCategories = new List<ItemCategory>(5)
            {
                DefaultItemCategories.Shield1,
                DefaultItemCategories.Shield2,
                DefaultItemCategories.Shield3,
                DefaultItemCategories.Shield4,
                DefaultItemCategories.Shield5
            };

            clothCategories = new List<ItemCategory>(3)
            {
                DefaultItemCategories.Wool,
                DefaultItemCategories.Linen,
                DefaultItemCategories.Flax
            };

            woodCategories = new List<ItemCategory>(1)
            {
                DefaultItemCategories.Wood
            };
        }

        [SaveableProperty(2)] public bool AutoBuying { get; private set; }
        public int DaysOfProvision { get; private set; }

        [SaveableProperty(1)] public MobileParty Party { get; private set; }
        [SaveableProperty(3)] public float AlcoholNeed { get; private set; }
        [SaveableProperty(4)] public float WoodNeed { get; private set; }
        [SaveableProperty(5)] public float ToolsNeed { get; private set; }
        [SaveableProperty(6)] public float ClothNeed { get; private set; }
        [SaveableProperty(7)] public float ArrowsNeed { get; private set; }
        [SaveableProperty(8)] public float WeaponsNeed { get; private set; }
        [SaveableProperty(9)] public float HorsesNeed { get; private set; }
        [SaveableProperty(10)] public float AnimalProductsNeed { get; private set; }
        [SaveableProperty(11)] public float ShieldsNeed { get; private set; }

        public int MinimumSoldiersThreshold => (int)BannerKingsConfig.Instance.PartyNeedsModel.MinimumSoldiersThreshold(this, false)
            .ResultNumber;

        public ExplainedNumber MinimumSoldiersThresholdExplained => BannerKingsConfig.Instance.PartyNeedsModel.MinimumSoldiersThreshold(this, true);
        public ExplainedNumber GetAlcoholCurrentNeed(bool explained = false) => 
            BannerKingsConfig.Instance.PartyNeedsModel.CalculateAlcoholNeed(this, explained);

        public ExplainedNumber GetTextileCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateClothNeed(this, explained);

        public ExplainedNumber GetWoodCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateWoodNeed(this, explained);

        public ExplainedNumber GetToolsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateToolsNeed(this, explained);

        public ExplainedNumber GetAnimalProductsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateAnimalProductsNeed(this, explained);

        public ExplainedNumber GetMountsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateHorsesNeed(this, explained);

        public ExplainedNumber GetArrowsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateArrowsNeed(this, explained);

        public ExplainedNumber GetWeaponsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateWeaponsNeed(this, explained);

        public ExplainedNumber GetShieldsCurrentNeed(bool explained = false) =>
           BannerKingsConfig.Instance.PartyNeedsModel.CalculateShieldsNeed(this, explained);

        public void Tick()
        {
            if (Party.MemberRoster.Count > MinimumSoldiersThreshold)
            {
                IPartyNeedsModel model = BannerKingsConfig.Instance.PartyNeedsModel;
                AlcoholNeed += model.CalculateAlcoholNeed(this, false).ResultNumber;
                WoodNeed += model.CalculateWoodNeed(this, false).ResultNumber;
                ToolsNeed += model.CalculateToolsNeed(this, false).ResultNumber;
                ClothNeed += model.CalculateClothNeed(this, false).ResultNumber;
                ArrowsNeed += model.CalculateArrowsNeed(this, false).ResultNumber;
                WeaponsNeed += model.CalculateWeaponsNeed(this, false).ResultNumber;
                HorsesNeed += model.CalculateHorsesNeed(this, false).ResultNumber;
                AnimalProductsNeed += model.CalculateAnimalProductsNeed(this, false).ResultNumber;
                ShieldsNeed += model.CalculateShieldsNeed(this, false).ResultNumber;
            }

            BuyItems();
            AlcoholNeed -= ConsumeItems(AlcoholNeed, alcoholCategories);
            WoodNeed -= ConsumeItems(WoodNeed, woodCategories);
            ToolsNeed -= ConsumeItems(ToolsNeed, toolsCategories);
            ClothNeed -= ConsumeItems(ClothNeed, clothCategories);
            ArrowsNeed -= ConsumeItems(ArrowsNeed, ammoCategories);
            WeaponsNeed -= ConsumeItems(WeaponsNeed, weaponCategories);
            HorsesNeed -= ConsumeItems(HorsesNeed, horseCategories);
            AnimalProductsNeed -= ConsumeItems(AnimalProductsNeed, animalProductsCategories);
            ShieldsNeed -= ConsumeItems(ShieldsNeed, shieldCategories);
        }

        public void BuyItems()
        {
            if (Party.EffectiveQuartermaster != null && AutoBuying && Party.CurrentSettlement != null)
            {
                BuyItems(AlcoholNeed * DaysOfProvision, alcoholCategories);
                BuyItems(WoodNeed * DaysOfProvision, woodCategories);
                BuyItems(ToolsNeed * DaysOfProvision, toolsCategories);
                BuyItems(ClothNeed * DaysOfProvision, clothCategories);
                BuyItems(ArrowsNeed * DaysOfProvision, ammoCategories);
                BuyItems(WeaponsNeed * DaysOfProvision, weaponCategories);
                BuyItems(HorsesNeed * DaysOfProvision, horseCategories);
                BuyItems(AnimalProductsNeed * DaysOfProvision, animalProductsCategories);
                BuyItems(ShieldsNeed * DaysOfProvision, shieldCategories);
            }
        }

        private void BuyItems(float floatCount, List<ItemCategory> categories)
        {
            int count = MathF.Floor(floatCount);
            if (count < 1)
            {
                return;
            }

            foreach (ItemRosterElement element in Party.CurrentSettlement.ItemRoster)
            {
                if (categories.Contains(element.EquipmentElement.Item.ItemCategory))
                {
                    count -= element.Amount;
                }
            }

            if (count > 0)
            {
                List<ItemRosterElement> toBuy = new List<ItemRosterElement>();
                foreach (ItemRosterElement element in Party.CurrentSettlement.ItemRoster)
                {
                    if (categories.Contains(element.EquipmentElement.Item.ItemCategory))
                    {
                        toBuy.Add(element);
                    }
                }

                toBuy.Sort((a, b) => a.EquipmentElement.ItemValue.CompareTo(b.EquipmentElement.ItemValue));
                foreach (ItemRosterElement element in toBuy)
                {
                    int canBuy = (int)(Party.LeaderHero.Gold / (float)element.EquipmentElement.ItemValue);
                    int result = MathF.Min(count, MathF.Min(canBuy, element.Amount));
                    int price;
                    if (Party.CurrentSettlement.Town != null)
                    {
                        price = Party.CurrentSettlement.Town.GetItemPrice(element.EquipmentElement, Party);
                    }
                    else if (Party.CurrentSettlement.Village != null)
                    {
                        price = Party.CurrentSettlement.Village.GetItemPrice(element.EquipmentElement, Party);
                    }
                    else break;

                    Party.CurrentSettlement.ItemRoster.AddToCounts(element.EquipmentElement, -result);
                    Party.ItemRoster.AddToCounts(element.EquipmentElement, result);
                    Party.LeaderHero.ChangeHeroGold((int)(price * (float)-result));

                    count -= result;
                    if (count < 1) break;
                }
            }
        }

        private float ConsumeItems(float floatCount, List<ItemCategory> categories)
        {
            float finalResult = 0;
            int count = MathF.Floor(floatCount);
            if (count < 1)
            {
                return finalResult;
            }

            List<ItemRosterElement> toConsume = new List<ItemRosterElement>();
            foreach (ItemRosterElement element in Party.ItemRoster)
            {
                if (categories.Contains(element.EquipmentElement.Item.ItemCategory))
                {
                    toConsume.Add(element);
                }
            }

            toConsume.Sort((a, b) => a.EquipmentElement.ItemValue.CompareTo(b.EquipmentElement.ItemValue));
            foreach (ItemRosterElement element in toConsume)
            {
                int result = MathF.Min(count, element.Amount);
                Party.ItemRoster.AddToCounts(element.EquipmentElement, -result);
                count -= result;
                float modifier = 1f;
                if (element.EquipmentElement.ItemModifier != null)
                {
                    modifier = element.EquipmentElement.ItemModifier.PriceMultiplier;
                }

                finalResult += result * modifier;
                if (count < 1) break;
            }

            return finalResult;
        }
    }
}
