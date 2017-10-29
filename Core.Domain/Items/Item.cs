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
        public virtual MagicalAuraStrength AuraStrength
        {
            get
            {
                if (!this.CasterLevel.HasValue || 0 == this.CasterLevel.Value)
                    return MagicalAuraStrength.None;
                switch (this.CasterLevel.Value)
                {
                    case byte cl when (cl <= 5):  return MagicalAuraStrength.Faint;
                    case byte cl when (cl <= 11): return MagicalAuraStrength.Moderate;
                    case byte cl when (cl <= 20): return MagicalAuraStrength.Strong;
                    default:                      return MagicalAuraStrength.Overwhelming;
                }
            }
        }

        public virtual sbyte? GetFortitude() => GetSavingThrow();

        public virtual sbyte? GetReflex() => GetSavingThrow();

        public virtual sbyte? GetWill() => GetSavingThrow();

        protected virtual sbyte? GetSavingThrow()
        {
            if (!this.CasterLevel.HasValue)
                return null;
            return Convert.ToSByte(2 + (this.CasterLevel.Value / 2));
        }
        #endregion

        #region Abstract members
        public abstract double Weight { get; }

        public abstract byte? CasterLevel { get; }

        public abstract INameFragment[] GetName();

        public abstract byte GetHardness();

        public abstract ushort GetHitPoints();

        public abstract double GetMarketPrice();

        public abstract School[] GetSchools();
        #endregion
    }
}