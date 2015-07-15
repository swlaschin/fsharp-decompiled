namespace ClassExamples

open System

// ======================================
// Example of a simple class
// ======================================

/// Example of a simple class
type Product(id, name, price) = 

    /// immutable Id property
    member this.Id = id

    /// mutable Name property
    member val Name = name with get,set

    /// mutable Price property
    member val Price = price with get,set

    /// secondary constructor
    new(id,name) = Product(id,name,Product.DefaultPrice)

    /// True if price > 10.00
    member this.IsExpensive = this.Price > 10.00

    /// Example of method
    member this.CanBeSoldTo(countryCode) = 
        match countryCode with
        | "US" 
        | "CA" 
        | "UK" -> true
        | "RU" -> false
        | _  -> false   //all others
    
    /// Example of static property
    static member DefaultPrice = 9.99

// ======================================
// Class with custom equality
// ======================================

/// Example of custom equality
type Entity(id:int, name:string) = 

    /// immutable Id property
    member this.Id = id

    /// mutable Name property
    member val Name = name with get,set

    /// Implement custom equality
    override this.Equals(obj) =
        match obj with
        | :? Entity as ent -> 
            this.Id = ent.Id   // no null checking needed
        | _ ->  false // all other cases

    /// Needed for custom equality
    override this.GetHashCode() =
        hash this.Id  

    /// Implement custom equality
    interface IEquatable<Entity> with
        member this.Equals(ent) =
            this.Id = ent.Id  // no null checking needed


// ======================================
// Class Hierarchy
// ======================================

/// Interface
type IShape =
    abstract Name : string
    abstract Draw : unit -> unit


/// Abstract Base Class
[<AbstractClass>]
type ShapeBase(name) as self = 

    /// concrete implementation of Name property
    member this.Name = name

    /// abstract definition of Draw method
    abstract Draw : unit -> unit

    /// Explicit implementation of interface
    interface IShape with
        member this.Name = self.Name
        member this.Draw() = self.Draw()


/// Concrete class Square
type Square(name,size) =
    inherit ShapeBase(name)

    /// subclass specific property
    member this.Size = size

    /// concrete implementation of Draw method
    override this.Draw() =
        Console.Write("I am a square with size {0}",size)


/// Concrete class Circle
type Circle(name,radius) =
    inherit ShapeBase(name)

    /// subclass specific property
    member this.Radius = radius

    /// concrete implementation of Draw method
    override this.Draw() =
        Console.Write("I am a circle with radius {0}",radius)

