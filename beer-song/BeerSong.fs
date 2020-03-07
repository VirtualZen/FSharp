module BeerSong
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
let getVerse (n: int) =
    [ getStartingBottles n;
     getTakeBottleDown n + getRemainingBottlesOnWall (n-1) ]  

let recite (startBottles: int) (takeDown: int) =
    getVerse startBottles
