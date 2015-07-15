using System;
using System.Collections;
using Microsoft.FSharp.Core; 

namespace CsEquivalents.UnionTypeExamples
{

	[Serializable]
	public class CardType : IEquatable<CardType>, IStructuralEquatable, IComparable<CardType>, IComparable, IStructuralComparable
	{
		public static class Tags
		{
			public const int MasterCard = 0;
			public const int Visa = 1;
		}

		internal readonly int _tag;

        // singletons -- one for each "enum"
		internal static readonly CardType _unique_MasterCard = new CardType(0);
		internal static readonly CardType _unique_Visa = new CardType(1);

        /// <summary>
        ///  Implemented for all F# union types. Used in this case to distinguish between the singletons.
        /// </summary>
        public int Tag
		{
			get
			{
				return this._tag;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
		public static CardType MasterCard
		{
			get
			{
				return CardType._unique_MasterCard;
			}
		}

		public bool IsMasterCard
		{
			get
			{
				return this.Tag == 0;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static CardType Visa
		{
			get
			{
				return CardType._unique_Visa;
			}
		}

		public bool IsVisa
		{
			get
			{
				return this.Tag == 1;
			}
		}

        /// <summary>
        /// private constructor 
        /// </summary>
        internal CardType(int _tag)
		{
			this._tag = _tag;
		}

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
		{
			if (this == null)
			{
				return 0;
			}
			if (this.Tag == 0)
			{
				return 0;
			}
			return 1;
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
			CardType cardType = obj as CardType;
			if (cardType != null)
			{
				CardType cardType2 = cardType;
				int tag = this._tag;
				int tag2 = cardType2._tag;
				return tag == tag2;
			}
			return false;
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(CardType obj)
		{
			if (this == null)
			{
				return obj == null;
			}
			if (obj != null)
			{
				int tag = this._tag;
				int tag2 = obj._tag;
				return tag == tag2;
			}
			return false;
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
		{
			CardType cardType = obj as CardType;
			return cardType != null && this.Equals(cardType);
		}

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(CardType obj)
        {
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }
                int tag = this._tag;
                int tag2 = obj._tag;
                if (tag == tag2)
                {
                    return 0;
                }
                return tag - tag2;
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
            return this.CompareTo((CardType)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            CardType cardType = (CardType)obj;
            if (this != null)
            {
                if ((CardType)obj == null)
                {
                    return 1;
                }
                int tag = this._tag;
                int tag2 = cardType._tag;
                if (tag == tag2)
                {
                    return 0;
                }
                return tag - tag2;
            }
            else
            {
                if ((CardType)obj != null)
                {
                    return -1;
                }
                return 0;
            }
        }
	}
}
