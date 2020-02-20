module Seq

let keep pred items = seq {
    for item in items do
        if pred item then
            yield item
}

let negate pred = not << pred

let discard pred items = keep (negate pred ) items
