module BinarySearchTree

type node = { value : int; left: node option; right: node option}

let left node  = node.left

let right node = node.right

let data node = node.value

let createItem item = {value = item; left = None ; right = None}
    
let rec create items =
    createItem (Seq.head items) //:: create (Seq.tail items)

let sortedData node = failwith "You need to implement this function."