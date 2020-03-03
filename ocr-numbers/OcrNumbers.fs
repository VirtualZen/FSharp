module OcrNumbers
let zero =
    ([ " _ ";
    "| |";
    "|_|";
    "   " ] , "0")

let one =
    ([ "   ";
    "  |";
    "  |";
    "   " ] , "1")

let two =
    ([ " _ ";
    " _|";
    "|_ ";
    "   " ] , "2")

let three =
    ([ " _ ";
    " _|";
    " _|";
    "   " ] , "3")
let four =
    ([ "   ";
    "|_|";
    "  |";
    "   " ] , "4")

let five =
    ([ " _ ";
    "|_ ";
    " _|";
    "   " ] , "5")

let six =
    ([ " _ ";
    "|_ ";
    "|_|";
    "   " ] , "6")

let seven =
    ([ " _ ";
    "  |";
    "  |";
    "   " ] , "7")

let eight =
    ([ " _ ";
    "|_|";
    "|_|";
    "   " ] , "8")
let nine =
    ([ " _ ";
    "|_|";
    " _|";
    "   " ] , "9")

let numbers = [zero ; one; two; three; four; five; six; seven; eight; nine]

let table =
    Map.ofList numbers

let convert input =
    let found = table.TryFind input
    match found with
    | Some x -> x
    | None -> failwith "not found"
    |> Some
