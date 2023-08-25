using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Collections;
using ProjectUsers.DataAccess;
using ProjectUsers.Entities.Concrete;

namespace ProjectUsers
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Dictionary<int, Panel> panelsDictionary = new Dictionary<int, Panel>();

        public void PanelTemizle()
        {
            panelsDictionary.Clear();
            for (int a = panel1.Controls.Count - 1; a >= 0; a--)
            {
                Control control = panel1.Controls[a];

                if (control is Panel)
                {
                    panel1.Controls.Remove(control);
                    control.Dispose();
                }
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            PanelTemizle();
            PanelView();


        }
        public void PanelView()
        {
            PeopleDbContext dbManager = new PeopleDbContext();

            const int panelHeight = 55;
            const int spacing = 5;
            int i = 0;
            //"SELECT * FROM People WHERE Name LIKE '%" + txtSearch.Text + "%' OR Surname LIKE '%" + txtSearch.Text + "%' ORDER BY Name, Surname"
            foreach (People data in dbManager.SearchPeopleByText(txtSearch.Text))
            {
                Panel panel = new Panel();
                panel.BackColor = Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(70)))), ((int)(((byte)(84)))));
                panel.Location = new Point(12, 12 + i * (panelHeight + spacing));
                panel.Size = new Size(250, panelHeight);
                panel.Name = data.ID.ToString();
                panel.Cursor = Cursors.Hand;

                Label label = new Label();
                label.AutoSize = true;
                label.Location = new Point(72, 20);
                label.Text = data.Name + " " + data.Surname;
                label.Font = new Font(label.Font.FontFamily, 12f, label.Font.Style);

                PictureBox pictureBox = new PictureBox();
                pictureBox.Location = new Point(3, 3);
                pictureBox.Size = new Size(50, 50);
                pictureBox.TabStop = false;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                try
                {
                    pictureBox.Image = Image.FromFile(data.PhotoUrl);
                }
                catch (Exception)
                {
                    pictureBox.Image = Image.FromFile(@"..\..\Img\default_profile.png");
                }

                panel.Controls.Add(label);
                panel.Controls.Add(pictureBox);
                panel.Click += PersonPanel_Click;
                panel1.Controls.Add(panel);
                panelsDictionary.Add(data.ID, panel);

                i++;
            }
        }

        private void PersonPanel_Click(object sender, EventArgs e)
        {
            Panel clickedPanel = (Panel)sender;
            int personID = int.Parse(clickedPanel.Name);

            FormDetails formDetails = new FormDetails();
            formDetails.Veri = personID;
            formDetails.Show();
        }



        private int increaseAmount = 5;
        private void timerTxtSize_Tick(object sender, EventArgs e)
        {
            txtSearch.Visible = true;
            if (txtSearch.Width + increaseAmount <= 180)
            {
                txtSearch.Width += increaseAmount;
            }
            else
            {
                timerTxtSize.Stop();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            timerTxtSize.Start();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormInsert frmInsert = new FormInsert();
            frmInsert.StartPosition = FormStartPosition.CenterParent;
            frmInsert.ShowDialog();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            PanelTemizle();
            PanelView();
        }
    }
}
