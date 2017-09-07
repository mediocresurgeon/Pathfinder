using Core.Domain.Spells;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells
{
    [TestFixture]
    public class MagicMissileTests
    {
        [Test]
        public void MagicMissile_AsSorcerer()
        {
			// Act
            var spell = MagicMissile.AsSorcerer;
			// Assert
			Assert.AreEqual("Magic Missile", spell.Name);
			Assert.AreEqual(1, spell.Level);
			Assert.AreEqual(School.Evocation, spell.School);
            Assert.IsEmpty(spell.Subschools);
            Assert.That(spell.Descriptors, Has.Exactly(1).Matches<Descriptor>(d => Descriptor.Force == d));
        }

		[Test]
		public void MagicMissile_AsWizard()
		{
			// Act
            var spell = MagicMissile.AsWizard;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}
