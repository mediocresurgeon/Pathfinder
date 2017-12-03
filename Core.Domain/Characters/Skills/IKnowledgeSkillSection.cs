namespace Core.Domain.Characters.Skills
{
    /// <summary>
    /// An ICharacter's Knowledge skills.
    /// </summary>
    public interface IKnowledgeSkillSection
    {
        /// <summary>
        /// An ICharacter's knowledge of ancient mysteries, magic traditions, and arcane symbols.
        /// </summary>
        ISkill Arcana { get; }

        /// <summary>
        /// An ICharacter's knowledge of aberrations, caverns, ozzes, and spelunking.
        /// </summary>
        ISkill Dungeoneering { get; }

        /// <summary>
        /// An ICharacter's knowledge of buildings, aqueducts, bridges, and fortifications.
        /// </summary>
        ISkill Engineering { get; }

        /// <summary>
        /// An ICharacter's knowledge of lands, terrain, climate, people, and astronomy.
        /// </summary>
        ISkill Geography { get; }

        /// <summary>
        /// An ICharacter's knowledge of wars, colonies, migrations, and the founding of cities.
        /// </summary>
        ISkill History { get; }

        /// <summary>
        /// An ICharacter's knowledge of legends, personalities, inhabitants, laws, customs, traditions, and humanoids.
        /// </summary>
        ISkill Local { get; }

        /// <summary>
        /// An ICharacter's knowledge of animals, fey, monstrous humanoids, plants, seasons and cycles, weather, and vermin.
        /// </summary>
        ISkill Nature { get; }

        /// <summary>
        /// An ICharacter's knowledge of lineages, heraldry, personalities, and royalty.
        /// </summary>
        ISkill Nobility { get; }

        /// <summary>
        /// An ICharacter's knowledge of the Inner Planes, the Outer Planes, the Astral Plane, the Ethereal Plane, outsiders, and planar magic.
        /// </summary>
        ISkill Planes { get; }

        /// <summary>
        /// An ICharacter's knowledge of gods and goddesses, mythic history, ecclesiastic tradition, holy symbols, and undead.
        /// </summary>
        ISkill Religion { get; }
    }
}