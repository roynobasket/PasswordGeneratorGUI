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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "0123456789"+
                "@#$%&*ㄱㄴㄷㄹㅁㅂㅅㅇㅈㅊㅋㅌㅍㅎㅏㅑㅓㅕㅗㅛㅜㅠㅡㅣこんにちは、私の名前はマンドリです";
           
            return GetRandomString(length, alphanumericCharacters);
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
           

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            var characterArray = characterSet.Distinct().ToArray();
       
           
           if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            
            else if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            else 
           {    for (int i = 0; i < length; i++)
                {
                    ulong value = BitConverter.ToUInt64(bytes, i * 8);
                    result[i] = characterArray[value % (uint)characterArray.Length];
                }
            }
            return new string(result);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int getnumber = int.Parse(textBox1.Text);

            if (getnumber < 8)
            {
                label2.Text = "length is too small";
            }
            else if (getnumber > 32)
                label2.Text = "length is too big";
            else
            {
                string randomstring = GetRandomAlphanumericString(getnumber);
                label2.Text = randomstring;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }
    }
}