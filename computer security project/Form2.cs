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
    public partial class Form2 : Form
    {
        List<char> x = "abcdefghijklmnopqrstuvwxyz".ToList();
        List<char> y = new List<char>();
        char c;
        int f;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            y.Clear();
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if(char.IsLetter(textBox2.Text[i]))
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
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                c = textBox1.Text[i];
                if (char.IsWhiteSpace(c))
                {
                    textBox3.AppendText(c.ToString());
                }
                else if (c.ToString() == ".")
                {
                    textBox3.AppendText(c.ToString());
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                        f = 1;
                    }
                    for (int j = 0; j < x.Count(); j++)
                    {
                        if (c == x[j])
                        {
                            if (f == 1)
                            {
                                char c2 = y[j];
                                textBox3.AppendText(char.ToUpper(c2).ToString());
                                f = 0;
                            }
                            else
                            {
                                textBox3.AppendText(y[j].ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            y.Clear();
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
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                c = textBox1.Text[i];
                if (char.IsWhiteSpace(c))
                {
                    textBox3.AppendText(c.ToString());
                }
                else if (c.ToString() == ".")
                {
                    textBox3.AppendText(c.ToString());
                }
                else
                {
                    if (char.IsUpper(c))
                    {
                        c = char.ToLower(c);
                        f = 1;
                    }
                    for (int j = 0; j < y.Count(); j++)
                    {
                        if (c == y[j])
                        {
                            if (f == 1)
                            {
                                char c2 = x[j];
                                textBox3.AppendText(char.ToUpper(c2).ToString());
                                f = 0;
                            }
                            else
                            {
                                textBox3.AppendText(x[j].ToString());
                            }
                            break;
                        }
                    }
                }
            }
        }
    }
}
