using System;
using Core.Domain.Spells;


namespace Core.Domain.Items
{
    /// <summary>
    /// A class which contains the basic logic for items.
    /// </summary>
    public abstract class Item : IItem
    {
        protected Item()
        {
            // Intentionally blank
        }

        #region Virtual members
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

        public virtual sbyte? GetFortitude() => GetSavingThrow();

        public virtual sbyte? GetReflex() => GetSavingThrow();

        public virtual sbyte? GetWill() => GetSavingThrow();

        protected virtual sbyte? GetSavingThrow()
        {
            if (!this.GetCasterLevel().HasValue)
                return null;
            return Convert.ToSByte(2 + (this.GetCasterLevel().Value / 2));
        }
        #endregion

        #region Abstract members
        public abstract double GetWeight();

        public abstract byte? GetCasterLevel();

        public abstract INameFragment[] GetName();

        public abstract byte GetHardness();

        public abstract ushort GetHitPoints();

        public abstract double GetMarketPrice();

        public abstract School[] GetSchools();
        #endregion
    }
}