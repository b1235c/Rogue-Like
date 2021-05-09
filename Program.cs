using System;

namespace gridDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Game Instruction Screen
            Console.WriteLine("Welcome to our extremely basic Roguelike!");
            Console.WriteLine("*****************************************");
            Console.WriteLine("This is how to Play the Game!");
            Console.WriteLine("To Win the Game you will Need to Collect 6 Teasures!");
            Console.WriteLine("You will start with 4 health points. If you get to 0, you lose.");
            Console.WriteLine("To move: W = UP; S = DOWN, A = LEFT, D= RIGHT");
            Console.WriteLine("P = QUIT!");
            Console.WriteLine("Press Enter To Start!");
            Console.ReadLine();
            //random number generator for object placement
            Random random = new Random();
            // create a 'grid'
            int boardSize = 10;
            string[,] board = new string[boardSize, boardSize];

            // Define Symbols
            string userCharacter = "@";
            string treasure = "*";
            string spike = "^";
            // fill up the array with something
            for (int row = 0; row < boardSize; row++)
            {
                for (int column = 0; column < boardSize; column++)
                {
                    // currentCell = whatever I want to fill it up with
                    board[row, column] = ".";
                }
            }

            // items to place on boar
            int spikeOnBoardNum = 4;
            int treasureOnBoardNum = 6;
            int userLocationX = 4;
            int userLocationY = 4;

            //for loop to generate treasure locations
            for (int i = 0; i < treasureOnBoardNum; i++)
            {
                int randomTreasureX = random.Next(0, 9);
                int randomTreasureY = random.Next(0, 9);
                // while this spot is not an empty spot or this spot is the players location
                while (board[randomTreasureX, randomTreasureY] != "." || (randomTreasureX == userLocationX && randomTreasureY == userLocationY))
                {
                    randomTreasureX = random.Next(0, 9);
                    randomTreasureY = random.Next(0, 9);
                }
                board[randomTreasureX, randomTreasureY] = treasure;
            }
            // for loop to generate spikes
            for (int i = 0; i < spikeOnBoardNum; i++)
            {
                int randomSpikeX = random.Next(0, 9);
                int randomSpikeY = random.Next(0, 9);
                while (board[randomSpikeX, randomSpikeY] != "." || (randomSpikeX == userLocationX && randomSpikeY == userLocationY))
                {
                    randomSpikeX = random.Next(0, 9);
                    randomSpikeY = random.Next(0, 9);
                }
                board[randomSpikeX, randomSpikeY] = spike;
            }

            int playerHp = 4;
            int treasureCount = 0;
            int newUserLocationX = 0;
            int newUserLocationY = 0;
            //Loop to keep game going
            while (treasureCount <= treasureOnBoardNum && playerHp > 0)
            {
                Console.Clear();
                board[userLocationX, userLocationY] = userCharacter;
                // print it out
                for (int row = 0; row < boardSize; row++)
                {
                    for (int column = 0; column < boardSize; column++)
                    {
                        // print out the value in the current spot
                        Console.Write(board[row, column] + " ");
                    }
                    Console.WriteLine();
                }

                // print out score
                Console.WriteLine("Player Score: " + treasureCount);
                Console.WriteLine("Player HP: " + playerHp);

                if (treasureCount == treasureOnBoardNum)
                {
                    Console.WriteLine("        .__                           ._.       ");
                    Console.WriteLine("__  _  _|__| ____   ____   ___________| |");
                    Console.WriteLine("\\ \\/ \\/ /  |/    \\ /    \\_/ __ \\_ __ \\  |");
                    Console.WriteLine(" \\     /|  |   |  \\   |  \\  ___/|  |\\/\\ |");
                    Console.WriteLine("  \\/\\_/ |__|___|  /___|  /\\___  >__|   __");
                    Console.WriteLine("                \\/     \\/     \\/       \\/");
                    break;
                }

                //Request user key input
                Console.WriteLine("Move by pressing W, A, S, or D. Press P to quit.");
                string userTypey = Console.ReadKey(true).Key.ToString();
                // replacing the users old space
                board[userLocationX, userLocationY] = ".";


                //Series of IF statements for movement -- Need to finish adding if/else statements to avoid plunging to doom in the abyss below the board
                if (userTypey == "W")
                {
                    newUserLocationX = userLocationX - 1;
                    newUserLocationY = userLocationY;
                }
                else if (userTypey == "S")
                {
                    newUserLocationX = userLocationX + 1;
                    newUserLocationY = userLocationY;
                }
                else if (userTypey == "A")
                {
                    newUserLocationY = userLocationY - 1;
                    newUserLocationX = userLocationX;
                }
                else if (userTypey == "D")
                {
                    newUserLocationY = userLocationY + 1;
                    newUserLocationX = userLocationX;
                }
                else if (userTypey == "P")
                {
                    break;
                }
                // keep character from falling off the edge
                if (newUserLocationX >= 0 && newUserLocationX <= 9 && newUserLocationY <= 9 && newUserLocationY >= 0)
                {
                    if (board[newUserLocationX, newUserLocationY] == treasure)
                    {
                        treasureCount += 1;
                    }
                    else if (board[newUserLocationX, newUserLocationY] == spike)
                    {
                        playerHp -= 1;
                    }

                    userLocationX = newUserLocationX;
                    userLocationY = newUserLocationY;
                }
            }

            if (treasureCount < treasureOnBoardNum)
            {
                Console.WriteLine("Thanks for playing, quitter.");
            }
        }
    }
}






