module Seq

//easy way, almost cheating
let keep pred items = Seq.filter pred items

// manual loop, not so functional
let keep2 pred items = seq {
    for item in items do
    // TODO: put the for contents within a separate function when code gets larger within do expression
        if pred item then
            yield item
}

let negate pred = pred >> not // tested forward function composition

let negate2 pred = not << pred // tested reverse function composition

let discard pred items = keep (negate pred) items
