# F# Decompiled

This repository shows what various F# code snippets look like when compiled and then decompiled into C#.  

In other words, what is the C# code you would have to write to get the same functionality as the F# code?

This is discussed in [a blog post on my site fsharpforfunandprofit.com](http://fsharpforfunandprofit.com/posts/fsharp-decompiled).


### Example: a simple immutable record

Say that you want to define a simple record type with standard requirements:

* it is immutable
* it supports equality by comparing all fields (e.g. a *value object* in DDD terminology)
* it supports comparison by comparing all fields 

The F# code might look like this:

```
/// Example of a simple immutable record 
type FinalGameScore = { 
    /// Game property
    Game: string
    /// FinalScore property
    FinalScore : int
    }
```


The equivalent C# code would look like this:

```
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
    public bool Equals(object obj, IEqualityComparer comp)
    {
        if (this == null)
        {
            return obj == null;
        }
        FinalGameScore finalGameScore = obj as FinalGameScore;
        if (finalGameScore != null)
        {
            FinalGameScore finalGameScore2 = finalGameScore;
            return string.Equals(this._Game, finalGameScore2._Game)
                && this._FinalScore == finalGameScore2._FinalScore;
        }
        return false;
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
            if (num < 0)
            {
                return num;
            }
            if (num > 0)
            {
                return num;
            }

            int _finalScore = this._FinalScore;
            int _finalScore2 = obj._FinalScore;
            if (_finalScore < _finalScore2)
            {
                return -1;
            }

            return (_finalScore > _finalScore2) ? 1 : 0;
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
        return this.CompareTo((FinalGameScore)obj);
    }

    /// <summary>
    ///  Implement custom comparison
    /// </summary>
    public int CompareTo(object obj, IComparer comp)
    {
        FinalGameScore finalGameScore = (FinalGameScore)obj;
        FinalGameScore finalGameScore2 = finalGameScore;
        if (this != null)
        {
            if ((FinalGameScore)obj == null)
            {
                return 1;
            }
            int num = string.CompareOrdinal(this._Game, finalGameScore2._Game);
            if (num < 0)
            {
                return num;
            }
            if (num > 0)
            {
                return num;
            }
            int _finalScore = this._FinalScore;
            int _finalScore2 = finalGameScore2._FinalScore;
            if (_finalScore < _finalScore2)
            {
                return -1;
            }
            return (_finalScore > _finalScore2) ? 1 : 0;
        }
        else
        {
            if ((FinalGameScore)obj != null)
            {
                return -1;
            }
            return 0;
        }
    }

}
```