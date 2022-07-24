﻿using System.Collections.Generic;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace BannerKings.Managers.Skills
{
    public class BKPerks : DefaultTypeInitializer<BKPerks, PerkObject>
    {
        private PerkObject scholarshipLiterate, scholarshipPolyglot, scholarshipLearner,
            scholarshipTutor, scholarshipWellRead, scholarshipMechanic, scholarshipAccountant, scholarshipTeacher, scholarshipBookWorm,
            scholarshipPeerReview, scholarshipBedtimeStory, scholarshipScientist, scholarshipTreasurer, scholarshipMagnumOpus;

        public PerkObject ScholarshipLiterate => scholarshipLiterate;
        public PerkObject ScholarshipAvidLearner => scholarshipLearner;
        public PerkObject ScholarshipTutor => scholarshipTutor;
        public PerkObject ScholarshipWellRead => scholarshipWellRead;
        public PerkObject ScholarshipTeacher => scholarshipTeacher;
        public PerkObject ScholarshipBookWorm => scholarshipBookWorm;
        public PerkObject ScholarshipPeerReview => scholarshipPeerReview;
        public PerkObject ScholarshipBedTimeStory => scholarshipBedtimeStory;
        public PerkObject ScholarshipPolyglot=> scholarshipPolyglot;
        public PerkObject ScholarshipMechanic => scholarshipMechanic;
        public PerkObject ScholarshipAccountant => scholarshipAccountant;
        public PerkObject ScholarshipNaturalScientist => scholarshipScientist;
        public PerkObject ScholarshipTreasurer => scholarshipTreasurer;
        public PerkObject ScholarshipMagnumOpus => scholarshipMagnumOpus;

        public override void Initialize()
        {
            scholarshipLiterate = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipLiterate"));
            scholarshipLiterate.InitializeNew("{=!}Literate", BKSkills.Instance.Scholarship, GetTierCost(1), null,
                "{=!}Allows reading books", SkillEffect.PerkRole.Personal, 0f,
                SkillEffect.EffectIncrementType.Invalid, string.Empty,
                SkillEffect.PerkRole.None, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipLearner = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipLearner"));
            scholarshipLearner.InitializeNew("{=!}Avid Learner", BKSkills.Instance.Scholarship, GetTierCost(2), null,
                "{=!}Increase language learning rate", 
                SkillEffect.PerkRole.Personal, 20f,
                SkillEffect.EffectIncrementType.AddFactor, 
                "{=!}Language limit is increased by 1",
                SkillEffect.PerkRole.Personal, 1f,
                SkillEffect.EffectIncrementType.Add,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipTutor = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipTutor"));
            scholarshipTutor.InitializeNew("{=!}Tutor", BKSkills.Instance.Scholarship, GetTierCost(3), null,
                "{=!}Additional attribute point to clan children coming of age.", 
                SkillEffect.PerkRole.ClanLeader, 1f,
                SkillEffect.EffectIncrementType.Add, 
                "{=!}Extra experience gain for companions and family members in party",
                SkillEffect.PerkRole.PartyLeader, 5f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipWellRead = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipWellRead"));
            scholarshipWellRead.InitializeNew("{=!}Well Read", BKSkills.Instance.Scholarship, GetTierCost(4), null,
                "{=!}Increased reading rates for books",
                SkillEffect.PerkRole.Personal, 12f,
                SkillEffect.EffectIncrementType.AddFactor,
                "{=!}Cultural fascination progresses faster",
                SkillEffect.PerkRole.Personal, 10f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);

            
            scholarshipMechanic = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipMechanic"));
            scholarshipAccountant = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipAccountant"));

            scholarshipMechanic.InitializeNew("{=!}Mechanic", BKSkills.Instance.Scholarship, GetTierCost(5), scholarshipAccountant,
                "{=!}Engineering skill tree yields both perks rather than 1",
                SkillEffect.PerkRole.Personal, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                string.Empty,
                SkillEffect.PerkRole.None, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                TroopClassFlag.None, TroopClassFlag.None);

            
            scholarshipAccountant.InitializeNew("{=!}Accountant", BKSkills.Instance.Scholarship, GetTierCost(5), scholarshipMechanic,
                "{=!}Stewardship skill tree yields both perks rather than 1",
                SkillEffect.PerkRole.Personal, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                string.Empty,
                SkillEffect.PerkRole.None, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipTeacher = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipTeacher"));
            scholarshipTeacher.InitializeNew("{=!}Teacher", BKSkills.Instance.Scholarship, GetTierCost(6), null,
                "{=!}Additional focus points to children coming of age",
                SkillEffect.PerkRole.ClanLeader, 2f,
                SkillEffect.EffectIncrementType.Add,
                "{=!}",
                SkillEffect.PerkRole.None, 10f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipBookWorm = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipBookWorm"));
            scholarshipBookWorm.InitializeNew("{=!}Book Worm", BKSkills.Instance.Scholarship, GetTierCost(7), null,
                "{=!}Increased reading rates for books",
                SkillEffect.PerkRole.Personal, 20f,
                SkillEffect.EffectIncrementType.Add,
                "{=!}Language limit is increased by 1",
                SkillEffect.PerkRole.Personal, 1f,
                SkillEffect.EffectIncrementType.Add,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipPeerReview = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipPeerReview"));
            scholarshipPeerReview.InitializeNew("{=!}Peer Review", BKSkills.Instance.Scholarship, GetTierCost(8), null,
                "{=!}Clan settlements yield more research points",
                SkillEffect.PerkRole.Personal, 20f,
                SkillEffect.EffectIncrementType.AddFactor,
                "{=!}Books yield double skill experience",
                SkillEffect.PerkRole.Personal, 100f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipBedtimeStory = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipBedTimeStory"));
            scholarshipBedtimeStory.InitializeNew("{=!}Bed Time Story", BKSkills.Instance.Scholarship, GetTierCost(9), null,
                "{=!}Daily experience points in random skill for companions and family in party",
                SkillEffect.PerkRole.PartyLeader, 10f,
                SkillEffect.EffectIncrementType.Add,
                "",
                SkillEffect.PerkRole.Personal, 100f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipTreasurer = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipTreasurer"));
            scholarshipScientist = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipNaturalScientist"));

            scholarshipTreasurer.InitializeNew("{=!}Treasurer", BKSkills.Instance.Scholarship, GetTierCost(10), scholarshipScientist,
                "{=!}Trade skill tree yields both perks rather than 1",
                SkillEffect.PerkRole.Personal, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                string.Empty,
                SkillEffect.PerkRole.None, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                TroopClassFlag.None, TroopClassFlag.None);
            
            scholarshipScientist.InitializeNew("{=!}Natural Scientist", BKSkills.Instance.Scholarship, GetTierCost(10), scholarshipTreasurer,
                "{=!}Medicine skill tree yields both perks rather than 1",
                SkillEffect.PerkRole.Personal, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                string.Empty,
                SkillEffect.PerkRole.None, 0f,
                SkillEffect.EffectIncrementType.Invalid,
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipPolyglot = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipPolyglot"));
            scholarshipPolyglot.InitializeNew("{=!}Polyglot", BKSkills.Instance.Scholarship, GetTierCost(11), null,
                "{=!}Language limit is increased by 2", SkillEffect.PerkRole.Personal, 10f, 
                SkillEffect.EffectIncrementType.AddFactor,
                "{=!}Language learning is significantly increased", 
                SkillEffect.PerkRole.None, 0f, 
                SkillEffect.EffectIncrementType.Invalid, 
                TroopClassFlag.None, TroopClassFlag.None);

            scholarshipMagnumOpus = Game.Current.ObjectManager.RegisterPresumedObject(new PerkObject("ScholarshipMagnumOpus"));
            scholarshipMagnumOpus.InitializeNew("{=!}Magnum Opus", BKSkills.Instance.Scholarship, GetTierCost(11), null,
                "{=!}+0.2% experience gain for every skill point in Scholarship above 230", 
                SkillEffect.PerkRole.Personal, 0.2f,
                SkillEffect.EffectIncrementType.AddFactor,
                "{=!}Focus points add 50% more learning limit",
                SkillEffect.PerkRole.Personal, 50f,
                SkillEffect.EffectIncrementType.AddFactor,
                TroopClassFlag.None, TroopClassFlag.None);
            
        }

        private int GetTierCost(int tierIndex) => Requirements[tierIndex - 1];

        private static readonly int[] Requirements = new int[]
        {
            25,
            50,
            75,
            100,
            125,
            150,
            175,
            200,
            225,
            250,
            275,
            300
        };

        public override IEnumerable<PerkObject> All => throw new System.NotImplementedException();
    }
}