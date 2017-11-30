﻿using Core.Domain.Spells;
using Core.Domain.Spells.Paizo.CoreRulebook;
using NUnit.Framework;


namespace Core.Domain.UnitTests.Spells.Paizo.CoreRulebook
{
	[TestFixture]
    [Parallelizable]
	public class DancingLightsTests
	{
		[Test(Description = "Ensures correct property values which are not characterclass-specific.")]
		public void DancingLights_GenericProperties()
		{
			// Act
            var spell = DancingLights.BardVersion;
			// Assert
			Assert.AreEqual("Dancing Lights", spell.Name);
            Assert.IsFalse(spell.AllowsSavingThrow);
            Assert.AreEqual(School.Evocation, spell.School);
			Assert.IsEmpty(spell.Subschools);
            Assert.That(spell.Descriptors, Has.Exactly(1).Matches<Descriptor>(d => Descriptor.Light == d));
		}


		[Test]
		public void DancingLights_BardVersion()
		{
			// Act
			var spell = DancingLights.BardVersion;
			// Assert
			Assert.AreEqual(0, spell.Level);
		}


		[Test]
		public void DancingLights_SorcererVersion()
		{
			// Act
            var spell = DancingLights.SorcererVersion;
			// Assert
			Assert.AreEqual(0, spell.Level);
		}


		[Test]
		public void DancingLights_WizardVersion()
		{
			// Act
            var spell = DancingLights.WizardVersion;
			// Assert
			Assert.AreEqual(0, spell.Level);
		}
	}
}