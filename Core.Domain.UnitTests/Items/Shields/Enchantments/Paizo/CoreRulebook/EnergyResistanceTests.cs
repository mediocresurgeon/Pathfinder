using System;
using System.Reflection;
using Core.Domain.Characters;
using Core.Domain.Characters.ModifierTrackers;
using Core.Domain.Items.Shields.Enchantments.Paizo.CoreRulebook;
using Core.Domain.Spells;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Items.Shields.Enchantments.Paizo.CoreRulebook
{
    [TestFixture]
    [Parallelizable]
    public class EnergyResistanceTests
    {
        #region Constructor
        [Test(Description = "Ensures that EnergyResistance cannot be instanciated with a null element argument.")]
        public void Constructor_NullElement_Throws()
        {
            // Arrange
            string elementName = null;
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;


            // Act
            TestDelegate constructor = () =>
            {
                var mockEnergyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true };
                var energyResistance = mockEnergyResistance.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentNullException>(outerException.InnerException);
        }


        [Test(Description = "Ensures that EnergyResistance cannot be instanciated with an element argument.")]
        public void Constructor_EmptyElement_Throws()
        {
            // Arrange
            string elementName = String.Empty;
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;


            // Act
            TestDelegate constructor = () =>
            {
                var mockEnergyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true };
                var energyResistance = mockEnergyResistance.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentException>(outerException.InnerException);
        }


        [Test(Description = "Ensures that EnergyResistance cannot be instanciated with a whitespace element argument.")]
        public void Constructor_WhiteSpaceElement_Throws()
        {
            // Arrange
            string elementName = " ";
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;


            // Act
            TestDelegate constructor = () =>
            {
                var mockEnergyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true };
                var energyResistance = mockEnergyResistance.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentException>(outerException.InnerException);
        }


        [Test(Description = "Ensures that EnergyResistance cannot be instanciated with null energyResistanceExpression argument.")]
        public void Constructor_NullResistanceExpression_Throws()
        {
            // Arrange
            string elementName = "Force";
            Func<ICharacter, IModifierTracker> resistanceExpression = null;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;


            // Act
            TestDelegate constructor = () =>
            {
                var mockEnergyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true };
                var energyResistance = mockEnergyResistance.Object;
            };

            // Assert
            var outerException = Assert.Throws<TargetInvocationException>(constructor);
            Assert.IsInstanceOf<ArgumentNullException>(outerException.InnerException);
        }
        #endregion

        #region ApplyTo
        [Test(Description = "Ensures that ApplyTo(ICharacter) does not accept null arguments.")]
        public void ApplyTo_NullCharacter_Throws()
        {
            // Arrange
            string elementName = "Force";
            var forceResistance = Mock.Of<IModifierTracker>();
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => forceResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;

            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Act
            TestDelegate constructor = () => energyResistance.ApplyTo(null);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }
        #endregion

        #region Energy Resistance 10
        [Test(Description = "Ensures that a fresh instance of Energy Resistance 10 has sensible defaults.")]
        public void Regular_Default()
        {
            // Arrange
            string elementName = "Force";
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;

            // Act
            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Assert
            Assert.AreEqual("Force Resistance", energyResistance.Name.Text);
            Assert.AreEqual(0, energyResistance.SpecialAbilityBonus);
            Assert.AreEqual(18_000, energyResistance.Cost);
            Assert.AreEqual(3, energyResistance.CasterLevel);
            Assert.AreEqual(1, energyResistance.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, energyResistance.GetSchools()[0]);
        }


        [Test(Description = "Ensures that a Regular-level energy resistance applies energy resistance of 10.")]
        public void Regular_ApplyTo_NullCharacter_Throws()
        {
            // Arrange
            string elementName = "Force";
            var forceResistance = Mock.Of<IModifierTracker>();
            Func<ICharacter, IModifierTracker> resistanceExpression = (c) => forceResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Regular;

            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Act
            energyResistance.ApplyTo(Mock.Of<ICharacter>());

            // Assert
            Mock.Get(forceResistance)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 10 == calc())),
                        "Energy Resistance should add 10 to the character's energy resistance.");
        }
        #endregion

        #region Energy Resistance 20
        [Test(Description = "Ensures that a fresh instance of Energy Resistance 20 has sensible defaults.")]
        public void Improved_Default()
        {
            // Arrange
            string elementName = "Force";
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Improved;

            // Act
            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Assert
            Assert.AreEqual("Improved Force Resistance", energyResistance.Name.Text);
            Assert.AreEqual(0, energyResistance.SpecialAbilityBonus);
            Assert.AreEqual(42_000, energyResistance.Cost);
            Assert.AreEqual(7, energyResistance.CasterLevel);
            Assert.AreEqual(1, energyResistance.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, energyResistance.GetSchools()[0]);
        }


        [Test(Description = "Ensures that a Improved-level energy resistance applies energy resistance of 20.")]
        public void Improved_ApplyTo_NullCharacter_Throws()
        {
            // Arrange
            string elementName = "Force";
            var forceResistance = Mock.Of<IModifierTracker>();
            Func<ICharacter, IModifierTracker> resistanceExpression = (c) => forceResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Improved;

            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Act
            energyResistance.ApplyTo(Mock.Of<ICharacter>());

            // Assert
            Mock.Get(forceResistance)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 20 == calc())),
                        "Improved Energy Resistance should add 20 to the character's energy resistance.");
        }
        #endregion

        #region Energy Resistance 30
        [Test(Description = "Ensures that a fresh instance of Energy Resistance 30 has sensible defaults.")]
        public void Greater_Default()
        {
            // Arrange
            string elementName = "Force";
            Func<ICharacter, IModifierTracker> resistanceExpression = (character) => character.EnergyResistances.AcidResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Greater;

            // Act
            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Assert
            Assert.AreEqual("Greater Force Resistance", energyResistance.Name.Text);
            Assert.AreEqual(0, energyResistance.SpecialAbilityBonus);
            Assert.AreEqual(66_000, energyResistance.Cost);
            Assert.AreEqual(11, energyResistance.CasterLevel);
            Assert.AreEqual(1, energyResistance.GetSchools().Length);
            Assert.AreEqual(School.Abjuration, energyResistance.GetSchools()[0]);
        }


        [Test(Description = "Ensures that a Greater-level energy resistance applies energy resistance of 30.")]
        public void Greater_ApplyTo_NullCharacter_Throws()
        {
            // Arrange
            string elementName = "Force";
            var forceResistance = Mock.Of<IModifierTracker>();
            Func<ICharacter, IModifierTracker> resistanceExpression = (c) => forceResistance;
            EnergyResistanceMagnitude protectionLevel = EnergyResistanceMagnitude.Greater;

            var energyResistance = new Mock<EnergyResistance>(MockBehavior.Loose, elementName, resistanceExpression, protectionLevel) { CallBase = true }.Object;

            // Act
            energyResistance.ApplyTo(Mock.Of<ICharacter>());

            // Assert
            Mock.Get(forceResistance)
                .Verify(er => er.Add(It.Is<Func<byte>>(calc => 30 == calc())),
                        "Greater Energy Resistance should add 30 to the character's energy resistance.");
        }
        #endregion
    }
}