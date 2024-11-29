using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace blackjack
{
    public class Game
    {
        private Deck Deck { get; set; }
        private Player Dealer { get; set; }
        private List<Player> Players { get; set; }

        public Game(List<string> playerNames)
        {
            Deck = new Deck();
            Deck.Shuffle();

            Dealer = new Player("Croupier");
            Players = playerNames.Select(name => new Player(name)).ToList();
        }

        public void StartGame()
        {
            Draw draw = new Draw();
            while (true)
            {
                DealInitialCards();

                foreach (Player player in Players)
                {
                    PlayerTurn(player);
                }

                DealerTurn();

                DetermineWinner();

                ShowPlayers();

                CheckIfLose();

                CheckIfRemaining();

                resetGame();

                Console.Clear();
            }
        }

        private void resetGame()
        {
            foreach (Player player in Players)
            {
                player.Hand.Clear();
                player.Bet = 0;
            }
            Dealer.Hand.Clear();
            Deck = new Deck();
            Deck.Shuffle();
        }

        private void DealInitialCards()
        {
            for (int i = 0; i < 2; i++)
            {
                foreach (Player player in Players)
                    player.Hit(Deck.Draw());
                Dealer.Hit(Deck.Draw());
            }
        }

        private void PlayerTurn(Player player)
        {
            Draw draw = new Draw();
            Console.Clear();
            draw.DrawBet();
            Console.WriteLine($"\nAu tour de {player.Name} | {player.Balance}$ :");
            while (player.Bet <= 0 || player.Bet > player.Balance)
            {
                Console.Write("Entrez votre mise (all/half/votre mise) : ");
                int bet;
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input == "MartimJack")
                    {
                        Console.Clear();
                        draw.DrawBlackJack();
                        Console.ReadKey(true);
                        input = "0";
                    }

                    if (input == "all")
                    {
                        input = $"{player.Balance}";
                    }

                    if ( input == "half")
                    {
                        input = $"{player.Balance / 2}";
                    }

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.Write("Vous devez entrer une mise. Essayez encore :");
                        continue;
                    }

                    if (int.TryParse(input, out bet) && bet > 0 && bet <= player.Balance)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Entrée invalide. Veuillez entrer un montant entre 1$ et {player.Balance}$ :");
                    }
                }
                player.Bet = bet;
                Console.Clear();
                draw.TurnBet(player.Name,bet);
            }
            while (true)
            {
                if (player.CalculateScore() == 21 && player.Hand.Count == 2)
                {
                    Draw draw1 = new Draw();
                    draw.DrawBlackJack();
                    Console.ReadKey(true);
                    break;
                }
                Console.WriteLine(player);
                if (CanDoubleDown(player))
                {
                    Console.Write("Doubler, Tirer ou Rester? (d/t/r): ");
                }
                else
                {
                    Console.Write("Tirer ou Rester? (t/r): ");
                }
                string choice = Console.ReadLine().ToLower();

                if (choice == "t")
                {
                    Card card = Deck.Draw();
                    player.Hit(card);
                    int score = player.CalculateScore();
                    Console.WriteLine($"{player.Name} a tiré: {card} (Score : {score})");
                    if (player.CalculateScore() > 21)
                    {
                        Console.WriteLine($"{player.Name} a dépassé!");
                        Console.ReadKey(true);
                        break;
                    }
                    Console.ReadKey(true);
                }
                else if (choice == "r")
                {
                    break;
                }
                else if (choice == "d" && CanDoubleDown(player))
                {
                    player.Bet *= 2;
                    Card card = Deck.Draw();
                    player.Hit(card);
                    int score = player.CalculateScore();
                    Console.WriteLine($"{player.Name} a doublé et tiré: {card} (Score : {score})");
                    if (score > 21)
                    {
                        Console.WriteLine($"{player.Name} a dépassé!");
                        Console.ReadKey(true);
                        break;
                    }
                    Console.ReadKey(true);
                    break;
                }
                

            }
        }

        private void DealerTurn()
        {
            Draw draw = new Draw();
            Console.Clear();
            while (Dealer.CalculateScore() < 17)
            {
                Dealer.Hit(Deck.Draw());
            }
            draw.TurnBet(Dealer.Name,0);
            Console.WriteLine(Dealer);
            Console.ReadKey(true);
        }

        private void DetermineWinner()
        {
            Draw draw = new Draw();
            Console.Clear();
            draw.DrawResults();
            foreach (Player player in Players)
            {
                int oldBalance = player.Balance;
                int playerScore = player.CalculateScore();
                if (player.CalculateScore() == 21 && player.Hand.Count == 2)
                {
                    Console.Write($"{player.Name} a BlackJack");
                    player.Balance += (int)(player.Bet * 1.5);
                }
                else if (player.CalculateScore() > 21)
                {
                    Console.Write($"{player.Name} a perdu (dépassé)");
                    player.Balance -= player.Bet;
                }
                else if (Dealer.CalculateScore() > 21 || player.CalculateScore() > Dealer.CalculateScore())
                {
                    Console.Write($"{player.Name} a gagné");
                    player.Balance += player.Bet;
                }
                else if (player.CalculateScore() == Dealer.CalculateScore())
                {
                    Console.Write($"{player.Name} a égalé le croupier");
                }
                else
                {
                    Console.Write($"{player.Name} a perdu");
                    player.Balance -= player.Bet;
                }
                string delta = player.Balance - oldBalance > 0 ? "+" : "";
                Console.Write($" avec un Score {playerScore}, une mise de {player.Bet}$ et donc une différence de {delta}{player.Balance - oldBalance}$ par rapport à son argent de départ : {oldBalance}\n\n");

            }
            Console.ReadKey(true);
        }

        private void ShowPlayers() 
        {
            Draw draw = new Draw();
            Console.Clear();
            draw.DrawPlayersBalance();
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name} | {player.Balance}$\n");
            }
            Console.ReadKey(true);
        }

        private void CheckIfLose()
        {
            List<Player> playersToRemove = new List<Player>();

            foreach (Player player in Players)
            {
                if (player.Balance <= 0)
                {
                    Console.WriteLine($"\n{player.Name} a perdu tout son argent et est donc éliminé!");
                    Console.ReadKey(true);
                    playersToRemove.Add(player);
                }
            }

            foreach (Player player in playersToRemove)
            {
                Players.Remove(player);
            }
        }


        private void CheckIfRemaining()
        {
            if (Players.Count == 0)
            {
                Draw draw = new Draw();
                draw.DrawFinishedGame();
                Console.ReadKey(true);
                Environment.Exit(0);
            }
        }
        public bool CanDoubleDown(Player player)
        {
            return player.Hand.Count == 2 && player.Bet * 2 <= player.Balance;
        }
    }

}
