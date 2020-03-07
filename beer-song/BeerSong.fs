module BeerSong

// auxiliary functions for deduplicated version
let getRemainingBottlesOnWall n =
    match n with
    | 1 ->  sprintf "%d bottle of beer on the wall." n
    | 0 -> "no more bottles of beer on the wall."
    | -1 -> "99 bottles of beer on the wall."
    | _ -> sprintf "%d bottles of beer on the wall." n

let getStartingBottles n =
    match n with
    | 1 -> "1 bottle of beer on the wall, 1 bottle of beer."
    | 0 -> "No more bottles of beer on the wall, no more bottles of beer."
    | _ -> sprintf "%d bottles of beer on the wall, %d bottles of beer." n n
let getTakeBottleDown n =
    match n with
    | 1 -> "Take it down and pass it around, "
    | 0 -> "Go to the store and buy some more, "
    | _ -> "Take one down and pass it around, "

// Deduplicated code, but harder to understand getStartingBottles getTakeBottleDown getRemainingBottlesOnWall
let getVerse_deduplicated (n: int) =
    [ getStartingBottles n;
     getTakeBottleDown n + getRemainingBottlesOnWall (n-1) ]  

// simpler version, easier to read and understand
let getVerse (n: int) =
    match n with
    | 2 ->
        [ "2 bottles of beer on the wall, 2 bottles of beer.";
        "Take one down and pass it around, 1 bottle of beer on the wall." ]
    | 1 ->
        [ "1 bottle of beer on the wall, 1 bottle of beer.";
        "Take it down and pass it around, no more bottles of beer on the wall." ]
    | 0 ->
        [ "No more bottles of beer on the wall, no more bottles of beer.";
        "Go to the store and buy some more, 99 bottles of beer on the wall." ]
    | _ ->
        [ sprintf "%d bottles of beer on the wall, %d bottles of beer." n n;
        sprintf "Take one down and pass it around, %d bottles of beer on the wall."  (n-1) ]


let recite (startBottles: int) (takeDown: int) =
    let endBottles = startBottles - takeDown + 1
    [startBottles .. -1 .. endBottles]
    |> List.map (fun n -> getVerse n)
    // TODO collect doesnt work because of empty line
    //|> List.collect (fun x-> x)
    // TODO not obvious code, would like to have two auxiliary functions for readability
    // result @ "" appends empty line to result
    // x :: y concatenates x and y
    |> List.reduce (fun result items -> result @ "" :: items)
