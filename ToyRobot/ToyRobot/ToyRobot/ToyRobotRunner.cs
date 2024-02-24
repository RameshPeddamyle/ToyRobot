using System;

// enum to cleanly identify the direction.
enum Direction
{
    NORTH,
    EAST,
    SOUTH,
    WEST
}

class ToyRobot
{
    private int x = -1;
    private int y = -1;
    private Direction? facing = null;
    private readonly int gridSize;

    // constructor to start the grid with a size being passed.
    public ToyRobot(int gridSize)
    {
        this.gridSize = gridSize;
    }

    // Method to position the robot on the grid.
    public void Place(int x, int y, Direction facing)
    {
        //validate and place the robot.
        if (IsValidPosition(x, y))
        {
            this.x = x;
            this.y = y;
            this.facing = facing;
        }
        else
        {
            Console.WriteLine("Placement failed. Invalid position.");
        }
    }

    public void Move()
    {
        // Dont do anything if not placed.
        if (!IsPlaced()) return;

        int newX = x;
        int newY = y;

        // based on the current direction of the robot, modify the values of x or y. 
        switch (facing)
        {
            case Direction.NORTH:
                newY++;
                break;
            case Direction.EAST:
                newX++;
                break;
            case Direction.SOUTH:
                newY--;
                break;
            case Direction.WEST:
                newX--;
                break;
        }

        if (IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
        }
        else
        {
            Console.WriteLine("Movement failed. Invalid move.");
        }
    }

    // Rotate anti-clockwise 90 degrees
    public void Left()
    {
        if (!IsPlaced()) return;
        // THIS IS THE MAIN LOGIC. 0 is NORTH which decrementing y and decrementally anti-clockwise directions.
        facing = (Direction)(((int)facing - 1 + 4) % 4);
    }

    // Rotate clockwise 90 degrees
    public void Right()
    {
        if (!IsPlaced()) return;
        // THIS IS THE MAIN LOGIC. 0 is NORTH which increments y and incrementally clockwise directions till 4 as east. Then if again rotated, then NORTH. Hence % to go back to 0
        facing = (Direction)(((int)facing + 1) % 4);
    }

    // Method to write the current state.
    public void Report()
    {
        if (!IsPlaced()) return;

        Console.WriteLine($"{x},{y},{facing}");
    }

    // method to validate if the given position is on the board.
    private bool IsValidPosition(int x, int y)
    {
        return x >= 0 && x < gridSize && y >= 0 && y < gridSize;
    }

    // Making sure if the given command can be executed by checing if the robot is already placed.
    private bool IsPlaced()
    {
        return x != -1 && y != -1 && facing != null;
    }
}

class ToyRobotRunner
{
    static void Main(string[] args)
    {
        // Initializing the toy robot with size 5 default. 
        ToyRobot robot = new ToyRobot(5);

        // Main runner program that takes the inputs.
        while (true)
        {
            Console.WriteLine("Enter command:");

            //Read commands from the commandline
            string input = Console.ReadLine();
            string[] inputCommand = input.Split(' ');

            if (inputCommand.Length > 0)
            {
                string command = inputCommand[0].ToUpper();

                switch (command)
                {
                    case "PLACE":
                        // validating if the input command for PLACE is correct 
                        if (inputCommand.Length == 2 && Enum.TryParse(inputCommand[1].Split(',')[2], out Direction direction))
                        {
                            int x, y;
                            if (int.TryParse(inputCommand[1].Split(',')[0], out x) && int.TryParse(inputCommand[1].Split(',')[1], out y))
                            {
                                //placing the robot once valid location is identified.
                                robot.Place(x, y, direction);
                            }
                            else
                            {
                                Console.WriteLine("Invalid parameters for PLACE command.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid parameters for PLACE command.");
                        }
                        break;
                    case "MOVE":
                        robot.Move();
                        break;
                    case "LEFT":
                        robot.Left();
                        break;
                    case "RIGHT":
                        robot.Right();
                        break;
                    case "REPORT":
                        robot.Report();
                        break;
                    default:
                        Console.WriteLine("Invalid command.");
                        break;
                }
            }
        }
    }
}
