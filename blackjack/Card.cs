using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Card
    {
        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public int Value
        {
            get
            {
                switch (Rank)
                {
                    case Rank.Valet:
                    case Rank.Dame:
                    case Rank.Roi:
                    case Rank.Dix:
                        return 10;

                    case Rank.As:
                        return 11; // Ou 1, selon le calcul du score total.

                    case Rank.Deux:
                        return 2;

                    case Rank.Troie:
                        return 3;

                    case Rank.Quatre:
                        return 4;

                    case Rank.Cinq:
                        return 5;

                    case Rank.Six:
                        return 6;

                    case Rank.Sept:
                        return 7;

                    case Rank.Huit:
                        return 8;

                    case Rank.Neuf:
                        return 9;

                    default:
                        throw new ArgumentException("Rank inconnu");
                }
            }
        }


        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }



        public override string ToString()
        {
            string signe = "";
            switch (Suit)
            {
                case Suit.Pique:
                    signe = "♠";
                    break;
                case Suit.Coeur:
                    signe = "♥";
                    break;
                case Suit.Carreau:
                    signe = "♦";
                    break;
                case Suit.Trefle:
                    signe = "♣";
                    break;
            }
            
            return $"{Rank} de {Suit} [{signe}]";
        }
    }

    public enum Suit { Pique, Coeur, Carreau, Trefle }
    public enum Rank { Deux, Troie, Quatre, Cinq, Six, Sept, Huit, Neuf, Dix, Valet, Dame, Roi, As }

}
