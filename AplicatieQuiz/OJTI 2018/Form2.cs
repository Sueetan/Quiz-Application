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
    public partial class Form2 : Form
    {
        public static string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mures\Documents\Visual Studio 2015\Projects\OJTI 2018\OJTI 2018\bin\Debug\eLearning1918.mdf;Integrated Security=True;Connect Timeout=30;";
        public Form2()
        {
            InitializeComponent();
            hide();
            adauga();
            //tabControl1.Hide();
            label_enunt.Text = "Problema nr.1";
        }
        public void random()
        {
            
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 TipItem,EnuntItem,Raspuns1Item,Raspuns2Item,Raspuns3Item,Raspuns4Item,RaspunsCorectItem FROM Itemi ORDER BY NEWID()", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                label_item.Text = "Item nr." + dr.GetValue(0);
                textBox1.Text = "" + dr.GetValue(1);
                radioButton1.Text = "" + dr.GetValue(2);
                radioButton2.Text = "" + dr.GetValue(3);
                radioButton3.Text = "" + dr.GetValue(4);
                radioButton4.Text = "" + dr.GetValue(5);
                checkBox1.Text = "" + dr.GetValue(2);
                checkBox2.Text = "" + dr.GetValue(3);
                checkBox3.Text = "" + dr.GetValue(4);
                checkBox4.Text = "" + dr.GetValue(5);
                textBox_raspuns.Text = "" + dr.GetValue(6);
                label_raspuns.Text = "" + dr.GetValue(6);
                
            }
                cmd.Dispose();

            if (label_item.Text =="Item nr.1")
            {
                panel2.Show();
            }
            if (label_item.Text == "Item nr.2")
            { 
                    panel1.Show();

            }
            if (label_item.Text == "Item nr.3")
            {
                panel3.Show();

            }
            if (label_item.Text == "Item nr.4")
            {
                panel4.Show();
                radioButton6.Text = "adevarat";
                radioButton7.Text = "fals";
            }
            con.Close();

        }

        private void iesireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tabControl1.Show();
            tabControl1.SelectedTab = tabPage1;
        }

        private void graficNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tabControl1.Show();
            tabControl1.SelectedTab = tabPage3;
        }

        private void carnetDeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // tabControl1.Show();
            tabControl1.SelectedTab = tabPage2;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
         public int nr = 1 ;
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            random();
            nr++;
            label_enunt.Text = "Problema nr." + nr;
            if (nr == 9)
            {
                button3.Enabled = false;
            }

        }
        public void hide()
        {
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            button2.Visible = false;
            button3.Visible = false;
            textBox1.Visible = false;
            label_enunt.Text = "";
            label_item.Text = "";
        }
        public void show()
        {
            panel1.Show();
            panel2.Show();
            panel3.Show();
            panel4.Show();
            button2.Visible = true;
            button3.Visible = true;
            textBox1.Visible = true;
        }
        public int raspuns = 1;
        private void button2_Click(object sender, EventArgs e)
        {
            if (label_item.Text == "Item nr.1")
            {
                if (textBox_raspuns.Text == textBox2.Text)
                {
                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else
                {
                    MessageBox.Show("Raspuns gresit");
                    next();
                }
            }
            else if (label_item.Text == "Item nr.2")
            {
                if (radioButton1.Checked == true && label_raspuns.Text == "1")
                {
                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else if (radioButton2.Checked == true && label_raspuns.Text == "2")
                {

                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else if (radioButton3.Checked == true && label_raspuns.Text == "3")
                {

                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else if (radioButton4.Checked == true && label_raspuns.Text == "4")
                {

                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else
                {
                    MessageBox.Show("Raspuns gresit");
                    next();
                }
            }
            else if (label_item.Text == "Item nr.3")
            {
                int r = 0;
                if (checkBox1.Checked == true)
                    r = r * 10 + 1;
                if (checkBox2.Checked == true)
                    r = r * 10 + 2;
                if (checkBox3.Checked == true)
                    r = r * 10 + 3;
                if (checkBox4.Checked == true)
                    r = r * 10 + 4;
                if (r.ToString() == label_raspuns.Text)
                {

                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else
                {
                    MessageBox.Show("Raspuns gresit");
                    next();
                }
            }
            else if (label_item.Text == "Item nr.4")
            {
                if (radioButton1.Checked == true && label_raspuns.Text == "1")
                {
                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else if (radioButton2.Checked == true && label_raspuns.Text == "0")
                {

                    raspuns++;
                    MessageBox.Show("Ai raspuns corect si ai avansat la urmatoarea intrebare"); next();
                }
                else
                {
                    MessageBox.Show("Raspuns gresit");
                    next();
                }
            }
        }
        private void next()
        {
            label_punctaj.Text = "Punctaj: " + raspuns;
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            textBox2.Text = "";
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            random();
            nr++;
            label_enunt.Text = "Problema nr." + nr;
            if (nr == 10)
            {
                hide();
                MessageBox.Show("Ai obtinut nota " + raspuns);
                update();
                idu();
                media();
                graph();
                button1.Enabled = true;
                adauga1();
            }
        }
        private void adauga()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nota", typeof(int));
            dt.Columns.Add("Data", typeof(DateTime));
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select notaevaluare,dataevaluare,idelev from Evaluari where IdElev='"+Form1.id+"'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr.GetValue(0), dr.GetValue(1));
                label_elev.Text = "Carnetul de note al elevului" + dr.GetValue(2);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            con.Close();
            cmd.Dispose();
        }
             void adauga1()
              {
            //dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            DataTable dt = new DataTable();
            dt.Columns.Add("Nota", typeof(int));
            dt.Columns.Add("Data", typeof(DateTime));
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select notaevaluare,dataevaluare,idelev from Evaluari where IdElev='" + Form1.id + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dt.Rows.Add(dr.GetValue(0), dr.GetValue(1));
                label_elev.Text = "Carnetul de note al elevului" + dr.GetValue(2);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            con.Close();
            cmd.Dispose();
        }
        public string idd = Form1.id;
        private void update()
        {
            SqlCommand cmd;
            
            DateTime dt = DateTime.Now;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            cmd = new SqlCommand("Insert into Evaluari(IdElev,DataEvaluare,NotaEvaluare) values (@idelev,@dataevaluare,@notaevaluare)", con);
            cmd.Parameters.AddWithValue("idelev",idd);
            cmd.Parameters.AddWithValue("dataevaluare", dt);
            cmd.Parameters.AddWithValue("notaevaluare", raspuns);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            show();
            random();
            button1.Enabled = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bmp, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));

            e.Graphics.DrawImage(bmp, 250, 120);

        }
        void graph()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select notaevaluare,dataevaluare,idelev,idevaluare from Evaluari where IdElev='" + Form1.id + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.chart1.Series["Nota elev"].Points.AddXY(dr.GetInt32(3), dr.GetInt32(0));
            }
            con.Close();
            cmd.Dispose();
        }
        public int idmedia;
        void idu()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select idutilizator from Utilizatori where ClasaUtilizator='" + Form1.clasa + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idmedia = dr.GetInt32(0);
            }
            con.Close();
            cmd.Dispose();
        }
        public int S,s1,nr1;
        void media()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand("select notaevaluare,dataevaluare,idelev,idevaluare from Evaluari where IdElev='" + idmedia + "'", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                S = dr.GetInt32(3);
                nr1++;
                s1 = S / nr1;
                this.chart1.Series["Media clasei"].Points.AddXY(s1, dr.GetInt32(0));
            }
            con.Close();
            cmd.Dispose();
        }
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
