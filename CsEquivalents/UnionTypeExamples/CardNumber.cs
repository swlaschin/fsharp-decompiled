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
        public string Item { get; private set; }

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
            this.Item = item;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            int num = 0;
            const int offset = -1640531527;
            string text = this.Item;
            return offset + (((text == null) ? 0 : text.GetHashCode()) + ((num << 6) + (num >> 2)));
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
            return obj != null && string.Equals(this.Item, obj.Item);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            var cardNumber = obj as CardNumber;
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
            if (obj != null)
            {
                return string.CompareOrdinal(this.Item, obj.Item);
            }
            return 1;
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
