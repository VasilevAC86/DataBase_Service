using Service;
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

namespace DataBase_AutoService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!FSWork.IsFileExist("Servis.db")) MakeStore();
            FillMechanicsName();
        }
        private void MakeStore()
        {
            if (DBWork.MakeDB())
            {
                MessageBox.Show($"База данных существует");
            };
        }

        private void FillMechanicsName()
        {
            foreach (string name in DBWork.GetMechanics())
            {
                cmbMechanic.Items.Add(name);
            }
            DBWork.GetMechanics();
        }

        private void picBoxAvatar_Click(object sender, EventArgs e)
        {
            if (cmbMechanic.SelectedItem != null) // Если в списке мы выбрали механика
            {
                byte[] _image = FSWork.GetImage();
                string _name = cmbMechanic.SelectedItem.ToString();
                DBWork.AddAvatar(_name, _image);
            }            
        }
        private void SetImagePicterBox()
        {
            string _name = cmbMechanic.SelectedItem.ToString();
            MemoryStream ms = DBWork.GetAvatar(_name);
            if (ms != null)
            {
                picBoxAvatar.Image = Image.FromStream(DBWork.GetAvatar(_name));
            }
            else
            {
                picBoxAvatar.BackColor = Color.Black;
                picBoxAvatar.Image = null;
            }
        }
        // Когда изменилось значение в combobox
        private void cmbMechanic_SelectedValueChanged(object sender, EventArgs e)
        {
            SetImagePicterBox();
        }
    }
}
