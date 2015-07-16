using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.UnionTypeExamples
{

    /// <summary>
    ///  example of single-case union as a wrapper round a primitive
    /// </summary>
    [Serializable]
    public class ProductId :
        IEquatable<ProductId>,
        IStructuralEquatable,
        IComparable<ProductId>,
        IComparable, IStructuralComparable
    {
        internal readonly int item;

        /// <summary>
        ///  Implemented for all F# union types. Not used in this case.
        /// </summary>
        public int Tag
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        ///  Property to access wrapped value
        /// </summary>
        public int Item
        {
            get
            {
                return this.item;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static ProductId NewProductId(int item)
        {
            return new ProductId(item);
        }

        /// <summary>
        /// private constructor 
        /// </summary>
        internal ProductId(int item)
        {
            this.item = item;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            if (this != null)
            {
                int num = 0;
                return -1640531527 + (this.item + ((num << 6) + (num >> 2)));
            }
            return 0;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public sealed override int GetHashCode()
        {
            return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(ProductId obj)
        {
            if (this != null)
            {
                return obj != null && this.item == obj.item;
            }
            return obj == null;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            ProductId productId = obj as ProductId;
            return productId != null && this.Equals(productId);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(object obj, IEqualityComparer comp)
        {
            // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
            return Equals(obj);
        }


        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(ProductId obj)
        {
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }
                return this.item.CompareTo(obj.item);
            }
            else
            {
                return obj != null ? -1 : 0;
            }
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj)
        {
            return this.CompareTo((ProductId)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((ProductId)obj);
        }
    }
}
