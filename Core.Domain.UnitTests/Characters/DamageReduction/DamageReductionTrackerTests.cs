using System;
using System.Linq;
using Core.Domain.Characters.DamageReduction;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.DamageReduction
{
    [TestFixture]
    [Parallelizable]
    public class DamageReductionTrackerTests
    {
        #region Add()
        [Test(Description = "Ensures that null Func<byte> arguments cannot be fed to .Add().")]
        public void Add_NullMagnitude_Throws()
        {
            // Arrange
            Func<byte> magnitude = null;
            string bypassedBy = "—";
            var drt = new DamageReductionTracker();

            // Act
            TestDelegate add = () => drt.Add(magnitude, bypassedBy);

            // Assert
            Assert.Throws<ArgumentNullException>(add);
        }


        [Test(Description = "Ensures that null string arguments cannot be fed to .Add().")]
        public void Add_NullBybassedBy_Throws()
        {
            // Arrange
            Func<byte> magnitude = () => 1;
            string bypassedBy = null;
            var drt = new DamageReductionTracker();

            // Act
            TestDelegate add = () => drt.Add(magnitude, bypassedBy);

            // Assert
            Assert.Throws<ArgumentNullException>(add);
        }


        [Test(Description = "Ensures that empty string arguments cannot be fed to .Add().")]
        public void Add_EmptyBybassedBy_Throws()
        {
            // Arrange
            Func<byte> magnitude = () => 1;
            string bypassedBy = String.Empty;
            var drt = new DamageReductionTracker();

            // Act
            TestDelegate add = () => drt.Add(magnitude, bypassedBy);

            // Assert
            Assert.Throws<ArgumentException>(add);
        }


        [Test(Description = "Ensures that white space string arguments cannot be fed to .Add().")]
        public void Add_WhiteSpaceBybassedBy_Throws()
        {
            // Arrange
            Func<byte> magnitude = () => 1;
            string bypassedBy = " ";
            var drt = new DamageReductionTracker();

            // Act
            TestDelegate add = () => drt.Add(magnitude, bypassedBy);

            // Assert
            Assert.Throws<ArgumentException>(add);
        }
        #endregion

        #region GetAll()
        [Test(Description = "Ensures that a single damage reduction can make a round trip.")]
        public void GetAll_SimpleCase()
        {
            // Arrange
            Func<byte> magnitude = () => 1;
            string bypassedBy = "—";
            var drt = new DamageReductionTracker();
            drt.Add(magnitude, bypassedBy);

            // Act
            var result = drt.GetAll();

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(1, result[0].Magnitude());
            Assert.AreEqual("—", result[0].BypassedBy);
        }


        [Test(Description = "Ensures that DR of magnitude zero is not returned by GetAll().")]
        public void GetAll_ZeroMagnitudeIgnored()
        {
            // Arrange
            Func<byte> magnitude = () => 0;
            string bypassedBy = "—";
            var drt = new DamageReductionTracker();
            drt.Add(magnitude, bypassedBy);

            // Act
            var result = drt.GetAll();

            // Assert
            Assert.IsEmpty(result);
        }


        [Test(Description = "Ensures that when there are multiple types of DR, each bypassedBy type is returned.")]
        public void GetAll_BothTypesReturned()
        {
            // Arrange
            Func<byte> magnitude = () => 1;
            string bypassedBy1 = "—";
            string bypassedBy2 = "Silver";
            var drt = new DamageReductionTracker();
            drt.Add(magnitude, bypassedBy1);
            drt.Add(magnitude, bypassedBy2);

            // Act
            var result = drt.GetAll();

            // Assert
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result.Any(dr => bypassedBy1 == dr.BypassedBy));
            Assert.IsTrue(result.Any(dr => bypassedBy2 == dr.BypassedBy));
        }


        [Test(Description = "Ensures that when there are multiple types of DR, only the DR with maximum magnitude for each bypassedBy type is returned.")]
        public void GetAll_MaxOfEachTypeReturned()
        {
            // Arrange
            Func<byte> lowMagnitude = () => 1;
            Func<byte> highMagnitude = () => 2;
            string bypassedBy1 = "—";
            string bypassedBy2 = "Silver";
            var drt = new DamageReductionTracker();
            drt.Add(lowMagnitude, bypassedBy1);
            drt.Add(highMagnitude, bypassedBy1);
            drt.Add(lowMagnitude, bypassedBy2);
            drt.Add(highMagnitude, bypassedBy2);

            // Act
            var result = drt.GetAll();

            // Assert
            Assert.AreEqual(2, result.Length);
            Assert.IsTrue(result.Any(dr => bypassedBy1 == dr.BypassedBy && 2 == dr.Magnitude()));
            Assert.IsTrue(result.Any(dr => bypassedBy2 == dr.BypassedBy && 2 == dr.Magnitude()));
        }


        [Test(Description = "Ensures that when there are capitalization differences in bypassedBy, they are still considered to be the same type of DR.")]
        public void GetAll_IgnoresCapitalizationDifferences()
        {
            // Arrange
            Func<byte> lowMagnitude = () => 1;
            Func<byte> highMagnitude = () => 2;
            string lowercase = "silver";
            string uppercase = "Silver";
            var drt = new DamageReductionTracker();
            drt.Add(lowMagnitude, lowercase);
            drt.Add(highMagnitude, uppercase);

            // Act
            var result = drt.GetAll();

            // Assert
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(2, result[0].Magnitude());
        }
        #endregion
    }
}