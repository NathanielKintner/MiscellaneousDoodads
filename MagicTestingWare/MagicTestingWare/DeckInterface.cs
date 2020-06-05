using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicTestingWare
{
    public partial class DeckInterface : Form
    {
        public List<Card> Deck = new List<Card>();
        public List<Card> Hand = new List<Card>();
        public List<Card> Graveyard = new List<Card>();
        public List<Card> Exile = new List<Card>();
        public List<Card> Untapped = new List<Card>();
        public List<Card> Tapped = new List<Card>();
        public List<CardListForm> forms = new List<CardListForm>();
        public Boolean doUpdate = true;
        public DeckInterface(List<Card> input)
        {
            InitializeComponent();
            Deck = input;
            buttonShuffle_Click(null, null);
        }

        public void updateforms()
        {
            if (!doUpdate)
                return;
            foreach(CardListForm clf in forms)
            {
                clf.update();
            }
        }

        private void buttonHand_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Hand, "Hand", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonTapped_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Tapped, "Tapped", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonUntapped_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Untapped, "Untapped", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonExile_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Exile, "Exile", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonGraveyard_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Graveyard, "Graveyard", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonDeck_Click(object sender, EventArgs e)
        {
            CardListForm fromopener = new CardListForm(Deck, "Deck", this);
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            Card c = Deck.ElementAt(0);
            Deck.RemoveAt(0);
            Hand.Add(c);
            updateforms();
        }
        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < 100; j++)
            {
                for (int i = Deck.Count; i != 0; i--)
                {
                    int remove = Program.r.Next(Deck.Count);
                    Card c = Deck[remove];
                    Deck.RemoveAt(remove);
                    Deck.Insert(Program.r.Next(Deck.Count), c);
                    Deck.Reverse();
                }
            }
            updateforms();
        }

        private void buttonMulligan_Click(object sender, EventArgs e)
        {
            doUpdate = false;
            foreach(Card c in Hand)
            {
                Deck.Add(c);
            }
            Hand.Clear();
            buttonShuffle_Click(null, null);
            for (int i = 0; i < 7; i++)
            {
                buttonDraw_Click(null, null);
            }
            doUpdate = true;
            updateforms();
        }

        private void buttonWipe_Click(object sender, EventArgs e)
        {
            foreach (Card c in Hand)
            {
                Deck.Add(c);
            }
            Hand.Clear();
            foreach (Card c in Tapped)
            {
                Deck.Add(c);
            }
            Tapped.Clear();
            foreach (Card c in Untapped)
            {
                Deck.Add(c);
            }
            Untapped.Clear();
            foreach (Card c in Graveyard)
            {
                Deck.Add(c);
            }
            Graveyard.Clear();
            foreach (Card c in Exile)
            {
                Deck.Add(c);
            }
            Exile.Clear();
            updateforms();
        }

        private void buttonUntap_Click(object sender, EventArgs e)
        {
            foreach (Card c in Tapped)
            {
                Untapped.Add(c);
            }
            Tapped.Clear();
            updateforms();
        }

        private void buttonExplode_Click(object sender, EventArgs e)
        {
            int col1 = -5;
            int col2 = 680;
            int row1 = 70;
            int row2 = 290;
            int row3 = 510;
            CardListForm fromopener = new CardListForm(Hand, "Hand", this) { StartPosition = FormStartPosition.Manual, Location = new Point(col2, row3) };
            fromopener.Show();
            forms.Add(fromopener);
            fromopener = new CardListForm(Graveyard, "Graveyard", this) { StartPosition = FormStartPosition.Manual, Location = new Point(col1, row3) };
            fromopener.Show();
            forms.Add(fromopener);
            fromopener = new CardListForm(Exile, "Exile", this) { StartPosition = FormStartPosition.Manual, Location = new Point(col1, row2) };
            fromopener.Show();
            forms.Add(fromopener);
            fromopener = new CardListForm(Untapped, "Untapped", this) { StartPosition = FormStartPosition.Manual, Location = new Point(col2, row2) };
            fromopener.Show();
            forms.Add(fromopener);
            fromopener = new CardListForm(Tapped, "Tapped", this) { StartPosition = FormStartPosition.Manual, Location = new Point(col2, row1) };
            fromopener.Show();
            forms.Add(fromopener);
        }

        private void buttonRandomDiscard_Click(object sender, EventArgs e)
        {
            int i = Program.r.Next(0, Hand.Count());
            Graveyard.Add(Hand[i]);
            Hand.RemoveAt(i);
            updateforms();
        }
    }
}
