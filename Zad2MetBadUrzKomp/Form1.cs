using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Zad2MetBadUrzKomp
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        List<string> list = new List<string>();
        List<float> firstValue = new List<float>();
        List<float> secondValue = new List<float>();
        private Calculating calc = new Calculating();

        
      

        private async void wybierzToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text File|*.txt", Multiselect = false })
            {
            

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader rd = new StreamReader(ofd.FileName))
                    {
                        string line;
                        while ((line = rd.ReadLine()) != null)
                        {
                            list.Add(line);
                      
                           
                        }


                    }
                }
                
                SplitString();
            
            }
         

        }

        public void SplitString()
        {
            foreach (var item in list)
            {

                string[] separators = {"\t"};
                string[] words = item.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                
                firstValue.Add(float.Parse(words[0]));
                secondValue.Add(float.Parse(words[1]));
            }
            listBox1.DataSource = firstValue;
            listBox2.DataSource = secondValue;
            calc.firstList = firstValue;
            calc.secondList = secondValue;
         

          
            for (int i = 0; i < firstValue.Count; i++)
            {

                this.chart1.Series["U"].Points.AddXY(i, firstValue[i]);
                this.chart1.Series["I"].Points.AddXY(i, secondValue[i]);
            }
            
           
      
            if (firstValue.Count == secondValue.Count)
            {
                quanitityLabel.Text = firstValue.Count.ToString();
                calc.quantity = firstValue.Count;

            }
            else
            {
                quanitityLabel.Text = "Listy różnią się wielkością.";
            }
            

        }

        private void wyjdźToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Szymon Sobieszczański \rPolitechnika Opolska 2017");
        }

        private void calcButton_Click(object sender, EventArgs e)
        {
            if (firstValue.Count !=0 &&  secondValue.Count != 0)
            {
              
                
                try
                {
                    calc.R = float.Parse(RTextBox.Text);
                    calc.X = float.Parse(XTextBox.Text);

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Wprowadzono Błędną Wartość!","Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
              return;
                }

                RpOutputTextBox.Text = calc.CalcRp().ToString();
                XpOutputTextBox.Text = calc.calcXp().ToString();
                LafOutputTextBox.Text = calc.calcLaf().ToString();
                RfOutputTextBox.Text = calc.calcRf().ToString();
                AkUResult.Text = calc.Aku().ToString();
                AkIResult.Text = calc.AkI().ToString();
                BkUREsult.Text = calc.Bku().ToString();
                BkIResult.Text = calc.BkI().ToString();

            }
            else
            {
                MessageBox.Show("Nie dodano żadnego Pliku","Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           
        }

      
    }
}
