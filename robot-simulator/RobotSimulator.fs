module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

// not obvious constructor call, it is possible to write robot with ...
let create direction position = { direction = direction; position = position}

let rotate robot newDirection =
    {robot with direction = newDirection}

// would like to refactor moveRight and moveLeft with a single function
// to use as parameter a list of tuples [(North,East);(East,South);(South,West);(West,North);]
let moveRight robot = 
    match robot.direction with
        | North -> rotate robot East
        | East -> rotate robot South
        | South -> rotate robot West
        | West -> rotate robot North

let moveLeft robot = 
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
        | 'R' -> moveRight robot
        | 'L' -> moveLeft robot
        | 'A' -> walk robot
        | _ -> failwith "Wrong Instruction"

let rec move instructions robot =
    let robot = Seq.head(instructions) |> moveInstruction robot
    // TODO make tail work nicer, understand solution with fold
    let t = Seq.tail(instructions)
    if Seq.length t > 0 then
        move t robot
    else
        robot

        