using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Feats;
using Core.Domain.Characters.Movements;
using Core.Domain.Characters.SpellRegistries;
using Core.Domain.Items;


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

        #region Movements
        /// <summary>
        /// Gets the land speed.
        /// </summary>
        IMovement LandSpeed { get; }
        #endregion

        #region Ability scores
        /// <summary>
        /// Gets the Strength.
        /// </summary>
        IAbilityScore Strength { get; }


        /// <summary>
        /// Gets the Dexterity.
        /// </summary>
        IAbilityScore Dexterity { get; }


        /// <summary>
        /// Gets the Consitution.
        /// </summary>
        IAbilityScore Constitution { get; }


        /// <summary>
        /// Gets the Intelligence.
        /// </summary>
        IAbilityScore Intelligence { get; }


        /// <summary>
        /// Gets the Wisdom.
        /// </summary>
        IAbilityScore Wisdom { get; }


        /// <summary>
        /// Gets the Charisma.
        /// </summary>
        IAbilityScore Charisma { get; }
        #endregion

        #region Spells
        ISpellRegistrar SpellRegistrar { get; }

        ISpellbook Spellbook { get; set; }

        ICastableSpellCollection SpellsPrepared { get; }

        ICastableSpellCollection SpellsKnown { get; }

        ISpellLikeAbilityRegistrar SpellLikeAbilityRegistrar { get; }

        ISpellLikeAbilityCollection SpellLikeAbilities { get; }
        #endregion

        #region Feats
        void Train(IFeat feat);
        #endregion
    }
}