using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GymCompetitionTest;

namespace GymCompetitionForm
{
    public partial class Login : Form
    {
        GymCompetitionService service = new GymCompetitionService();
        public GameInformation GameInfo { get; set; }
        bool chiefReferee = false;
        public Login()
        {
            InitializeComponent();
        }

        public Login(bool chiefReferee, GameInformation gameInfo) :this()
        {
            this.chiefReferee = chiefReferee;
            this.GameInfo = gameInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text != null)
            {
                int n = service.Login(textBox1.Text, textBox2.Text);
                switch (n)
                {
                    case 1:
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                        this.Close();
                        break;
                    case 2:
                        List<Team> teams = service.SearchTeamByAccount(textBox1.Text);
                        
                        TeamForm teamForm = new TeamForm(teams[0]);
                        teamForm.Show();
                        this.Close();
                        break;
                    case 3:
                        List<RefereeScore> ts = service.SearchRefereeScoreByRefereeIdAndGameInfo(GameInfo.Id, textBox1.Text);
                        if (ts.Count > 0)
                        {
                            if (chiefReferee)
                            {
                                ChiefRefereeForm chiefRefereeForm = new ChiefRefereeForm(ts[0]);
                                chiefRefereeForm.Show();
                            }
                            else
                            {
                                OrdinaryRefereeForm refereeForm = new OrdinaryRefereeForm(ts[0]);
                                refereeForm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("您不是当前比赛项目分组的裁判！");
                        }
                        this.Close();
                        break;
                    default:
                        MessageBox.Show("账号/密码/姓名错误");
                        break;
                }
            }
            else
            {
                MessageBox.Show("不能为空！");
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("系统管理员请用账号和密码登陆；\n" +
                "代表队请用账号和初始密码登陆；\n" +
                "裁判请用身份证号和姓名登陆；");
        }
    }
}
