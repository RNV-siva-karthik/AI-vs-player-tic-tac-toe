using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;

namespace XO_game
{

    public partial class Form1 : KryptonForm
    {
        int[] a = new int[3] { 0, 1, 2 };//creating arrays and providing data set......
        int[] b = new int[3] { 3, 4, 5 };
        int[] c = new int[3] { 6, 7, 8 };
        int[] p = new int[3] { 0, 3, 6 };
        int[] q = new int[3] { 1, 4, 7 };
        int[] r = new int[3] { 2, 5, 8 };
        int[] x = new int[3] { 0, 4, 8 };
        int[] y = new int[3] { 2, 4, 6 };
        List<int> player = new List<int>();//player moves are recorded here
        List<int> computer = new List<int>();//computer moves are recorded here
        int[] comp = new int[9];
        bool[] check1 = new bool[9];//keeps an array of buttons that are clicked already
        Button[] btn = new Button[9];//to create 9 buttons in a grid 
        static bool c1 = false;
        Random re = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = -32, y = 63;
            int n = 0;
            for (int i = 0; i < 9; i++)
            {
                btn[i] = new Button();
                btn[i].Width = 95;
                btn[i].Height = 83;
                btn[i].Name = Convert.ToString(i);
                btn[i].Font = new Font("Showcard Gothic", 16);
                btn[i].Click += new EventHandler(btnclick);
                btn[i].BackColor= Color.MintCream;
            }
            for (int i = 0; i < 3; i++)//to create a grid of 9 buttons
            {
                for (int j = n; j < n + 3; j++)
                {
                    x = x + 121;
                    btn[j].Location = new Point(x, y);
                }
                y = y + 105;
                n = n + 3;
                x = -32;
            }
            for (int i = 0; i < 9; i++)
            {
                this.Controls.Add(btn[i]);
            } 
        }
        void btnclick(object sender, EventArgs e)//buttonclick event for any of the 9 buttons
        {
            Button bt = sender as Button;
            string n = bt.Name;
            int btnno = Convert.ToInt32(n);
            if (!check1[btnno])
            {
                bt.Text = "X";
                check1[btnno] = true;
                player.Add(btnno);
                if (player.Count >= 3)
                {
                    checkwin("X",player);
                }
                compclick(btnno);
                checkwin("X",player);
            }
        }
        void compclick(int g)//this is for computer click event
        {
            if (player.Count == 1)
            ochange(rangen());
            if (g == 0)
            {
                check3(a, p, x);
            }
            else if (g == 1)
            {
                check2(a, q);
            }
            else if (g == 2)
            {
                check3(y, r, a);
            }
            else if (g == 3)
            {
                check2(p, b);
            }
            else if (g == 4)
            {
                check4(q, b, x, y);
            }
            else if (g == 5)
            {
                check2(r, b);
            }
            else if (g == 6)
            {
                check3(y, p, c);
            }
            else if (g == 7)
            {
                check2(q, c);
            }
            else if (g == 8)
            {
                check3(c, r, x);
            }
        }
        void check3(int[] d, int[] e, int[] f)//this checks all the buttons that are related in three ways 
        {
            int V, x = 0, y = 0;
            int length = player.Count;
            if (!(length < 2))
            {
                x = player[length - 2];
                y = player[length - 1];
            }
            if (d.Contains(x) && d.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (d[i] != x && d[i] != y)
                    {
                        V = d[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (e.Contains(x) && e.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (e[i] != x && e[i] != y)
                    {
                        V = e[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (f.Contains(x) && f.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (f[i] != x && f[i] != y)
                    {
                        V = f[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (x != y)
            {
                if (player.Count < 5)
                {
                    V = rangen();
                    ochange(V);
                }
            }

        }
        void check2(int[] d, int[] e)//this checks all the buttons that are related in two ways 
        {
            int V, x = 0, y = 0;
            int length = player.Count;
            if (!(length < 2))
            {
                x = player[length - 2];
                y = player[length - 1];
            }
            if (d.Contains(x) && d.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (d[i] != x && d[i] != y)
                    {
                        V = d[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (e.Contains(x) && e.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (e[i] != x && e[i] != y)
                    {
                        V = e[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (x != y)
            {
                if (player.Count < 5)
                {
                    V = rangen();
                    ochange(V);
                }
            }
        }
        void check4(int[] d, int[] e, int[] f, int[] g)//this checks all the buttons that are related in four ways 
        {
            int V, x = 0, y = 0;
            int length = player.Count;
            if (!(length < 2))
            {
                x = player[length - 2];
                y = player[length - 1];
            }
            if (d.Contains(x) && d.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (d[i] != x && d[i] != y)
                    {
                        V = d[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (e.Contains(x) && e.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (e[i] != x && e[i] != y)
                    {
                        V = e[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (f.Contains(x) && f.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (f[i] != x && f[i] != y)
                    {
                        V = f[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (g.Contains(x) && g.Contains(y) && x != y)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (g[i] != x && g[i] != y)
                    {
                        V = g[i];
                        ochange(V);
                        break;
                    }
                }
            }
            else if (x != y)
            {
                if (player.Count < 5)
                {
                    V = rangen();
                    ochange(V);
                }
            }
        }
        int rangen()//this function generates a random number from 0 to 9
        {
            try
            {
                    int V = re.Next(9);
                     return V;
                
            }
            catch(Exception e)
            {
                MessageBox.Show("error");
                return 0;
            }
        }
    
        void ochange(int v)//this function changes the value of button to be O
        {
            int V = v;
            if (check1[V] == false)
            {
                btn[V].Text = "O";
                check1[V] = true;
                computer.Add(V);
                if (computer.Count >= 3)
                checkwin("O", computer);
            }
            else
            {
                if (computer.Count < 4)
                {
                    int z = rangen();
                    ochange(z);
                    //computer.Add(z);
                    if (computer.Count >= 3)
                    {
                        checkwin("O", computer);
                    }
                }
                else
                {
                    Console.WriteLine("this is the error");
                }
            }
        }
        void checkwin(string s,List<int> l)//this function checks for possible winners 
        {
            bool xwon = false;
            bool ywon = false;
            Array[] arr = new Array[8] {a,b,c,p,q,r,x,y };
            for(int i= 0; i < arr.Length; i++)
            {
                int[] now = (int[])arr[i];
                if (l == player)
                {
                    if (player.Contains(now[0]) && player.Contains(now[1]) && player.Contains(now[2]))
                    {
                        showmsg("X");
                        xwon = true;
                        break;
                    }
                }
                else
                {
                    if (computer.Contains(now[0]) && computer.Contains(now[1]) && computer.Contains(now[2]))
                    {
                        showmsg("O");
                        ywon = true;
                        break;
                    }
                }
            }
            if (xwon == false && ywon == false)
                checktie();
            
        }
        void checktie()//this function checks for a tie or draw
        {
            int count = 0;
            foreach (bool b1 in check1)
            {
                if (b1)
                { count++; }
            }
            if (count == 9)
            {
                showmsg("");
            }
        }
        void showmsg(string s)//this is used to see the message as to draw or who won
        {
            button2.Visible = true;
            label2.Visible = true;
            for(int i=0;i<9;i++)
            {
                btn[i].Enabled = false;
            }
            try
            {
                label2.Text = string.Format("{0} won the match!!!", s);
            }
            catch(Exception e)
            { label2.Text = string.Format("{0} won the match!!!", s); }
            if(s=="")
            {
                label2.Text = "it seems top be a draw !!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }  
    }
}
