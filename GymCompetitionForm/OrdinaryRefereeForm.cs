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
    public partial class OrdinaryRefereeForm : Form
    {
        GymCompetitionService service = new GymCompetitionService();
        public RefereeScore refereeScore { get; set; }
        public OrdinaryRefereeForm()
        {
            InitializeComponent();
        }

        public OrdinaryRefereeForm(RefereeScore refereeScore):this()
        {
            this.refereeScore = refereeScore;
            label5.Text = service.SearchAthleteByAthleteNum(
                service.SearchGameInfoById(refereeScore.GameInfoId)[0].AthleteNum)[0].Name;
            label6.Text = service.SearchGameInfoById(refereeScore.GameInfoId)[0].AthleteNum;
            textBox1.Text = refereeScore.Score.ToString();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                double score = Convert.ToDouble(textBox1.Text.ToString());
                if (score > 0)
                {
                    refereeScore.Score = score;
                    service.UpdateRefereeScore(refereeScore);
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("分数为百分制！");
                }
            }catch(Exception ex)
            {
                MessageBox.Show("erro: " + ex.Message);
            }
        }
    }
}
