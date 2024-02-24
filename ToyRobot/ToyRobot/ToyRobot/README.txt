Toy Robot Simulator

This is a C# implementation of a Toy Robot simulator. The program allows you to control a virtual robot on a 5x5 grid tabletop by issuing commands through the command line interface.

How to Run:

1. Clone the Repository:
   Clone this repository to your local machine using Git:

   git clone <repository_url>

2. Navigate to the Project Directory:
   Open a terminal or command prompt and navigate to the directory containing the ToyRobot project files.

   cd /path/to/ToyRobot

3. Build the Project:
   Use the dotnet build command to build the project. This command compiles the source code and generates the output binaries.

   dotnet build

4. Navigate to the Output Directory:
   Once the project is built successfully, navigate to the bin directory.

   cd bin

5. Navigate to the Debug Directory:
   Inside the bin directory, navigate to the Debug directory. This is where the compiled executable resides.

   cd Debug

6. Run the Executable:
   Once inside the Debug directory, you should see the compiled executable file (ToyRobot.exe). Run this executable to start the program.

   ToyRobot.exe

   This command will execute the ToyRobot program and start the command-line interface where you can input commands to control the toy robot.

Notes:

- The grid tabletop is fixed at 5x5 units.
- The first valid command must be PLACE.
- Invalid commands will be ignored.
- The program runs in an infinite loop until terminated manually.

Assumptions:

- Command inputs are case-insensitive.
- Inputs are assumed to be well-formed (e.g., correct number of arguments, valid commands).
- Invalid positions and moves will be reported but won't halt the simulation.

Feel free to reach out if you have any questions or need further assistance!
