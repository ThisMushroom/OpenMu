﻿// <copyright file="DataInitialization.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.Initialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using MUnique.OpenMU.AttributeSystem;
    using MUnique.OpenMU.DataModel.Attributes;
    using MUnique.OpenMU.DataModel.Configuration;
    using MUnique.OpenMU.DataModel.Configuration.Items;
    using MUnique.OpenMU.DataModel.Entities;
    using MUnique.OpenMU.GameLogic;
    using MUnique.OpenMU.GameLogic.Attributes;
    using MUnique.OpenMU.GameServer;
    using MUnique.OpenMU.GameServer.MessageHandler;
    using MUnique.OpenMU.GameServer.MessageHandler.Friends;
    using MUnique.OpenMU.GameServer.MessageHandler.Guild;
    using MUnique.OpenMU.GameServer.MessageHandler.Items;
    using MUnique.OpenMU.GameServer.MessageHandler.Party;
    using MUnique.OpenMU.GameServer.MessageHandler.Trade;
    using MUnique.OpenMU.Persistence.Initialization.Items;
    using MUnique.OpenMU.Persistence.Initialization.Maps;

    /// <summary>
    /// Class to manage data initialization.
    /// </summary>
    public class DataInitialization
    {
        private readonly IPersistenceContextProvider persistenceContextProvider;
        private GameConfiguration gameConfiguration;
        private IContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataInitialization"/> class.
        /// </summary>
        /// <param name="persistenceContextProvider">The persistence context provider.</param>
        public DataInitialization(IPersistenceContextProvider persistenceContextProvider)
        {
            this.persistenceContextProvider = persistenceContextProvider;
        }

        /// <summary>
        /// Creates the initial data for a server.
        /// </summary>
        public void CreateInitialData()
        {
            using (var temporaryContext = this.persistenceContextProvider.CreateNewContext())
            {
                this.gameConfiguration = temporaryContext.CreateNew<GameConfiguration>();
            }

            using (this.context = this.persistenceContextProvider.CreateNewContext(this.gameConfiguration))
            {
                this.InitializeGameConfiguration();
                var gameServerConfiguration = this.CreateGameServerConfiguration(this.gameConfiguration.Maps);
                this.CreateGameServerDefinitions(gameServerConfiguration, 3);
                this.context.SaveChanges();

                var lorencia = this.gameConfiguration.Maps.First(map => map.Number == 0);
                foreach (var map in this.gameConfiguration.Maps)
                {
                    // set safezone to lorencia for now...
                    map.SafezoneMap = lorencia;
                }

                this.CreateTestAccounts(10);

                this.context.SaveChanges();
            }
        }

        private void CreateTestAccounts(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.CreateTestAccount(i);
            }
        }

        private long CalcNeededMasterExp(long lvl)
        {
            // f(x) = 505 * x^3 + 35278500 * x + 228045 * x^2
            return (505 * lvl * lvl * lvl) + (35278500 * lvl) + (228045 * lvl * lvl);
        }

        private long CalculateNeededExperience(long level)
        {
            if (level == 0)
            {
                return 0;
            }

            if (level < 256)
            {
                return 10 * (level + 8) * (level - 1) * (level - 1);
            }

            return (10 * (level + 8) * (level - 1) * (level - 1)) + (1000 * (level - 247) * (level - 256) * (level - 256));
        }

        private void CreateTestAccount(int index)
        {
            var loginName = "test" + index.ToString();

            var account = this.context.CreateNew<Account>();
            account.LoginName = loginName;
            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(loginName);
            account.Vault = this.context.CreateNew<ItemStorage>();

            var character = this.context.CreateNew<Character>();
            account.Characters.Add(character);
            character.CharacterClass = this.gameConfiguration.CharacterClasses.First(c => c.Number == (byte)CharacterClassNumber.DarkWizard);
            character.Name = loginName;
            character.CharacterSlot = 0;
            character.CreateDate = DateTime.Now;
            character.KeyConfiguration = new byte[30];
            foreach (
                var attribute in
                character.CharacterClass.StatAttributes.Select(
                    a => this.context.CreateNew<StatAttribute>(a.Attribute, a.BaseValue)))
            {
                character.Attributes.Add(attribute);
            }

            character.CurrentMap = character.CharacterClass.HomeMap;
            var spawnGate = character.CurrentMap.ExitGates.Where(m => m.IsSpawnGate).SelectRandom();
            character.PositionX = (byte)Rand.NextInt(spawnGate.X1, spawnGate.X2);
            character.PositionY = (byte)Rand.NextInt(spawnGate.Y1, spawnGate.Y2);
            var level = (index * 10) + 100;
            character.Attributes.First(a => a.Definition == Stats.Level).Value = level;
            character.Experience = this.CalculateNeededExperience(level);
            character.LevelUpPoints = (int)(character.Attributes.First(a => a.Definition == Stats.Level).Value - 1) * character.CharacterClass.PointsPerLevelUp;
            character.Inventory = this.context.CreateNew<ItemStorage>();
            character.Inventory.Money = 1000000;
            //character.Inventory.Items.Add(this.CreateSmallAxe(0));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(12));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(13));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(14));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(15));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(16));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(17));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(18));
            //character.Inventory.Items.Add(this.CreateJewelOfBless(19));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(20));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(21));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(22));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(23));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(24));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(25));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(26));
            //character.Inventory.Items.Add(this.CreateJewelOfSoul(27));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(28));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(29));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(30));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(31));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(32));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(33));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(34));
            //character.Inventory.Items.Add(this.CreateJewelOfLife(35));
            //character.Inventory.Items.Add(this.CreateHealthPotion(36, 0));
            //character.Inventory.Items.Add(this.CreateHealthPotion(37, 1));
            //character.Inventory.Items.Add(this.CreateHealthPotion(38, 2));
            //character.Inventory.Items.Add(this.CreateHealthPotion(39, 3));
            //character.Inventory.Items.Add(this.CreateManaPotion(40, 0));
            //character.Inventory.Items.Add(this.CreateManaPotion(41, 1));
            //character.Inventory.Items.Add(this.CreateManaPotion(42, 2));
            //character.Inventory.Items.Add(this.CreateAlcohol(43));
            //character.Inventory.Items.Add(this.CreateShieldPotion(44, 0));
            //character.Inventory.Items.Add(this.CreateShieldPotion(45, 1));
            //character.Inventory.Items.Add(this.CreateShieldPotion(46, 2));
            //character.Inventory.Items.Add(this.CreateSetItem(52, 5, 8)); // Leather armor
            //character.Inventory.Items.Add(this.CreateSetItem(47, 5, 7)); // Leather helm
            //character.Inventory.Items.Add(this.CreateSetItem(49, 5, 9)); // Leather pants
            //character.Inventory.Items.Add(this.CreateSetItem(63, 5, 10)); // Leather gloves
            //character.Inventory.Items.Add(this.CreateSetItem(65, 5, 11)); // Leather boots
        }

        private Item CreateSetItem(byte itemSlot, byte setNumber, byte group)
        {
            var item = this.context.CreateNew<Item>();
            item.Definition = this.gameConfiguration.Items.First(def => def.Group == group && def.Number == setNumber);
            item.Durability = item.Definition.Durability;
            item.ItemSlot = itemSlot;
            return item;
        }

        private Item CreateAlcohol(byte itemSlot)
        {
            var potion = this.context.CreateNew<Item>();
            potion.Definition = this.gameConfiguration.Items.FirstOrDefault(def => def.Group == 14 && def.Number == 9);
            potion.Durability = 1;
            potion.ItemSlot = itemSlot;
            return potion;
        }

        private Item CreateManaPotion(byte itemSlot, byte size)
        {
            return this.CreatePotion(itemSlot, (byte)(size + 4));
        }

        private Item CreateHealthPotion(byte itemSlot, byte size)
        {
            return this.CreatePotion(itemSlot, size);
        }

        private Item CreateShieldPotion(byte itemSlot, byte size)
        {
            return this.CreatePotion(itemSlot, (byte)(size + 35));
        }

        private Item CreatePotion(byte itemSlot, byte itemNumber)
        {
            var potion = this.context.CreateNew<Item>();
            potion.Definition = this.gameConfiguration.Items.FirstOrDefault(def => def.Group == 14 && def.Number == itemNumber);
            potion.Durability = 3; // Stack of 3 Potions
            potion.ItemSlot = itemSlot;
            return potion;
        }

        private Item CreateJewelOfBless(byte itemSlot)
        {
            return this.CreateJewel(itemSlot, 13);
        }

        private Item CreateJewelOfSoul(byte itemSlot)
        {
            return this.CreateJewel(itemSlot, 14);
        }

        private Item CreateJewelOfLife(byte itemSlot)
        {
            return this.CreateJewel(itemSlot, 16);
        }

        private Item CreateJewel(byte itemSlot, byte itemNumber)
        {
            var jewel = this.context.CreateNew<Item>();
            jewel.Definition = this.gameConfiguration.Items.FirstOrDefault(def => def.Group == 14 && def.Number == itemNumber);
            jewel.Durability = 1;
            jewel.ItemSlot = itemSlot;
            return jewel;
        }

        private Item CreateSmallAxe(byte itemSlot)
        {
            var smallAxe = this.context.CreateNew<Item>();
            smallAxe.Definition = this.gameConfiguration.Items.FirstOrDefault(def => def.Group == 1 && def.Number == 0); // small axe
            smallAxe.Durability = smallAxe.Definition?.Durability ?? 0;
            smallAxe.ItemSlot = itemSlot;
            return smallAxe;
        }

        private void CreateNpcs()
        {
            var init = new NpcInitialization(this.context, this.gameConfiguration);
            init.CreateNpcs();
        }

        private PacketHandlerConfiguration CreatePacketConfig<THandler>(PacketType packetType, bool needsEncryption = false)
            where THandler : IPacketHandler
        {
            var config = this.context.CreateNew<PacketHandlerConfiguration>();
            config.PacketIdentifier = (byte)packetType;
            config.PacketHandlerClassName = typeof(THandler).AssemblyQualifiedName;
            config.NeedsToBeEncrypted = needsEncryption;
            return config;
        }

        private ItemOptionDefinition CreateLuckOptionDefinition()
        {
            var definition = this.context.CreateNew<ItemOptionDefinition>();

            definition.Name = "Luck";
            definition.AddChance = 0.25f;
            definition.AddsRandomly = true;
            definition.MaximumOptionsPerItem = 1;

            var itemOption = this.context.CreateNew<IncreasableItemOption>();
            itemOption.OptionType = this.gameConfiguration.ItemOptionTypes.FirstOrDefault(o => o == ItemOptionTypes.Luck);
            itemOption.PowerUpDefinition = this.context.CreateNew<PowerUpDefinition>();
            itemOption.PowerUpDefinition.TargetAttribute = this.gameConfiguration.Attributes.FirstOrDefault(a => a == Stats.CriticalDamageChance);
            itemOption.PowerUpDefinition.Boost = this.context.CreateNew<PowerUpDefinitionValue>();
            itemOption.PowerUpDefinition.Boost.ConstantValue.Value = 0.05f;
            definition.PossibleOptions.Add(itemOption);

            return definition;
        }

        private ItemOptionDefinition CreateOptionDefinition(AttributeDefinition attributeDefinition)
        {
            var definition = this.context.CreateNew<ItemOptionDefinition>();

            definition.Name = "Option";
            definition.AddChance = 0.25f;
            definition.AddsRandomly = true;
            definition.MaximumOptionsPerItem = 1;

            var itemOption = this.context.CreateNew<IncreasableItemOption>();
            itemOption.OptionType = this.gameConfiguration.ItemOptionTypes.FirstOrDefault(o => o == ItemOptionTypes.Option);
            itemOption.PowerUpDefinition = this.context.CreateNew<PowerUpDefinition>();
            itemOption.PowerUpDefinition.TargetAttribute = this.gameConfiguration.Attributes.First(a => a == attributeDefinition);
            itemOption.PowerUpDefinition.Boost = this.context.CreateNew<PowerUpDefinitionValue>();
            itemOption.PowerUpDefinition.Boost.ConstantValue.Value = 4;
            for (int level = 2; level <= 4; level++)
            {
                var levelDependentOption = this.context.CreateNew<ItemOptionOfLevel>();
                levelDependentOption.Level = level;
                var powerUpDefinition = this.context.CreateNew<PowerUpDefinition>();
                powerUpDefinition.TargetAttribute = itemOption.PowerUpDefinition.TargetAttribute;
                powerUpDefinition.Boost = this.context.CreateNew<PowerUpDefinitionValue>();
                powerUpDefinition.Boost.ConstantValue.Value = level * 4;
                levelDependentOption.PowerUpDefinition = powerUpDefinition;
                itemOption.LevelDependentOptions.Add(levelDependentOption);
            }

            definition.PossibleOptions.Add(itemOption);

            return definition;
        }

        private void CreateItemOptionTypes()
        {
            var optionTypes = typeof(ItemOptionTypes)
                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(p => p.PropertyType == typeof(ItemOptionType))
                .Select(p => p.GetValue(typeof(ItemOptionType)))
                .OfType<ItemOptionType>()
                .ToList();

            foreach (var optionType in optionTypes)
            {
                var persistentOptionType = this.context.CreateNew<ItemOptionType>();
                persistentOptionType.Description = optionType.Description;
                persistentOptionType.Id = optionType.Id;
                persistentOptionType.Name = optionType.Name;
                this.gameConfiguration.ItemOptionTypes.Add(persistentOptionType);
            }
        }

        /// <summary>
        /// Creates the stat attributes.
        /// </summary>
        private void CreateStatAttributes()
        {
            var attributes = typeof(Stats)
                .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(p => p.PropertyType == typeof(AttributeDefinition))
                .Select(p => p.GetValue(typeof(Stats)))
                .OfType<AttributeDefinition>()
                .ToList();

            foreach (var attribute in attributes)
            {
                var persistentAttribute = this.context.CreateNew<AttributeDefinition>(attribute.Id, attribute.Designation, attribute.Description);
                this.gameConfiguration.Attributes.Add(persistentAttribute);
            }
        }

        private void CreateItemSlotTypes()
        {
            var leftHand = this.context.CreateNew<ItemSlotType>();
            leftHand.Description = "Left Hand";
            leftHand.ItemSlots.Add(0);
            this.gameConfiguration.ItemSlotTypes.Add(leftHand);

            var rightHand = this.context.CreateNew<ItemSlotType>();
            rightHand.Description = "Right Hand";
            rightHand.ItemSlots.Add(1);
            this.gameConfiguration.ItemSlotTypes.Add(rightHand);

            var helm = this.context.CreateNew<ItemSlotType>();
            helm.Description = "Helm";
            helm.ItemSlots.Add(2);
            this.gameConfiguration.ItemSlotTypes.Add(helm);

            var armor = this.context.CreateNew<ItemSlotType>();
            armor.Description = "Armor";
            armor.ItemSlots.Add(3);
            this.gameConfiguration.ItemSlotTypes.Add(armor);

            var pants = this.context.CreateNew<ItemSlotType>();
            pants.Description = "Pants";
            pants.ItemSlots.Add(4);
            this.gameConfiguration.ItemSlotTypes.Add(pants);

            var gloves = this.context.CreateNew<ItemSlotType>();
            gloves.Description = "Gloves";
            gloves.ItemSlots.Add(5);
            this.gameConfiguration.ItemSlotTypes.Add(gloves);

            var boots = this.context.CreateNew<ItemSlotType>();
            boots.Description = "Boots";
            boots.ItemSlots.Add(6);
            this.gameConfiguration.ItemSlotTypes.Add(boots);

            var wings = this.context.CreateNew<ItemSlotType>();
            wings.Description = "Wings";
            wings.ItemSlots.Add(7);
            this.gameConfiguration.ItemSlotTypes.Add(wings);

            var pet = this.context.CreateNew<ItemSlotType>();
            pet.Description = "Pet";
            pet.ItemSlots.Add(8);
            this.gameConfiguration.ItemSlotTypes.Add(pet);

            var pendant = this.context.CreateNew<ItemSlotType>();
            pendant.Description = "Pendant";
            pendant.ItemSlots.Add(9);
            this.gameConfiguration.ItemSlotTypes.Add(pendant);

            var ring = this.context.CreateNew<ItemSlotType>();
            ring.Description = "Ring";
            ring.ItemSlots.Add(10);
            ring.ItemSlots.Add(11);
            this.gameConfiguration.ItemSlotTypes.Add(ring);
        }

        private void CreateGameServerDefinitions(GameServerConfiguration gameServerConfiguration, int numberOfServers)
        {
            for (int i = 0; i < numberOfServers; i++)
            {
                var server = this.context.CreateNew<GameServerDefinition>();
                server.ServerID = (byte)i;
                server.Description = $"Server {i}";
                server.NetworkPort = 55901 + i;
                server.GameConfiguration = this.gameConfiguration;
                server.ServerConfiguration = gameServerConfiguration;
            }
        }

        private void CreateGameMapDefinitions()
        {
            this.gameConfiguration.Maps.Add(new Lorencia().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Dungeon().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Devias().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Noria().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new LostTower().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Exile().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Arena().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Atlans().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Tarkan().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new DevilSquare1To4().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Icarus().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Elvenland().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Karutan1().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Karutan2().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Aida().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Vulcanus().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new CrywolfFortress().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new LandOfTrials().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new LorenMarket().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new SantaVillage().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new SilentMap().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new ValleyOfLoren().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new BarracksOfBalgass().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new BalgassRefuge().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima1().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima2().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima3().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima4().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima5().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima6().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Kalima7().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new KanturuRelics().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new KanturuRuins().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new Raklion().Initialize(this.context, this.gameConfiguration));
            this.gameConfiguration.Maps.Add(new SwampOfCalmness().Initialize(this.context, this.gameConfiguration));

            var mapNames = new List<string>
            {
                "Lorencia", "Dungeon", "Devias", "Noria", "Lost Tower", "Exile", "Arena", "Atlans", "Tarkan", "Devil Square (1-4)", "Icarus", // 10
                "Blood_Castle 1", "Blood_Castle 2", "Blood_Castle 3", "Blood_Castle 4", "Blood_Castle 5", "Blood_Castle 6", "Blood_Castle 7", "Chaos_Castle 1", "Chaos_Castle 2", "Chaos_Castle 3", // 20
                "Chaos_Castle 4", "Chaos_Castle 5", "Chaos_Castle 6", "Kalima 1", "Kalima 2", "Kalima 3", "Kalima 4", "Kalima 5", "Kalima 6", "Valley of Loren", // 30
                "Land_of_Trials", "Devil_Square (5-6)", "Aida", "Crywolf Fortress", "?", "Kalima 7", "Kanturu_I", "Kanturu_III", "Kanturu_Event", "Silent Map?", // 40
                "Barracks of Balgass", "Balgass Refuge", "?", "?", "Illusion_Temple 1", "Illusion_Temple 2", "Illusion_Temple 3", "Illusion_Temple 4", "Illusion_Temple 5", "Illusion_Temple 6", // 50
                "Elvenland", "Blood_Castle 8", "Chaos_Castle 7", "?", "?", "Swamp Of Calmness", "LaCleon", "LaCleonBoss", "?", "?", // 60
                "?", "Santa Village", "Vulcanus", "Duel Arena", "Double Gear 1", "Double Gear 2", "Double Gear 3", "Double Gear 4", "Empire Fortress 1", // 69
                "Empire Fortress 2", "Empire Fortress 3", "Empire Fortress 4", "Empire Fortress 5", "?", "?", "?", "?", "?", "LorenMarket", // 79
                "Karutan1", "Karutan2"
            };

            var skipCount = this.gameConfiguration.Maps.Count;
            mapNames.Where(name => name != "?" && !this.gameConfiguration.Maps.Any(m => m.Name == name)).ToList()
                .ForEach((mapName) =>
                {
                    var map = this.context.CreateNew<GameMapDefinition>();
                    map.Name = mapName;
                    map.Number = (short)mapNames.IndexOf(mapName);
                    map.ExpMultiplier = 1;
                    var terrain =
                        Terrains.ResourceManager.GetObject("Terrain" + (map.Number + 1).ToString()) as byte[]
                        ?? Terrains.ResourceManager.GetObject("Terrain" + (mapNames.IndexOf(mapName.Substring(0, mapName.Length - 1) + "1") + 1)) as byte[];
                    map.TerrainData = terrain;
                    this.gameConfiguration.Maps.Add(map);
                });
        }

        private GameServerConfiguration CreateGameServerConfiguration(ICollection<GameMapDefinition> maps)
        {
            var gameServerConfiguration = this.context.CreateNew<GameServerConfiguration>();
            gameServerConfiguration.MaximumNPCs = 20000;
            gameServerConfiguration.MaximumPlayers = 1000;

            var mainPacketHandlerConfig = this.context.CreateNew<MainPacketHandlerConfiguration>();
            mainPacketHandlerConfig.ClientVersion = new byte[] { 0x31, 0x30, 0x34, 0x30, 0x34 };
            mainPacketHandlerConfig.ClientSerial = Encoding.UTF8.GetBytes("k1Pk2jcET48mxL3b");

            this.CreatePacketHandlerConfiguration().ToList().ForEach(mainPacketHandlerConfig.PacketHandlers.Add);
            gameServerConfiguration.SupportedPacketHandlers.Add(mainPacketHandlerConfig);

            // by default we add every map to a server configuration
            foreach (var map in maps)
            {
                gameServerConfiguration.Maps.Add(map);
            }

            return gameServerConfiguration;
        }

        private IEnumerable<PacketHandlerConfiguration> CreatePacketHandlerConfiguration()
        {
            yield return this.CreatePacketConfig<ChatMessageHandler>(PacketType.Speak);
            yield return this.CreatePacketConfig<ChatMessageHandler>(PacketType.Whisper);
            yield return this.CreatePacketConfig<LoginHandler>(PacketType.LoginLogoutGroup);
            yield return this.CreatePacketConfig<StoreHandler>(PacketType.PersonalShopGroup);
            yield return this.CreatePacketConfig<PickupItemHandler>(PacketType.PickupItem);
            yield return this.CreatePacketConfig<DropItemHandler>(PacketType.DropItem);
            yield return this.CreatePacketConfig<ItemMoveHandler>(PacketType.InventoryMove);
            yield return this.CreatePacketConfig<ConsumeItemHandler>(PacketType.ConsumeItem);
            yield return this.CreatePacketConfig<TalkNpcHandler>(PacketType.TalkNPC);
            yield return this.CreatePacketConfig<CloseNPCHandler>(PacketType.CloseNPC);
            yield return this.CreatePacketConfig<BuyNPCItemHandler>(PacketType.BuyNPCItem);
            yield return this.CreatePacketConfig<SellItemToNPCHandler>(PacketType.SellNPCItem);
            yield return this.CreatePacketConfig<WarpHandler>(PacketType.WarpCommand);
            yield return this.CreatePacketConfig<WarpGateHandler>(PacketType.WarpGate);
            yield return this.CreatePacketConfig<WarehouseCloseHandler>(PacketType.VaultClose);
            yield return this.CreatePacketConfig<JewelMixHandler>(PacketType.JewelMix);

            yield return this.CreatePacketConfig<PartyListRequestHandler>(PacketType.RequestPartyList);
            yield return this.CreatePacketConfig<PartyKickHandler>(PacketType.PartyKick);
            yield return this.CreatePacketConfig<PartyRequestHandler>(PacketType.PartyRequest);
            yield return this.CreatePacketConfig<PartyResponseHandler>(PacketType.PartyRequestAnswer);

            yield return this.CreatePacketConfig<CharacterMoveHandler>(PacketType.Walk);
            yield return this.CreatePacketConfig<CharacterMoveHandler>(PacketType.Teleport);
            yield return this.CreatePacketConfig<AnimationHandler>(PacketType.Animation);
            yield return this.CreatePacketConfig<CharacterGroupHandler>(PacketType.CharacterGroup);

            yield return this.CreatePacketConfig<HitHandler>(PacketType.Hit);
            yield return this.CreatePacketConfig<TargettedSkillHandler>(PacketType.SkillAttack);
            yield return this.CreatePacketConfig<AreaSkillAttackHandler>(PacketType.AreaSkill);
            yield return this.CreatePacketConfig<AreaSkillHitHandler>(PacketType.AreaSkillHit);

            yield return this.CreatePacketConfig<TradeCancelHandler>(PacketType.TradeCancel);
            yield return this.CreatePacketConfig<TradeButtonHandler>(PacketType.TradeButton);
            yield return this.CreatePacketConfig<TradeRequestHandler>(PacketType.TradeRequest);
            yield return this.CreatePacketConfig<TradeAcceptHandler>(PacketType.TradeAccept);
            yield return this.CreatePacketConfig<TradeMoneyHandler>(PacketType.TradeMoney);
            yield return this.CreatePacketConfig<LetterDeleteHandler>(PacketType.FriendMemoDelete);
            yield return this.CreatePacketConfig<LetterSendHandler>(PacketType.FriendMemoSend);
            yield return this.CreatePacketConfig<LetterReadRequestHandler>(PacketType.FriendMemoReadRequest);
            yield return this.CreatePacketConfig<GuildKickPlayerHandler>(PacketType.GuildKickPlayer);
            yield return this.CreatePacketConfig<GuildRequestHandler>(PacketType.GuildJoinRequest);
            yield return this.CreatePacketConfig<GuildRequestAnswerHandler>(PacketType.GuildJoinAnswer);
            yield return this.CreatePacketConfig<GuildListRequestHandler>(PacketType.RequestGuildList);
            yield return this.CreatePacketConfig<GuildCreateHandler>(PacketType.GuildMasterInfoSave);
            yield return this.CreatePacketConfig<GuildMasterAnswerHandler>(PacketType.GuildMasterAnswer);
            yield return this.CreatePacketConfig<GuildInfoRequestHandler>(PacketType.GuildInfoRequest);

            yield return this.CreatePacketConfig<ItemRepairHandler>(PacketType.ItemRepair);
            yield return this.CreatePacketConfig<ChaosMixHandler>(PacketType.ChaosMachineMix);
            yield return this.CreatePacketConfig<AddFriendHandler>(PacketType.FriendAdd);
            yield return this.CreatePacketConfig<DeleteFriendHandler>(PacketType.FriendDelete);
            yield return this.CreatePacketConfig<ChatRequestHandler>(PacketType.ChatRoomCreate);
            yield return this.CreatePacketConfig<ChatRoomInvitationRequest>(PacketType.ChatRoomInvitationReq);
            yield return this.CreatePacketConfig<FriendAddResponseHandler>(PacketType.FriendAddReponse);
            yield return this.CreatePacketConfig<ChangeOnlineStateHandler>(PacketType.FriendStateClient);
        }

        private void InitializeGameConfiguration()
        {
            this.gameConfiguration.MaximumLevel = 400;
            this.gameConfiguration.InfoRange = 12;
            this.gameConfiguration.AreaSkillHitsPlayer = false;
            this.gameConfiguration.MaximumInventoryMoney = int.MaxValue;
            this.gameConfiguration.RecoveryInterval = 3000;
            this.gameConfiguration.MaximumLetters = 50;
            this.gameConfiguration.MaximumCharactersPerAccount = 5;
            this.gameConfiguration.CharacterNameRegex = "^[a-zA-Z0-9]{3,10}$";
            this.gameConfiguration.MaximumPasswordLength = 20;
            this.gameConfiguration.MaximumPartySize = 5;
            this.gameConfiguration.ExperienceTable =
                Enumerable.Range(0, this.gameConfiguration.MaximumLevel + 2)
                    .Select(level => this.CalculateNeededExperience(level))
                    .ToArray();
            this.gameConfiguration.MasterExperienceTable =
                Enumerable.Range(0, 201).Select(level => this.CalcNeededMasterExp(level)).ToArray();
            var moneyDropItemGroup = this.context.CreateNew<DropItemGroup>();
            moneyDropItemGroup.Chance = 0.5;
            moneyDropItemGroup.ItemType = SpecialItemType.Money;
            this.gameConfiguration.BaseDropItemGroups.Add(moneyDropItemGroup);
            this.CreateStatAttributes();

            this.CreateItemSlotTypes();
            this.CreateItemOptionTypes();
            this.gameConfiguration.ItemOptions.Add(this.CreateLuckOptionDefinition());
            this.gameConfiguration.ItemOptions.Add(this.CreateOptionDefinition(Stats.DefenseBase));
            this.gameConfiguration.ItemOptions.Add(this.CreateOptionDefinition(Stats.MaximumPhysBaseDmg));
            this.gameConfiguration.ItemOptions.Add(this.CreateOptionDefinition(Stats.MaximumWizBaseDmg));

            new CharacterClassInitialization(this.context, this.gameConfiguration).CreateCharacterClasses();
            new Skills(this.context, this.gameConfiguration).Initialize();
            new Orbs(this.context, this.gameConfiguration).Initialize();
            new Scrolls(this.context, this.gameConfiguration).Initialize();
            new Wings(this.context, this.gameConfiguration).Initialize();
            new ExcellentOptions(this.context, this.gameConfiguration).Initialize();
            new Armors(this.context, this.gameConfiguration).Initialize();
            var weaponHelper = new WeaponItemHelper(this.context, this.gameConfiguration);
            weaponHelper.InitializeWeapons();
            new Potions(this.context, this.gameConfiguration).Initialize();
            new Jewels(this.context, this.gameConfiguration).Initialize();
            this.CreateNpcs();
            this.CreateGameMapDefinitions();
            this.AssignCharacterClassHomeMaps();
            new Gates().Initialize(this.context, this.gameConfiguration);
            //// TODO: ItemSetGroups
            //// TODO: MagicEffects
            //// TODO: MasterSkillRoots
        }

        private void AssignCharacterClassHomeMaps()
        {
            foreach (var characterClass in this.gameConfiguration.CharacterClasses)
            {
                byte mapNumber;
                switch ((CharacterClassNumber)characterClass.Number)
                {
                    case CharacterClassNumber.FairyElf:
                    case CharacterClassNumber.HighElf:
                    case CharacterClassNumber.MuseElf:
                        mapNumber = Noria.Number;
                        break;
                    case CharacterClassNumber.BloodySummoner:
                    case CharacterClassNumber.Summoner:
                        mapNumber = Elvenland.Number;
                        break;
                    default:
                        mapNumber = Lorencia.Number;
                        break;
                }

                characterClass.HomeMap = this.gameConfiguration.Maps.First(map => map.Number == mapNumber);
            }
        }
    }
}
