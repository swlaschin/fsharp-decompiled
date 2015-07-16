using System;

namespace CsEquivalents.ClassExamples
{

    /// <summary>
    ///  Example of custom equality
    /// </summary>
    [Serializable]
    public class Entity : IEquatable<Entity>
    {
        /// <summary>
        ///  immutable Id property
        /// </summary>
        public int Id { get; internal set; }

        /// <summary>
        ///  mutable Name property
        /// </summary>
        public string Name { get; set; }

        public Entity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            if (entity == null) return false;
            return this.Id == entity.Id;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public override int GetHashCode()
        {
            return this.Id;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        bool IEquatable<Entity>.Equals(Entity ent)
        {
            return this.Id == ent.Id;
        }
    }
}


