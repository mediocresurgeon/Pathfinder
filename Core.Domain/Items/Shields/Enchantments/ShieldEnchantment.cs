using System;
using Core.Domain.Characters;
using Core.Domain.Spells;


namespace Core.Domain.Items.Shields.Enchantments
{
    internal abstract class ShieldEnchantment : IShieldEnchantment
    {
        #region Backing variables
        private readonly INameFragment _name;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Core.Domain.Items.Shields.Paizo.CoreRulebook.Enchantments.ShieldEnchantment"/> class.
        /// </summary>
        /// <param name="name">The name of the enchantment.</param>
        /// <param name="webAddress">The web address of the enchantment.</param>
        protected ShieldEnchantment(string name, string webAddress)
        {
            if (null == name)
                throw new ArgumentNullException(nameof(name), "Argument cannot be null.");
            if (null == webAddress)
                throw new ArgumentNullException(nameof(webAddress), "Argument cannot be null.");
            _name = new NameFragment(name, webAddress);
        }
        #endregion

        #region Properties
        public virtual INameFragment Name => _name;

        public abstract byte CasterLevel { get; }

        public virtual byte SpecialAbilityBonus { get; protected set; }

        public virtual double Cost { get; protected set; }
        #endregion

        #region Methods
        public abstract School[] GetSchools();

        public abstract void Enchant(Shield shield);

        public abstract void ApplyTo(ICharacter character);
        #endregion
    }
}