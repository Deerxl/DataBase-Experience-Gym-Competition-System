using GymCompetitionTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymCompetitionForm
{
    public partial class SetRefereesForm : Form
    {
        public SetRefereesForm()
        {
            InitializeComponent();
            itemBindingSource.DataSource = service.QueryItems();
            gameInformationBindingSource.DataSource = service.QueryGameInformationById();
            refereeScoreBindingSource.DataSource = service.QueryRefereeScore();
        }
        GymCompetitionService service = new GymCompetitionService();
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                ScanRefereeScore();
                MessageBox.Show("保存成功！");
            }
            catch(Exception ex)
            {
                MessageBox.Show("error: " + ex.Message);
            }
        }

        public void ScanRefereeScore()
        {
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells[0].Value == null)
                    break;

                RefereeScore refereeScore = new RefereeScore
                {
                    Id = row.Cells[0].Value.ToString(),
                    GameInfoId = row.Cells[1].Value.ToString(),
                    RefereeId = row.Cells[2].Value.ToString(),
                    ChiefReferee = Convert.ToBoolean(row.Cells[3].Value.ToString()),
                    Score = 0,
                    P = 0,
                    D = 0
                };

                if (service.SearchRefereeScoreById(refereeScore.Id).Count == 0)
                {
                    service.AddRefereeScore(refereeScore);
                }
                else
                {
                    service.UpdateRefereeScore(refereeScore);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
