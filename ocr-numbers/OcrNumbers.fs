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

let matchSingleChar input =
    let found = table.TryFind input
    match found with
    | Some x -> x
    | None -> "?"

let (charHeight,charWidth) = (4 , 3)

// TODO try to get rid of ": list<string>" declaration
let isValidHeight (input : list<string>) =
   input.Length % charHeight = 0

let minMax (input : list<string>) =
    let lengths = [for item in input do yield item.Length]
    (List.max lengths,List.min lengths)

let isValidWidth (input : list<string>) =
    let (x,y) = minMax input
    (x=y) && (x % charWidth = 0)

let isValidSize (input : list<string>) =
    isValidHeight input && isValidWidth input

// TODO had to copy from solution
let rows (input:string list) = List.chunkBySize charHeight input
    
// TODO check how char is working, had to copy from solution
let rowToCharacters (row: string list) = 
// TODO this line will fail if rows have different lengths
    let chars = (row |> List.head |> String.length) / charWidth |> int
    let char i (str: string) = str.Substring(i * charWidth, charWidth)    
    List.init chars (fun i -> List.map (char i) row)

// TODO had to copy from solution    
let characters input = input |> rows |> List.map rowToCharacters

// TODO had to copy from solution    
let rowToDigits (row: string list list) =     
    List.map matchSingleChar row
    |> List.reduce (fun x y -> x + "" + y)
    
let convert input =
    if (isValidSize >> not) input then
        None
    else
        input
        |> characters 
        |> List.map rowToDigits
        |> List.reduce (fun x y -> x + "," + y)
        |> Some
