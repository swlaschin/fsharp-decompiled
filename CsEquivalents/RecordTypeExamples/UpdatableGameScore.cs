using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    ///  Example of a simple mutable record 
    /// </summary>
    [Serializable]
    public sealed class UpdatableGameScore :
        IEquatable<UpdatableGameScore>,
        IStructuralEquatable,
        IComparable<UpdatableGameScore>,
        IComparable,
        IStructuralComparable
    {
        internal string _Game;
        internal int _CurrentScore;

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
        /// Mutable CurrentScore property
        /// </summary>
        public int CurrentScore
        {
            get
            {
                return this._CurrentScore;
            }
            set
            {
                this._CurrentScore = value;
            }
        }

        /// <summary>
        /// Constructor 
        /// </summary>
        public UpdatableGameScore(string game, int currentScore)
        {
            this._Game = game;
            this._CurrentScore = currentScore;
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
                num = offset + (this._CurrentScore + ((num << 6) + (num >> 2)));
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
        public bool Equals(object obj, IEqualityComparer comp)
        {
            if (this == null)
            {
                return obj == null;
            }
            UpdatableGameScore updatableGameScore = obj as UpdatableGameScore;
            if (updatableGameScore != null)
            {
                UpdatableGameScore updatableGameScore2 = updatableGameScore;
                return string.Equals(this._Game, updatableGameScore2._Game)
                    && this._CurrentScore == updatableGameScore2._CurrentScore;
            }
            return false;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(UpdatableGameScore obj)
        {
            if (this != null)
            {
                return obj != null
                    && string.Equals(this._Game, obj._Game)
                    && this._CurrentScore == obj._CurrentScore;
            }
            return obj == null;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public sealed override bool Equals(object obj)
        {
            UpdatableGameScore updatableGameScore = obj as UpdatableGameScore;
            return updatableGameScore != null && this.Equals(updatableGameScore);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(UpdatableGameScore obj)
        {
            if (this != null)
            {
                if (obj == null)
                {
                    return 1;
                }

                int num = string.CompareOrdinal(this._Game, obj._Game);
                if (num < 0)
                {
                    return num;
                }
                if (num > 0)
                {
                    return num;
                }

                int _currentScore = this._CurrentScore;
                int _currentScore2 = obj._CurrentScore;
                if (_currentScore < _currentScore2)
                {
                    return -1;
                }

                return (_currentScore > _currentScore2) ? 1 : 0;
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
            return this.CompareTo((UpdatableGameScore)obj);
        }

        /// <summary>
        ///  Implement custom comparison
        /// </summary>
        public int CompareTo(object obj, IComparer comp)
        {
            UpdatableGameScore updatableGameScore = (UpdatableGameScore)obj;
            UpdatableGameScore updatableGameScore2 = updatableGameScore;
            if (this != null)
            {
                if ((UpdatableGameScore)obj == null)
                {
                    return 1;
                }
                int num = string.CompareOrdinal(this._Game, updatableGameScore2._Game);
                if (num < 0)
                {
                    return num;
                }
                if (num > 0)
                {
                    return num;
                }
                int _currentScore = this._CurrentScore;
                int _currentScore2 = updatableGameScore2._CurrentScore;
                if (_currentScore < _currentScore2)
                {
                    return -1;
                }
                return (_currentScore > _currentScore2) ? 1 : 0;
            }
            else
            {
                if ((UpdatableGameScore)obj != null)
                {
                    return -1;
                }
                return 0;
            }
        }

    }
}

