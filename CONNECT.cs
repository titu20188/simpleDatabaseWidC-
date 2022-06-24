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
    class CONNECT
    {
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource =localhost;port=3306;username=root;password=;database=mysimple_database";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySqlConnection! \n " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            return con;
        }
    }
}
