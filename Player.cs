using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    class Player : Hand
    {


        public string Name { get; set; }
        public int Score { get; set; }
        public bool isEnabled;
        public bool skip;

        public void AceToOne(Cards cards)
        {
            for (int i = 0; i < cards.CardCount(); i++)
            {
                if (cards.CardValue(i).Name == NAME.ACE && cards.CardValue(i).Value != 1)
                {
                    cards.CardValue(i).Value = 1;
                    break;
                }
            }
        }



    }
}
