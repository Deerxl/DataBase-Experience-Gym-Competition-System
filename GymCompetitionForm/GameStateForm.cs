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
    public partial class GameStateForm : Form
    {
        GymCompetitionService service = new GymCompetitionService();

        public static int playOrder = 0;

        public GameInformation GameInfo { get; set; }

        public GameStateForm()
        {
            InitializeComponent();
        }

        public GameStateForm(bool finalGame)
        {
            label7.Text = (finalGame == true) ? "决赛" : "初赛";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            GameInfo = service.CurrentGameInfo(++playOrder);
            if(GameInfo == null)
            {
                MessageBox.Show("比赛完毕！");
                return;
            }
            label8.Text = service.SearchItemById(GameInfo.ItemId)[0].Name;
            label9.Text = service.SearchItemById(GameInfo.ItemId)[0].AgeAndSexGroup;
            label10.Text = GameInfo.GroupNumber.ToString();
            label11.Text = GameInfo.AthleteNum;
            label12.Text = GameInfo.PlayOrder.ToString();
            
            List<RefereeScore> refereeScores =  service.SearchRefereeScoreByGameInfoId(GameInfo.Id);
            for (int j = 0; j < refereeScores.Count; j++)
            {
                if (refereeScores[j].ChiefReferee)
                {
                    label24.Text = service.SearchRefereeByIdCard(refereeScores[j].RefereeId)[0].Name;
                    refereeScores.RemoveAt(j);
                    break;
                }
            }
            
            int count = refereeScores.Count;
            int i = 0;
            while(i < 5)
            {
                switch (i)
                {
                    case 0:
                        label15.Text = (i < count) ? service.SearchRefereeByIdCard(refereeScores[0].RefereeId)[0].Name : "null";
                        i++;
                        break;
                    case 1:
                        label16.Text = (i < count) ? service.SearchRefereeByIdCard(refereeScores[1].RefereeId)[0].Name : "null";
                        i++;
                        break;
                    case 2:
                        label21.Text = (i < count) ? service.SearchRefereeByIdCard(refereeScores[2].RefereeId)[0].Name : "null";
                        i++;
                        break;
                    case 3:
                        label22.Text = (i < count) ? service.SearchRefereeByIdCard(refereeScores[3].RefereeId)[0].Name : "null";
                        i++;
                        break;
                    case 4:
                        label23.Text = (i < count) ? service.SearchRefereeByIdCard(refereeScores[4].RefereeId)[0].Name : "null";
                        i++;
                        break;
                }
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Login login = new Login(false, GameInfo);
            login.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Login login = new Login(true, GameInfo);
            login.Show();
        }
    }
}
