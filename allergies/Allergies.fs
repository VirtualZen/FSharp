module Allergies

open System

// TODO: define the Allergen type
[<Flags>]
type Allergen = 
   | None           = 0b00000000
   | Eggs           = 0b00000001
   | Peanuts        = 0b00000010
   | Shellfish      = 0b00000100
   | Strawberries   = 0b00001000
   | Tomatoes       = 0b00010000
   | Chocolate      = 0b00100000
   | Pollen         = 0b01000000
   | Cats           = 0b10000000


let allergicTo score allergen =
    enum<Allergen> (score) &&& allergen > Allergen.None

let list codedAllergies = failwith "Not Implenented."
