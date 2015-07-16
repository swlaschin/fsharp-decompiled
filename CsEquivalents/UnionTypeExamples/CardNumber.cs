using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.UnionTypeExamples
{

    [Serializable]
    public class CardNumber :
        IEquatable<CardNumber>,
        IStructuralEquatable,
        IComparable<CardNumber>,
        IComparable,
        IStructuralComparable
    {
        internal readonly string item;

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
        public string Item
        {
            get
            {
                return this.item;
            }
        }

        /// <summary>
        /// static public constructor 
        /// </summary>
        public static CardNumber NewCardNumber(string item)
        {
            return new CardNumber(item);
        }

        /// <summary>
        /// private constructor 
        /// </summary>
        internal CardNumber(string item)
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
                int arg_39_0 = -1640531527;
                string text = this.item;
                return arg_39_0 + (((text == null) ? 0 : text.GetHashCode()) + ((num << 6) + (num >> 2)));
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
        public bool Equals(CardNumber obj)
        {
            if (this != null)
            {
                return obj != null && string.Equals(this.item, obj.item);
            }
            return obj == null;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            CardNumber cardNumber = obj as CardNumber;
            return cardNumber != null && this.Equals(cardNumber);
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
        public int CompareTo(CardNumber obj)
        {
            if (this != null)
            {
                if (obj != null)
                {
                    return string.CompareOrdinal(this.item, obj.item);
                }
                return 1;
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
            return this.CompareTo((CardNumber)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((CardNumber)obj);
        }


    }
}
