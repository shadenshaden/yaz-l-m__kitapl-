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
    public partial class Form1 : Form
    {

        int move;
        int movx;
        int monee;


        // SQL 
        SqlConnection con = new SqlConnection();
        SqlDataAdapter da = new SqlDataAdapter();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized; 
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            movx = e.X;
            monee = e.Y; 
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movx, MousePosition.Y - monee);
            }

        }

        private void Form1_Activated(object sender, EventArgs e)
        {

            DataTable dd = new DataTable();

            con.ConnectionString = ( @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\aliba\source\repos\Books libar\Books libar\Dbbook.mdf;Integrated Security=True");
            var sql = "SELECT ID as التسلسل  ,TITLE,AUTHER,PRICE,CAT FROM BOOKS";
            da = new SqlDataAdapter(sql,con);
            da.Fill(dd);
            dataGridView1.DataSource = dd;
            dataGridView1.Columns[0].HeaderText = "";
        
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            at A= new at();
            bunifuTransition1.ShowSync(A);
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            frm_de d = new frm_de();
            d.Show(); 
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbbookDataSet.BOOKS' table. You can move, or remove it, as needed.
            this.bOOKSTableAdapter.Fill(this.dbbookDataSet.BOOKS);

        }
    }
}
