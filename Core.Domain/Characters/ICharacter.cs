using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Initiatives;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.SavingThrows;
using Core.Domain.Characters.Skills;
using Core.Domain.Characters.SpellRegistries;


namespace Core.Domain.Characters
{
    /// <summary>
    /// An avatar for a player character.
    /// Or sometimes a game element for a game master.
    /// </summary>
    public interface ICharacter
    {
        /// <summary>
        /// Gets the level.
        /// </summary>
        byte Level { get; }

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        SizeCategory Size { get; set; }

        IMovementSection MovementModes { get; }

        IAbilityScoreSection AbilityScores { get; }

        IInitiative Initiative { get; }

        ISavingThrowSection SavingThrows { get; }

        ISkillSection Skills { get; }

        ISpellSection Spells { get; }

        ISpellLikeAbilitySection SpellLikeAbilities { get; }

        #region Feats
        void Train(IFeat feat);
        #endregion
    }
}