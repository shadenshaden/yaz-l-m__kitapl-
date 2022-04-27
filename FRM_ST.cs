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

namespace Books_libar
{
    public partial class FRM_ST : Form
    {
        // SQL 
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public FRM_ST()
        {
            InitializeComponent();
        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_ST_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {


            if (id_cat.Text != "")
            {
                con.ConnectionString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aliba\source\repos\Books libar\Books libar\Dbbook.mdf;Integrated Security=True");
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO TBCAT (CAT) VALUES (@CAT)";
                cmd.Parameters.AddWithValue("@CAT", id_cat.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                frm_dee F = new frm_dee();
                F.Show();
                this.Close(); 

            }
            else
            {
                MessageBox.Show("قم بأضافو اولآ ");
            }
          


        }
    }
}
