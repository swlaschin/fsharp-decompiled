using System;

namespace CsEquivalents.ClassExamples
{
    /// <summary>
    ///  Abstract Base Class
    /// </summary>
    [Serializable]
    public abstract class ShapeBase : IShape
    {
        internal string name;

        /// <summary>
        ///  Explicit implementation of interface
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        ///  abstract definition of Draw method
        /// </summary>
        public abstract void Draw();

        protected ShapeBase(string name)
        {
            this.name = name;
        }

    }
}
