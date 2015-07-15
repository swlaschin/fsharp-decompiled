using System;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    ///  Example of a simple class
    /// </summary>
    [Serializable]
    public class Product
    {
        internal object _Id;
        internal object _Name;
        internal double _Price;

        /// <summary>
        ///  immutable Id property
        /// </summary>
        public object Id
        {
            get
            {
                return this._Id;
            }
        }

        /// <summary>
        ///  mutable Name property
        /// </summary>
        public object Name
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

        /// <summary>
        ///  mutable Price property
        /// </summary>
        public double Price
        {
            get
            {
                return this._Price;
            }
            set
            {
                this._Price = value;
            }
        }

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
            this._Id = id;
            this._Price = price;
            this._Name = name;
        }

        /// <summary>
        ///  secondary constructor
        /// </summary>
        public Product(object id, object name)
            : this(id, name, Product.DefaultPrice)
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


