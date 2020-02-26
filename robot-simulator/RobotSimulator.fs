module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }
type Rotation = Left | Right

let create direction position = { direction = direction; position = position}

let rotate robot newDirection =
    {robot with direction = newDirection}

let turn rotation robot =
    match rotation with
        |Right ->
            match robot.direction with
                | North -> rotate robot East
                | East -> rotate robot South
                | South -> rotate robot West
                | West -> rotate robot North
        |Left ->
            match robot.direction with
                | North -> rotate robot West
                | West -> rotate robot South
                | South -> rotate robot East
                | East -> rotate robot North
    
let walk robot =
    let (x, y) = robot.position
    match robot.direction with
        | North -> {robot with position = (x, y + 1)}
        | South -> {robot with position = (x, y - 1)}
        | East -> {robot with position = (x + 1, y)}
        | West -> {robot with position = (x - 1, y)}

let moveInstruction robot instruction =
    match instruction with
        | 'R' -> turn Right robot
        | 'L' -> turn Left robot
        | 'A' -> walk robot
        | _ -> failwith "Wrong Instruction"

let rec move2 instructions robot =
    let robot = Seq.head(instructions) |> moveInstruction robot
    let remainingInstructions = Seq.tail(instructions)
    if Seq.length remainingInstructions > 0 then
        move2 remainingInstructions robot
    else
        robot

let move instructions robot = Seq.fold (fun robot -> moveInstruction robot) robot instructions