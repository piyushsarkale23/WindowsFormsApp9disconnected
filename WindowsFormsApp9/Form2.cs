using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml.Linq;


namespace WindowsFormsApp9
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }

        private DataSet GetAllBooks()
        {
            da = new SqlDataAdapter("select * from Book", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "Book");
            return ds;
        }


        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllBooks();
                DataRow row = ds.Tables["Book"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int res = da.Update(ds.Tables["Book"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record deleted");
                    }

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllBooks();
                DataRow row = ds.Tables["Book"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row["Bookname"] = txtname.Text;
                    row["author"] = txtauthor.Text;
                    row["price"] = txtprice.Text;
                    int res = da.Update(ds.Tables["Book"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record updated");
                    }

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllBooks();
                DataRow row = ds.Tables["Book"].Rows.Find(Convert.ToInt32(txtid.Text));
                if (row != null)
                {
                    txtname.Text = row["Bookname"].ToString();
                    txtauthor.Text = row["author"].ToString();
                    txtprice.Text = row["price"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtauthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            try
            {
                DataSet ds = GetAllBooks();
                DataRow row = ds.Tables["Book"].NewRow();
                row["id"] = txtid.Text;
                row["Bookname"] = txtname.Text;
                row["author"] = txtauthor.Text;
                row["price"] = txtprice.Text;
                // add new row in the dataset table
                ds.Tables["Book"].Rows.Add(row);
                int res = da.Update(ds.Tables["Book"]);
                if (res >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
