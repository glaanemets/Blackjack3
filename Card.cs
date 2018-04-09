using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    public enum SUIT
    {
        SPADES,
        CLUBS,
        DIAMONDS,
        HEARTS

    };

    public enum NAME
    {
        ACE = 1,
        TWO,
        THREE,
        FOUR,
        FIVE,
        SIX,
        SEVEN,
        EIGHT,
        NINE,
        TEN,
        JACK,
        QUEEN,
        KING,
        highACE
    };

    class Card
    {
        public SUIT Suit { get; set; }
        public NAME Name { get; set; }
        public int Value { get; set; }
    }
}
