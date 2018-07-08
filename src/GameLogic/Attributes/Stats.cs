﻿// <copyright file="Stats.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.Attributes
{
    using System;
    using System.Collections.Generic;
    using MUnique.OpenMU.AttributeSystem;

    /// <summary>
    /// A collection of standard attributes.
    /// </summary>
    public class Stats
    {
        /// <summary>
        /// Gets the base strength attribute definition.
        /// </summary>
        public static AttributeDefinition BaseStrength { get; } = new AttributeDefinition(new Guid("123282FE-FEAD-448E-AD2C-BAECE939B4B1"), "Base Strength", "The base strength of the character.");

        /// <summary>
        /// Gets the total strength attribute definition.
        /// </summary>
        public static AttributeDefinition TotalStrength { get; } = new AttributeDefinition(new Guid("F59709A3-44B0-4147-AAEB-E90CEC251641"), "Total Strength", "The total strength of the character, which contains the base strength and additional strength powerups");

        /// <summary>
        /// Gets the base agility attribute definition.
        /// </summary>
        public static AttributeDefinition BaseAgility { get; } = new AttributeDefinition(new Guid("1AE9C014-E3CD-4703-BD05-1B65F5F94CEB"), "baseAgility", string.Empty);

        /// <summary>
        /// Gets the total agility attribute definition.
        /// </summary>
        public static AttributeDefinition TotalAgility { get; } = new AttributeDefinition(new Guid("364F1207-00F8-485B-9F2C-74E04CB78C73"), "totalAgility", string.Empty);

        /// <summary>
        /// Gets the base vitality attribute definition.
        /// </summary>
        public static AttributeDefinition BaseVitality { get; } = new AttributeDefinition(new Guid("6CA5C3A6-B109-45A5-87A7-FDCB107B4982"), "baseVitality", string.Empty);

        /// <summary>
        /// Gets the total vitality attribute definition.
        /// </summary>
        public static AttributeDefinition TotalVitality { get; } = new AttributeDefinition(new Guid("6A0076E4-69DC-42E7-A92B-C8711392EF82"), "totalVitality", string.Empty);

        /// <summary>
        /// Gets the base energy attribute definition.
        /// </summary>
        public static AttributeDefinition BaseEnergy { get; } = new AttributeDefinition(new Guid("01B0EF28-F7A0-46B5-97BA-2B624A54CD75"), "baseEnergy", string.Empty);

        /// <summary>
        /// Gets the total energy attribute definition.
        /// </summary>
        public static AttributeDefinition TotalEnergy { get; } = new AttributeDefinition(new Guid("12956B45-007C-453A-AE1F-36475B8CEBBF"), "totalEnergy", string.Empty);

        /// <summary>
        /// Gets the base leadership attribute definition.
        /// </summary>
        public static AttributeDefinition BaseLeadership { get; } = new AttributeDefinition(new Guid("6AF2C9DF-3AE4-4721-8462-9A8EC7F56FE4"), "baseLeadership", string.Empty);

        /// <summary>
        /// Gets the total leadership attribute definition.
        /// </summary>
        public static AttributeDefinition TotalLeadership { get; } = new AttributeDefinition(new Guid("35E04272-63F3-4EBB-8FB5-EF2128DDB9F6"), "totalLeadership", string.Empty);

        /// <summary>
        /// Gets the level attribute definition.
        /// </summary>
        public static AttributeDefinition Level { get; } = new AttributeDefinition(new Guid("560931AD-0901-4342-B7F4-FD2E2FCC0563"), "Level", "The level of the character.");

        /// <summary>
        /// Gets the experience rate attribute definition.
        /// </summary>
        public static AttributeDefinition ExperienceRate { get; } = new AttributeDefinition(new Guid("1AD454D4-BEF9-416E-BC49-82A5B0277FC7"), "experienceRate", string.Empty);

        /// <summary>
        /// Gets the master level definition.
        /// </summary>
        public static AttributeDefinition MasterLevel { get; } = new AttributeDefinition(new Guid("70CD8C10-391A-4C51-9AA4-A854600E3A9F"), "Master Level", "The level of the character.");

        /// <summary>
        /// Gets the master experience rate definition.
        /// </summary>
        public static AttributeDefinition MasterExperienceRate { get; } = new AttributeDefinition(new Guid("E367A231-C8A4-4F92-B553-C665F98DB1FC"), "Master experience rate", string.Empty);

        /// <summary>
        /// Gets the zen amount rate attribute definition.
        /// </summary>
        public static AttributeDefinition MoneyAmountRate { get; } = new AttributeDefinition(new Guid("D84D1A5C-3A56-4CB9-8DD4-158AFD4D1EDB"), "zenAmountRate", string.Empty);

        /// <summary>
        /// Gets the item drop rate attribute definition.
        /// </summary>
        public static AttributeDefinition ItemDropRate { get; } = new AttributeDefinition(new Guid("2EC8394B-E258-4237-86C5-AD6E2DB844AF"), "itemDropRate", string.Empty);

        /// <summary>
        /// Gets the current health attribute definition.
        /// </summary>
        public static AttributeDefinition CurrentHealth { get; } = new AttributeDefinition(new Guid("20686FFD-7A96-4BE2-9889-2A4DD9FF5A25"), "currentHealth", string.Empty);

        /// <summary>
        /// Gets the maximum health attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumHealth { get; } = new AttributeDefinition(new Guid("A6C39A5C-295F-415E-A314-5E9F9A748D27"), "maximumHealth", string.Empty);

        /// <summary>
        /// Gets the current mana attribute definition.
        /// </summary>
        public static AttributeDefinition CurrentMana { get; } = new AttributeDefinition(new Guid("B3299EE6-3815-4E48-B620-95DB78F8A142"), "currentMana", string.Empty);

        /// <summary>
        /// Gets the maximum mana attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumMana { get; } = new AttributeDefinition(new Guid("17CB8826-0677-4C93-A0C9-C0E3D2DA7D73"), "maximumMana", string.Empty);

        /// <summary>
        /// Gets the current shield attribute definition.
        /// </summary>
        public static AttributeDefinition CurrentShield { get; } = new AttributeDefinition(new Guid("0E255161-8A3D-4367-BFF0-EFCD238C16FD"), "currentShield", string.Empty);

        /// <summary>
        /// Gets the maximum shield attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumShield { get; } = new AttributeDefinition(new Guid("BC745471-6EC6-48BC-8C7A-C8AACA3A92D9"), "maximumShield", string.Empty);

        /// <summary>
        /// Gets the maximum shield intermediate attribute definition, which should contain the Level ^ 2.
        /// </summary>
        public static AttributeDefinition MaximumShieldTemp { get; } = new AttributeDefinition(new Guid("91321D76-F60E-41E1-948F-5B05D788C2BB"), "Maximum shield level pow intermediate", "Intermediate value for maximum shield");

        /// <summary>
        /// Gets the current ability attribute definition.
        /// </summary>
        public static AttributeDefinition CurrentAbility { get; } = new AttributeDefinition(new Guid("39EB6747-0689-4BBF-B832-8936E00C5DF6"), "currentAbility", string.Empty);

        /// <summary>
        /// Gets the maximum ability attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumAbility { get; } = new AttributeDefinition(new Guid("466BBBBA-C1D8-45DC-8832-2EAA1130ACFD"), "maximumAbility", string.Empty);

        /// <summary>
        /// Gets the attack rate PVM attribute definition.
        /// </summary>
        public static AttributeDefinition AttackRatePvm { get; } = new AttributeDefinition(new Guid("1129442A-E1C7-4240-8866-B781C2838C25"), "attackRatePvm", string.Empty);

        /// <summary>
        /// Gets the attack rate PVP attribute definition.
        /// </summary>
        public static AttributeDefinition AttackRatePvp { get; } = new AttributeDefinition(new Guid("C39C1C4B-0F58-49FC-9C71-8A58D570C5D2"), "attackRatePvp", string.Empty);

        /// <summary>
        /// Gets the minimum physical base DMG by weapon attribute definition.
        /// </summary>
        public static AttributeDefinition MinimumPhysBaseDmgByWeapon { get; } = new AttributeDefinition(new Guid("1AC59D93-6A52-4E88-8201-5F125A63B2A1"), "Minimum Physical Base Damage By Weapon", string.Empty);

        /// <summary>
        /// Gets the maximum physical base DMG by weapon attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumPhysBaseDmgByWeapon { get; } = new AttributeDefinition(new Guid("EC0D70BE-839C-4BAD-9FC5-1AD7438C75F8"), "Maximum Physical Base Damage By Weapon", string.Empty);

        /// <summary>
        /// Gets the minimum physical base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MinimumPhysBaseDmg { get; } = new AttributeDefinition(new Guid("3E8D6A02-E973-4AE4-9DF3-CDDC3D3183B3"), "Minimum Physical Base Damage", string.Empty);

        /// <summary>
        /// Gets the maximum physical base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumPhysBaseDmg { get; } = new AttributeDefinition(new Guid("8A918EA2-893A-48B2-A684-3E71526CA71F"), "Maximum Physical Base Damage", string.Empty);

        /// <summary>
        /// Gets the minimum wiz base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MinimumWizBaseDmg { get; } = new AttributeDefinition(new Guid("65583A02-AB94-4A17-9B79-86ECC82DC835"), "minimumWizBaseDmg", string.Empty);

        /// <summary>
        /// Gets the maximum wiz base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumWizBaseDmg { get; } = new AttributeDefinition(new Guid("44B8236A-BF5B-4082-BA8B-5DEDA1458D33"), "maximumWizBaseDmg", string.Empty);

        /// <summary>
        /// Gets the minimum curse base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MinimumCurseBaseDmg { get; } = new AttributeDefinition(new Guid("B8AE2D6B-05CE-43A9-B2BB-3C32F288A043"), "minimumCurseBaseDmg", string.Empty);

        /// <summary>
        /// Gets the maximum curse base DMG attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumCurseBaseDmg { get; } = new AttributeDefinition(new Guid("5E7B5B56-BB4D-4645-9593-836FE86E80EA"), "maximumCurseBaseDmg", string.Empty);

        /// <summary>
        /// Gets the skill multiplier attribute definition.
        /// </summary>
        public static AttributeDefinition SkillMultiplier { get; } = new AttributeDefinition(new Guid("D9FB3323-6DF5-48F7-8253-FDBB5EF82114"), "skillMultiplier", string.Empty);

        /// <summary>
        /// Gets the attack speed attribute definition.
        /// </summary>
        public static AttributeDefinition AttackSpeed { get; } = new AttributeDefinition(new Guid("BACC1115-1E8B-4E62-B952-8F8DDB58A949"), "attackSpeed", string.Empty);

        /// <summary>
        /// Gets the attack damage increase attribute definition.
        /// </summary>
        public static AttributeDefinition AttackDamageIncrease { get; } = new AttributeDefinition(new Guid("0765CCD2-C70A-4338-BF49-0D652364C223"), "attackDamageIncrease", string.Empty);

        /// <summary>
        /// Gets the combo bonus attribute definition.
        /// </summary>
        public static AttributeDefinition ComboBonus { get; } = new AttributeDefinition(new Guid("53A479FE-8A73-4A45-AACA-5B1AA4362CF9"), "comboBonus", string.Empty);

        /// <summary>
        /// Gets the final damage increase PVP attribute definition.
        /// </summary>
        public static AttributeDefinition FinalDamageIncreasePvp { get; } = new AttributeDefinition(new Guid("20BE9BFA-A2DC-4868-8ABF-B6DE4B51D4D2"), "finalDamageIncreasePvp", string.Empty);

        /// <summary>
        /// Gets the defense base attribute definition.
        /// </summary>
        public static AttributeDefinition DefenseBase { get; } = new AttributeDefinition(new Guid("EB098C46-60D4-4CA6-BBD4-5B6270A1407B"), "defenseBase", string.Empty);

        /// <summary>
        /// Gets the defense PVM attribute definition.
        /// </summary>
        public static AttributeDefinition DefensePvm { get; } = new AttributeDefinition(new Guid("B4201610-2824-4EC1-A145-76B15DB9DEC6"), "defensePvm", string.Empty);

        /// <summary>
        /// Gets the defense PVP attribute definition.
        /// </summary>
        public static AttributeDefinition DefensePvp { get; } = new AttributeDefinition(new Guid("28D14EB7-1049-45BE-A7B7-D5E28E63943B"), "defensePvp", string.Empty);

        /// <summary>
        /// Gets the defense rate PVM attribute definition.
        /// </summary>
        public static AttributeDefinition DefenseRatePvm { get; } = new AttributeDefinition(new Guid("C520DD2D-1B06-4392-95EE-3C41F33E68DA"), "defenseRatePvm", string.Empty);

        /// <summary>
        /// Gets the defense rate PVP attribute definition.
        /// </summary>
        public static AttributeDefinition DefenseRatePvp { get; } = new AttributeDefinition(new Guid("B995C627-C17B-4D24-9FA5-3830AACC6912"), "defenseRatePvp", string.Empty);

        /// <summary>
        /// Gets the damage receive decrement attribute definition.
        /// </summary>
        public static AttributeDefinition DamageReceiveDecrement { get; } = new AttributeDefinition(new Guid("9D9761EF-EF47-4E5C-8106-EBC555786F20"), "damageReceiveDecrement", string.Empty);

        /// <summary>
        /// Gets the shield block damage decrement attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldBlockDamageDecrement { get; } = new AttributeDefinition(new Guid("DAC6690B-5922-4446-BCE5-5E701BE62EC1"), "shieldBlockDamageDecrement", string.Empty);

        /// <summary>
        /// Gets the ice resistance attribute definition.
        /// </summary>
        public static AttributeDefinition IceResistance { get; } = new AttributeDefinition(new Guid("47235C36-41BB-44B4-8823-6FC415709F59"), "iceResistance", string.Empty);

        /// <summary>
        /// Gets the fire resistance attribute definition.
        /// </summary>
        public static AttributeDefinition FireResistance { get; } = new AttributeDefinition(new Guid("9AE4D80D-5706-48B9-AD11-EAC4FE088A81"), "fireResistance", string.Empty);

        /// <summary>
        /// Gets the water resistance attribute definition.
        /// </summary>
        public static AttributeDefinition WaterResistance { get; } = new AttributeDefinition(new Guid("3AF88672-D8DB-44E1-937A-7E6484134C39"), "waterResistance", string.Empty);

        /// <summary>
        /// Gets the earth resistance attribute definition.
        /// </summary>
        public static AttributeDefinition EarthResistance { get; } = new AttributeDefinition(new Guid("4470890F-00CE-44A6-BADB-203684B6014D"), "earthResistance", string.Empty);

        /// <summary>
        /// Gets the wind resistance attribute definition.
        /// </summary>
        public static AttributeDefinition WindResistance { get; } = new AttributeDefinition(new Guid("03A29C46-7B7E-424D-8325-8390692570C3"), "windResistance", string.Empty);

        /// <summary>
        /// Gets the poison resistance attribute definition.
        /// </summary>
        public static AttributeDefinition PoisonResistance { get; } = new AttributeDefinition(new Guid("3D50D0B7-63A2-4DA9-8855-12173EAE6B39"), "poisonResistance", string.Empty);

        /// <summary>
        /// Gets the lightning resistance attribute definition.
        /// </summary>
        public static AttributeDefinition LightningResistance { get; } = new AttributeDefinition(new Guid("3E339393-2D17-452E-81D9-3987947A407F"), "lightningResistance", string.Empty);

        /// <summary>
        /// Gets the damage reflection attribute definition.
        /// </summary>
        public static AttributeDefinition DamageReflection { get; } = new AttributeDefinition(new Guid("1535A2FB-6094-48B8-8578-086BA166A0F7"), "damageReflection", string.Empty);

        /// <summary>
        /// Gets the mana recovery attribute definition.
        /// </summary>
        public static AttributeDefinition ManaRecovery { get; } = new AttributeDefinition(new Guid("E4EC7913-5004-48FC-ACB1-E1764237A251"), "manaRecovery", string.Empty);

        /// <summary>
        /// Gets the health recovery attribute definition.
        /// </summary>
        public static AttributeDefinition HealthRecovery { get; } = new AttributeDefinition(new Guid("0A427A13-3708-4125-BA83-A2DF7C0753B8"), "healthRecovery", string.Empty);

        /// <summary>
        /// Gets the ability recovery attribute definition.
        /// </summary>
        public static AttributeDefinition AbilityRecovery { get; } = new AttributeDefinition(new Guid("A3E274F5-FA74-4E6A-97EA-D0930AAF0374"), "abilityRecovery", string.Empty);

        /// <summary>
        /// Gets the shield recovery attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldRecovery { get; } = new AttributeDefinition(new Guid("6B99AA99-C1A3-413B-8C70-602567EB5163"), "shieldRecovery", string.Empty);

        /// <summary>
        /// Gets the critical damage chance attribute definition.
        /// </summary>
        public static AttributeDefinition CriticalDamageChance { get; } = new AttributeDefinition(new Guid("ADE8092E-870F-4968-B707-8BFD6CBF8FFC"), "criticalDamageChance", string.Empty);

        /// <summary>
        /// Gets the excellent damage chance attribute definition.
        /// </summary>
        public static AttributeDefinition ExcellentDamageChance { get; } = new AttributeDefinition(new Guid("577AE8D4-D9E5-4A1F-9A69-45D1A2519EEE"), "excellentDamageChance", string.Empty);

        /// <summary>
        /// Gets the defense ignore chance attribute definition.
        /// </summary>
        public static AttributeDefinition DefenseIgnoreChance { get; } = new AttributeDefinition(new Guid("56BDC72E-9D37-4EDA-8AC8-9E12473966FC"), "defenseIgnoreChance", string.Empty);

        /// <summary>
        /// Gets the shield bypass chance attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldBypassChance { get; } = new AttributeDefinition(new Guid("7F6F1804-271E-40DF-A970-0CE19064A54B"), "shieldBypassChance", string.Empty);

        /// <summary>
        /// Gets the double damage chance attribute definition.
        /// </summary>
        public static AttributeDefinition DoubleDamageChance { get; } = new AttributeDefinition(new Guid("2B8A03E6-1CC2-48A0-8633-3F36E17050F4"), "doubleDamageChance", string.Empty);

        /// <summary>
        /// Gets the mana after monster kill attribute definition.
        /// </summary>
        public static AttributeDefinition ManaAfterMonsterKill { get; } = new AttributeDefinition(new Guid("3DE9DEE5-C717-456B-8E94-6C224553674F"), "manaAfterMonsterKill", string.Empty);

        /// <summary>
        /// Gets the health after monster kill attribute definition.
        /// </summary>
        public static AttributeDefinition HealthAfterMonsterKill { get; } = new AttributeDefinition(new Guid("0498AA9E-A4BB-4DE5-B112-58D921101899"), "healthAfterMonsterKill", string.Empty);

        /// <summary>
        /// Gets the shield after monster kill attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldAfterMonsterKill { get; } = new AttributeDefinition(new Guid("783F0178-C23C-4F20-BE10-B73D3D31D4F6"), "shieldAfterMonsterKill", string.Empty);

        /// <summary>
        /// Gets the ability after monster kill attribute definition.
        /// </summary>
        public static AttributeDefinition AbilityAfterMonsterKill { get; } = new AttributeDefinition(new Guid("47433CD1-C7D5-4BF5-AC52-E0F33BF90504"), "abilityAfterMonsterKill", string.Empty);

        /// <summary>
        /// Gets the shield decrease rate increase attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldDecreaseRateIncrease { get; } = new AttributeDefinition(new Guid("A0F376C9-C9C6-4E0D-83D6-24EC005E282E"), "SD decrease rate increase", "The damage absorbed by the opponents' shield in PVP directly translates into HP damange according to set value.");

        /// <summary>
        /// Gets the shield rate increase attribute definition.
        /// </summary>
        public static AttributeDefinition ShieldRateIncrease { get; } = new AttributeDefinition(new Guid("C2FFBA46-4DC3-4861-84F5-313DED038997"), "SD rate increase", "Increases the shield’s damage absorb rate in PVP according to set value.");

        /// <summary>
        /// Gets the item duration increase attribute definition.
        /// </summary>
        public static AttributeDefinition ItemDurationIncrease { get; } = new AttributeDefinition(new Guid("03EBE702-90FF-473C-8CBB-E83669FE3C68"), "itemDurationIncrease", string.Empty);

        /// <summary>
        /// Gets the pet duration increase attribute definition.
        /// </summary>
        public static AttributeDefinition PetDurationIncrease { get; } = new AttributeDefinition(new Guid("B4455150-D3A9-4A5F-914B-F41F9387FE9A"), "petDurationIncrease", string.Empty);

        /// <summary>
        /// Gets the maximum guild size attribute definition.
        /// </summary>
        public static AttributeDefinition MaximumGuildSize { get; } = new AttributeDefinition(new Guid("898EF69B-3965-4DBF-9783-E9709698236B"), "Maximum Guild Size", string.Empty);

        /// <summary>
        /// Gets the attributes which are regenerated in an interval.
        /// </summary>
        public static IEnumerable<Regeneration> IntervalRegenerationAttributes
        {
            get
            {
                yield return ManaRegeneration;
                yield return HealthRegeneration;
                yield return AbilityRegeneration;
                yield return ShieldRegeneration;
            }
        }

        /// <summary>
        /// Gets the attributes which regenerate after a monster has been killed by the player.
        /// </summary>
        public static IEnumerable<AttributeDefinition> AfterMonsterKillRegenerationAttributes
        {
            get
            {
                yield return ManaAfterMonsterKill;
                yield return HealthAfterMonsterKill;
                yield return ShieldAfterMonsterKill;
                yield return AbilityAfterMonsterKill;
            }
        }

        private static Regeneration ManaRegeneration { get; } = new Regeneration(ManaRecovery, MaximumMana, CurrentMana);

        private static Regeneration HealthRegeneration { get; } = new Regeneration(HealthRecovery, MaximumHealth, CurrentHealth);

        private static Regeneration AbilityRegeneration { get; } = new Regeneration(AbilityRecovery, MaximumAbility, CurrentAbility);

        private static Regeneration ShieldRegeneration { get; } = new Regeneration(ShieldRecovery, MaximumShield, CurrentShield);

        /// <summary>
        /// A regeneration definition.
        /// At regeneration the value of <see cref="RegenerationMultiplier"/> * <see cref="MaximumAttribute"/> is getting added to
        /// <see cref="CurrentAttribute"/>, until the value of <see cref="MaximumAttribute"/> is reached.
        /// </summary>
        public class Regeneration
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="Regeneration"/> class.
            /// At regeneration the value of <paramref name="regenerationMultiplier"/> * <paramref name="maximumAttribute"/> is getting added to
            /// <paramref name="currentAttribute"/>, until the value of <paramref name="maximumAttribute"/> is reached.
            /// </summary>
            /// <param name="regenerationMultiplier">The regeneration multiplier.</param>
            /// <param name="maximumAttribute">The maximum attribute.</param>
            /// <param name="currentAttribute">The current attribute.</param>
            public Regeneration(AttributeDefinition regenerationMultiplier, AttributeDefinition maximumAttribute, AttributeDefinition currentAttribute)
            {
                this.RegenerationMultiplier = regenerationMultiplier;
                this.MaximumAttribute = maximumAttribute;
                this.CurrentAttribute = currentAttribute;
            }

            /// <summary>
            /// Gets or sets the regeneration multiplier.
            /// </summary>
            public AttributeDefinition RegenerationMultiplier { get; set; }

            /// <summary>
            /// Gets or sets the maximum attribute.
            /// </summary>
            public AttributeDefinition MaximumAttribute { get; set; }

            /// <summary>
            /// Gets or sets the current attribute.
            /// </summary>
            public AttributeDefinition CurrentAttribute { get; set; }
        }
    }
}
