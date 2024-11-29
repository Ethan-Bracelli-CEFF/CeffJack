using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Deck
    {
        private List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    Cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random rng = new Random();
            Cards = Cards.OrderBy(_ => rng.Next()).ToList();
        }

        public Card Draw()
        {
            if (Cards.Count == 0)
                throw new InvalidOperationException("Le deck est vide!");
            Card drawnCard = Cards[0];
            Cards.RemoveAt(0);
            return drawnCard;
        }
    }

}