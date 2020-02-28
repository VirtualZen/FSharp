module Hamming

let distance (strand1: string) (strand2: string): int option =
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
