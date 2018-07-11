﻿// <copyright file="Orbs.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.Initialization.Items
{
    using System.Linq;
    using MUnique.OpenMU.DataModel.Configuration;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.GameLogic.Attributes;

    /// <summary>
    /// Initializes orb items which are used to learn skills.
    /// </summary>
    public class Orbs : InitializerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Orbs"/> class.
        /// </summary>
        /// <param name="context">The persistence context.</param>
        /// <param name="gameConfiguration">The game configuration.</param>
        public Orbs(IContext context, GameConfiguration gameConfiguration)
            : base(context, gameConfiguration)
        {
        }

        /// <summary>
        /// Initializes all orbs.
        /// </summary>
        /// <remarks>
        /// Regex: (?m)^\s*(\d+)\s+(-*\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+\"(.+?)\"\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+)\s+(\d+).*$
        /// Replace by: this.CreateOrb($1, TODO, $5, "$9", $10, $13, $14, $15, $16, $17, $18, $19, $20, $21, $22, $23, $24, 0);
        /// </remarks>
        public override void Initialize()
        {
            this.CreateOrb(7, 41, 1, "Orb of Twisting Slash", 47, 80, 0, 0, 0, 0, 29000, 0, 1, 0, 1, 0, 0, 0);
            this.CreateOrb(8, 26, 1, "Orb of Healing", 8, 0, 100, 0, 0, 0, 800, 0, 0, 1, 0, 0, 0, 0);
            this.CreateOrb(9, 27, 1, "Orb of Greater Defense", 13, 0, 100, 0, 0, 0, 3000, 0, 0, 1, 0, 0, 0, 0);
            this.CreateOrb(10, 28, 1, "Orb of Greater Damage", 18, 0, 100, 0, 0, 0, 7000, 0, 0, 1, 0, 0, 0, 0);
            this.CreateOrb(11, 30, 1, "Orb of Summoning", 3, 0, 0, 0, 0, 0, 150, 0, 0, 1, 0, 0, 0, 0);
            this.CreateOrb(12, 42, 1, "Orb of Rageful Blow", 78, 170, 0, 0, 0, 0, 150000, 0, 2, 0, 0, 0, 0, 0);
            this.CreateOrb(13, 47, 1, "Orb of Impale", 20, 28, 0, 0, 0, 0, 10000, 0, 1, 0, 1, 0, 0, 0);
            this.CreateOrb(14, 48, 1, "Orb of Greater Fortitude", 60, 120, 0, 0, 0, 0, 43000, 0, 1, 0, 0, 0, 0, 0);
            this.CreateOrb(16, 55, 1, "Orb of Fire Slash", 60, 0, 0, 320, 0, 0, 51000, 0, 0, 0, 1, 0, 0, 0);
            this.CreateOrb(17, 52, 1, "Orb of Penetration", 64, 130, 0, 0, 0, 0, 72000, 0, 0, 1, 0, 0, 0, 0);
            this.CreateOrb(18, 51, 1, "Orb of Ice Arrow", 81, 0, 0, 0, 258, 0, 195000, 0, 0, 2, 0, 0, 0, 0);
            this.CreateOrb(19, 43, 1, "Orb of Death Stab", 72, 160, 0, 0, 0, 0, 85000, 0, 2, 0, 0, 0, 0, 0);
            this.CreateOrb(44, 232, 1, "Crystal of Destruction", 100, 220, 0, 0, 0, 0, 380000, 0, 2, 0, 0, 0, 0, 0);
            this.CreateOrb(45, 235, 1, "Crystal of Multi-Shot", 100, 220, 0, 0, 0, 0, 380000, 0, 0, 2, 0, 0, 0, 0);
            this.CreateOrb(46, 234, 1, "Crystal of Recovery", 100, 220, 37, 0, 0, 0, 250000, 0, 0, 2, 0, 0, 0, 0);
            this.CreateOrb(47, 236, 1, "Crystal of Flame Strike", 100, 220, 0, 0, 0, 0, 380000, 0, 0, 0, 1, 0, 0, 0);

            // The next ones are actually no "Orbs", but are defined in the same group
            this.CreateOrb(21, 61, 2, "Scroll of FireBurst", 74, 0, 20, 0, 0, 0, 115000, 0, 0, 0, 0, 1, 0, 0);
            this.CreateOrb(22, 63, 2, "Scroll of Summon", 98, 0, 34, 0, 0, 400, 375000, 0, 0, 0, 0, 1, 0, 0);
            this.CreateOrb(23, 64, 2, "Scroll of Critical Damage", 82, 0, 25, 0, 0, 300, 220000, 0, 0, 0, 0, 1, 0, 0);
            this.CreateOrb(24, 65, 2, "Scroll of Electric Spark", 92, 0, 29, 0, 0, 340, 295000, 0, 0, 0, 0, 1, 0, 0);
            this.CreateOrb(35, 78, 2, "Scroll of Fire Scream", 102, 0, 32, 0, 0, 70, 300000, 0, 0, 0, 0, 1, 0, 0);
            this.CreateOrb(48, 238, 2, "Scroll of Chaotic Diseier", 100, 220, 16, 0, 0, 0, 380000, 0, 0, 0, 0, 1, 0, 0);
        }

        private void CreateOrb(byte number, int skillNumber, byte height, string name, byte dropLevel, int levelRequirement, int energyRequirement, int strengthRequirement, int agilityRequirement, int leadershipRequirement, int money, int darkWizardClassLevel, int darkKnightClassLevel, int elfClassLevel, int magicGladiatorClassLevel, int darkLordClassLevel, int summonerClassLevel, int ragefighterClassLevel)
        {
            var orb = this.Context.CreateNew<ItemDefinition>();
            this.GameConfiguration.Items.Add(orb);
            orb.Group = 12;
            orb.Number = number;
            orb.Skill = this.GameConfiguration.Skills.First(skill => skill.SkillID == skillNumber);
            orb.Width = 1;
            orb.Height = height;
            orb.Name = name;
            orb.DropLevel = dropLevel;
            orb.DropsFromMonsters = true;
            orb.Durability = 1;
            orb.ConsumeHandlerClass = typeof(OpenMU.GameLogic.PlayerActions.ItemConsumeActions.LearnablesConsumeHandler).FullName;

            if (levelRequirement > 0)
            {
                var requirement = this.Context.CreateNew<AttributeRequirement>();
                requirement.Attribute = Stats.Level.GetPersistent(this.GameConfiguration);
                requirement.MinimumValue = levelRequirement;
                orb.Requirements.Add(requirement);
            }

            if (energyRequirement > 0)
            {
                var requirement = this.Context.CreateNew<AttributeRequirement>();
                requirement.Attribute = Stats.TotalEnergy.GetPersistent(this.GameConfiguration);
                requirement.MinimumValue = energyRequirement;
                orb.Requirements.Add(requirement);
            }

            if (strengthRequirement > 0)
            {
                var requirement = this.Context.CreateNew<AttributeRequirement>();
                requirement.Attribute = Stats.TotalStrength.GetPersistent(this.GameConfiguration);
                requirement.MinimumValue = strengthRequirement;
                orb.Requirements.Add(requirement);
            }

            if (agilityRequirement > 0)
            {
                var requirement = this.Context.CreateNew<AttributeRequirement>();
                requirement.Attribute = Stats.TotalAgility.GetPersistent(this.GameConfiguration);
                requirement.MinimumValue = agilityRequirement;
                orb.Requirements.Add(requirement);
            }

            if (leadershipRequirement > 0)
            {
                var requirement = this.Context.CreateNew<AttributeRequirement>();
                requirement.Attribute = Stats.TotalLeadership.GetPersistent(this.GameConfiguration);
                requirement.MinimumValue = leadershipRequirement;
                orb.Requirements.Add(requirement);
            }

            orb.Value = money;
            var classes = this.GameConfiguration.DetermineCharacterClasses(darkWizardClassLevel, darkKnightClassLevel, elfClassLevel, magicGladiatorClassLevel, darkLordClassLevel, summonerClassLevel, ragefighterClassLevel);
            foreach (var characterClass in classes)
            {
                orb.QualifiedCharacters.Add(characterClass);
            }
        }
    }
}
