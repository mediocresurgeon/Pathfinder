using Core.Domain.Characters.Movements;


namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// A character's ability to perform daring or complex maneuvers while airborne.
    /// </summary>
    internal sealed class Fly : Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.Skills.Fly"/> class.
        /// </summary>
        /// <param name="character">The character to whom this skill belongs.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal Fly(ICharacter character)
            : base(character, character?.AbilityScores?.Dexterity, "Fly")
        {
            #region Untyped maneuverability bonus
            this.UntypedBonuses.Add(() =>
            {
                if (this.Character.MovementModes.Fly.BaseSpeed.HasValue)
                {
                    switch (this.Character.MovementModes.Fly.Maneuverability)
                    {
                        case Maneuverability.Perfect: return 8;
                        case Maneuverability.Good: return 4;
                    }
                }
                return 0;
            });
            #endregion
            #region Maneuverabiity penalty
            this.Penalties.Add(() =>
            {
                if (this.Character.MovementModes.Fly.BaseSpeed.HasValue)
                {
                    switch (this.Character.MovementModes.Fly.Maneuverability)
                    {
                        case Maneuverability.Clumsy: return 8;
                        case Maneuverability.Poor: return 4;
                    }
                }
                return 0;
            });
            #endregion
            #region Size bonus
            this.SizeBonuses.Add(() =>
            {
                if (this.Character.MovementModes.Fly.BaseSpeed.HasValue)
                {
                    switch (this.Character.Size)
                    {
                        case SizeCategory.Small: return 2;
                        // Add more sizes here
                    }
                }
                return 0;
            });
            #endregion
            #region Size penalty
            this.Penalties.Add(() =>
            {
                if (this.Character.MovementModes.Fly.BaseSpeed.HasValue)
                {
                    switch (this.Character.Size)
                    {
                        case SizeCategory.Large: return 2;
                        // Add more sizes here
                    }
                }
                return 0;
            });
            #endregion
        }


        /// <summary>
        /// Characters with a fly speed treat this skill as a class skill.
        /// </summary>
        public override bool IsClassSkill
        {
            // Characters with a fly speed treat Fly as a class skill.
            get
            {
                return (this.Character.MovementModes.Fly.BaseSpeed.HasValue || base.IsClassSkill);
            }
            set => base.IsClassSkill = value;
        }
    }
}