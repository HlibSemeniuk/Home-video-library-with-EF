using BLL.DTO;
using BLL.Services;
using DAL.Entitys;
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
    public partial class DirectorMenu : Form
    {
        FilmService filmService;
        DirectorService directorService;

        int selectedRow;

        public DirectorMenu(DirectorService directorService, FilmService filmService)
        {
            this.directorService = directorService;
            this.filmService = filmService;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void DirectorMenu_Load(object sender, EventArgs e)
        {
            CreateColumns();
            RefreshDataGrid(dataGridView1);
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("ID", "ID");
            dataGridView1.Columns.Add("Name", "Ім'я та прізвище");
            dataGridView1.Columns.Add("Birthdate", "Дата народження");
            dataGridView1.Columns.Add("Country", "Країна");
            dataGridView1.Columns.Add("Description", "Опис");
            dataGridView1.Columns.Add("Filmography", "Фільмографія");
        }

        private void RefreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            List<DirectorDTO> directors = directorService.GetAll().ToList();
            FillRows(dgv, directors);
        }

        private void FillRows(DataGridView dgv, List<DirectorDTO> directors)
        {
            FilmCrewInfoFiller filler = new FilmCrewInfoFiller();
            filler.Fill(dgv, directors.ToArray());
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            AddDirector addDirector = new AddDirector(filmService, directorService);
            addDirector.ShowDialog();
            RefreshDataGrid(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                textBox_ID.Text = row.Cells[0].Value.ToString();
                textBox_Name.Text = row.Cells[1].Value.ToString();
                textBox_Age.Text = row.Cells[2].Value.ToString();
                textBox_Country.Text = row.Cells[3].Value.ToString();
                textBox_Description.Text = row.Cells[4].Value.ToString();
                textBox_Filmography.Text = row.Cells[5].Value.ToString();
            }
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            SearchBy(dataGridView1);
        }

        private void SearchBy(DataGridView dgv)
        {

            dgv.Rows.Clear();

            Func<Director, bool> propertyMatch = a => a.Name.Contains(textBox_Search.Text) || a.ID.ToString().Contains(textBox_Search.Text) || a.Description.Contains(textBox_Search.Text) || a.Country.Contains(textBox_Search.Text) || a.Birthdate.ToString("dd.MM.yyyy").Contains(textBox_Search.Text) || a.Films.ToList().Exists(x => x.Name.Contains(textBox_Search.Text));

            List<DirectorDTO> dirctors = directorService.Find(propertyMatch);
            FillRows(dgv, dirctors);
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                UpdateDirector updateDirector = new UpdateDirector(row, directorService, filmService);
                updateDirector.ShowDialog();
                RefreshDataGrid(dataGridView1);
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (selectedRow >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                directorService.Delete((int)row.Cells[0].Value);

                RefreshDataGrid(dataGridView1);
            }
        }
    }
}
