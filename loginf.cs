using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Windows.Forms;
using System.Data;

namespace simpleDatabasewidMysql
{
    public partial class loginf : Form
    {
        public loginf()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            iExit = MessageBox.Show("                                                          للخروج  ", "هل أنت متأكد من رغبتك في الخروج من البرنامج؟؟", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK  == iExit )
            {
                Application.Exit();
            }
            
        }

        private void loginf_Load(object sender, EventArgs e)
        {
            //System.Drawing.Drawing2D.GraphicsPath shape = new System.Drawing.Drawing2D.GraphicsPath();
            //shape.AddEllipse(2,-50, this.Width, this.Height);
            //this.Region = new System.Drawing.Region(shape);
        }

        private void SigninBtn_Click(object sender, EventArgs e)
        {
            string Query = "";
            MySqlConnection conn = new MySqlConnection();
            DataTable sqldt = new DataTable();
            MySqlDataReader sqldRead ;
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String username = untextBox.Text;
            String password = uptextBox.Text;
            String selectQuery = "SELECT * FROM `usrs` WHERE `username`=@un  AND `Password`=@pass";
            command.CommandText = selectQuery;
            command.Connection = CONNECT.GetConnection();

            command.Parameters.Add("@un", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = command;
            adapter.Fill(sqldt);

            if (sqldt.Rows.Count > 0)
            {
                MainForm dBs = new MainForm();
                dBs.Show();
            }
            else
                MessageBox.Show( "رجــاءأعد إدخال بياناتك ", "خطأ بيانات", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnEditData_Click(object sender, EventArgs e)
        {
            untextBox.Text = "";
            uptextBox.Text = "";
        }
    }
}
