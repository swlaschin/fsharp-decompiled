namespace RecordTypeExamples

open System

/// Example of a simple immutable record 
type FinalGameScore = { 
    /// Game property
    Game: string
    /// FinalScore property
    FinalScore : int
    }

/// Example of a simple mutable record without comparison
[<NoComparisonAttribute>]
type UpdatableGameScore = {
    /// Game property
    Game: string
    /// Mutable CurrentScore property
    mutable CurrentScore : int
    }

/// Definition of a Person
type Person = {
    /// Stores first name
    FirstName: string
    /// Stores last name
    LastName: string
    /// Stores date of birth
    DateOfBirth: DateTime
    }
    with 
    
    /// FullName property
    member this.FullName = 
        this.FirstName + " " + this.LastName

    /// IsBirthday method
    member this.IsBirthday() = 
        DateTime.Today.Month = this.DateOfBirth.Month 
        && DateTime.Today.Day = this.DateOfBirth.Day


