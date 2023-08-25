﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ProjectUsers
{
    public partial class FormInsert : Form
    {
        public FormInsert()
        {
            InitializeComponent();
        }

        public string selectedFilePath;

        private void btnPhotoSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.png|Tüm Dosyalar (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnDirectoryDelete_Click(object sender, EventArgs e)
        {
            selectedFilePath = "";
            pictureBox1.Image = null;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        private void btnDataSave_Click(object sender, EventArgs e)
        {
            MainForm mainForm = Application.OpenForms.OfType<MainForm>().FirstOrDefault();
            DialogResult result = MessageBox.Show("Kişiyi kaydetmek istediğinize emin misiniz?", "Kişi Kaydetme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string destinationFolder = "";
            if (result == DialogResult.Yes)
            {
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

                DateTime? birthDate = null;

                try
                {
                    if (!string.IsNullOrEmpty(txtShortDate.Text))
                    {
                        birthDate = DateTime.Parse(txtShortDate.Text);
                    }
                }
                catch (Exception)
                {

                }

                DatabaseManager dbManager = new DatabaseManager();
                dbManager.InsertDataToDatabase(txtName.Text, txtSurname.Text, birthDate, txtMail.Text, txtNumber.Text, txtAddress.Text, txtCity.Text, txtCountry.Text, destinationFolder);
                
                
                
                mainForm?.PanelTemizle();
                mainForm?.PanelView();
                this.Close();
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Çıkmak İster misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    mainForm?.PanelTemizle();
                    mainForm?.PanelView();
                    this.Close();
                }
            }
        }

    }
}
