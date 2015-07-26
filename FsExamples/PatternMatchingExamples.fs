module PatternMatchingExamples


/// demonstrates some simple pattern matching
let IntPatternMatching x = 
    match x with
    | 1 -> "1"
    | 2 -> "2"
    | 3 -> "3"
    | 4 -> "4"
    // example of guard 
    | e when x%2 = 0 -> "even" 
    // wildcard
    | _ -> "other"


type Name= {First:string; Last:string}
type Person = {Name:Name; Age:int}

/// demonstrates some nested pattern matching
let NestedPatternMatching person = 
    match person with
    | {Name={First="Jane";Last="Doe"}} -> "Jane Doe"
    | {Name={First="Jane"}} -> "Jane something"
    | {Name={Last="Doe"}} -> "something Doe"
    // example of guard 
    | {Age=age} when age > 18 -> "Adult" 
    // wildcard
    | _ -> "other"


type Email = Email of string

/// demonstrates some in-parameter pattern matching
let LowercaseEmail (Email e) = 
    e.ToLowerInvariant() |> Email


/// demonstrates some list-testing pattern matching
let ListTesting list = 
    match list with 
    | [] -> 
        sprintf "Empty list"
    | [a;b] -> 
        sprintf "Exactly two elements %A and %A" a b
    | a::b::rest -> 
        sprintf "Two or more elements starting with  %A and %A" a b
    | a::rest -> 
        sprintf "One or more elements starting with  %A" a

/// demonstrates some type-testing pattern matching
let TypeTesting obj = 
    match box obj with
    | :? string as s -> 
        sprintf "Obj is string with value %s" s
    | :? int as i -> 
        sprintf "Obj is int with value %i" i
    | :? Person as p -> 
        sprintf "Obj is Person with name %s %s" p.Name.First p.Name.Last
    | _ -> 
        sprintf "Obj is something else" 

    



