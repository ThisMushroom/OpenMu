﻿// <copyright file="LearnablesConsumeHandler.cs" company="MUnique">
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
        /// <inheritdoc/>
        public bool ConsumeItem(Player player, byte itemSlot, byte targetSlot)
        {
            if (player.PlayerState.CurrentState != PlayerState.EnteredWorld)
            {
                return false;
            }

            Item item = player.Inventory.GetItem(itemSlot);
            if (item == null || item.Durability == 0)
            {
                return false;
            }

            var learnable = item.Definition;

            // Check Requirements
            if (!player.CompliesRequirements(learnable))
            {
                return false;
            }

            if (learnable.Skill == null || player.SkillList.ContainsSkill(learnable.Skill.SkillID.ToUnsigned()))
            {
                log.WarnFormat("Failed to use learnable by [{0}] because already has this skill", player.Name);
                return false;
            }

            player.SkillList.AddLearnedSkill(learnable.Skill);
            item.Durability--;
            player.Inventory.RemoveItem(item);
            player.PersistenceContext.Delete(item);
            return true;
        }
    }
}
