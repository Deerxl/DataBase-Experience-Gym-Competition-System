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
    public partial class GroupTotalScoreForm : Form
    {
        GymCompetitionService service = new GymCompetitionService();
        public RefereeScore chiefRefereeScore { get; set; }

        public GroupTotalScoreForm()
        {
            InitializeComponent();
        }

        public GroupTotalScoreForm(RefereeScore chiefRefereeScore):this()
        {
            this.chiefRefereeScore = chiefRefereeScore;
            object[][] TABLE = service.GetGroupTotalScore(chiefRefereeScore);
            
            foreach(object[] row in TABLE)
            {
                int index = this.dataGridView1.Rows.Add();
                for(int i = 0; i< 5; i++)
                {
                    this.dataGridView1.Rows[index].Cells[i].Value = row[i];
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
