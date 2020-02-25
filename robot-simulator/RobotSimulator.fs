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
        | _ -> {robot with position = (x    , y + 1)}


let move instructions robot =
    match instructions with
        | "R" -> moveRight robot
        | "L" -> moveLeft robot
        | "A" -> walk robot