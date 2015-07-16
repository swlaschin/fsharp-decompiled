using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    ///  Example of a simple immutable record 
    /// </summary>
    [Serializable]
    public sealed class FinalGameScore :
        IEquatable<FinalGameScore>,
        IStructuralEquatable,
        IComparable<FinalGameScore>,
        IComparable,
        IStructuralComparable
    {
        /// <summary>
        /// Game property
        /// </summary>
        public string Game { get; internal set; }

        /// <summary>
        /// FinalScore property
        /// </summary>
        public int FinalScore { get; internal set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        public FinalGameScore(string game, int finalScore)
        {
            this.Game = game;
            this.FinalScore = finalScore;
        }


        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            var num = 0;
            const int offset = -1640531527;
            num = offset + (this.FinalScore + ((num << 6) + (num >> 2)));
            var game = this.Game;
            return offset + (((game == null) ? 0 : game.GetHashCode()) + ((num << 6) + (num >> 2)));
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public override int GetHashCode()
        {
            return this.GetHashCode(LanguagePrimitives.GenericEqualityComparer);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(FinalGameScore obj)
        {
            return obj != null
                   && string.Equals(this.Game, obj.Game)
                   && this.FinalScore == obj.FinalScore;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var finalGameScore = obj as FinalGameScore;
            return finalGameScore != null && this.Equals(finalGameScore);
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
        public int CompareTo(FinalGameScore obj)
        {
            if (obj == null)
            {
                return 1;
            }

            int num = string.CompareOrdinal(this.Game, obj.Game);
            if (num != 0)
            {
                return num;
            }

            return this.FinalScore.CompareTo(obj.FinalScore);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj)
        {
            return this.CompareTo((FinalGameScore)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            // ignore the IComparer as a simplification -- the generated F# code is more complex
            return this.CompareTo((FinalGameScore)obj);
        }

    }
}

