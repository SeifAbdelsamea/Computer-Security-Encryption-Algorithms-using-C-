using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace computer_security_project
{
    public partial class Form3 : Form
    {
        List<char> x = "abcdefghiklmnopqrstuvwxyz".ToList();
        List<char> y = new List<char>();
        List<char> p = new List<char>();
        List<char> pns = new List<char>();
        List<char> p2 = new List<char>();
        List<char> rs = new List<char>();
        char c;
        char c2;
        int f=0;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            y.Clear();
            p2.Clear();
            rs.Clear();
            pns.Clear();
            p = textBox1.Text.ToList();
            for (int i = 0; i < p.Count; i++)
            {
                if(char.IsLetter(p[i]))
                {
                    if (char.IsUpper(p[i]))
                        pns.Add(Char.ToLower(p[i]));
                    else
                        pns.Add(p[i]);
                }
            }
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (char.IsLetter(textBox2.Text[i]))
                {
                    if (!y.Contains(textBox2.Text[i]))
                        y.Add(textBox2.Text[i]);
                }
            }
            for (int i = 0; i < x.Count; i++)
            {
                if (!y.Contains(x[i]))
                    y.Add(x[i]);
            }
            for (int i = 0; i < pns.Count - 1; i++)
            {
                //balloon
                //balxloon
                if (pns[i] == pns[i + 1] && p2.Count % 2 == 0)
                {
                    p2.Add(pns[i]);
                    p2.Add(x[22]);
                }
                else
                    p2.Add(pns[i]);
            }
            p2.Add(pns[pns.Count() - 1]);
            if (p2.Count % 2 != 0)
            {
                p2.Add(x[22]);
            }
            /*
             0   1   2   3   4 
             5   6   7   8   9
             10  11  12  13  14
             15  16  17  18  19
             20  21  22  23  24
             */
            char[,] y3 = new char[5, 5];
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            f = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    y3[j, i] = y[f];
                    f += 1;
                }
            }
            for (int i = 0; i < p2.Count; i += 2)
            {
                c = p2[i];
                c2 = p2[i + 1];
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (c == y3[j, k])
                        {
                            x1 = j;
                            y1 = k;
                            break;
                        }
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (c2 == y3[j, k])
                        {
                            x2 = j;
                            y2 = k;
                            break;
                        }
                    }
                }
                //textBox3.AppendText(c.ToString() + c2.ToString() + y1.ToString() + x1.ToString() + y2.ToString() + x2.ToString());
                if (x1 == x2) //sc
                {
                    if (y1 + 1 > 4)
                    {
                        rs.Add(y3[x1, 0]);
                        rs.Add(y3[x2, y2 + 1]);

                    }
                    else if (y2 + 1 > 4)
                    {
                        rs.Add(y3[x1, y1 + 1]);
                        rs.Add(y3[x2, 0]);
                    }
                    else
                    {
                        rs.Add(y3[x1, y1 + 1]);
                        rs.Add(y3[x2, y2 + 1]);
                    }
                }
                else if (y1 == y2) //sr
                {
                    if (x1 + 1 > 4)
                    {
                        rs.Add(y3[0, y1]);
                        rs.Add(y3[x2 + 1, y2]);
                    }
                    else if (x2 + 1 > 4)
                    {
                        rs.Add(y3[x1 + 1, y1]);
                        rs.Add(y3[0, y2]);
                    }
                    else
                    {
                        rs.Add(y3[x1 + 1, y1]);
                        rs.Add(y3[x2 + 1, y2]);
                    }
                }
                else if (x1 < x2 && y2 > y1)
                {
                    rs.Add(y3[x2, y1] ); 
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 > x2 && y2 < y1)
                {
                    rs.Add(y3[x2, y1] ); 
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 < x2 && y2 < y1)
                {
                    rs.Add(y3[x2, y1] ); 
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 > x2 && y2 > y1)
                {
                    rs.Add(y3[x2, y1] ); 
                    rs.Add(y3[x1, y2]);
                }
            }
            for (int i = 0; i < p.Count; i++)
            {
                if (char.IsWhiteSpace(p[i]))
                {
                    rs.Insert(i, p[i]);
                }
                if(char.IsUpper(p[i]))
                {
                    rs[i] = char.ToUpper(rs[i]);
                }
            }
            if(!char.IsLetter(p[p.Count - 1]))
            {
                rs.Add(p[p.Count - 1]);
            }
            for (int i = 0; i < rs.Count; i++)
            {
                textBox3.AppendText(rs[i].ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            y.Clear();
            p2.Clear();
            rs.Clear();
            pns.Clear();
            p = textBox1.Text.ToList();
            for (int i = 0; i < p.Count; i++)
            {
                if (char.IsLetter(p[i]))
                {
                    if (char.IsUpper(p[i]))
                        pns.Add(Char.ToLower(p[i]));
                    else
                        pns.Add(p[i]);
                }
            }
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (char.IsLetter(textBox2.Text[i]))
                {
                    if (!y.Contains(textBox2.Text[i]))
                        y.Add(textBox2.Text[i]);
                }
            }
            for (int i = 0; i < x.Count; i++)
            {
                if (!y.Contains(x[i]))
                    y.Add(x[i]);
            }
            for (int i = 0; i < pns.Count - 1; i++)
            {
                //balloon
                //balxloon
                if (pns[i] == pns[i + 1] && p2.Count % 2 == 0)
                {
                    p2.Add(pns[i]);
                    p2.Add(x[22]);
                }
                else
                    p2.Add(pns[i]);
            }
            p2.Add(pns[pns.Count() - 1]);
            if (p2.Count % 2 != 0)
            {
                p2.Add(x[22]);
            }
            /*
             0   1   2   3   4 
             5   6   7   8   9
             10  11  12  13  14
             15  16  17  18  19
             20  21  22  23  24
             */
            char[,] y3 = new char[5, 5];
            int x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            f = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    y3[j, i] = y[f];
                    f += 1;
                }
            }
            for (int i = 0; i < p2.Count; i += 2)
            {
                c = p2[i];
                c2 = p2[i + 1];
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (c == y3[j, k])
                        {
                            x1 = j;
                            y1 = k;
                            break;
                        }
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (c2 == y3[j, k])
                        {
                            x2 = j;
                            y2 = k;
                            break;
                        }
                    }
                }
                //textBox3.AppendText(c.ToString() + c2.ToString() + y1.ToString() + x1.ToString() + y2.ToString() + x2.ToString());
                if (x1 == x2) //sc
                {
                    if (y1 - 1 < 0)
                    {
                        rs.Add(y3[x1, 4]);
                        rs.Add(y3[x2, y2 - 1]);

                    }
                    else if (y2 - 1 < 0)
                    {
                        rs.Add(y3[x1, y1 - 1]);
                        rs.Add(y3[x2, 4]);
                    }
                    else
                    {
                        rs.Add(y3[x1, y1 - 1]);
                        rs.Add(y3[x2, y2 - 1]);
                    }
                }
                else if (y1 == y2) //sr
                {
                    if (x1 - 1 < 0)
                    {
                        rs.Add(y3[4, y1]);
                        rs.Add(y3[x2 - 1, y2]);
                    }
                    else if (x2 - 1 < 0)
                    {
                        rs.Add(y3[x1 - 1, y1]);
                        rs.Add(y3[4, y2]);
                    }
                    else
                    {
                        rs.Add(y3[x1 - 1, y1]);
                        rs.Add(y3[x2 - 1, y2]);
                    }
                }
                else if (x1 < x2 && y2 > y1)
                {
                    rs.Add(y3[x2, y1]);
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 > x2 && y2 < y1)
                {
                    rs.Add(y3[x2, y1]);
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 < x2 && y2 < y1)
                {
                    rs.Add(y3[x2, y1]);
                    rs.Add(y3[x1, y2]);
                }
                else if (x1 > x2 && y2 > y1)
                {
                    rs.Add(y3[x2, y1]);
                    rs.Add(y3[x1, y2]);
                }
            }
            for (int i = 0; i < p.Count; i++)
            {
                if (char.IsWhiteSpace(p[i]))
                {
                    rs.Insert(i, p[i]);
                }
                if (char.IsUpper(p[i]))
                {
                    rs[i] = char.ToUpper(rs[i]);
                }
            }
            if (!char.IsLetter(p[p.Count - 1]))
            {
                rs.Add(p[p.Count - 1]);
            }
            for (int i = 0; i < rs.Count; i++)
            {
                textBox3.AppendText(rs[i].ToString());
            }
        }
    }
}