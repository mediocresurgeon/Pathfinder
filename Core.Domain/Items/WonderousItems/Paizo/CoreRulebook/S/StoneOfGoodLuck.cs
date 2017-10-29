using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.WonderousItems.Paizo.CoreRulebook
{
    /// <summary>
    /// A small bit of agate which grants a luck bonus to saving throws, ability checks and skill checks.
    /// </summary>
    public sealed class StoneOfGoodLuck : Item, IStowable
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.WonderousItems.Paizo.CoreRulebook.StoneOfGoodLuck"/> class.
        /// </summary>
        public StoneOfGoodLuck()
            : base()
        {
            // Intentionally blank
        }
        #endregion

        #region Properties
        public override double Weight => 0;

        public override byte? CasterLevel => 5;
        #endregion

        #region Methods
        public override byte GetHardness()
        {
            return 8;
        }

        public override ushort GetHitPoints()
        {
            return 15;
        }

        public override double GetMarketPrice()
        {
            return 20_000;
        }

        public override INameFragment[] GetName()
        {
            return new INameFragment[]
            {
                new NameFragment(
                    text:       "Stone of Good Luck",
                    webAddress: "http://www.d20pfsrd.com/magic-items/wondrous-items/wondrous-items/r-z/stone-of-good-luck-luckstone/"
                )
            };
        }

        public override School[] GetSchools()
        {
            return new School[] { School.Evocation };
        }

        /// <summary>
        /// Applies the effects of this item to the character.
        /// </summary>
        /// <param name="character">The character who is stowing this item.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public void ApplyTo(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            character.Initiative?.LuckBonuses?.Add(1); // Initiative is an ability check
            #region Saving throws
            character.SavingThrows?.Fortitude?.LuckBonuses?.Add(1);
            character.SavingThrows?.Reflex?.LuckBonuses?.Add(1);
            character.SavingThrows?.Will?.LuckBonuses?.Add(1);
            #endregion
            #region Skills
            character.Skills?.Acrobatics?.LuckBonuses?.Add(1);
            character.Skills?.Appraise?.LuckBonuses?.Add(1);
            character.Skills?.Bluff?.LuckBonuses?.Add(1);
            character.Skills?.Climb?.LuckBonuses?.Add(1);
            #region Craft
            character.Skills?.Craft?.Alchemy?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Armor?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Baskets?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Books?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Bows?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Calligraphy?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Carpentry?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Cloth?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Clothing?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Glass?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Jewelry?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Leather?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Locks?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Paintings?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Pottery?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Sculptures?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Ships?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Shoes?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Stonemasonry?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Traps?.LuckBonuses?.Add(1);
            character.Skills?.Craft?.Weapons?.LuckBonuses?.Add(1);
            #endregion
            character.Skills?.Diplomacy?.LuckBonuses?.Add(1);
            character.Skills?.DisableDevice?.LuckBonuses?.Add(1);
            character.Skills?.Disguise?.LuckBonuses?.Add(1);
            character.Skills?.EscapeArtist?.LuckBonuses?.Add(1);
            character.Skills?.Fly?.LuckBonuses?.Add(1);
            character.Skills?.HandleAnimal?.LuckBonuses?.Add(1);
            character.Skills?.Heal?.LuckBonuses?.Add(1);
            character.Skills?.Intimidate?.LuckBonuses?.Add(1);
            #region Knowledge
            character.Skills?.Knowledge?.Arcana?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Dungeoneering?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Engineering?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Geography?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.History?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Local?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Nature?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Nobility?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Planes?.LuckBonuses?.Add(1);
            character.Skills?.Knowledge?.Religion?.LuckBonuses?.Add(1);
            #endregion
            character.Skills?.Linguistics?.LuckBonuses?.Add(1);
            character.Skills?.Perception?.LuckBonuses?.Add(1);
            #region Perform
            character.Skills?.Perform?.Act?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.Comedy?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.Dance?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.KeyboardInstruments?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.Oratory?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.PercussionInstruments?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.Sing?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.StringInstruments?.LuckBonuses?.Add(1);
            character.Skills?.Perform?.WindInstruments?.LuckBonuses?.Add(1);
            #endregion
            #region Profession
            character.Skills?.Profession?.Architect.LuckBonuses.Add(1);
            character.Skills?.Profession?.Baker?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Barrister?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Brewer?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Butcher?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Clerk?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Cook?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Courtesan?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Driver?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Engineer?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Farmer?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Fisherman?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Gambler?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Gardener?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Herbalist?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Innkeeper?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Librarian?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Merchant?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Midwife?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Miller?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Miner?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Porter?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Sailor?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Scribe?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Shepherd?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Soldier?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.StableMaster?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Tanner?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Trapper?.LuckBonuses?.Add(1);
            character.Skills?.Profession?.Woodcutter?.LuckBonuses?.Add(1);
            #endregion
            character.Skills?.Ride?.LuckBonuses?.Add(1);
            character.Skills?.SenseMotive?.LuckBonuses?.Add(1);
            character.Skills?.SleightOfHand?.LuckBonuses?.Add(1);
            character.Skills?.Spellcraft?.LuckBonuses?.Add(1);
            character.Skills?.Stealth?.LuckBonuses?.Add(1);
            character.Skills?.Survival?.LuckBonuses?.Add(1);
            character.Skills?.Swim?.LuckBonuses?.Add(1);
            character.Skills?.UseMagicDevice?.LuckBonuses?.Add(1);
            #endregion
        }
        #endregion
    }
}