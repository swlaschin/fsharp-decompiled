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
        internal string _Game;
        internal int _FinalScore;
        
        /// <summary>
        /// Game property
        /// </summary>
        public string Game
        {
            get
            {
                return this._Game;
            }
        }

        /// <summary>
        /// FinalScore property
        /// </summary>
        public int FinalScore
        {
            get
            {
                return this._FinalScore;
            }
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public FinalGameScore(string game, int finalScore)
        {
            this._Game = game;
            this._FinalScore = finalScore;
        }


        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            if (this != null)
            {
                int num = 0;
                int offset = -1640531527;
                num = offset + (this._FinalScore + ((num << 6) + (num >> 2)));
                string _game = this._Game;
                return offset + (((_game == null) ? 0 : _game.GetHashCode()) + ((num << 6) + (num >> 2)));
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
        public bool Equals(FinalGameScore obj)
        {
            if (this != null)
            {
                return obj != null
                    && string.Equals(this._Game, obj._Game)
                    && this._FinalScore == obj._FinalScore;
            }
            return obj == null;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            FinalGameScore finalGameScore = obj as FinalGameScore;
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
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }

                int num = string.CompareOrdinal(this._Game, obj._Game);
                if (num != 0)
                {
                    return num;
                }

                return this._FinalScore.CompareTo(obj._FinalScore);
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

