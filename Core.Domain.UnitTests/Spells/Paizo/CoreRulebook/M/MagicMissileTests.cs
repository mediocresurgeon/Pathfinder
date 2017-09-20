﻿using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
    [TestFixture]
    public class MagicMissileTests
    {
        [Test]
        public void MagicMissile_SorcererVersion()
        {
			// Act
            var spell = MagicMissile.SorcererVersion;
			// Assert
			Assert.AreEqual("Magic Missile", spell.Name);
			Assert.AreEqual(1, spell.Level);
            Assert.IsFalse(spell.AllowsSavingThrow);
			Assert.AreEqual(School.Evocation, spell.School);
            Assert.IsEmpty(spell.Subschools);
            Assert.That(spell.Descriptors, Has.Exactly(1).Matches<Descriptor>(d => Descriptor.Force == d));
        }


		[Test]
		public void MagicMissile_WizardVersion()
		{
			// Act
            var spell = MagicMissile.WizardVersion;
			// Assert
			Assert.AreEqual(1, spell.Level);
		}
    }
}