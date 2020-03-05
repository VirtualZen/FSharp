module Allergies

open System

// TODO: define the Allergen type
[<Flags>]
type Allergen = 
//   | None           = 0b00000000
   | Eggs           = 0b00000001
   | Peanuts        = 0b00000010
   | Shellfish      = 0b00000100
   | Strawberries   = 0b00001000
   | Tomatoes       = 0b00010000
   | Chocolate      = 0b00100000
   | Pollen         = 0b01000000
   | Cats           = 0b10000000


let allergicTo score allergen =
    int (enum<Allergen> (score) &&& allergen) > 0

// TODO understand this deeper, feel that it is good code but not very readable because of the downcast
// Is it possible or necessary to make this static or evaluate just once
let enumToList<'a> =
    (System.Enum.GetValues(typeof<'a>)
    :?>
        ('a [])) |> Array.toList

let list score =
    enumToList<Allergen>
    |> List.filter (fun item -> allergicTo score item)
    
