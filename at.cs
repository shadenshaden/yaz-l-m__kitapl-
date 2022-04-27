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
namespace Books_libar
{
    public partial class at : Form
    {


        // sql 
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        List<string> List = new List<string>();
        public int state;

        public object COVER { get; private set; }

        public at()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            try
            {

                con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aliba\source\repos\Books libar\Books libar\Dbbook.mdf;Integrated Security=True");
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "SELECT CAT FROM TBCAT";
                var rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    List.Add(Convert.ToString(rd[0]));

                }

                int i = 0;
                while (i < List.LongCount())
                {
                    comboBox1.Items.Add(List[i]);
                    i = i + 1;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRM_ST S =   new FRM_ST();
            bunifuTransition1.ShowSync(S);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            MemoryStream ma = new MemoryStream();
            pictureBox1.Image.Save(ma, System.Drawing.Imaging.ImageFormat.Jpeg);
            var _cover = ma.ToArray();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aliba\source\repos\Books libar\Books libar\Dbbook.mdf;Integrated Security=True");
            con.Open();

            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO TBBOOKS (TITLE,AUTHER,PRICE,CAT,DATE,RATE,COVER) VALUES (@TITLE,@AUTHER,@PRICE,@CAT,@DATE,@RATE,@COVER)";
            cmd.Parameters.AddWithValue("@TITLE", bunifuMaterialTextbox1.Text);
            cmd.Parameters.AddWithValue("@AUTHER", bunifuMaterialTextbox2.Text);
            cmd.Parameters.AddWithValue("@PRICE", bunifuMaterialTextbox3.Text.ToString());
            cmd.Parameters.AddWithValue("@CAT", bunifuMaterialTextbox2.Text);
            cmd.Parameters.AddWithValue("@DATE", bunifuDatepicker1.Text);
            cmd.Parameters.AddWithValue("@RATE", bunifuRating1.Value);
            cmd.Parameters.AddWithValue("@COVER", _cover.ToString());
            cmd.ExecuteNonQuery();
    

            frm_dee F = new frm_dee();
            F.Show();
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dia = new OpenFileDialog();
            var result = dia.ShowDialog();
            if (result == DialogResult.OK)
            {
             pictureBox1.Image = Image.FromFile(dia.FileName);
            }
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
