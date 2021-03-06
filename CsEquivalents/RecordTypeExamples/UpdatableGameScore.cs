﻿using System;
using System.Collections;
using Microsoft.FSharp.Core;

namespace CsEquivalents.RecordTypeExamples
{

    /// <summary>
    /// Example of a simple mutable record without comparison
    /// </summary>
    [Serializable]
    public sealed class UpdatableGameScore :
        IEquatable<UpdatableGameScore>,
        IStructuralEquatable
    {
        /// <summary>
        /// Game property
        /// </summary>
        public string Game { get; internal set; }

        /// <summary>
        /// Mutable CurrentScore property
        /// </summary>
        public int CurrentScore { get; set; }

        /// <summary>
        /// Constructor 
        /// </summary>
        public UpdatableGameScore(string game, int currentScore)
        {
            this.Game = game;
            this.CurrentScore = currentScore;
        }

        /// <summary>
        ///  Needed for custom equality
        /// </summary>
        public int GetHashCode(IEqualityComparer comp)
        {
            int num = 0;
            const int offset = -1640531527;
            num = offset + (this.CurrentScore + ((num << 6) + (num >> 2)));
            string game = this.Game;
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
        public bool Equals(UpdatableGameScore obj)
        {
            return obj != null
                   && string.Equals(this.Game, obj.Game)
                   && this.CurrentScore == obj.CurrentScore;
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public override bool Equals(object obj)
        {
            var updatableGameScore = obj as UpdatableGameScore;
            return updatableGameScore != null && this.Equals(updatableGameScore);
        }

        /// <summary>
        ///  Implement custom equality
        /// </summary>
        public bool Equals(object obj, IEqualityComparer comp)
        {
            // ignore the IEqualityComparer as a simplification -- the generated F# code is more complex
            return Equals(obj);
        }
    }
}

