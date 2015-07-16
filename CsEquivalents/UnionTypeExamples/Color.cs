using System;
using System.Collections;
using Microsoft.FSharp.Core; 

namespace CsEquivalents.UnionTypeExamples
{

	/// <summary>
	///  example of simple "enum"
	/// </summary>
	[Serializable]
	public class Color : 
        IEquatable<Color>, 
        IStructuralEquatable, 
        IComparable<Color>, 
        IComparable, 
        IStructuralComparable
	{
		public static class Tags
		{
			public const int Red = 0;
			public const int Green = 1;
			public const int Blue = 2;
		}

	    // singletons -- one for each "enum"
		internal static readonly Color _unique_Red = new Color(0);
		internal static readonly Color _unique_Green = new Color(1);
		internal static readonly Color _unique_Blue = new Color(2);

	    /// <summary>
	    ///  Implemented for all F# union types. Used in this case to distinguish between the singletons.
	    /// </summary>
	    public int Tag { get; private set; }

	    /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static Color Red
		{
			get
			{
				return _unique_Red;
			}
		}

		public bool IsRed
		{
			get
			{
				return Tag == 0;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static Color Green
		{
			get
			{
				return _unique_Green;
			}
		}

		public bool IsGreen
		{
			get
			{
				return Tag == 1;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static Color Blue
		{
			get
			{
				return _unique_Blue;
			}
		}

		public bool IsBlue
		{
			get
			{
				return Tag == 2;
			}
		}

        /// <summary>
        /// private constructor 
        /// </summary>
        internal Color(int tag)
		{
			Tag = tag;
		}

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
		{
            return Tag;
		}

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public sealed override int GetHashCode()
		{
			return GetHashCode(LanguagePrimitives.GenericEqualityComparer);
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(Color obj)
		{
            if (obj != null)
			{
                return Tag == obj.Tag;
            }
			return false;
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
		{
			var color = obj as Color;
			return color != null && Equals(color);
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
        public int CompareTo(Color obj)
        {
            if (obj == null)
            {
                return 1;
            }

            return Tag.CompareTo(obj.Tag);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj)
        {
            return CompareTo((Color)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return CompareTo((Color)obj);
        }
	}
}
