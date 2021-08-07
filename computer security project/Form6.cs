using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace computer_security_project
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        List<int> key = new List<int>();
        List<int> p = new List<int>();
        List<int> w0 = new List<int>();
        List<int> w1 = new List<int>();
        List<int> w2 = new List<int>();
        List<int> w3 = new List<int>();
        List<int> w4 = new List<int>();
        List<int> w5 = new List<int>();
        List<int> key0 = new List<int>();
        List<int> key1 = new List<int>();
        List<int> key2 = new List<int>();
        List<int> const1 = new List<int>() {1,0,0,0,0,0,0,0};
        List<int> const2 = new List<int>() { 0, 0, 1, 1, 0, 0, 0, 0 };
        List<int> temp1 = new List<int>();
        List<int> temp2 = new List<int>();
        List<int> tempw1 = new List<int>();
        List<int> tempw3 = new List<int>();
        List<int> R1 = new List<int>(); //round 1.2.2 round 1 p xor key 0
        List<int> tempR1 = new List<int>();
        List<int> tempR2 = new List<int>();
        List<string> sub4 = new List<string>();
        /*int[,] m = new int[15, 15] {  {1, 2, 3, 4, 5, 6, 7, 8, 9, "a", "b", "c", "d", "e",  "f" },
                                      {2, 4 ,6, 8, "a", "c", "e", 3, 1, 7, 5, "b", 9, "f",  "d" },
                                      {3, 6, 5, 'c', 'f', 'a', 9, 'b', 8, 'd', 'e', 7, 4, 1, 2 },
                                      {4, 8, 'c', 3, 7, 'b', 'f', 6, 2, 'e', 'a', 5, 1, 'd', 9 },
                                      {5, "a", "f", 7, 2, "d", 8, "e", "b", 4, 1, 9, "c", 3, 6 },
                                      {6, 'c', 'a', 'b', 'd', 7, 1, 5, 3, 9, 'f', 'e', 8, 2, 4 },
                                      {7, "e", 9, "f", 8, 1, 6, "d", "a", 3, 4, 2, 5, "c",  "b" },
                                      {8, 3, "b", 6, "e", 5, "d", "c", 4, "f", 7, "a", 2, 9, 1 },
                                      {9, 1, 8, 2, "b", 3, "a", 4, "d", 5, "c", 6, "f", 7,  "e" },
                                      {"a", 7, "d", "e", 4, 9, 3, "f", 5, 8, 2, 1, "b", 6,  "c" },
                                      {"b", 5, "e", "a", 1, "f", 4, 7, "c", 2, 9, "d", 6, 8, 3 },
                                      {"c", "b", 7, 5, 9, "e", 2, "a", 6, 1, "d", "f", 3, 4, 8 },
                                      {"d", 9, 4, 1, "c", 8, 5, 2, "f", "b", 6, 3, "e", "a", 7 },
                                      {"e", "f", 1, "d", 3, 2, "c", 9, 7, 6, 8, 4, "a", "b", 5 },
                                      {"f", "d", 2, 9, 6, 4,"b", 1, "e", "c", 3, 8, 7, 5,  "a" },    

        };*/

        string[,] m = new string[15, 15] {     {"1", "2", "3", "4"," 5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" },
                                               {"2", "4 ","6", "8", "a", "c", "e", "3", "1", "7", "5", "b", "9", "f", "d" },
                                               {"3", "6", "5", "c", "f", "a", "9", "b", "8", "d", "e", "7", "4", "1", "2" },
                                               {"4", "8", "c", "3", "7", "b", "f", "6", "2", "e", "a", "5", "1", "d", "9" },
                                               {"5", "a", "f", "7", "2", "d", "8", "e", "b", "4"," 1", "9", "c", "3", "6" },
                                               {"6", "c", "a", "b", "d", "7", "1", "5", "3", "9", "f", "e", "8", "2", "4" },
                                               {"7", "e", "9", "f", "8", "1", "6", "d", "a", "3", "4", "2", "5", "c", "b" },
                                               {"8", "3", "b", "6", "e", "5", "d", "c", "4", "f", "7", "a", "2", "9", "1" },
                                               {"9", "1", "8", "2", "b", "3", "a", "4", "d", "5", "c", "6", "f", "7", "e" },
                                               {"a", "7", "d", "e", "4", "9", "3", "f", "5", "8", "2", "1", "b", "6", "c" },
                                               {"b", "5", "e", "a", "1", "f", "4", "7", "c", "2", "9", "d", "6", "8", "3" },
                                               {"c", "b", "7", "5", "9", "e", "2", "a", "6", "1", "d", "f", "3", "4", "8" },
                                               {"d", "9", "4", "1", "c", "8", "5", "2", "f", "b", "6", "3", "e", "a", "7" },
                                               {"e", "f", "1", "d", "3", "2", "c", "9", "7", "6", "8", "4", "a", "b", "5" },
                                               {"f", "d", "2", "9", "6", "4","b", "1", "e", "c", "3", "8", "7", "5",  "a" },

        };
        string[,] a = new string[16, 16] {     {"0", "1", "2", "3"," 4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" },
                                               {"1", "0 ","3", "2", "5", "3", "7", "6", "9", "8", "b", "a", "d", "c", "f", "e" },
                                               {"2", "3", "0", "1", "6", "7", "4", "5", "a", "b", "8", "9", "e", "f", "c", "d" },
                                               {"3", "2", "1", "0", "7", "6", "5", "4", "b", "a", "9", "8", "f", "e", "d", "c" },
                                               {"4", "5", "6", "7", "0", "1", "2", "3", "c", "d"," e", "f", "8", "9", "a", "b" },
                                               {"5", "4", "7", "6", "1", "0", "3", "2", "d", "c", "f", "e", "9", "8", "b", "a" },
                                               {"6", "7", "4", "5", "2", "3", "0", "1", "e", "f", "c", "d", "a", "b", "8", "9" },
                                               {"7", "6", "5", "4", "3", "2", "1", "0", "f", "e", "d", "c", "b", "a", "9", "8" },
                                               {"8", "9", "a", "b", "c", "d", "e", "f", "0", "1", "2", "3", "4", "5", "6", "7" },
                                               {"9", "8", "b", "a", "d", "c", "f", "e", "1", "0", "3", "2", "5", "4", "7", "6" },
                                               {"a", "b", "8", "9", "e", "f", "c", "d", "2", "3", "0", "1", "6", "7", "4", "5" },
                                               {"b", "a", "9", "8", "f", "e", "d", "c", "3", "2", "1", "0", "7", "6", "5", "4" },
                                               {"c", "d", "e", "f", "8", "9", "a", "b", "4", "5", "6", "7", "0", "1", "2", "3" },
                                               {"d", "c", "f", "e", "9", "8", "b", "a", "5", "4", "7", "6", "1", "0", "3", "2" },
                                               {"e", "f", "c", "d", "a", "b","8", "9", "6", "7", "4", "5", "2", "3",  "0", "1" },
                                               {"f", "e", "d", "c", "b", "a","9", "8", "7", "6", "5", "4", "3", "2",  "1", "0" },
        };
        string s0 = "";
        string s1 = "";
        string s2 = "";
        string s3 = "";
        
        string[,] ME = new string[2, 2] {
                                          {"1", "4"},
                                          {"4", "1"} 
        };




        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            onclick();

            for (int i = 0; i < textBox1.TextLength; i++)
            {
                if (char.IsNumber(textBox1.Text[i]))
                {
                    key.Add(Int32.Parse(textBox1.Text[i].ToString()));
                }
            }
            if (key.Count() < 16 || key.Count() > 16)
            {
                MessageBox.Show("Key  must be 16 bits");
                return;
            }
            for (int i = 0; i < textBox2.TextLength; i++)
            {
                if (char.IsNumber(textBox2.Text[i]))
                {
                    p.Add(Int32.Parse(textBox2.Text[i].ToString()));
                }
            }
            if (p.Count() < 16 || p.Count() > 16)
            {
                MessageBox.Show("Plain Text   must be 16 bits");
                return;
            }
            ////Ws 
            for (int i = 0; i < key.Count; i++)
            {
                key0.Add(key[i]);
                if (i < 8 && i < key.Count / 2)
                    w0.Add(key[i]);  /// W0
                if (i >= 8 && i < key.Count)
                    w1.Add(key[i]);    ///W1

            }

            temp1 = xor(w0, const1);
            tempw1 = w1;

            tempw1=Rotnib(tempw1);
            tempw1=Subnib(tempw1);
            w2 = xor(temp1, tempw1);   ///W2

            w3 = xor(w2, w1);      ///W3 

            temp1.Clear();
            temp1 = xor(w2, const2);
            tempw3 = w3;
            tempw3 = Rotnib(tempw3);
            tempw3 = Subnib(tempw3);
            w4 = xor(temp1, tempw3);   ////W4
            w5 = xor(w4, w3);          /// W5

            //Keeys
            key0.Clear();
            for (int i = 0; i < w0.Count; i++)      ///Key 0
            {
                key0.Add(w0[i]);
            }
            for (int i = 0; i < w1.Count; i++)
            {
                key0.Add(w1[i]);
            }
            for (int i = 0; i < w2.Count; i++)      ///Key 1
            {
                key1.Add(w2[i]);
            }
            for (int i = 0; i < w3.Count; i++)
            {
                key1.Add(w3[i]);
            }
            for (int i = 0; i < w4.Count; i++)      ///Key 2
            {
                key2.Add(w4[i]);
            }
            for (int i = 0; i < w5.Count; i++)
            {
                key2.Add(w5[i]);
            }
            //1.2.2 Round 1
            R1 = xor(p, key0);         /////1.2.2 round 1
            R1 = Subnib(R1);            ///Nibble Substituion
            R1 = XDDD(R1);           ///Shift rows (shift 2nd nibble with 4th nibble)
            //////////////
            //// Body is naruto simp 
            ///Mix Columns
            for (int i = 0; i < 4; i++)
            {
                s0 += R1[i];
            }
            for (int i = 4; i < 8; i++)
            {
                s1 += R1[i];
            }
            for (int i = 8; i < 12; i++)
            {
                s2 += R1[i];
            }
            for (int i = 12; i < 16; i++)
            {
                s3 += R1[i];
            }
            s0 = HexConverted(s0);
            s1 = HexConverted(s1);
            s2 = HexConverted(s2);
            s3 = HexConverted(s3);
            string[,] S0 = new string[2, 2] { {s0 ,s2 },
                                              {s1, s3 } };
            string[,] result1 = new string[2, 2];

            ///////////////////////////////////////////////////////
            string[,] x1 = new string[1, 2] { { "1", s0 } };
            
            string[,] x11 = new string[1, 2] { { "4", s1 } };
            

           
            string l = "";
            string l1 = "" ;

            l = mult(x1, m);
            l1 = mult(x11, m);
            string ls = l;
            string ls1 = l1;
           ls = hex2binary(ls);
            ls1 = hex2binary(ls1);
          
            int myInt1;
            int myInt2;
            List<int> S00 = new List<int>();
            List<int> B = ls.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt1)).Select(x => int.Parse(x.ToString())).ToList();
            List<int> B2 = ls1.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt2)).Select(x => int.Parse(x.ToString())).ToList();
            S00 = xor(B, B2); ///////////s00
            B.Clear();
            B2.Clear();
            ls = "";
            ls1 = "";
            /////////////////////////////////////////////////////s10
            string[,] x2 = new string[1, 2] { { "4", s0 } };
            string[,] x22 = new string[1, 2] { { "1", s1 } };
            
            string l2 = "";
            string l22 = "";

            l2 = mult(x2, m);
            l22 = mult(x22, m);
            ls = l2;
            ls1 = l22;
            ls = hex2binary(ls);
            ls1 = hex2binary(ls1);
            myInt1 = 0 ;
            myInt2 = 0;
            List<int> S10 = new List<int>();
             B = ls.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt1)).Select(x => int.Parse(x.ToString())).ToList();
            B2 = ls1.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt2)).Select(x => int.Parse(x.ToString())).ToList();
            S10 = xor(B, B2);
            B.Clear();
            B2.Clear();
            ls = "";
            ls = "";
            //////////////////////////////////////////////S01
            string[,] x3 = new string[1, 2] { { "1", s2 } };
            string[,] x33 = new string[1, 2] { { "4", s3 } };
           
            string l3 = "";
            string l33 = "";
            l3 = mult(x3, m);
            l33 = mult(x33, m);
            ls = l3;
            ls1 = l33;
            ls = hex2binary(ls);
            ls1 = hex2binary(ls1);
            myInt1 = 0;
            myInt2 = 0;
            List<int> S01 = new List<int>();
            B = ls.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt1)).Select(x => int.Parse(x.ToString())).ToList();
            B2 = ls1.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt2)).Select(x => int.Parse(x.ToString())).ToList();
            S01 = xor(B, B2);
            B.Clear();
            B2.Clear();
            ls = "";
            ls = "";
            //////////////////////////////// S11
            ///
            string[,] x4 = new string[1, 2] { { "4", s2 } };
            string[,] x44 = new string[1, 2] { { "1", s3 } };
            string l4= "";
            string l44 = "";
            
            l4 = mult(x4, m);
            l44 = mult(x44, m);
            ls = l4;
            ls1 = l44;
            ls = hex2binary(ls);
            ls1 = hex2binary(ls1);
            myInt1 = 0;
            myInt2 = 0;
            List<int> S11 = new List<int>();
            B = ls.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt1)).Select(x => int.Parse(x.ToString())).ToList();
            B2 = ls1.ToCharArray().Where(x => int.TryParse(x.ToString(), out myInt2)).Select(x => int.Parse(x.ToString())).ToList();
            S11 = xor(B, B2);
            B.Clear();
            B2.Clear();
            ls = "";
            ls = "";
            List<int> result = new List<int>();
            for (int i = 0; i <S00.Count;i++)
            {
                result.Add( S00[i]);
            }
            for (int i = 0; i < S10.Count; i++)
            {
                result.Add(S10[i]);
            }
            for (int i = 0; i < S01.Count; i++)
            {
                result.Add(S01[i]);
            }
            for (int i = 0; i < S11.Count; i++)
            {
                result.Add(S11[i]);
            }

            result = xor(result, key1);
            result = Subnib(result);
            result = XDDD(result);
            result = xor(result, key2);
            for(int i = 0; i <result.Count;i++)
            {
                textBox3.AppendText(result[i].ToString());
                if(i==3 || i==7 || i==11 ||i==15)
                {
                    textBox3.AppendText(" ");
                }
            }
            
            


        }
        private string hex2binary(string hexvalue) 
        {
           
            string binaryval = ""; binaryval = Convert.ToString(Convert.ToInt32(hexvalue, 16), 2).PadLeft(4,'0');
            return binaryval;
            
        }
    /// x1= [1,2]
        public static string mult(string[,] x1, string[,] m)
        {
            int[] arry = new int[2];

            string[,] l = new string[1,1] ;
            string ls = "";

            for (int i = 0; i < 2; i++)
            {
                int numericValue;
                bool isNumber = int.TryParse(x1[0, i], out numericValue);
                if (isNumber == false)
                {

                    arry[i] = Convert.ToInt32(x1[0, i], 16); 
                    

                }
              else  if(isNumber==true)
                {
                    arry[i] = Convert.ToInt32(x1[0, i]);
                }
            }


            ls = m[arry[0]-1, arry[1]-1];

            return ls;
        }

        
        public static string HexConverted(string strBinary)
        {
            string strHex = Convert.ToInt32(strBinary, 2).ToString("X");
            return strHex;
        }

        List<int> XDDD (List<int> xD)
        {
            tempR1.Clear();
            tempR2.Clear();
            string shift0 = "";
            string shift1 = "";
            string shift2 = "";
            string shift3 = "";
            string sum = "";
            for( int i = 0; i < 4;i ++)
            {
                shift0 += xD[i];
            }
            for (int i = 4; i <8; i++)
            {
                shift1 += xD[i];
            }
            for(int i = 8; i < 12; i++)
            {
                shift2 += xD[i];
            }
            for(int i = 12; i <16; i++)
            {      
                shift3 += xD[i];
            }
            //////////swapp 
            List<int> xDD = new List<int>();
            sum = shift0 + shift3 + shift2+shift1 ;
            for (int i = 0; i < sum.Length; i++)
            {
                xDD.Add(Int32.Parse(sum[i].ToString()));
            }
            return xDD;
        }
        List<int> Subnib(List<int> sub)
        {
            string sub1="";
            string sub2 ="";
            string sub3 ="";
            string sub11 ="";
            string sub1234 ="";

            for (int i = 0; i <sub.Count; i ++)
            {
                if (i < 4)
                {
                    sub1 += sub[i];                    
                }
                if (i >= 4 && i < 8)
                {
                    sub2 += sub[i]; 
                }
                if (i >= 8 && i <12)
                {
                    sub3 += sub[i];
                }
                if (i >= 12 && i < 16)
                {
                    sub11 += sub[i];
                }
            }
            ////sub1
            if(sub1=="0000")//
            {
                sub1 = "1001";
            }
            //
            else if (sub1 == "0001")
            {
                sub1 = "0100";
            }
            //
            else if (sub1 == "0010")
            {
                sub1 = "1010";
            }
            //
            else if (sub1 == "0011")
            {
                sub1 = " 1011";
            }
            //
            else if (sub1 == "0100")
            {
                sub1 = "1101";
            }
            //
            else if (sub1 == "0101")
            {
                sub1 = "0001";
            }
            //
            else if (sub1 == "0110")
            {
                sub1 = "1000";
            }
            //
            else if (sub1=="0111")
            {
                sub1 = "0101";
            }
            //
            else if (sub1 == "1000")
            {
                sub1 = "0110";
            }
            ///
            else if(sub1 == "1001")
            {
                sub1 = "0010";
            }
            ///
            else if (sub1 == "1010")
            {
                sub1 = "0000";
            }
            //
            else if (sub1 == "1011")
            {
                sub1 = "0011";
            }
            //
            else if (sub1 == "1100")
            {
                sub1 = "1100";
            }
            //
            else if (sub1 == "1101")
            {
                sub1 = "1110";
            }
            else if (sub1 == "1110")
            {
                sub1 = "1111";
            }
            else if (sub1 == "1111")
            {
                sub1 = "0111";
            }
            ////////////////////////////
            ///2
            ////sub2
            if (sub2 == "0000")//
            {
                sub2 = "1001";
            }
            //
            else if (sub2 == "0001")
            {
                sub2 = "0100";
            }
            //
            else if (sub2 == "0010")
            {
                sub2 = "1010";
            }
            //
            else if (sub2 == "0011")
            {
                sub2 = " 1011";
            }
            //
            else if (sub2 == "0100")
            {
                sub2 = "1101";
            }
            //
            else if (sub2 == "0101")
            {
                sub2 = "0001";
            }
            //
            else if (sub2 == "0110")
            {
                sub2 = "1000";
            }
            //
            else if (sub2 == "0111")
            {
                sub2 = "0101";
            }
            //
            else if (sub2 == "1000")
            {
                sub2 = "0110";
            }
            ///
            else if (sub2 == "1001")
            {
                sub2 = "0010";
            }
            ///
            else if (sub2 == "1010")
            {
                sub2 = "0000";
            }
            //
            else if (sub2 == "1011")
            {
                sub2 = "0011";
            }
            //
            else if (sub2 == "1100")
            {
                sub2 = "1100";
            }
            //
            else if (sub2 == "1101")
            {
                sub2 = "1110";
            }
            else if (sub2 == "1110")
            {
                sub2 = "1111";
            }
            else if (sub2 == "1111")
            {
                sub2 = "0111";
            }
            ///////////sub3
            ///
            if (sub3 == "0000")//
            {
                sub3 = "1001";
            }
            //
            else if (sub3 == "0001")
            {
                sub3 = "0100";
            }
            //
            else if (sub3 == "0010")
            {
                sub3 = "1010";
            }
            //
            else if (sub3 == "0011")
            {
                sub3 = " 1011";
            }
            //
            else if (sub3 == "0100")
            {
                sub3 = "1101";
            }
            //
            else if (sub3 == "0101")
            {
                sub3 = "0001";
            }
            //
            else if (sub3 == "0110")
            {
                sub3 = "1000";
            }
            //
            else if (sub3 == "0111")
            {
                sub3 = "0101";
            }
            //
            else if (sub3 == "1000")
            {
                sub3 = "0110";
            }
            ///
            else if (sub3 == "1001")
            {
                sub3 = "0010";
            }
            ///
            else if (sub3 == "1010")
            {
                sub3 = "0000";
            }
            //
            else if (sub3 == "1011")
            {
                sub3 = "0011";
            }
            //
            else if (sub3 == "1100")
            {
                sub3 = "1100";
            }
            //
            else if (sub3 == "1101")
            {
                sub3 = "1110";
            }
            else if (sub3 == "1110")
            {
                sub3 = "1111";
            }
            else if (sub3 == "1111")
            {
                sub3 = "0111";
            }
            /////////sub 4
            ///
            if (sub11 == "0000")//
            {
                sub11 = "1001";
            }
            //
            else if (sub11 == "0001")
            {
                sub11 = "0100";
            }
            //
            else if (sub11 == "0010")
            {
                sub11 = "1010";
            }
            //
            else if (sub11 == "0011")
            {
                sub11 = " 1011";
            }
            //
            else if (sub11 == "0100")
            {
                sub11 = "1101";
            }
            //
            else if (sub11 == "0101")
            {
                sub11 = "0001";
            }
            //
            else if (sub11 == "0110")
            {
                sub11 = "1000";
            }
            //
            else if (sub11 == "0111")
            {
                sub11 = "0101";
            }
            //
            else if (sub11 == "1000")
            {
                sub11 = "0110";
            }
            ///
            else if (sub11 == "1001")
            {
                sub11 = "0010";
            }
            ///
            else if (sub11 == "1010")
            {
                sub11 = "0000";
            }
            //
            else if (sub11 == "1011")
            {
                sub11 = "0011";
            }
            //
            else if (sub11 == "1100")
            {
                sub11 = "1100";
            }
            //
            else if (sub11 == "1101")
            {
                sub11 = "1110";
            }
            else if (sub11 == "1110")
            {
                sub11 = "1111";
            }
            else if (sub11 == "1111")
            {
                sub11 = "0111";
            }

            sub1234 = sub1 +sub2+sub3+sub11;
           
            

            List<int> sub4 = new List<int>();
            
            for(int i =0; i < sub1234.Length;i++)
            {
               // sub4.Add(sub1234[i]);
                sub4.Add(Int32.Parse(sub1234[i].ToString()));
            }

            return sub4;
        }
        List<int> Rotnib(List<int> rot)
        {
            List<int> rot1 = new List<int>();
            List<int> rot2 = new List<int>();
            List<int> rot3 = new List<int>();
            for ( int i = 0; i < rot.Count;i++)
            {
                if(i< rot.Count/2)
                {
                    rot1.Add(rot[i]);
                }
                if (i >= rot.Count / 2 && i< rot.Count)
                {
                    rot2.Add(rot[i]);
                }
               
            }
            for (int i = 0; i < 4; i++)
            {
                if (i < 4)
                {
                    rot3.Add(rot2[i]);
                }
            }
            for(int i=0; i <4; i++)
            { 
                if (i < 4 )
                {
                    rot3.Add(rot1[i]);
                }
            }
            
            return rot3;
        }
        void onclick()
        {
            button1.Hide();
            key.Clear();
            p.Clear();
            w0.Clear();
            w1.Clear();
            w2.Clear();
            w3.Clear();
            w4.Clear();
            w5.Clear();
            key0.Clear();
            key1.Clear();
            key2.Clear();
            temp1.Clear();
            temp2.Clear();
            tempR1.Clear();
            tempR2.Clear();
            tempw1.Clear();
            tempw3.Clear();
            sub4.Clear();

            
        }
        List<int> xor(List<int> ss, List<int> ss2)
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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
