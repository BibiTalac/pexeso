using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;


namespace pexeso
{

    public partial class MainWdw : Form
    {
        public static int Click_count = 0;    //click count
        public static int Moves_count = 0;      //moves count
        public static List<Card> Pair = new List<Card>();   //pair field

        public int _widthSize = 0;       //grpbox width
        public int _heightSize = 0;      //grpbox height
        private int _wSizeImage = 0;         //image width
        private int _hSizeImage = 0;         //image height
        private List<Image> _list;      //set of images from resources
        private Timer _check_timer = new Timer();       //timer running 10ms, paused for covering cards-wrong pair
        private System.Timers.Timer _cover_timer;   //timer for covering-1 sec 
        private DateTime _start;        //start time
        private int _matched = 0;       //match counting

        public MainWdw()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Height = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenHeight - 100);
            this.Width = Convert.ToInt32(System.Windows.SystemParameters.PrimaryScreenWidth - 100);
            this.Location = new Point(50, 50);
            this._start = DateTime.Now;     //time start
            
            _list = GetImages();        //fill list
            GrpBoxSet();        //controls settings
            LabelsSet();
            CardsAdd(); 
            SetTimer();
        }
        private void SetTimer()     //timer 10ms, pair count & click count check
        {
            _check_timer.Interval = 10;
            _check_timer.Tick += CheckProcedure;
            _check_timer.Start();
        }
        private void TimerCover(int indx)       //click count & pair count==2 procedure after 1 sec
        {
             _cover_timer = new System.Timers.Timer(1000);      //new timer
            switch (indx)
            {
                case 1:
                    _cover_timer.Elapsed += OnTimeElapsedCover;     //procedure in case of wrong pair
                    break;
                case 2:
                    _cover_timer.Elapsed += OnTimeElapsedDispose;   //procedure in case of matching pair
                    break;
            }
            _cover_timer.Enabled = true;
        }
        private void OnTimeElapsedDispose(object sender,System.Timers.ElapsedEventArgs e)
        {
            //dispose object can not be from another thread, need to establish delegate on parent-lesson learned
            //images disposal a pair count setting to 0
            this.grpBox.Invoke(new MethodInvoker(delegate 
            { Pair[0].Dispose();
                Pair[1].Dispose();
                while (Pair.Count > 0)
                { Pair.Remove(Pair[0]); }
            }));

            this._matched++;        //counting matched
            _cover_timer.Stop();
            _cover_timer.Dispose();
        }
        //not matching pair procedure
        private void OnTimeElapsedCover(object sender, System.Timers.ElapsedEventArgs e)
        {
            Pair[0].CoverCard();
            Pair[1].CoverCard();
           
            while (Pair.Count > 0)      //setting pair count to 0
            {
                Pair.Remove(Pair[0]);
            }
            _cover_timer.Stop();
            _cover_timer.Dispose();
        }
        private string TimeElapsed()        //method returning elapsed time form start
        {
            TimeSpan diff = DateTime.Now - this._start;
            return $"{diff.Minutes} Min : {diff.Seconds} Sec : {diff.Milliseconds} Ms";
        }
        private void CheckProcedure(object sender,EventArgs e)
        {
            //procedure checking count of pair and clicks
            this.lblMoves.Text = $"Moves: {Moves_count}";
            this.lblTimer.Text = TimeElapsed();

            try
            {
                if (Click_count == 2)
                {
                    Click_count = 0;    //reset

                    if (Pair.Count == 2)
                    {
                        if (Pair[0].CompareImage(Pair[1]))      //matching pair
                        {
                            TimerCover(2);
                        }
                        else
                        {
                            TimerCover(1);
                        }
                    }
                }
                if (this._matched == 15)        //end of game
                {
                    _check_timer.Dispose();
                    this.lblEnd.Location = new Point((this.grpBox.Width - this.lblEnd.Width) / 2, (this.grpBox.Height - this.lblEnd.Height) / 2);
                    this.lblEnd.Text = "All matched!";
                    this.lblEnd.Visible = true;
                }
            }
            catch(Exception ex) { MessageBox.Show($"Sorry, something went wrong: {ex.Message}"); }
        }
        private void GrpBoxSet()
        {
            this.grpBox.Size = new Size(Convert.ToInt32(this.Width * 0.75), Convert.ToInt32(this.Height) - 100);
            _widthSize = this.grpBox.Width;
            _heightSize = this.grpBox.Height;
            _wSizeImage = _widthSize / 6;
            _hSizeImage = _heightSize / 5;
        }
        private void CardsAdd()
        {
            List<Point> points_list = new List<Point>();
            Random rand = new Random();
            //field of points for controls location
            for(int x = 0; x < 6; x++)
            {
                for(int y = 0; y < 5; y++)
                {
                    Point p = new Point(_wSizeImage*x,_hSizeImage*y);
                    points_list.Add(p);
                }
            }
            
            try
            {
                int id = 0;     //id of card
                while (_list.Count > 0)
                {
                    int indx = rand.Next(0, _list.Count);       //random index of image
                    int point1 = rand.Next(0, points_list.Count);       //random point for card1
                    Card c1 = new Card(this.grpBox, _list[indx], id);   //first card
                    c1.Parent = this.grpBox;
                    c1.Location = points_list[point1];
                    c1.Show();
                    points_list.RemoveAt(point1);       //delete from list of points

                    Card c2 = new Card(this.grpBox, _list[indx], id);
                    int point2= rand.Next(0, points_list.Count);        //second card location
                    c2.Parent = this.grpBox;
                    c2.Location = points_list[point2];
                    c2.Show();
                    points_list.RemoveAt(point2);       //delete point of second card-occupied
                    _list.RemoveAt(indx);       //remove image from list
                    id++;
                }
                
            }catch(Exception e) { MessageBox.Show($"Error message: {e.Message}"); }

        }
        private List<Image> GetImages()
        {
            //get images from resources
            List<Image> list = new List<Image>();
            var resMan = Properties.Resources.ResourceManager;
            var coll = resMan.GetResourceSet(System.Globalization.CultureInfo.InvariantCulture, true, true);
            foreach(DictionaryEntry entry in coll)
            {
                if(entry.Key.ToString()!="cover")
                {
                    list.Add((Bitmap)entry.Value);
                }
            }
            return list;
        }
        private void LabelsSet()
        {
            this.lblMoves.Text = $"Moves: {Moves_count}";
            this.lblMoves.Location = new Point(this.grpBox.Width + 50, this.grpBox.Top);
            this.lblTimer.Text = "";
            this.lblTimer.Font = new Font("Arial", Convert.ToInt32(this.Width * 0.25 / 20));
            this.lblTimer.Location = new Point(this.grpBox.Width + 20, this.grpBox.Top + 100);
        }
    }
}
