namespace Core.Domain.Spells
{
	/// <summary>
	/// A subschool of magic is a group of related spells that work in similar ways.
	/// It is more specific than a school.
	/// </summary>
	/// <remarks>See this page for details: http://www.d20pfsrd.com/magic#TOC-School-Subschool-</remarks>
	public enum Subschool
    {
		/// <summary>
		/// A calling spell transports a creature from another plane
        /// to the plane you are on.
		/// </summary>
		Calling,

		/// <summary>
		/// A creation spell manipulates matter to create an object
        /// or creature
        /// in the place the spellcaster designates.
		/// </summary>
		Creation,

		/// <summary>
		/// Healing spells heal creatures
        /// or even bring them back to life.
		/// </summary>
		Healing,

		/// <summary>
		/// A summoning spell instantly brings a creature
        /// or object
        /// to a place you designate.
		/// </summary>
		Summoning,

		/// <summary>
		/// A teleportation spell transports one or more creatures
        /// or objects
        /// a great distance.
		/// </summary>
		Teleportation,

		/// <summary>
		/// A scrying spell creates an invisible magical sensor that sends you information.
		/// </summary>
		Scrying,

		/// <summary>
		/// A charm spell changes how the subject views you,
        /// typically making it see you as a good friend.
		/// </summary>
		Charm,

		/// <summary>
		/// A compulsion spell forces the subject to act in some manner
        /// or changes the way its mind works.
		/// </summary>
		Compulsion,

		/// <summary>
		/// A figment spell creates a false sensation.
		/// </summary>
		Figment,

		/// <summary>
		/// A glamer spell changes a subject’s sensory qualities,
        /// making it look,
        /// feel,
        /// taste,
        /// smell,
        /// or sound
        /// like something else,
        /// or even seem to disappear.
		/// </summary>
		Glamer,

		/// <summary>
		/// A pattern spell creates an image that others can see,
        /// and affects the minds of those who see it
        /// or are caught in it.
		/// </summary>
		Pattern,

		/// <summary>
		/// A phantasm spell creates a mental image that usually only the caster
        /// and the subject (or subjects)
        /// of the spell can perceive.
		/// </summary>
		Phantasm,

		/// <summary>
		/// A shadow spell creates something that is partially real
        /// from extradimensional energy.
		/// </summary>
		Shadow,

		/// <summary>
		/// A polymorph spell transforms your physical body
        /// to take on the shape of another creature.
		/// </summary>
		Polymorph
    }
}
