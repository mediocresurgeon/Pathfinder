using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.ArmorClasses
{
    internal sealed class ArmorClass : IArmorClass
    {
        #region Backing variables
        private readonly ICharacter _character;
        private IAbilityScore _keyAbilityScore;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.ArmorClasses.ArmorClass"/> class.
        /// </summary>
        /// <param name="character">The character to whom this armor class belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal ArmorClass(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
            this.KeyAbilityScore = character?.AbilityScores?.Dexterity;
        }
        #endregion

        #region Properties
        public IAbilityScore KeyAbilityScore
        {
            get => _keyAbilityScore;
            set => _keyAbilityScore = value ?? throw new ArgumentNullException(nameof(value), "KeyAbilityScore cannot be null.");
        }

        public IModifierTracker MaxKeyAbilityScore { get; } = new MaxDexTracker();

        public IModifierTracker ArmorBonuses { get; } = new ArmorBonusTracker();

        public IModifierTracker ShieldBonuses { get; } = new ShieldBonusTracker();

        public IModifierTracker CircumstanceBonuses { get; } = new CircumstanceBonusTracker();

        public IModifierTracker DodgeBonuses { get; } = new DodgeBonusTracker();

        public IModifierTracker DeflectionBonuses { get; } = new DeflectionBonusTracker();

        public IModifierTracker InsightBonuses { get; } = new InsightBonusTracker();

        public IModifierTracker LuckBonuses { get; } = new LuckBonusTracker();

        public IModifierTracker MoraleBonuses { get; } = new MoraleBonusTracker();

        public IModifierTracker NaturalArmorBonuses { get; } = new NaturalArmorBonusTracker();

        public IModifierTracker NaturalArmorEnhancementBonuses { get; } = new NaturalArmorBonusTracker();

        public IModifierTracker ProfaneBonuses { get; } = new ProfaneBonusTracker();

        public IModifierTracker SacredBonuses { get; } = new SacredBonusTracker();

        public IModifierTracker UntypedBonuses { get; } = new UntypedBonusTracker();

        public IModifierTracker Penalties { get; } = new PenaltyTracker();
        #endregion

        #region Methods
        public sbyte GetSizeModifier()
        {
            switch(_character.Size)
            {
                case SizeCategory.Small:  return  1;
                case SizeCategory.Medium: return  0;
                case SizeCategory.Large:  return -1;
                default:
                    throw new NotImplementedException($"Unable to calculate a size modifier for SizeCategory { _character.Size }");
            }
        }


        public sbyte GetTotal()
        {
            sbyte abilityScoreModifier = this.KeyAbilityScore.GetModifier();
            byte maxAbilityScoreModifier = this.MaxKeyAbilityScore.GetTotal();
            int cappedAbilityScoreModifier = (abilityScoreModifier < maxAbilityScoreModifier)
                                           ? (int)abilityScoreModifier
                                           : (int)maxAbilityScoreModifier;
            int runningTotal = 10;
            runningTotal += cappedAbilityScoreModifier;
            runningTotal += this.GetSizeModifier();
            runningTotal += this.ArmorBonuses.GetTotal();
            runningTotal += this.ShieldBonuses.GetTotal();
            runningTotal += this.CircumstanceBonuses.GetTotal();
            runningTotal += this.DodgeBonuses.GetTotal();
            runningTotal += this.DeflectionBonuses.GetTotal();
            runningTotal += this.InsightBonuses.GetTotal();
            runningTotal += this.LuckBonuses.GetTotal();
            runningTotal += this.MoraleBonuses.GetTotal();
            runningTotal += this.NaturalArmorBonuses.GetTotal();
            runningTotal += this.NaturalArmorEnhancementBonuses.GetTotal();
            runningTotal += this.ProfaneBonuses.GetTotal();
            runningTotal += this.SacredBonuses.GetTotal();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }
        #endregion

        #region Private classes
        /// <summary>
        /// A private class used to calculate a max dex bonus.
        /// It is different from most IModifierTracker in that it returns the smallest possible modifier,
        /// with a default value of 255.
        /// </summary>
        private sealed class MaxDexTracker : IModifierTracker
        {
            #region Properties
            /// <summary>
            /// A mutable collection of modifier data which is used in calculations by this class.
            /// </summary>
            /// <value>The modifiers.</value>
            private IList<Func<byte>> Modifiers { get; } = new List<Func<byte>>();
            #endregion

            #region Methods
            /// <summary>
            /// Adds a static modifier.
            /// </summary>
            /// <param name="amount">The magnitude of the modifier.</param>
            public void Add(byte amount)
            {
                this.Add(() => amount);
            }


            /// <summary>
            /// Adds a dynamic modifier.
            /// </summary>
            /// <param name="calculation">The calculation which determines a modifier.</param>
            /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
            public void Add(Func<byte> calculation)
            {
                if (null == calculation)
                    throw new ArgumentNullException(nameof(calculation), "Cannot be null.");
                this.Modifiers.Add(calculation);
            }


            /// <summary>
            /// Returns the total modifier.
            /// </summary>
            /// <returns>The total.</returns>
            public byte GetTotal()
            {
                Func<byte> seedFunction = () => Byte.MaxValue;
                return this.Modifiers
                           .Aggregate(seedFunction, (Func<byte> calc1, Func<byte> calc2) =>
                           {
                               var result1 = calc1();
                               var result2 = calc2();
                               return () => (result1 < result2) ? result1 : result2;
                           })
                           (); // Calls the resultant function
            }
            #endregion
        }
        #endregion
    }
}