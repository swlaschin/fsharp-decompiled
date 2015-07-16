using System;
using System.Collections;
using Microsoft.FSharp.Core; 

namespace CsEquivalents.UnionTypeExamples
{

	[Serializable]
	public class CheckNumber : 
        IEquatable<CheckNumber>, 
        IStructuralEquatable, 
        IComparable<CheckNumber>, 
        IComparable, 
        IStructuralComparable
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
        public static CheckNumber NewCheckNumber(int item)
		{
			return new CheckNumber(item);
		}

        /// <summary>
        /// private constructor 
        /// </summary>
        internal CheckNumber(int item)
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
        public bool Equals(CheckNumber obj)
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
			CheckNumber checkNumber = obj as CheckNumber;
			return checkNumber != null && this.Equals(checkNumber);
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
        public int CompareTo(CheckNumber obj)
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
            return this.CompareTo((CheckNumber)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((CheckNumber)obj);
        }
	}
}
