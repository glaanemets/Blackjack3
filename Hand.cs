using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    class Hand : Cards
    {
        public int handVal = 0;

        public override int AddCard(Card NewCard)
        {
            handVal += base.AddCard(NewCard);
            return handVal;
        }

    }
}
