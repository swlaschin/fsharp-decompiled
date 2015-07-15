namespace UnionTypeExamples

/// example of single-case union as a wrapper round a primitive
type ProductId = ProductId of int

/// example of simple "enum"
type Color = Red | Green | Blue

/// example of a real C# enum
type ColorEnum = Red=1 | Green=2 | Blue=3

// ===========================================
// example of complex union type
// ===========================================

type CheckNumber = CheckNumber of int
type CardType = MasterCard | Visa
type CardNumber = CardNumber of string

/// PaymentMethod is cash, check or card
type PaymentMethod = 
    /// Cash needs no extra information
    | Cash
    /// Check needs a CheckNumber 
    | Check of CheckNumber 
    /// CreditCard needs a CardType and CardNumber 
    | CreditCard of CardType * CardNumber 