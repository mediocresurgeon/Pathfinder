using System;
using System.Linq;
using Core.Domain.Spells;


namespace Core.Domain.Items
{
    /// <summary>
    /// An physical game item, such as an inkpen or a magical weapon.
    /// </summary>
    public abstract class Item : IItem
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Items.Item"/> class.
        /// </summary>
        protected Item()
        {
            // Intentionally blank
        }
        #endregion

        #region Virtual - Protected
        /// <summary>
        /// Returns this item's saving throw.
        /// </summary>
        protected virtual sbyte? GetSavingThrow()
        {
            if (!this.GetCasterLevel().HasValue)
                return null;
            return Convert.ToSByte(2 + (this.GetCasterLevel().Value / 2));
        }
        #endregion

        #region Virtual - Public
        /// <summary>
        /// Returns this item's fortitude saving throw.
        /// </summary>
        public virtual sbyte? GetFortitude() => GetSavingThrow();


        /// <summary>
        /// Returns this item's reflex saving throw.
        /// </summary>
        public virtual sbyte? GetReflex() => GetSavingThrow();


        /// <summary>
        /// Returns this item's will saving throw.
        /// </summary>
        public virtual sbyte? GetWill() => GetSavingThrow();


        /// <summary>
        /// Returns this item's magical aura strength.
        /// </summary>
        public virtual MagicalAuraStrength GetAuraStrength()
        {
            if (!this.GetCasterLevel().HasValue || 0 == this.GetCasterLevel().Value)
                return MagicalAuraStrength.None;
            switch (this.GetCasterLevel().Value)
            {
                case byte cl when (cl <= 5): return MagicalAuraStrength.Faint;
                case byte cl when (cl <= 11): return MagicalAuraStrength.Moderate;
                case byte cl when (cl <= 20): return MagicalAuraStrength.Strong;
                default: return MagicalAuraStrength.Overwhelming;
            }
        }


        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Item"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:Core.Domain.Items.Item"/>.</returns>
        public override string ToString()
        {
            return String.Join(" ", this.GetName().Select(nf => nf.Text));
        }
        #endregion

        #region Abstract - Public
        /// <summary>
        /// Returns the name of this item.
        /// </summary>
        public abstract INameFragment[] GetName();


        /// <summary>
        /// Returns the market price of this item.
        /// </summary>
        public abstract double GetMarketPrice();


        /// <summary>
        /// Returns the caster level of this item.
        /// </summary>
        public abstract byte? GetCasterLevel();


        /// <summary>
        /// Returns the schools of this item's magical auras.
        /// </summary>
        public abstract School[] GetSchools();


        /// <summary>
        /// Returns the weight of this item.
        /// </summary>
        public abstract double GetWeight();


        /// <summary>
        /// Returns the hardness of this item.
        /// </summary>
        public abstract byte GetHardness();


        /// <summary>
        /// Returns the hit points of this item.
        /// </summary>
        public abstract ushort GetHitPoints();
        #endregion
    }
}