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
    public partial class AdminForm : Form
    {

        GymCompetitionService service = new GymCompetitionService();
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            teamBindingSource.DataSource = service.QueryAllTeams();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AlterTable();
            teamBindingSource.DataSource = service.QueryAllTeams();
            if(textBox1.Text!=null && textBox2.Text != null && textBox3.Text!=null && textBox4.Text != null)
            {
                GymCompetitionService.MaxAthletesPerGroup = Convert.ToInt16(textBox1.Text);
                GymCompetitionService.MaxAthletesPerGame = Convert.ToInt16(textBox2.Text);
                GymCompetitionService.GroupGradeCount = Convert.ToInt16(textBox3.Text);
                GymCompetitionService.HostTeamAccount = textBox4.Text;
            }
            
        }

        private void AlterTable()    
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value == null)
                    break;

                Team team = new Team();
                team.Account = row.Cells[0].Value.ToString();
                team.Password = row.Cells[1].Value.ToString();
                team.Name = row.Cells[2].Value.ToString();

                int count = service.SearchTeamByAccount(team.Account).Count();
                if (count == 0)
                {
                    service.AddTeam(team);
                }
                else
                {
                    service.UpdateTeam(team);
                }
            }
        } 

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
