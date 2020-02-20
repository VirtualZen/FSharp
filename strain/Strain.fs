module Seq

let keep pred items = seq {
    for item in items do
    // TODO: put the for contents within a separate function when code gets larger within do expression
        if pred item then
            yield item
}

let negate pred = pred >> not

let negate2 pred = not << pred // tested reverse function composition

let discard pred items = keep (negate pred) items
