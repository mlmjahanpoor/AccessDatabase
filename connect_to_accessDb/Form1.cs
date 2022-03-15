using System.Data;
using System.Data.OleDb;

namespace connect_to_accessDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=protick1.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            //cmd.CommandText = "Insert into Student(FirstName,LastName)Values('" + textBox1.Text + "','" + textBox2.Text + "')";

            cmd.CommandText = "select * from members where code=1354";

            cmd.Connection = con;

            var x = cmd.ExecuteReader();
            OleDbDataReader reader = x;
            if (x.Read())
            {
                var code = x["Code"];
                var record = x["LastRecord"];

                lblCode.Text = code.ToString();
                lblRecord.Text = record.ToString();
            }
            //MessageBox.Show("Record Submitted", "Congrats");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=protick1.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            //cmd.CommandText = "Insert into Student(FirstName,LastName)Values('" + textBox1.Text + "','" + textBox2.Text + "')";

            string sql = "UPDATE members SET lastRecord = @x where code = @c";
            cmd.Connection = con;
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.Add("@x", 5465476);
            cmd.Parameters.Add("@c", 1354);
            //cmd.CommandText = $"Update members set members lastrecord = {10000} where code=1354";
            cmd.ExecuteNonQuery();
            //MessageBox.Show("Record Submitted", "Congrats");
            con.Close();
        }
    }
}