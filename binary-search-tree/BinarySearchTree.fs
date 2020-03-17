module BinarySearchTree

type node = { value : int; left: node option; right: node option}

let left node  = node.left
let right node = node.right
let data node = node.value

let private getNode value = { left = None; right = None; value = value }

// TODO still having issues with options, in this case in the visit function
let rec private insert target newValue =
    let visit search newValue = 
        match search with
        | Some item -> insert item newValue |> Some 
        | None   -> getNode newValue |> Some

    if newValue <= target.value then 
        { target with left  = visit target.left newValue }
    else
        { target with right = visit target.right newValue }

let create = 
    function
    | head::items -> (getNode head, items) ||> List.fold (fun tree number -> insert tree number )
    | [] -> failwith "Empty list. cannot create nodes."

let rec getList node =
    match node with
    | Some node -> getList node.left @ [node.value]  @ getList node.right
    | None -> List.empty

let sortedData (root : node) = 
    getList (Some root)