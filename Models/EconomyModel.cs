﻿using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.Library;
using static Populations.PopulationManager;

namespace Populations.Models
{
    class EconomyModel : DefaultSettlementEconomyModel
    {

        public override float GetDailyDemandForCategory(Town town, ItemCategory category, int extraProsperity)
        {
            if (PopulationConfig.Instance.PopulationManager != null && PopulationConfig.Instance.PopulationManager.IsSettlementPopulated(town.Settlement)
                && category.IsValid && category.StringId != "banner")
            {
                PopulationData data = PopulationConfig.Instance.PopulationManager.GetPopData(town.Settlement);
                float nobles = data.GetTypeCount(PopType.Nobles);
                float craftsmen = data.GetTypeCount(PopType.Craftsmen);
                float serfs = data.GetTypeCount(PopType.Serfs);
                ConsumptionType type = Helpers.Helpers.GetTradeGoodConsumptionType(category);

                float prosperity = 0.5f + town.Prosperity * 0.0001f;
                float baseResult = 0f;
                if (type == ConsumptionType.Luxury)
                {
                    baseResult += nobles * 15f;
                    baseResult += craftsmen * 3f;
                } else if (type == ConsumptionType.Industrial)
                {
                    baseResult += craftsmen * 10f;
                    baseResult += serfs * 0.1f;
                } else
                {
                    baseResult += nobles * 1f;
                    baseResult += craftsmen * 1f;
                    baseResult += serfs * 0.12f;
                }
                
                float num = MathF.Max(0f, baseResult * prosperity + extraProsperity);
                float num2 = MathF.Max(0f, baseResult * prosperity);
                float num3 = category.BaseDemand * num;
                float num4 = category.LuxuryDemand * num2;
                float result = num3 + num4;
                if (category.BaseDemand < 1E-08f)
                {
                    result = num * 0.01f;
                }

                return result;
            } else return base.GetDailyDemandForCategory(town, category, extraProsperity);
        }

        public override float GetEstimatedDemandForCategory(Town town, ItemData itemData, ItemCategory category) => 
            this.GetDailyDemandForCategory(town, category, 1000);

        public override float GetDemandChangeFromValue(float purchaseValue)
        {
            float value = base.GetDemandChangeFromValue(purchaseValue);
            return value;
        }

        public override (float, float) GetSupplyDemandForCategory(Town town, ItemCategory category, float dailySupply, float dailyDemand, float oldSupply, float oldDemand)
        {
            ValueTuple<float, float> baseResult = base.GetSupplyDemandForCategory(town, category, dailySupply, dailyDemand, oldSupply, oldDemand);
            return baseResult;
        }

        public override int GetTownGoldChange(Town town)
        {
            return base.GetTownGoldChange(town);
        }
    }
}
