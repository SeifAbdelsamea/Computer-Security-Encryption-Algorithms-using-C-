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
    public partial class Form4 : Form
    {
        List<int> x = new List<int>();
        List<int> y = new List<int>();
        List<int> temp = new List<int>();
        List<int> temp1 = new List<int>();
        List<int> temp2 = new List<int>();
        List<int> k1 = new List<int>();
        List<int> k2 = new List<int>();
        List<int> p10 = new List<int>() {2,4,1,6,3,9,0,8,7,5};
        List<int> p8 = new List<int>() {5,2,6,3,7,4,9,8};
        List<int> ip= new List<int>() {1,5,2,0,3,7,4,6};
        List<int> ipin = new List<int>() {3,0,2,4,6,1,7,5};
        List<int> ep = new List<int>() {3,0,1,2,1,2,3,0};
        List<int> p4 = new List<int>() {1,3,2,0};
        int[,] s0 = new int[4, 4] { {1,0,3,2}, {3,2,1,0}, {0,2,1,3},{3,1,3,2} } ;
        int[,] s1 = new int[4,4] { {0,1,2,3}, {2,0,1,3}, {3,0,1,0}, {2,1,0,3} } ;

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            onclick();
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (char.IsNumber(textBox1.Text[i]))
                    x.Add(Int32.Parse(textBox1.Text[i].ToString()));
            }
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (char.IsNumber(textBox2.Text[i]))
                    y.Add(Int32.Parse(textBox2.Text[i].ToString()));
            }
            if (x.Count() < 8 || x.Count() > 8)
            {
                MessageBox.Show("Plaintext or Ciphertext must be 8 bits");
                return;
            }
            if (y.Count() < 10 || y.Count() > 10)
            {
                MessageBox.Show("Key must be 10 bits");
                return;
            }
            for (int i = 0; i < p10.Count; i++)
            {
                k1.Add(y[p10[i]]);
                k2.Add(y[p10[i]]);
            }
            for (int i = 0; i < k1.Count/2; i++)
            {
                temp1.Add(k1[i]);
                temp2.Add(k1[i+5]);
            }
            temp1.Add(temp1[0]);
            temp1.RemoveAt(0);
            temp2.Add(temp2[0]);
            temp2.RemoveAt(0);
            for (int i = 0; i < temp1.Count; i++)
            {
                temp.Add(temp1[i]);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                temp.Add(temp2[i]);
            }
            k1.Clear();
            for (int i = 0; i < p8.Count; i++)
            {
                k1.Add(temp[p8[i]]);
            }
            temp1.Clear();
            temp2.Clear();
            temp.Clear();
            for (int i = 0; i < k2.Count / 2; i++)
            {
                temp1.Add(k2[i]);
                temp2.Add(k2[i + 5]);
            }
            for (int i = 0; i < 3; i++)
            {
                temp1.Add(temp1[i]);
            }
            temp1.RemoveRange(0, 3);
            for (int i = 0; i < 3; i++)
            {
                temp2.Add(temp2[i]);
            }
            temp2.RemoveRange(0, 3);
            for (int i = 0; i < temp1.Count; i++)
            {
                temp.Add(temp1[i]);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                temp.Add(temp2[i]);
            }
            k2.Clear();
            for (int i = 0; i < p8.Count; i++)
            {
                k2.Add(temp[p8[i]]);
            }
            temp.Clear();
            for (int i = 0; i < ip.Count; i++)
            {
                temp.Add(x[ip[i]]);
            }
            //
            //round 1
            x.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                x.Add(temp[i]);
            }
            temp1.Clear();
            temp2.Clear();
            for (int i = 0; i < 4; i++)
            {
                temp2.Add(x[i]);
                temp1.Add(x[i+4]);
            }
            temp.Clear();
            for (int i = 0; i < ep.Count; i++)
            {
                temp.Add(temp1[ep[i]]);
            }
            temp1.Clear();
            temp1 = xor(temp, k1);
            temp = sbox(temp1);
            temp1.Clear();
            for (int i = 0; i < p4.Count; i++)
            {
                temp1.Add(temp[p4[i]]);
            }
            temp = xor(temp1, temp2);
            temp1.Clear();
            for (int i = 4; i < x.Count; i++)
            {
                temp1.Add(x[i]);
            }
            for (int i = 0; i < temp.Count(); i++)
            {
                temp1.Add(temp[i]);
            }
            //
            //round 2
            x.Clear();
            for (int i = 0; i < temp1.Count; i++)
            {
                x.Add(temp1[i]);
            }
            temp1.Clear();
            temp2.Clear();
            for (int i = 0; i < 4; i++)
            {
                temp2.Add(x[i]);
                temp1.Add(x[i + 4]);
            }
            temp.Clear();
            for (int i = 0; i < ep.Count; i++)
            {
                temp.Add(temp1[ep[i]]);
            }
            temp1.Clear();
            temp1 = xor(temp, k2);
            temp = sbox(temp1);
            temp1.Clear();
            for (int i = 0; i < p4.Count; i++)
            {
                temp1.Add(temp[p4[i]]);
            }
            temp = xor(temp1, temp2);
            temp1.Clear();
            for (int i = 0; i < temp.Count(); i++)
            {
                temp1.Add(temp[i]);
            }
            for (int i = 4; i < x.Count; i++)
            {
                temp1.Add(x[i]);
            }
            temp.Clear();
            for (int i = 0; i < ipin.Count; i++)
            {
                temp.Add(temp1[ipin[i]]);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                textBox3.AppendText(temp[i].ToString());
            }
            //for (int i = 0; i < temp2.Count; i++)
            //{
            //    textBox3.AppendText(temp2[i].ToString());
            //}
        }
        private void button2_Click(object sender, EventArgs e)
        {
            onclick();
            //if (textBox1.Text.Count() < 8 && textBox1.Text.Count()==2)
            //{
            //    x0 = String.Join(String.Empty, textBox1.Text.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))).ToList();
            //}
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (char.IsNumber(textBox1.Text[i]))
                    x.Add(Int32.Parse(textBox1.Text[i].ToString()));
            }
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (char.IsNumber(textBox2.Text[i]))
                    y.Add(Int32.Parse(textBox2.Text[i].ToString()));
            }
            if (x.Count() < 8 || x.Count() > 8)
            {
                MessageBox.Show("Plaintext or Ciphertext must be 8 bits");
                return;
            }
            if (y.Count() < 10 || y.Count() > 10)
            {
                MessageBox.Show("Key must be 10 bits");
                return;
            }
            for (int i = 0; i < p10.Count; i++)
            {
                k1.Add(y[p10[i]]);
                k2.Add(y[p10[i]]);
            }
            for (int i = 0; i < k1.Count / 2; i++)
            {
                temp1.Add(k1[i]);
                temp2.Add(k1[i + 5]);
            }
            temp1.Add(temp1[0]);
            temp1.RemoveAt(0);
            temp2.Add(temp2[0]);
            temp2.RemoveAt(0);
            for (int i = 0; i < temp1.Count; i++)
            {
                temp.Add(temp1[i]);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                temp.Add(temp2[i]);
            }
            k1.Clear();
            for (int i = 0; i < p8.Count; i++)
            {
                k1.Add(temp[p8[i]]);
            }
            temp1.Clear();
            temp2.Clear();
            temp.Clear();
            for (int i = 0; i < k2.Count / 2; i++)
            {
                temp1.Add(k2[i]);
                temp2.Add(k2[i + 5]);
            }
            for (int i = 0; i < 3; i++)
            {
                temp1.Add(temp1[i]);
            }
            temp1.RemoveRange(0, 3);
            for (int i = 0; i < 3; i++)
            {
                temp2.Add(temp2[i]);
            }
            temp2.RemoveRange(0, 3);
            for (int i = 0; i < temp1.Count; i++)
            {
                temp.Add(temp1[i]);
            }
            for (int i = 0; i < temp2.Count; i++)
            {
                temp.Add(temp2[i]);
            }
            k2.Clear();
            for (int i = 0; i < p8.Count; i++)
            {
                k2.Add(temp[p8[i]]);
            }
            temp.Clear();
            for (int i = 0; i < ip.Count; i++)
            {
                temp.Add(x[ip[i]]);
            }
            //
            //round 1
            x.Clear();
            for (int i = 0; i < temp.Count; i++)
            {
                x.Add(temp[i]);
            }
            temp1.Clear();
            temp2.Clear();
            for (int i = 0; i < 4; i++)
            {
                temp2.Add(x[i]);
                temp1.Add(x[i + 4]);
            }
            temp.Clear();
            for (int i = 0; i < ep.Count; i++)
            {
                temp.Add(temp1[ep[i]]);
            }
            temp1.Clear();
            temp1 = xor(temp, k2);
            temp = sbox(temp1);
            temp1.Clear();
            for (int i = 0; i < p4.Count; i++)
            {
                temp1.Add(temp[p4[i]]);
            }
            temp = xor(temp1, temp2);
            temp1.Clear();
            for (int i = 4; i < x.Count; i++)
            {
                temp1.Add(x[i]);
            }
            for (int i = 0; i < temp.Count(); i++)
            {
                temp1.Add(temp[i]);
            }
            //
            //round 2
            x.Clear();
            for (int i = 0; i < temp1.Count; i++)
            {
                x.Add(temp1[i]);
            }
            temp1.Clear();
            temp2.Clear();
            for (int i = 0; i < 4; i++)
            {
                temp2.Add(x[i]);
                temp1.Add(x[i + 4]);
            }
            temp.Clear();
            for (int i = 0; i < ep.Count; i++)
            {
                temp.Add(temp1[ep[i]]);
            }
            temp1.Clear();
            temp1 = xor(temp, k1);
            temp = sbox(temp1);
            temp1.Clear();
            for (int i = 0; i < p4.Count; i++)
            {
                temp1.Add(temp[p4[i]]);
            }
            temp = xor(temp1, temp2);
            temp1.Clear();
            for (int i = 0; i < temp.Count(); i++)
            {
                temp1.Add(temp[i]);
            }
            for (int i = 4; i < x.Count; i++)
            {
                temp1.Add(x[i]);
            }
            temp.Clear();
            for (int i = 0; i < ipin.Count; i++)
            {
                temp.Add(temp1[ipin[i]]);
            }
            for (int i = 0; i < temp.Count; i++)
            {
                textBox3.AppendText(temp[i].ToString());
            }
        }
        List<int> sbox(List<int> ss)
        {
            int x=0,y=0,z=0;
            List<int> temp = new List<int>();
            if (ss[0] == 0 && ss[3] == 0)
                x = 0;
            else if (ss[0] == 0 && ss[3] == 1)
                x = 1;
            else if (ss[0] == 1 && ss[3] == 0)
                x = 2;
            else if (ss[0] == 1 && ss[3] == 1)
                x = 3;
            if (ss[1] == 0 && ss[2] == 0)
                y = 0;
            else if (ss[1] == 0 && ss[2] == 1)
                y = 1;
            else if (ss[1] == 1 && ss[2] == 0)
                y = 2;
            else if (ss[1] == 1 && ss[2] == 1)
                y = 3;
            z = s0[x, y];
            if (z == 0)
            {
                temp.Add(0);
                temp.Add(0);
            }
            else if (z == 1)
            {
                temp.Add(0);
                temp.Add(1);
            }
            else if (z == 2)
            {
                temp.Add(1);
                temp.Add(0);
            }
            else if (z == 3)
            {
                temp.Add(1);
                temp.Add(1);
            }
            if (ss[4] == 0 && ss[7] == 0)
                x = 0;
            else if (ss[4] == 0 && ss[7] == 1)
                x = 1;
            else if (ss[4] == 1 && ss[7] == 0)
                x = 2;
            else if (ss[4] == 1 && ss[7] == 1)
                x = 3;
            if (ss[5] == 0 && ss[6] == 0)
                y = 0;
            else if (ss[5] == 0 && ss[6] == 1)
                y = 1;
            else if (ss[5] == 1 && ss[6] == 0)
                y = 2;
            else if (ss[5] == 1 && ss[6] == 1)
                y = 3;
            z = s1[x, y];
            if (z == 0)
            {
                temp.Add(0);
                temp.Add(0);
            }
            else if (z == 1)
            {
                temp.Add(0);
                temp.Add(1);
            }
            else if (z == 2)
            {
                temp.Add(1);
                temp.Add(0);
            }
            else if (z == 3)
            {
                temp.Add(1);
                temp.Add(1);
            }
            return temp;
        }
        List<int> xor (List<int> ss, List<int> ss2)
        {
            List<int> temp = new List<int>();
            for (int i = 0; i < ss.Count; i++)
            {
                if (ss[i] == ss2[i])
                    temp.Add(0);
                else
                    temp.Add(1);
            }
            return temp;
        }
        void onclick()
        {
            temp.Clear();
            temp1.Clear();
            temp2.Clear();
            x.Clear();
            y.Clear();
            k1.Clear();
            k2.Clear();
            textBox3.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
