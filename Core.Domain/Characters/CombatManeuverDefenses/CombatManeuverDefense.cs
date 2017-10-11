using System;
using Core.Domain.Characters.ModifierTrackers;


namespace Core.Domain.Characters.CombatManeuverDefenses
{
    internal sealed class CombatManeuverDefense : ICombatManeuverDefense
    {
        #region Backing variables
        private readonly ICharacter _character;
		#endregion

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the
		/// <see cref="T:Core.Domain.Characters.CombatManeuverDefenses.CombatManeuverDefense"/> class.
		/// </summary>
		/// <param name="character">The character to whom this CMD belongs.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
		internal CombatManeuverDefense(ICharacter character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character), "Argument cannot be null.");
			// "A creature can also add any circumstance, deflection, dodge,
			// insight, luck, morale, profane, and sacred bonuses to AC to its CMD.
			// Any penalties to a creature’s AC also apply to its CMD."
			// http://www.d20pfsrd.com/gamemastering/combat/#TOC-Combat-Maneuver-Defense
			this.CircumstanceBonuses.Add(
                () => _character.ArmorClass?
                                .CircumstanceBonuses?
                                .GetTotal() ?? 0
            );
            this.DeflectionBonuses.Add(
                () => _character.ArmorClass?
                                .DeflectionBonuses?
                                .GetTotal() ?? 0
            );
            this.DodgeBonuses.Add(
                () => _character.ArmorClass?
                                .DodgeBonuses?
                                .GetTotal() ?? 0
            );
            this.InsightBonuses.Add(
                () => _character.ArmorClass?
                                .InsightBonuses?
                                .GetTotal() ?? 0
            );
            this.LuckBonuses.Add(
                () => _character.ArmorClass?
                                .LuckBonuses?
                                .GetTotal() ?? 0
            );
            this.MoraleBonuses.Add(
                () => _character.ArmorClass?
                                .MoraleBonuses?
                                .GetTotal() ?? 0
            );
            this.ProfaneBonuses.Add(
                () => _character.ArmorClass?
                                .ProfaneBonuses?
                                .GetTotal() ?? 0
            );
            this.SacredBonuses.Add(
                () => _character.ArmorClass?
                                .SacredBonuses?
                                .GetTotal() ?? 0
            );
            this.Penalties.Add(
                () => _character.ArmorClass?
                                .Penalties?
                                .GetTotal() ?? 0
            );
        }
        #endregion

        #region Properties
        public IModifierTracker CircumstanceBonuses { get; } = new CircumstanceBonusTracker();

        public IModifierTracker DeflectionBonuses { get; } = new DeflectionBonusTracker();

        public IModifierTracker DodgeBonuses { get; } = new DodgeBonusTracker();

        public IModifierTracker InsightBonuses { get; } = new InsightBonusTracker();

        public IModifierTracker LuckBonuses { get; } = new LuckBonusTracker();

        public IModifierTracker MoraleBonuses { get; } = new MoraleBonusTracker();

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
                case SizeCategory.Small:  return -1;
                case SizeCategory.Medium: return  0;
                case SizeCategory.Large:  return  1;
                default:
                    throw new NotImplementedException($"Unable to calculate CMD size modifier for SizeCategory { _character.Size }.");
            }
        }


        public sbyte GetTotal()
        {
            int runningTotal = 10;
            runningTotal += _character.AttackBonuses.BaseAttackBonus.GetTotal();
            runningTotal += _character.AbilityScores.Strength.GetModifier();
            runningTotal += _character.AbilityScores.Dexterity.GetModifier();
            runningTotal += this.GetSizeModifier();
            runningTotal += this.CircumstanceBonuses.GetTotal();
            runningTotal += this.DeflectionBonuses.GetTotal();
            runningTotal += this.DodgeBonuses.GetTotal();
            runningTotal += this.InsightBonuses.GetTotal();
            runningTotal += this.LuckBonuses.GetTotal();
            runningTotal += this.MoraleBonuses.GetTotal();
            runningTotal += this.ProfaneBonuses.GetTotal();
            runningTotal += this.SacredBonuses.GetTotal();
            runningTotal += this.UntypedBonuses.GetTotal();
            runningTotal -= this.Penalties.GetTotal();
            return Convert.ToSByte(runningTotal);
        }
        #endregion
    }
}