using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PL
{
    public class FilmCrewInfoFiller
    {
        public void Fill(DataGridView dgv, IFilmCrew[] filmCrew)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < filmCrew.Length; i++)
            {
                for (int j = 0; j < filmCrew[i].Films.Count; j++)
                {
                    string filmName = '«' + filmCrew[i].Films.ElementAt(j).Name + '»';

                    if (j == 0)
                    {
                        stringBuilder.Append(filmName);
                    }
                    else
                    {
                        stringBuilder.Append(", " + filmName);
                    }
                }

                if (stringBuilder.ToString() == "")
                {
                    stringBuilder.Append("Немає інформації");
                }

                string filmNames = stringBuilder.ToString();
                int age = (int)((DateTime.Now - filmCrew[i].Birthdate).TotalDays / 365.242199);

                dgv.Rows.Add(filmCrew[i].Id, filmCrew[i].Name, filmCrew[i].Birthdate.ToString("dd.MM.yyyy") + $" ({age} y/o)", filmCrew[i].Country, filmCrew[i].Description, filmNames);

                stringBuilder.Clear();
            }
        }
    }
}
