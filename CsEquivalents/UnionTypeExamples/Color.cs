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

		internal readonly int _tag;

        // singletons -- one for each "enum"
		internal static readonly Color _unique_Red = new Color(0);
		internal static readonly Color _unique_Green = new Color(1);
		internal static readonly Color _unique_Blue = new Color(2);

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
        public static Color Red
		{
			get
			{
				return Color._unique_Red;
			}
		}

		public bool IsRed
		{
			get
			{
				return this.Tag == 0;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static Color Green
		{
			get
			{
				return Color._unique_Green;
			}
		}

		public bool IsGreen
		{
			get
			{
				return this.Tag == 1;
			}
		}

        /// <summary>
        ///  Static method to get one of the singletons
        /// </summary>
        public static Color Blue
		{
			get
			{
				return Color._unique_Blue;
			}
		}

		public bool IsBlue
		{
			get
			{
				return this.Tag == 2;
			}
		}

        /// <summary>
        /// private constructor 
        /// </summary>
        internal Color(int _tag)
		{
			this._tag = _tag;
		}

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
		{
			if (this != null)
			{
				switch (this.Tag)
				{
				case 0:
					return 0;
				case 1:
					return 1;
				case 2:
					return 2;
				}
				return 0;
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
        public bool Equals(object obj, IEqualityComparer comp)
		{
			if (this == null)
			{
				return obj == null;
			}
			Color color = obj as Color;
			if (color != null)
			{
				Color color2 = color;
				int tag = this._tag;
				int tag2 = color2._tag;
				return tag == tag2;
			}
			return false;
		}

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(Color obj)
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
			Color color = obj as Color;
			return color != null && this.Equals(color);
		}

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(Color obj)
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
            return this.CompareTo((Color)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            Color color = (Color)obj;
            if (this != null)
            {
                if ((Color)obj == null)
                {
                    return 1;
                }
                int tag = this._tag;
                int tag2 = color._tag;
                if (tag == tag2)
                {
                    return 0;
                }
                return tag - tag2;
            }
            else
            {
                if ((Color)obj != null)
                {
                    return -1;
                }
                return 0;
            }
        }
	}
}
