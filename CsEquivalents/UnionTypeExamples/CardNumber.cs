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
        public sealed override int GetHashCode()
        {
            return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(object obj, IEqualityComparer comp)
        {
            if (this == null)
            {
                return obj == null;
            }
            CardNumber cardNumber = obj as CardNumber;
            if (cardNumber != null)
            {
                CardNumber cardNumber2 = cardNumber;
                CardNumber cardNumber3 = cardNumber2;
                return string.Equals(this.item, cardNumber3.item);
            }
            return false;
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
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(CardNumber obj)
        {
            if (this != null)
            {
                if (obj != null)
                {
                    IComparer genericComparer = LanguagePrimitives.GenericComparer;
                    return string.CompareOrdinal(this.item, obj.item);
                }
                return 1;
            }
            else
            {
                if (obj != null)
                {
                    return -1;
                }
                return 0;
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
            CardNumber cardNumber = (CardNumber)obj;
            if (this != null)
            {
                if ((CardNumber)obj != null)
                {
                    CardNumber cardNumber2 = cardNumber;
                    return string.CompareOrdinal(this.item, cardNumber2.item);
                }
                return 1;
            }
            else
            {
                if ((CardNumber)obj != null)
                {
                    return -1;
                }
                return 0;
            }
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
    }
}
