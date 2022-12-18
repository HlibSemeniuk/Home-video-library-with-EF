using BLL.DTO;
using BLL.Services;
using DAL;
using DAL.EF;
using DAL.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public partial class Form1 : Form
    {
        int selectedRow;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
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
            using (HomeVideoLibraryContext context = new HomeVideoLibraryContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                ActorService actorService = new ActorService(uow);
                List<ActorDTO> actors = actorService.GetAll();
                FillRows(dgv, actors);

            }

        }

        private void FillRows(DataGridView dgv, List<ActorDTO> actors)
        {
                dgv.Rows.Clear();
                foreach (ActorDTO actor in actors)
                {
                string films = "";
                int i = 0;
                foreach (FilmDTO film in actor.Films)
                {
                    if (i == 0)
                    {
                        films += '«' + film.Name + '»';
                }
                    else
                    {
                        films += ", «" + film.Name + '»';
                    }
                }

                if (films == "")
                {
                    films = "Немає інформації";
            }

                dgv.Rows.Add(actor.Id, actor.Name, actor.Birthdate.ToString("dd.MM.yyyy"), actor.Country, actor.Description, films);
            }
        }

        private void textBox_Search_TextChanged(object sender, EventArgs e)
        {
            SearchBy(dataGridView1);
        }

        

        private void SearchBy(DataGridView dgv)
        {

            dgv.Rows.Clear();

            using (HomeVideoLibraryContext context = new HomeVideoLibraryContext())
            {
                UnitOfWork uow = new UnitOfWork(context);
                ActorService actorService = new ActorService(uow);
                List<ActorDTO> actors = actorService.Find(a => a.Name.Contains(textBox_Search.Text) || a.Id.ToString().Contains(textBox_Search.Text) || a.Description.Contains(textBox_Search.Text) || a.Country.Contains(textBox_Search.Text) || a.Birthdate.ToString("dd.MM.yyyy").Contains(textBox_Search.Text));

                FillRows(dgv, actors);

                foreach (ActorDTO actor in actors)
                {
                    dgv.Rows.Add(actor.Id, actor.Name, actor.Birthdate, actor.Country, actor.Description);
                }

            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            selectedRow= e.RowIndex;

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
    }
}
