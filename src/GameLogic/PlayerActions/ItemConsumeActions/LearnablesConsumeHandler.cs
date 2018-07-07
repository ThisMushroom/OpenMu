// <copyright file="LearnablesConsumeHandler.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.ItemConsumeActions
{
    using log4net;
    using MUnique.OpenMU.DataModel.Entities;

    /// <summary>
    /// Consume handler for items (e.g. scrolls, orbs) which add a skill when being consumed.
    /// </summary>
    public class LearnablesConsumeHandler : IItemConsumeHandler
    {
        private static ILog log = LogManager.GetLogger(typeof(LearnablesConsumeHandler));

        /// <summary>
        /// Initializes a new instance of the <see cref="LearnablesConsumeHandler"/> class.
        /// </summary>
        public LearnablesConsumeHandler()
        {
        }

        /// <inheritdoc/>
        public bool ConsumeItem(Player player, byte itemSlot, byte targetSlot)
        {
            if (player.PlayerState.CurrentState != PlayerState.EnteredWorld)
            {
                return false;
            }

            Item item = player.Inventory.GetItem(itemSlot);
            if (item == null)
            {
                return false;
            }

            var learnable = item.Definition;

            // Check Requirements
            if (!player.CompliesRequirements(learnable))
            {
                log.WarnFormat("Failed to use learnable by [{0}] because !CompliesRequirements", player.Name);

                // TODO:Send unsuccessful packet
                return false;
            }

            if (player.SkillList.ContainsSkill(learnable.Skill.SkillID.ToUnsigned()))
            {
                log.WarnFormat("Failed to use learnable by [{0}] because already has this skill", player.Name);
                return false;
            }

            if (learnable != null && learnable.Skill != null)
            {
                log.WarnFormat("Using learnable by [{0}]", player.Name);
                var skillIndex = player.SkillList.SkillCount;
                player.SkillList.AddLearnedSkill(learnable.Skill);
                player.PlayerView.AddSkill(learnable.Skill, skillIndex);
                player.Inventory.RemoveItem(item);
                return true;
            }

            return false;
        }
    }
}
