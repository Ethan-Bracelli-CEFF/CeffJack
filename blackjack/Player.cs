using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; private set; }
        public int Balance { get; set; }
        public int Bet { get; set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
            Balance = 50000;
            Bet = 0;
        }

        public void Hit(Card card)
        {
            Hand.Add(card);
        }

        public int CalculateScore()
        {
            int score = Hand.Sum(card => card.Value);
            int aceCount = Hand.Count(card => card.Rank == Rank.As);

            // Ajuste la valeur des As si le score dépasse 21.
            while (score > 21 && aceCount > 0)
            {
                score -= 10;
                aceCount--;
            }

            return score;
        }

        public override string ToString()
        {
            return $"{Name}: {string.Join(", ", Hand)} (Score: {CalculateScore()})";
        }
    }

}
