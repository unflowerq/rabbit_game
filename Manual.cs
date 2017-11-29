using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 소실과제마지막_2
{
    public partial class Manual : Form
    {
        public Manual()
        {
            InitializeComponent();
        }

        private void Manual_Load(object sender, EventArgs e)
        {
            textBox1.Text = "폭탄을 피하면서 열심히 과일을 먹는 게임입니다.";
            textBox1.AppendText("\r\n\r\n게임 종료 조건 : Life = 0");
            textBox1.AppendText("\r\n\r\nLife가 늘어나는 조건 : 하트를 먹을 때");
            textBox1.AppendText("\r\nLife가 1씩 줄어드는 조건 : 과일을 놓칠 때, 폭탄을 먹을 때");
            textBox1.AppendText("\r\n\r\nKey 입력 안내");
            textBox1.AppendText("\r\nNumpad4 : 왼쪽이동");
            textBox1.AppendText("\r\nNumpad6 : 오른쪽이동");
            textBox1.AppendText("\r\nQ : 토끼 속도(skip frame) 1 증가");
            textBox1.AppendText("\r\nW : 토끼 속도(skip frame) 1 감소");
            textBox1.AppendText("\r\nE : 무적 스킬");
            textBox1.AppendText("\r\n\r\n특이사항");
            textBox1.AppendText("\r\n- 점수가 올라갈수록 레벨이 높아지고 어려워집니다.");
            textBox1.AppendText("\r\n- 별을 먹을 시 Star Point가 올라갑니다.");
            textBox1.AppendText("\r\n- 무적 스킬(E)을 사용할 경우 폭탄에 3초간 면역이 됩니다.");
            textBox1.AppendText("\r\n  [놓치는 과일에 대해서는 점수 차감이 정상적으로 이루어집니다.]");
            textBox1.AppendText("\r\n- 두 키를 동시에 누를 경우 키가 무시될 수 있습니다.");
        }
    }
}
