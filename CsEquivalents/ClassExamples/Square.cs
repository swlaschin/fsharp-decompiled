using System;

namespace CsEquivalents.ClassExamples
{
    /// <summary>
    ///  Concrete class Square
    /// </summary>
    [Serializable]
    public class Square : ShapeBase
    {
        /// <summary>
        ///  subclass specific property
        /// </summary>
        public int Size { get; internal set; }

        public Square(string name, int size)
            : base(name)
        {
            this.Size = size;
        }

        /// <summary>
        ///  concrete implementation of Draw method
        /// </summary>
        public override void Draw()
        {
            Console.Write("I am a square with size {0}", this.Size);
        }
    }
}
