using System;
using Core.Domain.Characters.Skills;


namespace Core.Domain.Characters.Feats.Paizo.CoreRulebook
{
    /// <summary>
    /// A trained character is more adept at the chosen skill.
    /// </summary>
    public sealed class SkillFocus : Feat
    {
        #region Backing variables
        private readonly ISkill _skill;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Characters.Feats.Paizo.CoreRulebook.S.SkillFocus"/> class.
        /// </summary>
        /// <param name="skill">The skill being focused on.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        public SkillFocus(ISkill skill)
            : base(name: $"Spell Focus ({ skill?.ToString() })",
                   webAddress: "http://www.d20pfsrd.com/feats/general-feats/skill-focus-final/")
        {
            _skill = skill ?? throw new ArgumentNullException(nameof(skill), "Argument cannot be null.");
        }
		#endregion

		#region Override methods
		/// <summary>
		/// Trains the specified character in this feat.
		/// </summary>
		/// <param name="character">The character to train.</param>
		public override void ApplyTo(ICharacter character)
        {
            // Ignore the character argument; we already have a reference to the skill we need to modify
            // If the skill has 10 or more ranks, apply a +6 bonus.  Otherwise, apply a +3 bonus.
            _skill.UntypedBonuses.Add(() => 10 <= _skill.Ranks ? (byte)6 : (byte)3);
        }
        #endregion
    }
}