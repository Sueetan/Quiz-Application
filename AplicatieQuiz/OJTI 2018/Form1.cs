using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace OJTI_2018
{
    public partial class Form1 : Form
    {
        public static class elev
        {
            public static string email { get; set; }
        }

        public static string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mures\Documents\Visual Studio 2015\Projects\OJTI 2018\OJTI 2018\bin\Debug\eLearning1918.mdf;Integrated Security=True;Connect Timeout=30;";

        public Form1()
        {
            InitializeComponent();

        }

        private int img = 1;
        private void loadnext()
        {
            if (img == 5)
            {
                img = 1;
            }
            pictureBox1.ImageLocation = string.Format(@"slide\{0}.jpg", img);
            img++;
        }
        private void stergere()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd;
             cmd = new SqlCommand("Delete from Evaluari", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Evaluari", con);
            cmd.ExecuteNonQuery();
             cmd = new SqlCommand("Delete from Itemi", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Itemi", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("Delete from Utilizatori", con);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("TRUNCATE TABLE Utilizatori", con);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        private void Initializare()
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd;
            StreamReader sr = new StreamReader(Application.StartupPath + @"\..\..\date.txt");
            string sir;
            char[] split = { ';' };
            con.Open();
            int d = 0;
            while((sir = sr.ReadLine())!=null)
            {
                if(sir.Contains("Utilizatori:"))
                {
                    d = 1;
                    sir = sr.ReadLine();
                }
                if (sir.Contains("Itemi:"))
                {
                    d = 2;
                    sir = sr.ReadLine();
                }
                if (sir.Contains("Evaluari:"))
                {
                    d = 3;
                    sir = sr.ReadLine();
                }
                if(d==1)
                {

                    string[] siruri = sir.Split(split);
                    cmd = new SqlCommand("Insert into Utilizatori(numeprenumeutilizator,parolautilizator,emailutilizator,clasautilizator) values ('" + siruri[0] + "','" + siruri[1] + "','" + siruri[2] + "','" + siruri[3] + "')", con);
                    cmd.ExecuteNonQuery();
                }
                else if (d ==2 )
                {
                    string[] siruri = sir.Split(split);
                    cmd = new SqlCommand("Insert into Itemi(TipItem,EnuntItem,Raspuns1Item,Raspuns2Item,Raspuns3Item,Raspuns4Item,RaspunsCorectItem)values('" + Convert.ToInt32(siruri[0]) + "','" + siruri[1] + "','" + siruri[2] + "','" + siruri[3] + "','" + siruri[4] + "','" + siruri[5] + "','" + siruri[6] + "')", con);
                    cmd.ExecuteNonQuery();
                }
                else if (d==3)
                {
                    string[] siruri = sir.Split(split);
                    cmd = new SqlCommand("insert into Evaluari(IdElev,DataEvaluare,NotaEvaluare)values('" + Convert.ToInt32(siruri[0]) + "','" + Convert.ToDateTime(siruri[1]) + "','" + Convert.ToInt32(siruri[2]) + "')", con);
                    cmd.ExecuteNonQuery();
                }
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        stergere();
            Initializare();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool ok = false;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select EmailUtilizator,ParolaUtilizator,IdUtilizator,ClasaUtilizator from Utilizatori", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if(dr.GetValue(0).ToString() == textBox2.Text && dr.GetValue(1).ToString() == textBox3.Text)
                {
                    id = dr.GetValue(2).ToString();
                    clasa = dr.GetValue(3).ToString();
                    ok = true;
                    Form2 ss = new Form2();
                    this.Hide();
                    ss.Show();
                }
            }
            if (!ok)
            {
                MessageBox.Show("Eroare de autentificare!");
                textBox2.Text = "";
                textBox3.Text = "";
            }
            con.Close();
            cmd.Dispose();
        }
        public bool dirtyBool = true;
        private void button4_Click(object sender, EventArgs e)
        {

            if (dirtyBool)
            {
                m1();
            }
            else
            {
                m2();
            }
            dirtyBool = !dirtyBool;
        }
        public void m1()
        {
            timer1.Start();
            button4.Text = "Manual";
            button3.Enabled = false;
            button5.Enabled = false;
        }
        public void m2()
        {
            timer1.Stop();
            button4.Text = "Auto";
            button3.Enabled = true;
            button5.Enabled = true;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            loadnext();
            if(progressBar1.Value != 10)
        {
                progressBar1.Value++;
            }
        else
        {
                timer1.Stop();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Maximum = 10;
            timer1.Enabled = true;  // Enable the timer.
            timer1.Start(); //Strart it
                            // timer1.Interval = 1000; // The time per tick.
            timer1.Tick += new EventHandler(timer1_Tick);
            button4.Text = "Manual";
            button3.Enabled = false;
            button5.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value != 0)
            {
                if (img == 5)
                {
                    img = 1;
                }
                if (img == 1)
                {
                    img = 4;
                }
                pictureBox1.ImageLocation = string.Format(@"slide\{0}.jpg", img);
                img--;
                progressBar1.Value--;
            }

        }
        public static string id,clasa;
        private void button5_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value != 10)
            {
                if (img == 5)
                {
                    img = 1;
                }
                pictureBox1.ImageLocation = string.Format(@"slide\{0}.jpg", img);
                img++;
                progressBar1.Value++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
