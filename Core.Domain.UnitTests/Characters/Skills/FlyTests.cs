using Core.Domain.Characters;
using Core.Domain.Characters.AbilityScores;
using Core.Domain.Characters.Movements;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.Skills
{
    [TestFixture]
    [Parallelizable]
    public class FlyTests
    {
        #region IsClassSkill
        [Test(Description = "Ensures that a character without a fly speed can toggle true/false values for Fly skill.")]
        public void IsClassSkill_NoFlySpeed_CanToggle()
        {
            var mockFlySpeed = new Mock<IFly>();
            // mockFlySpeed.Setup(f => f.BaseSpeed).Returns(null); // Redundant, since it will return null be default

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Act & Assert
            Assert.IsTrue(flySkill.ArmorCheckPenaltyApplies);
            Assert.IsFalse(flySkill.IsClassSkill);

            flySkill.IsClassSkill = true;
            Assert.IsTrue(flySkill.IsClassSkill);

            flySkill.IsClassSkill = false;
            Assert.IsFalse(flySkill.IsClassSkill);
        }


        [Test(Description = "Ensures that a character with a fly speed always treats Fly as a class skill.")]
        public void IsClassSkill_WithFlySpeed_AlwaysTrue()
        {
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Act & Assert
            Assert.IsTrue(flySkill.ArmorCheckPenaltyApplies);
            Assert.IsTrue(flySkill.IsClassSkill);

            flySkill.IsClassSkill = false;
            Assert.IsTrue(flySkill.IsClassSkill);

            flySkill.IsClassSkill = true;
            Assert.IsTrue(flySkill.IsClassSkill);
        }
        #endregion

        #region Small characters
        [Test(Description = "Ensures sensible defaults for a small character with no fly speed.")]
        public void Small_NoFlySpeed_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            // mockFlySpeed.Setup(f => f.BaseSpeed).Returns(null); // Redundant, since it will return null be default

            var dexterity = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
            Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
            Assert.AreEqual(0, flySkill.Penalties.GetTotal());
        }


        [Test(Description = "Ensures correct aggregates for a small character with perfect maneuverability.")]
        public void Small_Perfect_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
            mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Perfect);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(2, flySkill.SizeBonuses.GetTotal(),
                           "Small size gives a +2 size bonus to fly skill.");
            Assert.AreEqual(8, flySkill.UntypedBonuses.GetTotal(),
                           "Perfect maneuverability gives a +8 bonus to fly skill.");
            Assert.AreEqual(0, flySkill.Penalties.GetTotal());
        }


        [Test(Description = "Ensures correct aggregates for a small character with good maneuverability.")]
        public void Small_Good_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
            mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Good);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(2, flySkill.SizeBonuses.GetTotal(),
                           "Small size gives a +2 size bonus to fly skill.");
            Assert.AreEqual(4, flySkill.UntypedBonuses.GetTotal(),
                           "Perfect maneuverability gives a +8 bonus to fly skill.");
            Assert.AreEqual(0, flySkill.Penalties.GetTotal());
        }


        [Test(Description = "Ensures correct aggregates for a small character with average maneuverability.")]
        public void Small_Average_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
            mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Average);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(2, flySkill.SizeBonuses.GetTotal(),
                           "Small size gives a +2 size bonus to fly skill.");
            Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
            Assert.AreEqual(0, flySkill.Penalties.GetTotal());
        }


        [Test(Description = "Ensures correct aggregates for a small character with poor maneuverability.")]
        public void Small_Poor_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
            mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Poor);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(2, flySkill.SizeBonuses.GetTotal(),
                           "Small size gives a +2 size bonus to fly skill.");
            Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
            Assert.AreEqual(4, flySkill.Penalties.GetTotal(),
                           "Poor maneuverability gives -4 penalty to fly skill.");
        }


        [Test(Description = "Ensures correct aggregates for a small character with clumsy maneuverability.")]
        public void Small_Clumsy_Aggregates()
        {
            // Arrange
            var mockFlySpeed = new Mock<IFly>();
            mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
            mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Clumsy);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

            var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
            mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Small);

            var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

            // Assert
            Assert.AreEqual(2, flySkill.SizeBonuses.GetTotal(),
                           "Small size gives a +2 size bonus to fly skill.");
            Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
            Assert.AreEqual(8, flySkill.Penalties.GetTotal(),
                           "Clumsy maneuverability gives -8 penalty to fly skill.");
        }
		#endregion

		#region Medium characters
		[Test(Description = "Ensures sensible defaults for a medium character with no fly speed.")]
		public void Medium_NoFlySpeed_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			// mockFlySpeed.Setup(f => f.BaseSpeed).Returns(null); // Redundant, since it will return null be default

            var dexterity = Mock.Of<IAbilityScore>();

            var mockAbilityScores = new Mock<IAbilityScoreSection>();
            mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures correct aggregates for a small character with perfect maneuverability.")]
		public void Medium_Perfect_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Perfect);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(8, flySkill.UntypedBonuses.GetTotal(),
						   "Perfect maneuverability gives a +8 bonus to fly skill.");
			Assert.AreEqual(0, flySkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures correct aggregates for a medium character with good maneuverability.")]
		public void Medium_Good_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Good);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(4, flySkill.UntypedBonuses.GetTotal(),
						   "Perfect maneuverability gives a +8 bonus to fly skill.");
			Assert.AreEqual(0, flySkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures correct aggregates for a medium character with average maneuverability.")]
		public void Medium_Average_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Average);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures correct aggregates for a medium character with poor maneuverability.")]
		public void Medium_Poor_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Poor);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(4, flySkill.Penalties.GetTotal(),
						   "Poor maneuverability gives -4 penalty to fly skill.");
		}


		[Test(Description = "Ensures correct aggregates for a medium character with clumsy maneuverability.")]
		public void Medium_Clumsy_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Clumsy);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Medium);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(8, flySkill.Penalties.GetTotal(),
						   "Clumsy maneuverability gives -8 penalty to fly skill.");
		}
		#endregion

		#region Large characters
		[Test(Description = "Ensures sensible defaults for a large character with no fly speed.")]
		public void Large_NoFlySpeed_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			// mockFlySpeed.Setup(f => f.BaseSpeed).Returns(null); // Redundant, since it will return null be default

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.Penalties.GetTotal());
		}


		[Test(Description = "Ensures correct aggregates for a large character with perfect maneuverability.")]
		public void Large_Perfect_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Perfect);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(8, flySkill.UntypedBonuses.GetTotal(),
						   "Perfect maneuverability gives a +8 bonus to fly skill.");
			Assert.AreEqual(2, flySkill.Penalties.GetTotal(),
                           "Large characters have a -2 penalty to fly skill.");
		}


		[Test(Description = "Ensures correct aggregates for a large character with good maneuverability.")]
		public void Large_Good_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Good);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(4, flySkill.UntypedBonuses.GetTotal(),
						   "Perfect maneuverability gives a +8 bonus to fly skill.");
			Assert.AreEqual(2, flySkill.Penalties.GetTotal(),
						   "Large characters have a -2 penalty to fly skill.");
		}


		[Test(Description = "Ensures correct aggregates for a large character with average maneuverability.")]
		public void Large_Average_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Average);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(2, flySkill.Penalties.GetTotal(),
						   "Large characters have a -2 penalty to fly skill.");
		}


		[Test(Description = "Ensures correct aggregates for a large character with poor maneuverability.")]
		public void Large_Poor_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Poor);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(6, flySkill.Penalties.GetTotal(),
						   "Poor maneuverability gives -4 penalty to fly skill, and large characters have a -2 penalty to fly skill.");
		}


		[Test(Description = "Ensures correct aggregates for a large character with clumsy maneuverability.")]
		public void Large_Clumsy_Aggregates()
		{
			// Arrange
			var mockFlySpeed = new Mock<IFly>();
			mockFlySpeed.Setup(f => f.BaseSpeed)
                        .Returns(6);
			mockFlySpeed.Setup(f => f.Maneuverability)
                        .Returns(Maneuverability.Clumsy);

            var dexterity = Mock.Of<IAbilityScore>();

			var mockAbilityScores = new Mock<IAbilityScoreSection>();
			mockAbilityScores.Setup(abs => abs.Dexterity)
                             .Returns(dexterity);

			var mockSpeeds = new Mock<IMovementSection>();
			mockSpeeds.Setup(ms => ms.Fly)
                      .Returns(mockFlySpeed.Object);

			var mockCharacter = new Mock<ICharacter>();
            mockCharacter.Setup(c => c.AbilityScores)
                         .Returns(mockAbilityScores.Object);
            mockCharacter.Setup(c => c.MovementModes)
                         .Returns(mockSpeeds.Object);
			mockCharacter.Setup(c => c.Size)
                         .Returns(SizeCategory.Large);

			var flySkill = new Core.Domain.Characters.Skills.Fly(mockCharacter.Object);

			// Assert
			Assert.AreEqual(0, flySkill.SizeBonuses.GetTotal());
			Assert.AreEqual(0, flySkill.UntypedBonuses.GetTotal());
			Assert.AreEqual(10, flySkill.Penalties.GetTotal(),
						   "Clumsy maneuverability gives -8 penalty to fly skill, and large characters have a -2 penalty to fly skill.");
		}
		#endregion
	}
}