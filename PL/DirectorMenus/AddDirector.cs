using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.DirectorMenus
{
    public partial class AddDirector : Form
    {
        FilmService filmService;
        DirectorService directorService;

        public AddDirector(FilmService filmService, DirectorService directorService)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.filmService = filmService;
            this.directorService = directorService;
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox_Name.Text) && !string.IsNullOrEmpty(maskedTextBox_Birthdate.Text) && !string.IsNullOrEmpty(textBox_Country.Text) && !string.IsNullOrEmpty(textBox_Description.Text))
            {

                DirectorDTO directorDTO = new DirectorDTO() { Name = textBox_Name.Text, Birthdate = Convert.ToDateTime(maskedTextBox_Birthdate.Text), Country = textBox_Country.Text, Description = textBox_Description.Text };

                foreach (string filmName in checkedListBox1.CheckedItems)
                {
                    directorDTO.Films.Add(new FilmDTO() { Name = filmName });
                }

                directorService.Add(directorDTO);
                this.Close();
            }
        }

        private void AddDirector_Load(object sender, EventArgs e)
        {
            maskedTextBox_Birthdate.Mask = "00/00/0000";
            FilmListFill();
        }

        private void FilmListFill()
        {
            List<FilmDTO> films = filmService.GetAll();

            int i = 0;
            foreach (FilmDTO film in films)
            {
                checkedListBox1.Items.Add(film.Name);
                i++;
            }
        }

        private void ProhibitEnteringNumbers(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void textBox_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProhibitEnteringNumbers(e);
        }

        private void textBox_Country_KeyPress(object sender, KeyPressEventArgs e)
        {
            ProhibitEnteringNumbers(e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
