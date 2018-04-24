using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartes
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //}


        enum Color
        {
            Spade, Diamond, Club, Hearth
        }

        enum Value
        {
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace
        }

        class GameException : Exception
        {

        }

        class Card
        {
            public Color color;
            public Value value;

            public Card(Color c, Value v)
            {
                this.color = c;
                this.value = v;
            }
        }

        class Deck
        {
            private List<Card> cards;

            private void initDeck(int nb_cards)
            {
                int nb_card_distribute = 0;
                while (nb_card_distribute < nb_cards)
                {
                    foreach (Color c in Enum.GetValues(typeof(Color)))
                    {
                        if (nb_card_distribute >= nb_cards)
                            break;
                        foreach (Value v in Enum.GetValues(typeof(Value)))
                        {
                            if (nb_card_distribute >= nb_cards)
                                break;
                            cards.Add(new Card(c, v));
                            nb_card_distribute++;
                        }
                    }
                }
            }

            public Deck(int nb_cards)
            {
                if (nb_cards % 4 != 0)
                    throw new GameException();
                cards = new List<Card>(nb_cards);
                initDeck(nb_cards);
            }

            public int size()
            {
                return cards.Count;
            }

            public List<Card> displayDeck()
            {
                return cards;
            }

            public void shuffle()
            {
                //Collections.shuffle(cards);

            }
        }

        class Player
        {
            private List<Card> hand = new List<Card>(); // TODO
            private int indexDia = 0;
            private int indexClub = 0;
            private int indexHeart = 0;
            private int indexSpade = 0;
            private String name;


            public Player(String name)
            {
                this.name = name;
            }

            public void addInPosition(int indiceCouleurMax, Card c)
            {
                int borneInf = indiceCouleurMax;
                while ((borneInf > 0) && ((int)c.value < (int)hand[borneInf].value) && ((int)hand[borneInf].color == (int)c.color))
                {
                    borneInf--;
                }
                //hand.add(borneInf + 1, c);
                hand.Insert(borneInf + 1, c);
            }
            public List<Card> getHand()
            {
                return hand;
            }

            public void addCard(Card c)
            {

                if (hand.Contains(c))
                {
                    throw new GameException();
                }
                else
                {
                    switch (c.color)
                    {
                        case Color.Spade:
                            if (indexSpade != 0)
                            {
                                addInPosition(indexSpade - 1, c);
                            }
                            else
                            {
                                hand.Insert(0, c);
                                //hand.add(0,c);
                            }
                            indexClub++;
                            indexDia++;
                            indexSpade++;
                            indexHeart++;
                            break;
                        case Color.Diamond:
                            if (indexDia != 0)
                            {
                                addInPosition(indexDia - 1, c);
                            }
                            else
                            {
                                hand.Insert(0, c);
                                //hand.add(0,c);
                            }
                            indexClub++;
                            indexDia++;
                            indexHeart++;
                            break;
                        case Color.Club:
                            if (indexClub != 0)
                            {
                                addInPosition(indexClub - 1, c);
                            }
                            else
                            {
                                hand.Insert(0, c);
                                //hand.Add(0,c);
                            }
                            indexClub++;
                            indexHeart++;
                            break;
                        case Color.Hearth:
                            if (indexSpade != 0)
                            {
                                addInPosition(indexHeart - 1, c);
                            }
                            else
                            {
                                hand.Insert(0, c);
                                //hand.Add(0,c);
                            }
                            indexHeart++;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        class Game
        {
            private int nb_player;
            private int nb_card;
            private Deck deck;
            private List<Player> players;

            public Game(int nb_player, int nb_card)
            {
                this.nb_player = nb_player;
                this.nb_card = nb_card;
                this.players = initPlayers(nb_player);
                this.deck = initDeck(nb_card);
            }

            public Game(int nb_player, Deck deck)
            {
                this.players = initPlayers(nb_player);
                this.deck = deck;
            }

            private Deck initDeck(int nb_card)
            {
                return new Deck(nb_card);
            }

            private List<Player> initPlayers(int nb_player)
            {
                List<Player> p = new List<Player>();
                for (int i = 0; i < nb_player; i++)
                {
                    p.Add(new Player("player " + i));
                }
                return p;
            }

            public Deck getDeck()
            {
                return deck;
            }

            List<Player> getPlayers()
            {
                return players;
            }

            public void startGame()
            {
                shuffleDeck();
                distributeDeck();
            }

            public void distributeDeck()
            {
                int j = 0;
                for (int k = 0; k < players.Count; k++)
                {
                    List<Card> deckList = (List<Card>)getDeck().displayDeck();
                    for (int i = 0; i < getDeck().displayDeck().Count / getPlayers().Count; i++)
                    {
                        players[k].addCard(deckList[j]);
                        j++;
                    }
                }
            }

            public void shuffleDeck()
            {
                this.deck.shuffle();
            }

        }
    }
}

