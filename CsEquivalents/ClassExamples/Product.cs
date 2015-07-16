using System;

namespace CsEquivalents.ClassExamples
{

    /// <summary>
    ///  Example of a simple class
    /// </summary>
    [Serializable]
    public class Product
    {
        /// <summary>
        ///  immutable Id property
        /// </summary>
        public object Id { get; internal set; }

        /// <summary>
        ///  mutable Name property
        /// </summary>
        public object Name { get; set; }

        /// <summary>
        ///  mutable Price property
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///  True if price &gt; 10.00
        /// </summary>
        public bool IsExpensive
        {
            get
            {
                return this.Price > 10.0;
            }
        }

        /// <summary>
        /// Example of static property
        /// </summary>
        public static double DefaultPrice
        {
            get
            {
                return 9.99;
            }
        }

        /// <summary>
        ///  primary constructor
        /// </summary>
        public Product(object id, object name, double price)
        {
            this.Id = id;
            this.Price = price;
            this.Name = name;
        }

        /// <summary>
        ///  secondary constructor
        /// </summary>
        public Product(object id, object name)
            : this(id, name, DefaultPrice)
        {
        }

        /// <summary>
        /// Example of method
        /// </summary>
        public bool CanBeSoldTo(string countryCode)
        {
            if (!string.Equals(countryCode, "US"))
            {
                if (!string.Equals(countryCode, "CA"))
                {
                    if (!string.Equals(countryCode, "UK"))
                    {
                        return string.Equals(countryCode, "RU") && false;
                    }
                }
            }
            return true;
        }
    }
}


