using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLibrary
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        //Kad se pokrene aplikacija, inicijalizira se glavna forma i dodaje se Login forma
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Login login = new Login();

            //Predbilježiti se na Event
            login.UserLoggedIn += Login_UserLoggedIn;

            login.Show(this);
        }

        private void Login_UserLoggedIn(object sender, EventArgs e)
        {
            
        using (DataSet dataSet = new DataSet())
            {
                //Read xml to dataset and pass file path as parameter
                dataSet.ReadXml("popisKnjiga.xml");
                dataGridView.DataSource = dataSet.Tables[0];
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
