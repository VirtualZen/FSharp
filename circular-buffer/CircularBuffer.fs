﻿module CircularBuffer

type CircularBuffer<'a> = { items: 'a list; size: int }

let mkCircularBuffer size = { items = []; size = size }

let clear buffer = { buffer with items = []}

// TODO struggled half an hour forgetting to put value in a list
let write value buffer =
    if buffer.items.Length = buffer.size then
        failwith "Buffer Full."
    else
        { buffer with items = buffer.items @ [value] }

        
let forceWrite value buffer =
    if buffer.items.Length = buffer.size then
        { buffer with items = buffer.items.Tail @ [value] }
    else
        { buffer with items = buffer.items @ [value] }


let read buffer =
    match buffer.items with    
    | [] -> failwith "Cannot read from empty buffer."
    | head :: tail -> (head, {buffer with items = tail})
