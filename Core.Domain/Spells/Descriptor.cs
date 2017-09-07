namespace Core.Domain.Spells
{
	/// <summary>
	/// Descriptors subcategorize spells and have no game effect by themselves,
    /// but they govern how the spell interacts with other spells,
    /// with special abilities,
    /// with unusual creatures,
    /// with alignment,
    /// and so on.
	/// </summary>
	public enum Descriptor
    {
		/// <summary>
		/// Acid effects deal damage with chemical reactions rather than cold, electricity, heat, or vibration.
        /// This descriptor includes both actual acids and their chemical opposites (called bases or alkalines).
		/// </summary>
		Acid,

		/// <summary>
		/// Spells that create air,
        /// manipulate air,
        /// or conjure creatures from air-dominant planes or with the air subtype.
		/// </summary>
		Air,

		/// <summary>
		/// Spells that draw upon the power of true chaos
        /// or conjure creatures from chaos-aligned planes
        /// or with the chaotic subtype should have the chaos descriptor.
		/// </summary>
		Chaotic,

		/// <summary>
		/// Cold effects deal damage by making the target colder,
        /// typically by blasting it with supernaturally cooled matter or energy.
		/// </summary>
		Cold,

		/// <summary>
		/// Curses are often permanent effects, and usually cannot be dispelled.
		/// </summary>
		Curse,

		/// <summary>
		/// Spells that create darkness or reduce the amount of light should have the darkness descriptor.
		/// </summary>
		Darkness,

		/// <summary>
		/// Spells with the death descriptor directly attack a creature’s life force to cause immediate death,
        /// or to draw on the power of a dead or dying creature.
		/// </summary>
		Death,

		/// <summary>
		/// Disease effects give the target a disease,
        /// which may be an invading organism such as a bacteria or virus,
        /// an abnormal internal condition (such as a cancer or mental disorder),
        /// or a recurring magical effect that acts like one of the former.
		/// </summary>
		Disease,

		/// <summary>
		/// Spells that manipulate earth
        /// or conjure creatures from earth-dominant planes or with the earth subtype.
		/// </summary>
		Earth,

		/// <summary>
		/// Electricity effects involve the presence and flow of electrical charge,
        /// whether expressed in amperes or volts.
		/// </summary>
		Electricity,

		/// <summary>
		/// Spells with this descriptor create emotions
        /// or manipulate the target’s existing emotions.
		/// </summary>
		Emotion,

		/// <summary>
		/// Spells that draw upon evil powers
        /// or conjure creatures from evil-aligned planes or with the evil subtype.
		/// </summary>
		Evil,

		/// <summary>
		/// Spells with the fear descriptor create,
        /// enhance,
        /// or manipulate fear.
		/// </summary>
		Fear,

		/// <summary>
		/// Fire effects make the target hotter by creating fire,
        /// directly heating the target with magic or friction.
		/// </summary>
		Fire,

		/// <summary>
		/// Spells with the force descriptor create
        /// or manipulate magical force.
		/// </summary>
		Force,

		/// <summary>
		/// Spells that draw upon the power of true goodness
        /// or conjure creatures from good-aligned planes or with the good subtype.
		/// </summary>
		Good,

		/// <summary>
		/// A language-dependent spell uses intelligible language as a medium for communication.
		/// </summary>
		LanguageDependent,

		/// <summary>
		/// Spells that draw upon the power of true law
        /// or conjure creatures from law-aligned planes or with the lawful subtype.
		/// </summary>
		Lawful,

		/// <summary>
		/// Spells that create significant amounts of light
        /// or attack darkness effects should have the light descriptor.
		/// </summary>
		Light,

		/// <summary>
		/// Mindless creatures (those with an Intelligence score of "—")
        /// and undead are immune to mind-affecting effects.
		/// </summary>
		MindAffecting,

		/// <summary>
		/// Pain effects cause unpleasant sensations without any permanent physical damage.
		/// </summary>
		Pain,

		/// <summary>
		/// Poison effects use poison,
        /// venom,
        /// drugs,
        /// or similar toxic substances
        /// to disrupt and damage living creatures through chemical reactions.
		/// </summary>
		Poison,

		/// <summary>
		/// Shadow spells manipulate matter or energy from the Shadow Plane,
        /// or allow transport to or from that plane.
		/// </summary>
		Shadow,

		/// <summary>
		/// Sonic effects transmit energy to the target through
        /// frequent oscillations of pressure through the air,
        /// water,
        /// or ground.
		/// </summary>
		Sonic,

		/// <summary>
		/// Spells that manipulate water
        /// or conjure creatures from water-dominant planes or with the water subtype.
		/// </summary>
		Water,
    }
}