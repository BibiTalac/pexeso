using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace pexeso
{
    public partial class Card : UserControl
    {
        private Image _image { get; set; }
        private Image _cover = pexeso.Properties.Resources.cover;
        private bool _covered;
        private int _id { get; set; }

        public Card(Control control,Image image,int id)
        {
            InitializeComponent();
            this._image = ImageSet(image);
            this._id = id;
            this._covered = true;
            SetCard(control);
        }
        public bool CompareImage(Card card)
        {
            bool stat = false;
            if (this._id == card._id)
            {
                stat = true;
            }
            return stat;
        }
        public void CoverCard()
        {
            this.BackgroundImage = _cover;
            this._covered = true;
        }
        private void SetCard(Control control)
        {
            this.Width = control.Width / 6;
            this.Height = control.Height / 5;
            this.BackgroundImage = _cover;
        }
        private Image ImageSet(Image image)
        {
            Bitmap b = new Bitmap(image, new Size(this.Width, this.Height));
            image = b;
            return image;
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (this._covered && MainWdw.Click_count<2 && MainWdw.Pair.Count<2)
            {
                this.BackgroundImage = _image;
                MainWdw.Click_count++;
                MainWdw.Pair.Add(this);
                MainWdw.Moves_count++;
                this._covered = false;
                //MessageBox.Show(MainWdw.Click_count.ToString());
            }
        }
    }
}
