using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        List<Person> people = new List<Person>();
        public Dashboard()
        {
            InitializeComponent();
            UpdateBinding();
        }

        private void UpdateBinding()
        {
            PeopleFoundListBox.DataSource = people;
            PeopleFoundListBox.DisplayMember = "FullInfo";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            people = db.GetPeople(LastNameText.Text);

            UpdateBinding(); 
        }

        private void InsertRecordButton_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();
            db.InsertPerson(FirstNameInsText.Text, LastNameInsText.Text, emailAddressInsText.Text, PhoneNumberInsText.Text);
            FirstNameInsText.Text = "";
            LastNameInsText.Text = "";
            emailAddressInsText.Text = "";
            PhoneNumberInsText.Text = "";
        }
    }
}
