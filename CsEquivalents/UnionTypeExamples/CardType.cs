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

	    // singletons -- one for each "enum"
		internal static readonly CardType _unique_MasterCard = new CardType(0);
		internal static readonly CardType _unique_Visa = new CardType(1);

	    /// <summary>
	    ///  Implemented for all F# union types. Used in this case to distinguish between the singletons.
	    /// </summary>
	    public int Tag { get; private set; }

	    /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
		public static CardType MasterCard
		{
			get
			{
				return _unique_MasterCard;
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
				return _unique_Visa;
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
        internal CardType(int tag)
		{
			this.Tag = tag;
		}

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
		{
            return this.Tag;
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
        public bool Equals(CardType obj)
		{
            if (obj != null)
            {
                return this.Tag == obj.Tag;
            }
            return false;
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
		{
			var cardType = obj as CardType;
			return cardType != null && this.Equals(cardType);
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
        public int CompareTo(CardType obj)
        {
            if (obj == null)
            {
                return 1;
            }
            return this.Tag.CompareTo(obj.Tag);
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
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((CardType)obj);
        }
	}
}
