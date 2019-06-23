# BattleRobots

This project is of Console type.
To run - start the BattleRobots.csproj.
Program outputs the results to Console.

The test data is in the file named BattlePlan.txt which is in the BattleRobots project directory.
You can change/add any data within the file. (Be aware that the Program assumes the data is CORRECT and will throw exceptions if the data format is incorrect/not according to the specification)

Robots will be deployed only if their starting coordinates are within the arena boundaries.

Program is designed so that the Robots can not drive through the Arena boundaries. If the Robot is against the Arena "wall" and gets a Command.M (Move) - it will stay in the same place until it can move after some Turns (Command.L, Command.R)
