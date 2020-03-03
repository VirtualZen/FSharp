module OcrNumbers
let zero =
    [ " _ ";
      "| |";
      "|_|";
      "   " ]

let one =
    [ "   ";
      "  |";
      "  |";
      "   " ]

let numbers = [zero;one]

let convert input =
    if input = zero then "0"
    elif input = one then "1"
    else ""
    |> Some