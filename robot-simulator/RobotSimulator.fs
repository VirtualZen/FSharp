module RobotSimulator

type Direction = North | East | South | West
type Position = int * int
type Robot = { direction: Direction; position: Position }

// not obvious constructor call, it is possible to write robot with ...
let create direction position = { direction = direction; position = position}

let rotate robot newDirection =
    {robot with direction = newDirection}

let move instructions robot = 
    match robot.direction with
        | North -> rotate robot East
        | East -> rotate robot South