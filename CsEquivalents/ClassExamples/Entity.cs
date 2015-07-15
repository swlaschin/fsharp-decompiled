using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    ///  Example of custom equality
    /// </summary>
    [Serializable]
    public class Entity : IEquatable<Entity>
    {
        internal int _Id;
        internal string _Name;

        /// <summary>
        ///  immutable Id property
        /// </summary>
        public int Id
        {
            get
            {
                return this._Id;
            }
        }

        /// <summary>
        ///  mutable Name property
        /// </summary>
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
            }
        }

        public Entity(int id, string name)
        {
            this._Id = id;
            this._Name = name;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public override bool Equals(object obj)
        {
            Entity entity = obj as Entity;
            if (entity != null)
            {
                Entity ent = entity;
                return this.Id == ent.Id;
            }
            return false;
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


