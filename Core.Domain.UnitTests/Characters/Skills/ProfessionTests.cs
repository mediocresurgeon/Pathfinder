﻿using System;
using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Skills;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    public class ProfessionTests
    {
		#region Constructor
		[Test(Description = "Ensures that Profession cannot be instanciated with a null ICharacter argument.")]
		public void Constructor_NullICharacter_Throws()
		{
			// Arrange
			ICharacter character = null;
			string professionType = "Superhero";

			// Act
			TestDelegate constructor = () => new Profession(character, professionType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}


		[Test(Description = "Ensures that Profession cannot be instanciated with a null professionType argument.")]
		public void Constructor_NullCraftType_Throws()
		{
			// Arrange
			IAbilityScore wisdom = new Mock<IAbilityScore>().Object;
			var mockCharacter = new Mock<ICharacter>();
			mockCharacter.Setup(c => c.Wisdom).Returns(wisdom);
			string professionType = null;

			// Act
			TestDelegate constructor = () => new Profession(mockCharacter.Object, professionType);

			// Assert
			Assert.Throws<ArgumentNullException>(constructor);
		}
		#endregion

		[Test(Description = "Ensures a Profession skill has sensible defaults.")]
		public void Default()
		{
			// Arrange
			IAbilityScore wisdom = new Mock<IAbilityScore>().Object;
			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.Wisdom).Returns(wisdom);
			string professionType = "Superhero";

			// Act
			var profession = new Profession(mockCharacter.Object, professionType);

			// Assert
			Assert.AreSame(wisdom, profession.KeyAbilityScore);
			Assert.AreEqual("Profession (Superhero)", profession.ToString());
			Assert.IsFalse(profession.CanBeUsedUntrained);
		}
    }
}