using System;

namespace CsEquivalents.ClassExamples
{
    /// <summary>
    ///  Concrete class Square
    /// </summary>
    [Serializable]
    public class Square : ShapeBase
    {
        internal int size;

        /// <summary>
        ///  subclass specific property
        /// </summary>
        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public Square(string name, int size)
            : base(name)
        {
            this.size = size;
        }

        /// <summary>
        ///  concrete implementation of Draw method
        /// </summary>
        public override void Draw()
        {
            Console.Write("I am a square with size {0}", this.size);
        }
    }
}
