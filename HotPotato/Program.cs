using System;
using System.Collections.Generic;

namespace HotPotato
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Program game = new Program();
            game.Run();
        }

        private void PlayHotPotatoGame(int numberOfPlayers, int eliminationInterval)
        {
            Queue<string> playersQueue = new Queue<string>();
            for (int i = 1; i <= numberOfPlayers; i++)
            {
                playersQueue.Enqueue($"Player {i}");
            }
            
            Stack<string> eliminatedPlayers = new Stack<string>();
            while (playersQueue.Count > 1)
            {
                for (int i = 1; i < eliminationInterval; i++)
                {
                    string currentPlayer = playersQueue.Dequeue();
                    playersQueue.Enqueue(currentPlayer);
                }
                string eliminationatedPlayer = playersQueue.Dequeue();
                eliminatedPlayers.Push(eliminationatedPlayer);
                Console.WriteLine($"Player {eliminationatedPlayer} is eliminated.");
            }
            
            string winner = playersQueue.Dequeue();
            Console.WriteLine($"Player {winner} wins!");
            
            Console.WriteLine("\n Order of Elimination:");
            while (eliminatedPlayers.Count>0)
            {
                Console.WriteLine(eliminatedPlayers.Pop());
            }
        }

        public void Run()
        {
            Console.Write("Enter number of players: ");
            int numberOfPlayers = int.Parse(Console.ReadLine());
            
            Console.Write("Enter elimination interval: ");
            int eliminationInterval = int.Parse(Console.ReadLine());
            PlayHotPotatoGame(numberOfPlayers, eliminationInterval);
        }
        
        
    }
}