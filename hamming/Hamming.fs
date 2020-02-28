module Hamming

// Piped version
let distance (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length then
        None
    else
        Array.zip (strand1.ToCharArray()) (strand2.ToCharArray())
        |> Array.filter (fun (first,second) -> first <> second )
        |> Array.length
        |> Some

// Build Tuples
let distance0 (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length then
        None
    else
        let a1 = strand1.ToCharArray()
        let a2 = strand2.ToCharArray()        
        let pairs = Array.zip a1 a2
        let filtered = Array.filter (fun (first,second) -> first <> second ) pairs
        Some (Array.length filtered)

// Array.init keep Seq.length
let distance1 (strand1: string) (strand2: string): int option =
    let keep pred items = seq {
        for item in items do
            if pred item then
                yield item
    }

    if strand1.Length <> strand2.Length then
        None
    else
        let a1 = strand1.ToCharArray()
        let a2 = strand2.ToCharArray()
        let pairs = Array.init a1.Length (fun index -> (a1.[index], a2.[index]))        
        let filtered = keep (fun (x,y) -> x<>y ) pairs
        Some (Seq.length filtered)

// for loop
let distance2 (strand1: string) (strand2: string): int option =
    if strand1.Length <> strand2.Length then
        None
    else
        let a1 = strand1.ToCharArray()
        let a2 = strand2.ToCharArray()
        let mutable count = 0
        for index in 0 .. a1.Length - 1 do
            if( a1.[index] <> a2.[index]) then
                count <- count + 1    
        Some count
