using System;


namespace Core.Domain.Characters.Skills
{
    internal sealed class CraftSkillSection : ICraftSkillSection
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Core.Domain.Characters.SpellRegistries.CraftSkillSection"/> class.
        /// </summary>
        /// <param name="character">The character to whom these skills belong.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when an argument is null.</exception>
        internal CraftSkillSection(ICharacter character)
        {
            if (null == character)
                throw new ArgumentNullException(nameof(character), "Arguments cannot be null.");
            this.Alchemy      = new Craft(character, "Alchemy");
            this.Armor        = new Craft(character, "Armor");
            this.Baskets      = new Craft(character, "Baskets");
            this.Books        = new Craft(character, "Books");
            this.Bows         = new Craft(character, "Bows");
            this.Calligraphy  = new Craft(character, "Calligraphy");
            this.Carpentry    = new Craft(character, "Carpentry");
            this.Cloth        = new Craft(character, "Cloth");
            this.Clothing     = new Craft(character, "Clothing");
            this.Glass        = new Craft(character, "Glass");
            this.Jewelry      = new Craft(character, "Jewelry");
            this.Leather      = new Craft(character, "Leather");
            this.Locks        = new Craft(character, "Locks");
            this.Paintings    = new Craft(character, "Paintings");
            this.Pottery      = new Craft(character, "Pottery");
            this.Sculptures   = new Craft(character, "Sculptures");
            this.Ships        = new Craft(character, "Ships");
            this.Shoes        = new Craft(character, "Shoes");
            this.Stonemasonry = new Craft(character, "Stonemasonry");
            this.Traps        = new Craft(character, "Traps");
            this.Weapons      = new Craft(character, "Weapons");
        }
        #endregion

        #region Properties
        public ISkill Alchemy { get; }

        public ISkill Armor { get; }

        public ISkill Baskets { get; }

        public ISkill Books { get; }

        public ISkill Bows { get; }

        public ISkill Calligraphy { get; }

        public ISkill Carpentry { get; }

        public ISkill Cloth { get; }

        public ISkill Clothing { get; }

        public ISkill Glass { get; }

        public ISkill Jewelry { get; }

        public ISkill Leather { get; }

        public ISkill Locks { get; }

        public ISkill Paintings { get; }

        public ISkill Pottery { get; }

        public ISkill Sculptures { get; }

        public ISkill Ships { get; }

        public ISkill Shoes { get; }

        public ISkill Stonemasonry { get; }

        public ISkill Traps { get; }

        public ISkill Weapons { get; }
        #endregion
    }
}