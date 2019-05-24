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
    public partial class InitForm : Form
    {
        GymCompetitionService service = new GymCompetitionService();

        public InitForm()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            service.ArrangeNumber(GymCompetitionService.HostTeamAccount);
            service.AlterAthnumInGameInfo(); 
            service.ArrangeGroups();

            SetRefereesForm setRefereesForm = new SetRefereesForm();
            setRefereesForm.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GameStateForm gameStateForm = new GameStateForm();
            gameStateForm.Show();
        }
    }
}
