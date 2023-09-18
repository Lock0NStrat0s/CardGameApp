namespace CardGame;

class Program
{
    static void Main(string[] args)
    {
        PokerDeck deck = new PokerDeck();

        
        Console.ReadLine();
    }
}

public abstract class Deck
{
    protected List<PlayingCard> fullDeck = new List<PlayingCard>();
    protected List<PlayingCard> drawPile = new List<PlayingCard>();
    protected List<PlayingCard> discardPile = new List<PlayingCard>();

    protected void CreateDeck()
    {
        fullDeck.Clear();

        for (int suit = 0; suit < 4; suit++)
        {
            for (int val = 0; val < 13; val++)
            {
                fullDeck.Add(new PlayingCard { Suit = (CardSuit)suit, Value = (CardValue)val });
            }
        }
    }

    public virtual void ShuffleDeck()
    {
        var rnd = new Random();
        drawPile = fullDeck.OrderBy(x => rnd.Next()).ToList();
    }

    public abstract List<PlayingCard> DealCard();

    public virtual PlayingCard RequestCard()
    {
        PlayingCard output = drawPile.Take(1).First();
        drawPile.Remove(output);

        return output;
    }
}

public class PokerDeck : Deck
{
    public PokerDeck()
    {
        CreateDeck();
        ShuffleDeck();
    }

    public override List<PlayingCard> DealCard()
    {
        List<PlayingCard> output = new List<PlayingCard>();

        for (int i = 0; i < 5; i++)
        {
            output.Add(RequestCard());
        }

        return output;
    }
}

public class PlayingCard
{
    public CardSuit Suit { get; set; }
    public CardValue Value { get; set; }
}

public enum CardValue
{
    Ace,
    Two,
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King
}

public enum CardSuit
{
    Hearts,
    Clubs,
    Diamonds,
    Spades
}