module CircularBuffer

type CircularBuffer<'a> = { items: 'a list; size: int }

let mkCircularBuffer size = { items = []; size = size }

let clear buffer = { buffer with items = []}

// TODO struggled half an hour forgetting to put value in a list
let write value buffer =
    { buffer with items = buffer.items @ [value] }

        
let forceWrite value buffer = failwith "You need to implement this function."

let read buffer =
    match buffer.items with    
    | [] -> failwith "Cannot read from empty buffer."
    | head :: tail -> (head, {buffer with items = tail})
