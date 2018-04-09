using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    class Game
    {
        public Game(int howManyPlayers)
        {
        
            List<Player> players = CreatePlayer(howManyPlayers);
            Cards deck = Deck();
            deck.Randomize();
            AddCardsToPlayer(2, players, deck);
            Console.WriteLine("new game started");
            while (deck.GotCards && PlayerCount(players) > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    PlayerInterface(players, deck);
                    if (deck.GotCards && players[i].isEnabled && !players[i].skip)
                    {
                        Console.WriteLine($"{players[i].Name} turn");
                        Char otsus = GetKeyPress("Press a for new card, b for skip", new Char[] { 'A', 'B', 'C' });
                        switch (otsus)
                        {
                            case 'A':
                            case 'a':
                                if (players[i].AddCard(deck.GetFromDeck()) > 21)
                                    players[i].isEnabled = false;
                                break;
                            case 'B':
                            case 'b':
                                players[i].skip = true;
                                break;
                            case 'C':
                            case 'c':
                                break;
                        }
                        
                    }
                    else
                    {
                    }
                }
            }
            PlayerInterface(players, deck);
            Winners(players);
            Console.WriteLine("out of cards");
        }

        public Cards Deck()
        {
            Cards cards = new Cards();
            int value = 0;
            cards.GotCards = true;
            //cards.GotCards(true);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 13; j++)
                {
                    if (j <= 9)
                        value = j;
                    else
                        value = 10;

                    cards.AddCard(new Card() { Suit = (SUIT)i, Name = (NAME)j, Value = value });

                }
            }
            return cards;
        }

        private static Char GetKeyPress(String msg, Char[] validChars)
        {
            ConsoleKeyInfo keyPressed;
            bool valid = false;

            Console.WriteLine();
            do
            {
                Console.Write(msg);
                keyPressed = Console.ReadKey();
                Console.WriteLine();
                if (Array.Exists(validChars, ch => ch.Equals(Char.ToUpper(keyPressed.KeyChar))))
                    valid = true;

            } while (!valid);
            return keyPressed.KeyChar;
        }

        public List<Player> CreatePlayer(int howManyPlayers)
        {
            List<Player> players = new List<Player>();

            for (int i = 0; i < howManyPlayers; i++)
            {
                Console.WriteLine($"Enter player nr{i} name");
                string getName = Console.ReadLine();
                if (getName == null)
                {
                    Console.WriteLine("sth went wrong");
                    i--;
                }
                else
                {
                    players.Add(new Player { Name = getName, isEnabled = true });
                }
            }
            return players;
        }

        void AddCardsToPlayer(int howManyCards, List<Player> players, Cards deck)
        {
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < howManyCards; j++)
                {
                    players[i].AddCard(deck.GetFromDeck());
                }
                
            }
        }

        int PlayerCount(List<Player> players)
        {
            int playeables = 0;
            foreach (Player player in players)
                if(player.isEnabled && !player.skip)
                    playeables++;
            return playeables;
        }

        void PlayerInterface(List<Player> players, Cards deck)
        {
            Console.Clear();
            Console.WriteLine($"{deck.CardCount()} cards left in deck\n");
            foreach(Player player in players)
            {
                Console.WriteLine($"{player.Name} handval:{player.handVal}");
                if (!player.isEnabled)
                    Console.WriteLine("bust");
                if (player.skip)
                    Console.WriteLine("skip");
                if(player.handVal == 21)
                {
                    Console.WriteLine("blackjack!");
                    player.skip = true;
                }
                for (int i = 0; i < player.CardCount(); i++)
                {
                    Console.WriteLine($"{player.CardValue(i).Name} of {player.CardValue(i).Suit}");
                }
                Console.WriteLine();
            }
        }

        void Winners(List<Player> players)
        {
            int maxHandVal = 0;
            Console.WriteLine("winnders");
            for (int i = 0; i < players.Count; i++)
            {
                if (maxHandVal < players[i].handVal && players[i].isEnabled)
                {
                    maxHandVal = players[i].handVal;
                    Console.WriteLine($"{players[i].Name} {players[i].handVal} {maxHandVal} {players[i].isEnabled}");
                }
                    //maxHandVal = players[i].handVal;
            }

            foreach(Player player in players)
                if(player.handVal == maxHandVal)
                    Console.WriteLine($"Winner {player.Name}");


        }
    }
}
