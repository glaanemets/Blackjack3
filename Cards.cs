using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack3
{
    class Cards
    {
        protected List<Card> cards = new List<Card>();
        bool gotCards;

        public bool GotCards
        {

            get
            {
                if (this.cards.Count < 1)
                    gotCards = false;
                return this.gotCards;
            }
            set
            {

                this.gotCards = value;
            }
        }


        public virtual int AddCard(Card NewCard)
        {
            cards.Add(NewCard);
            return NewCard.Value;
        }

        public void RemoveCard()
        {
            cards.RemoveAt(0);
        }

        public Card CardValue(int element)
        {
            return cards.ElementAt(element);
        }



        public int CardCount()
        {
            return cards.Count();
        }

        public void RemoveAllCards()
        {

        }

        public void Remove()
        {
            cards.RemoveAt(0);
        }

        public Card GetFromDeck()
        {
            Card thisCard = cards.ElementAt(0);
            cards.RemoveAt(0);
            return thisCard;
        }

        //public bool GotCards()
        //{
        //    if (cards.Count == 1)
        //    {
        //        gotCards = false;
        //        Console.WriteLine("out of cards");
        //    }

        //    return gotCards;
        //}

        //public void GotCards(bool DoYouGot)
        //{
        //    gotCards = DoYouGot;
        //}

        public void Randomize()
        {
            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card card = cards[k];
                cards[k] = cards[n];
                cards[n] = card;
            }
        }

        public void PrintAll()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                Console.WriteLine($"{cards[i].Value} {cards[i].Name}");
            }
        }

    }
}

