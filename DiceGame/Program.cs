﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a board
            Board board = new Board();

            //Create list of players
            List<Player> players = new List<Player>();

            //New instance of player
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");

            //Add player to list
            players.Add(player1);
            players.Add(player2);

            //Show score
            foreach (Player player in players)
            {
                Console.WriteLine(player);
            }

            //Create Gridspace
            Gridspace gridspace = new Gridspace();

            //Create dice
            Dice dice = new Dice();


            // Loop til 50 point reached
            while (player1.familywon < 50 && player2.familywon < 50 && player1.wealthwon < 50 && player2.wealthwon < 50)

            {
                // Displays message asking player1 to press any key
                Console.WriteLine("Who will have a better life? Press any key to roll the dice.");

                // Waits for the player1 to press any key before generating number
                Console.ReadKey();

                // Generates a random number between 1 and 6 for player1
                player1.RandomNum = dice.Rnd();

                // Prints out player1's randomly generated number
                Console.WriteLine("Player 1 rolled a " + player1.RandomNum);

                Console.WriteLine("...");

                // Waits one second
                System.Threading.Thread.Sleep(1000);

                // Generates a random number between 1 and 6 for player2
                player2.RandomNum = dice.Rnd();

                // Prints out player2's randomly generated number
                Console.WriteLine("Player 2 rolled a " + player2.RandomNum);

                // If the player1 rolls higher than player2
                if (player1.RandomNum > player2.RandomNum)

                {
                    //Which gridspace would affect the player
                    gridspace.lifespace = gridspace.pointsCategory();

                    player1.RandLife = dice.RndLife();

                    if (gridspace.lifespace == 1)
                    {
                        //Increase family by multiplier
                        player1.familywon = player1.familywon + player1.RandLife;
                    }

                    if (gridspace.lifespace == 2)
                    {
                        //Increase wealth by multiplier
                        player1.wealthwon = player1.wealthwon + player1.RandLife;
                    }

                    // Display message saying player1 has won this round
                    Console.WriteLine("Player 1 gets a life!");
                }

                // If the player2 rolls higher than player1
                else if (player1.RandomNum < player2.RandomNum)
                {
                    // Which gridspace would affect the player
                    gridspace.lifespace = gridspace.pointsCategory();

                    player2.RandLife = dice.RndLife();

                    if (gridspace.lifespace == 1)
                    {
                        //Increase family by multiplier
                        player2.familywon = player2.familywon + player2.RandLife;
                    }

                    if (gridspace.lifespace == 2)
                    {
                        //Increase wealth by multiplier
                        player2.wealthwon = player2.wealthwon + player2.RandLife;
                    }

                    // Display message saying player1 has won this round
                    Console.WriteLine("Player 2 gets a life!");
                }
                // If player1 and player2 have rolled the same number
                else
                {
                    // Display message saying this round is a draw
                    Console.WriteLine("Draw!");
                }


                // Displays player1 and player2 scores
                foreach (Player player in players)
                {
                    Console.WriteLine(player);
                }

                // Creates an empty line in between each round
                Console.WriteLine();
            }

            // If the player1 reached the score needed before player2
            if (player1.wealthwon > 50 || player1.familywon > 50)
            {
                // Display a message saying player1 wins
                Console.WriteLine("Player 1 wins a better life!");
                Console.ReadKey();
            }
            // If the player2 eached the score needed before player1
            else if (player2.familywon > 50 || player2.wealthwon > 50)
            {
                // Display message saying player1 loses
                Console.WriteLine("Player 2 wins a better life!");
                Console.ReadKey();
            }
            // If player1 and player2 score the same amount of points
            else 
            {
                // Display message saying it's a draw
                Console.WriteLine("It's a draw!");
                Console.ReadKey();
            }
            // Wait for user input before console window closes
            Console.ReadKey();
        }
    }
}