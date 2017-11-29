using System;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Characters.Spellcasting;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Spellcasting
{
    [TestFixture]
    public class CasterLevelTests
    {
        #region Constructor
        [Test(Description = "Ensures that CasterLevel cannot be created without a base value.")]
        public void Constructor_NullBaseCasterLevel_Throws()
        {
            // Arrange
            Func<byte> baseCasterLevel = null;

            // Act
            TestDelegate constructor = () => new CasterLevel(baseCasterLevel);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Properties
        [Test(Description = "Ensures that a fresh instance of CasterLevel has sensible defaults.")]
        public void Default()
        {
            // Arrange
            Func<byte> baseCasterLevel = () => 1;
            CasterLevel cl = new CasterLevel(baseCasterLevel);

            // Assert
            Assert.IsInstanceOf<UntypedBonusTracker>(cl.UntypedBonuses);
        }
        #endregion

        #region GetTotal()
        [Test(Description = "Ensures that CasterLevel.GetTotal() aggregates correctly.")]
        public void GetTotal_Aggregates()
        {
            // Arrange
            Func<byte> baseCasterLevel = () => 1;
            CasterLevel cl = new CasterLevel(baseCasterLevel);
            cl.UntypedBonuses.Add(() => 2);

            // Act
            byte total = cl.GetTotal();

            // Assert
            Assert.AreEqual(3, total,
                            "3 = (1 base) + (2 untyped)");
        }
        #endregion
    }
}