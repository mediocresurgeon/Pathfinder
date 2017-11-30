using System;
using Core.Domain.Characters.Spellcasting;
using Moq;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Characters.SpellRegistries
{
    [TestFixture]
    [Parallelizable]
    public class SpellLikeAbilityRegisteredEventArgsTests
    {
        #region Constructor
        [Test(Description = "Ensures that SpellLikeAbilityRegisteredEventArgs will not accept null ISpellLikeAbility arguments.")]
        public void Constructor_NullArg_Throws()
        {
            // Arrange
            ISpellLikeAbility sla = null;

            // Act
            TestDelegate constructor = () => new SpellLikeAbilityRegisteredEventArgs(sla);

            // Assert
            Assert.Throws<ArgumentNullException>(constructor,
                                                 "Null arguments are not allowed.");
        }
        #endregion

        #region .SpellLikeAbility
        [Test(Description = "Ensures that the reference returned by the .SpellLikeAbility property is the same as the reference passed into the constructor.")]
        public void SpellLikeAbility_Property_RoundTrip()
        {
            // Arrange
            ISpellLikeAbility sla = Mock.Of<ISpellLikeAbility>();
            SpellLikeAbilityRegisteredEventArgs eventArgs = new SpellLikeAbilityRegisteredEventArgs(sla);

            // Act
            var result = eventArgs.SpellLikeAbility;

            // Assert
            Assert.AreSame(sla, result,
                           "The .SpellLikeAbility property should return a reference to the same object that was passed into the constructor.");
        }
        #endregion
    }
}