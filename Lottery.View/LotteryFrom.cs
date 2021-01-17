using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lottery.Enums;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Interfaces.Views;
using Lottery.Utils;

namespace Lottery.View
{
    public partial class LotteryFrom : Form, ILotteryForm
    {
        private readonly ILotteryFormController _controller;

        public LotteryFrom(ILotteryFormController controller, IWebCralwer webCralwer)
        {
            InitializeComponent();
            _controller = controller;

            foreach (LottoType enumType in Enum.GetValues(typeof(LottoType)))
                cbxLotteryType.Items.Add(enumType);
            cbxLotteryType.SelectedIndex = 1;

            foreach (AnalyzeType analyzeType in Enum.GetValues(typeof(AnalyzeType)))
                cbxAnalyzeType.Items.Add(analyzeType);
            cbxAnalyzeType.SelectedIndex = 0;

            for (int i = 0; i < 1500; i++)
                cbxVariableOne.Items.Add(i);
            cbxVariableOne.SelectedIndex = 3;

            for (int i = 0; i < 1500; i++)
                cbxVariableTwo.Items.Add(i);
            cbxVariableTwo.SelectedIndex = 1;

            for (int i = 0; i < 1500; i++)
                cbxVariableEndValue.Items.Add(i);
            cbxVariableEndValue.SelectedIndex = 10;

            for (int i = 0; i < 100; i++)
                cbxExpectValueCount.Items.Add(i);
            cbxExpectValueCount.SelectedIndex = 10;

            for (int i = 0; i < 100; i++)
                cbxSelectCount.Items.Add(i);
            cbxSelectCount.SelectedIndex = 6;
        }

        private void btnInitialSimulate_Click(object sender, System.EventArgs e)
        {
            _controller.BtnInitialSimulate();
            MessageBox.Show("Done!");
        }

        private async void btnUpdateData_Click(object sender, System.EventArgs e)
        {
            if (!Enum.TryParse(cbxLotteryType.SelectedItem.ToString(), out LottoType type))
                MessageBox.Show("Type Error!");
            _controller.UpdateData(type, () => { MessageBox.Show("Done!"); });
        }

        private async void btnAnalyzeDat_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(cbxAnalyzeType.Text.ToString(), out AnalyzeType analyzeType))
                MessageBox.Show("Type Error!");

            if (!Enum.TryParse(cbxLotteryType.Text.ToString(), out LottoType lottoType))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableOne.Text.ToString(), out int variableOne))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableTwo.Text.ToString(), out int variableTwo))
                MessageBox.Show("Type Error!");


            tbxResult.Text = "Calculating.....";
            btnAnalyzeDat.Enabled = false;

            var result = await _controller.AnalyzeData(lottoType, analyzeType, variableOne, variableTwo);

            btnAnalyzeDat.Enabled = true;
            tbxResult.Text = result;
        }

        private async void btnCalculateExpectValue_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(cbxAnalyzeType.Text.ToString(), out AnalyzeType analyzeType))
                MessageBox.Show("Type Error!");

            if (!Enum.TryParse(cbxLotteryType.Text.ToString(), out LottoType lottoType))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableOne.Text.ToString(), out int variableOne))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableTwo.Text.ToString(), out int variableTwo))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableEndValue.Text.ToString(), out int periodEnd))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxExpectValueCount.Text.ToString(), out int expectValueCount))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxSelectCount.Text.ToString(), out int selectCount))
                MessageBox.Show("Type Error!");

            var showBingo = cbxShowBIngo.Checked;
            var progressBar = 0;

            btnCalculateExpectValue.Enabled = false;

            tbxExpectShoot.Text = "Calculating..... 0.0%";

            var totalCount = (periodEnd - variableOne) * (variableTwo == 0 ? (periodEnd - variableOne) : 1);


            var result = await Task.Run(function: async () =>
                await _controller.CalculateExpectValue(lottoType, analyzeType,
                    variableOne, expectValueCount,
                    periodEnd, variableTwo, selectCount, showBingo, () =>
                    {
                        progressBar++;
                        tbxExpectShoot.UpdateText($"Calculating..... {(double)progressBar / (double)totalCount:P}");
                    }));

            btnCalculateExpectValue.Enabled = true;

            tbxExpectShoot.Text = result;
        }

        private void btnCalculateCost_Click(object sender, EventArgs e)
        {
            string promptValue = Prompt.ShowDialog("Buy Range", "Calculate Cost");
            if (!int.TryParse(promptValue, out int buyRange))
            {
                MessageBox.Show("please input a number.");
                return;
            }

            if (!Enum.TryParse(cbxLotteryType.Text.ToString(), out LottoType lottoType))
                MessageBox.Show("Type Error!");


            int combination = Calculator.Combination(buyRange, lottoType == LottoType.PowerLottery ? 6 : 6);

            MessageBox.Show($"Cost:{combination * (lottoType == LottoType.PowerLottery ? 100 * 8 : 50):N} NT");

        }
    }
}