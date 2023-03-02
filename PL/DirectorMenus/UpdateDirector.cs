using BLL.DTO;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL.DirectorMenus
{
    public partial class UpdateDirector : Form
    {
        DataGridViewRow row;
        DirectorService directorService;
        FilmService filmService;

        public UpdateDirector(DataGridViewRow row, DirectorService directorService, FilmService filmService)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.row = row;
            this.directorService = directorService;
            this.filmService = filmService;
        }

        private void UpdateDirector_Load(object sender, EventArgs e)
        {
            FillTextBoxes();
        }

        private void FillTextBoxes()
        {
            textBox_Name.Text = row.Cells[1].Value.ToString();
            maskedTextBox_Birthdate.Text = row.Cells[2].Value.ToString();
            textBox_Country.Text = row.Cells[3].Value.ToString();
            textBox_Description.Text = row.Cells[4].Value.ToString();

            string filmsName = row.Cells[5].Value.ToString();


            MatchCollection matchList = Regex.Matches(filmsName, @"«(.*?)»");
            List<string> filmNames = matchList.Cast<Match>().Select(m => m.Value.Substring(1, m.Value.Length - 2)).ToList();

            int i = 0;

            List<FilmDTO> films = filmService.GetAll();


            foreach (FilmDTO film in films)
            {
                checkedListBox1.Items.Add(film.Name);
                i++;
            }

            foreach (string name in filmNames)
            {
                for (int j = 0; j < checkedListBox1.Items.Count; j++)
                {
                    if (name.Equals(checkedListBox1.Items[j]))
                    {
                        checkedListBox1.SetItemChecked(j, true);
                    }
                }
            }
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            DirectorDTO director = new DirectorDTO() { Id = (int)row.Cells[0].Value, Name = textBox_Name.Text, Birthdate = Convert.ToDateTime(maskedTextBox_Birthdate.Text), Country = textBox_Country.Text, Description = textBox_Description.Text };

            List<FilmDTO> films = new List<FilmDTO>();

            foreach (string filmName in checkedListBox1.CheckedItems)
            {
                FilmDTO temp = new FilmDTO() { Name = filmName };
                films.Add(temp);
            }

            director.Films = films;

            directorService.ChangeData(director);

            this.Close();
        }
    }
}
