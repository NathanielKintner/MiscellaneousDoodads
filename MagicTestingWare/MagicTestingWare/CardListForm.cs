using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace MagicTestingWare
{
    public partial class CardListForm : Form
    {
        DeckInterface interfce;
        List<Card> connection;
        public CardListForm(List<Card> listToDisplay, String title, DeckInterface parent)
        {
            InitializeComponent();
            connection = listToDisplay;
            listBoxCards.DataSource = connection;
            this.Text = title;
            interfce = parent;
            update();
        }

        public class CardPanel : Panel
        {
            public Card heldCard;
        }

        public void update()
        {
            listBoxCards.Text = "";
            listBoxCards.DataSource = null;
            listBoxCards.Text = "";
            listBoxCards.DataSource = null;
            listBoxCards.ResetText();
            listBoxCards.DataSource = connection;
            listBoxCards.Update();
            this.Update();
            flowLayoutPanelCards.Controls.Clear();
            foreach(Card c in connection)
            {
                CardPanel p = new CardPanel();
                p.Width = Math.Max(45, Math.Min(106, 425/connection.Count));
                if(c == connection.Last())
                {
                    p.Width = 106;
                }
                p.Height = 150;
                p.BackgroundImage = ResizeImage(GetCardImage(c), 106, 150);
                p.BackgroundImageLayout = ImageLayout.None;
                p.heldCard = c;
                p.MouseClick += CardClick;
                p.MouseDoubleClick += listBoxCards_MouseDoubleClick;
                p.Margin = new Padding() { All = 0 };
                flowLayoutPanelCards.Controls.Add(p);
            }
            listBoxCards_SelectedIndexChanged(null, null);
        }
        private void CardClick(object sender, EventArgs e)
        {
            listBoxCards.SelectedItem = ((CardPanel)sender).heldCard;
        }

        private void buttonHand_Click(object sender, EventArgs e)
        {
            if (checkBoxAllCards.Checked)
            {
                for (int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Hand);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Hand);

        }

        private void buttonTapped_Click(object sender, EventArgs e)
        {
            if (checkBoxAllCards.Checked)
            {
                for (int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Tapped);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Tapped);

        }

        private void buttonUntapped_Click(object sender, EventArgs e)
        {

            if (checkBoxAllCards.Checked)
            {
                for (int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Untapped);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Untapped);

        }

        private void buttonExile_Click(object sender, EventArgs e)
        {
            if (checkBoxAllCards.Checked)
            {
                for (int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Exile);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Exile);

        }

        private void buttonGraveyard_Click(object sender, EventArgs e)
        {
            if (checkBoxAllCards.Checked)
            {
                for (int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Graveyard);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Graveyard);
        }

        private void buttonDeckTop_Click(object sender, EventArgs e)
        {
            if (checkBoxAllCards.Checked)
            {
                for(int i = connection.Count; i != 0; i--)
                {
                    moveCard(connection[0], interfce.Deck);
                }
                return;
            }
            moveCard((Card)listBoxCards.SelectedItem, interfce.Deck);

        }
        public void moveCard(Card c, List<Card> dest)
        {
            if(c == null)
            {
                return;
            }
            interfce.Deck.Remove(c);
            interfce.Hand.Remove(c);
            interfce.Graveyard.Remove(c);
            interfce.Exile.Remove(c);
            interfce.Tapped.Remove(c);
            interfce.Untapped.Remove(c);
            dest.Insert(0, c);
            interfce.updateforms();
        }

        private Bitmap GetCardImage(Card c)
        {
            if(c == null)
            {
                c = new Card() { Name = "asdfasdfasdfasdfasdfasdf" };
            }
            string filename = @"Cardimages\" + c.Name + ".jpg";
            if (File.Exists(filename))
            {
                Bitmap b = new Bitmap(filename);
                b = ResizeImage(b, panelCardImage.Width, (int)(b.Height * ((double)panelCardImage.Width) / b.Width));
                return b;
            }
            else
            {
                return new Bitmap(@"Cardimages\NAN.jpg");
            }
        }

        private void listBoxCards_SelectedIndexChanged(object sender, EventArgs e)
        {
            panelCardImage.BackgroundImage = GetCardImage((Card)listBoxCards.SelectedItem);
            textBoxDesc.TextChanged -= textBoxDesc_TextChanged;
            textBoxDesc.Text = "";
            if((Card)listBoxCards.SelectedItem != null)
                textBoxDesc.Text = ((Card)listBoxCards.SelectedItem).Comment;            
            textBoxDesc.TextChanged += textBoxDesc_TextChanged;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private void listBoxCards_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (RadioButtonDeckTop.Checked)
            {
                buttonDeckTop_Click(null, null);
            }
            if (RadioButtonExile.Checked)
            {
                buttonExile_Click(null, null);
            }
            if (RadioButtonGraveyard.Checked)
            {
                buttonGraveyard_Click(null, null);
            }
            if (RadioButtonHand.Checked)
            {
                buttonHand_Click(null, null);
            }
            if (RadioButtonTapped.Checked)
            {
                buttonTapped_Click(null, null);
            }
            if (RadioButtonUntapped.Checked)
            {
                buttonUntapped_Click(null, null);
            }
        }

        private void textBoxDesc_TextChanged(object sender, EventArgs e)
        {
            if(listBoxCards.SelectedItem != null)
            {
                ((Card)(listBoxCards.SelectedItem)).Comment = textBoxDesc.Text;
            }
            
        }

        private void CardListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            interfce.forms.Remove(this);
        }
    }
}
