using System;
using System.Collections;
using Microsoft.FSharp.Core;

using CsEquivalents.RecordTypeExamples;

namespace CsSample
{

    public static class ModuleExample
    {
        /// <summary>
        ///  add two numbers
        /// </summary>
        public static int Add(int x, int y)
        {
            return x + y;
        }

        /// <summary>
        ///  add 1 to a number
        /// </summary>
        public static int Add1(int x)
        {
            return x + 1;
        }

        [Serializable]
        public class Something
        {
            public Something()                
            {
            }
        }

        /// <summary>
        ///  Create a submodule
        /// </summary>
        public static class GameFunctions
        {
            /// <summary>
            /// Create a game with score=12
            /// </summary>
            public static FinalGameScore CreateGame(string name)
            {
                return new FinalGameScore(name, 12);
            }

            /// <summary>
            /// Change the score for an existing game
            /// </summary>
            public static FinalGameScore ChangeScore(int newScore, FinalGameScore game)
            {
                return new FinalGameScore(game.Game, newScore);
            }

            /// <summary>
            ///  Example of a higher order function
            /// </summary>
            public static FinalGameScore MapScore(FSharpFunc<int, int> f, FinalGameScore game)
            {
                return new FinalGameScore(game.Game, f.Invoke(game.FinalScore));
            }
        }



    }
}