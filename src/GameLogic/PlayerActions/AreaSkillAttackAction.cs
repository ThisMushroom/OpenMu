﻿// <copyright file="AreaSkillAttackAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions
{
    using System.Linq;
    using log4net;
    using MUnique.OpenMU.DataModel.Configuration;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Action to attack with a skill which inflicts damage to an area of the current map of the player.
    /// </summary>
    public class AreaSkillAttackAction
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(AreaSkillAttackAction));
        private readonly IGameContext gameContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="AreaSkillAttackAction"/> class.
        /// </summary>
        /// <param name="gameContext">The game context.</param>
        public AreaSkillAttackAction(IGameContext gameContext)
        {
            this.gameContext = gameContext;
        }

        /// <summary>
        /// Performs the skill by the player at the specified area. Additionally to the target area, a target object can be specified.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="extraTargetId">The extra target identifier.</param>
        /// <param name="skillId">The skill identifier.</param>
        /// <param name="targetAreaCenterX">The x coordinate of the center of the target area.</param>
        /// <param name="targetAreaCenterY">The y coordinate of the center of the target area.</param>
        /// <param name="rotation">The rotation in which the player is looking. It's not really relevant for the hitted objects yet, but for some directed skills in the future it might be.</param>
        public void Attack(Player player, ushort extraTargetId, ushort skillId, byte targetAreaCenterX, byte targetAreaCenterY, byte rotation)
        {
            SkillEntry skillEntry = player.SkillList.GetSkill(skillId);
            var skill = skillEntry.Skill;
            if (skill.SkillType == SkillType.PassiveBoost)
            {
                Logger.WarnFormat("AreaSkill is a passive boost");
                return;
            }

            if (!player.TryConsumeForSkill(skill))
            {
                Logger.WarnFormat("AreaSkill not enough resources");
                return;
            }

            if (skill.SkillType == SkillType.AreaSkillAutomaticHits)
            {
                Logger.WarnFormat("AreaSkill perform automatic hits");
                this.PerformAutomaticHits(player, extraTargetId, targetAreaCenterX, targetAreaCenterY, skillEntry, skill);
            }

            player.ForEachObservingPlayer(p => p.PlayerView.WorldView.ShowAreaSkillAnimation(player, skill, targetAreaCenterX, targetAreaCenterY, rotation), true);
        }

        private void PerformAutomaticHits(Player player, ushort extraTargetId, byte targetAreaCenterX, byte targetAreaCenterY, SkillEntry skillEntry, Skill skill)
        {
            bool extraTarget = extraTargetId == 0xFFFF;
            var attackablesInRange = player.CurrentMap.GetAttackablesInRange(targetAreaCenterX, targetAreaCenterY, skill.Range);
            if (!this.gameContext.Configuration.AreaSkillHitsPlayer)
            {
                attackablesInRange = attackablesInRange.Where(a => !(a is Player));
                extraTarget = false;
            }

            foreach (var target in attackablesInRange)
            {
                Logger.WarnFormat("AreaSkill attack target [{0}] by skill [{1}]", target.Id, skillEntry.Skill.Name);
                target.AttackBy(player, skillEntry);
            }

            if (extraTarget)
            {
                if (player.CurrentMap.GetObject(extraTargetId) is IAttackable otherObject)
                {
                    otherObject.AttackBy(player, skillEntry);
                }
            }
        }
    }
}