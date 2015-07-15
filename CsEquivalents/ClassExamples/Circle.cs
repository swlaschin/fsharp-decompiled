using System;

namespace CsEquivalents.ClassExamples
{

    /// <summary>
    ///  Concrete class Circle
    /// </summary>
    [Serializable]
    public class Circle : ShapeBase
    {
        internal int radius;

        /// <summary>
        ///  subclass specific property
        /// </summary>
        public int Radius
        {
            get
            {
                return this.radius;
            }
        }

        public Circle(string name, int radius)
            : base(name)
        {
            this.radius = radius;
        }

        /// <summary>
        ///  concrete implementation of Draw method
        /// </summary>
        public override void Draw()
        {
            Console.Write("I am a circle with radius {0}", this.radius);
        }
    }
}
