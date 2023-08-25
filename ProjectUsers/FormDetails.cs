using ProjectUsers.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUsers
{
    public partial class FormDetails : Form
    {
        public int Veri { get; set; }
        public FormDetails()
        {
            InitializeComponent();
        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager();
            People userDetails = dbManager.GetDataFromDatabase("SELECT * FROM People WHERE ID = " + Veri)[0];

            

            try
            {
                pictureBox1.Image = Image.FromFile(userDetails.PhotoUrl);
            }
            catch (Exception)
            {
                pictureBox1.Image = Image.FromFile(@"..\..\Img\default_profile.png");
            }

            txtName.Text = userDetails.Name;
            txtSurname.Text = userDetails.Surname;
            txtEmail.Text = userDetails.Email;
            txtNumber.Text = userDetails.PhoneNumber;
            string birthdate = userDetails.Birthdate.ToString("yyyy/MM/dd");
            if (birthdate == "0001.01.01")
            {
                birthdate = "";
            }
            txtBirthdate.Text = birthdate;
            txtAddress.Text = userDetails.Address;
            txtCity.Text = userDetails.City;
            txtCountry.Text = userDetails.Country;
        }

        private void tıklaToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            DatabaseManager dbManager = new DatabaseManager();
            dbManager.PeopleDelete(Veri);
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            btnDirectoryDelete.Visible = true;
            btnDirectorySelection.Visible = true;

            txtName.ReadOnly = false;
            txtSurname.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtNumber.ReadOnly = false;
            txtBirthdate.ReadOnly = false;
            txtAddress.ReadOnly = false;
            txtCity.ReadOnly = false;
            txtCountry.ReadOnly = false;
        }
        public DateTime birthDate;
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                birthDate = DateTime.Parse(txtBirthdate.Text);
            }
            catch (Exception)
            {
                birthDate = DateTime.Parse("0001.01.01");
            }

            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.PeopleUpdate(Veri, txtName.Text, txtSurname.Text, birthDate.ToString("yyyy/MM/dd"), txtEmail.Text, txtNumber.Text, txtAddress.Text, txtCity.Text, txtCountry.Text, destinationFolder);

            

            btnConfirm.Visible = false;
            btnDirectorySelection.Visible = false;
            btnDirectoryDelete.Visible = false;

            txtName.ReadOnly = true;
            txtSurname.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtNumber.ReadOnly = true;
            txtBirthdate.ReadOnly = true;
            txtAddress.ReadOnly = true;
            txtCity.ReadOnly = true;
            txtCountry.ReadOnly = true;

            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            mainForm?.PanelTemizle();
            mainForm?.PanelView();
        }

        public string selectedFilePath;
        public string destinationFolder = "";
        private void btnDirectorySelection_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.png|Tüm Dosyalar (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                destinationFolder = @"..\..\Img\" + DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(selectedFilePath);

                string fileName = Path.GetFileName(selectedFilePath);
                File.Copy(selectedFilePath, destinationFolder, true);
            }
            else
            {
                destinationFolder = string.Empty;
            }
        }

        private void btnDirectoryDelete_Click(object sender, EventArgs e)
        {
            selectedFilePath = "";
            pictureBox1.Image = null;
        }
    }
}
