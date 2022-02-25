using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quasar_Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var str = richTextBox1.Text;
            var unique = false;
            var usable = false;
            var description = "Just a description";
            var multiplier = 1;
            var shouldClose = false;
            var charsToRemove = new string[] { "(", ",", ")", "'", "\"", };

            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }

            if (checkBox1.Checked) unique = true;
            else unique = false;
            if (checkBox2.Checked) usable = true;
            else usable = false;
            if (checkBox3.Checked) shouldClose = true;

            description = richTextBox2.Text;

            if (richTextBox3.TextLength == 0) multiplier = 1;
            else multiplier = Convert.ToInt16(richTextBox3.Text);

            string[] subs = str.Split(' ');
            var item = subs[0];
            var label = subs[1];
            int weight = Convert.ToInt16(subs[2]) * multiplier;
            textBox1.Multiline = true;
            textBox1.Text = $"[\"{item}\"]" + "{\r\n" +
                            $"      [\"name\"] = \"{item}\",\r\n" +
                            $"      [\"label\"] = \"{label}\",\r\n" +
                            $"      [\"weight\"] = {weight},\r\n" +
                            $"      [\"type\"] = \"item\",\r\n" +
                            $"      [\"image\"] = \"{item}.png\",\r\n" +
                            $"      [\"unique\"] = {unique},\r\n" +
                            $"      [\"useable\"] = {usable},\r\n" +
                            $"      [\"shouldClose\"] = {shouldClose},\r\n" +
                            $"      [\"combinable\"] = nil,\r\n" +
                            $"      [\"description\"] = \"{description}\"\r\n" +
                            "},";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            textBox1.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
