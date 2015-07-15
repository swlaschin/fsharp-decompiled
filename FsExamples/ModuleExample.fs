module ModuleExample


/// add two numbers
let Add x y = x + y

/// add 1 to a number
let Add1 x = x + 1


/// Create a submodule
module GameFunctions =
    open RecordTypeExamples

    /// Create a game with score=12
    let CreateGame name = {Game=name; FinalScore=12}

    /// Change the score for an existing game
    let ChangeScore newScore game = 
        {game with FinalScore=newScore}

    /// Example of a higher order function
    let MapScore f game = 
        {game with FinalScore=f game.FinalScore}
