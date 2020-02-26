module Seq

// manual loop, not so functional
let keep pred items = seq {
    for item in items do
    // TODO: put the for contents within a separate function when code gets larger within do expression
        if pred item then
            yield item
}

//easy way, cheating as excercise forbids using built in features
let keep2 pred items = Seq.filter pred items

//LINQ
let keep3 pred items = query {
    for item in seq items do
        where (pred item)
        select item
}

let negate pred = pred >> not // tested forward function composition

//not good practice
let negate2 pred = not << pred // tested reverse function composition

let discard pred items = keep (negate pred) items
