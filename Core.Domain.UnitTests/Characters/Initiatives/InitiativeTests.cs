﻿using System;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Initiatives;
using Core.Domain.Characters.ModifierTrackers;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Initiatives
{
    [TestFixture]
    public class InitiativeTests
    {
        [Test(Description = "Ensures that Initiative cannot be created without an instance of IAbilityScore.")]
        public void Constructor_NullIAbilityScore_Throws()
        {
            // Arrange
            IAbilityScore abilityScore = null;

            // Act
            TestDelegate constructor = () => new Initiative(abilityScore);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor);
        }


        [Test(Description = "Ensures that Initiative has sensible defaults.")]
        public void Default()
        {
            // Arrange
            var abilityScore = Mock.Of<IAbilityScore>();
            Initiative init = new Initiative(abilityScore);

            // Assert
            Assert.AreSame(abilityScore, init.KeyAbilityScore);
            Assert.IsInstanceOf<LuckBonusTracker>(init.LuckBonuses);
            Assert.IsInstanceOf<UntypedBonusTracker>(init.UntypedBonuses);
            Assert.IsInstanceOf<PenaltyTracker>(init.Penalties);
        }


        [Test(Description = "Ensures that GetTotal() is aggregated correctly.")]
		public void GetTotal()
		{
            // Arrange
            var mockAbilityScore = new Mock<IAbilityScore>();
            mockAbilityScore.Setup(abs => abs.GetModifier()).Returns(1);

            Initiative init = new Initiative(mockAbilityScore.Object);
            init.LuckBonuses.Add(2);
            init.UntypedBonuses.Add(3);
            init.Penalties.Add(5);

            // Act
            var result = init.GetTotal();

			// Assert
            Assert.AreEqual(1, result,
                            "1 = (1 ability) + (2 luck) + (3 untyped) - (5 penalty)");
		}
    }
}