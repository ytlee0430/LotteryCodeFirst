using System;
using System.Data.Entity.Core.Metadata.Edm;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lottery.Enums;
using Lottery.Interfaces.Controller;
using Lottery.Interfaces.Services;
using Lottery.Interfaces.Views;

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

            for (int i = 0; i < 1000; i++)
                cbxVariableOne.Items.Add(i);
            cbxVariableOne.SelectedIndex = 3;

            for (int i = 0; i < 1000; i++)
                cbxVariableTwo.Items.Add(i);
            cbxVariableTwo.SelectedIndex = 1;

            for (int i = 0; i < 1000; i++)
                cbxVariableEndValue.Items.Add(i);
            cbxVariableEndValue.SelectedIndex = 10;

            for (int i = 0; i < 100; i++)
                cbxExpectValueCount.Items.Add(i);
            cbxExpectValueCount.SelectedIndex = 10;
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
            if (!Enum.TryParse(cbxAnalyzeType.SelectedItem.ToString(), out AnalyzeType analyzeType))
                MessageBox.Show("Type Error!");

            if (!Enum.TryParse(cbxLotteryType.SelectedItem.ToString(), out LottoType lottoType))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableOne.SelectedItem.ToString(), out int variableOne))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableTwo.SelectedItem.ToString(), out int variableTwo))
                MessageBox.Show("Type Error!");


            var result = await _controller.AnalyzeData(lottoType, analyzeType, variableOne, variableTwo);

            tbxResult.Text = result;
        }

        private async void btnCalculateExpectValue_Click(object sender, EventArgs e)
        {
            if (!Enum.TryParse(cbxAnalyzeType.SelectedItem.ToString(), out AnalyzeType analyzeType))
                MessageBox.Show("Type Error!");

            if (!Enum.TryParse(cbxLotteryType.SelectedItem.ToString(), out LottoType lottoType))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableOne.SelectedItem.ToString(), out int variableOne))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableTwo.SelectedItem.ToString(), out int variableTwo))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxVariableEndValue.SelectedItem.ToString(), out int variableEndValue))
                MessageBox.Show("Type Error!");

            if (!int.TryParse(cbxExpectValueCount.SelectedItem.ToString(), out int expectValueCount))
                MessageBox.Show("Type Error!");


            btnCalculateExpectValue.Enabled = false;

            tbxExpectShoot.Text = "Calculating.....";

            var result = await Task.Run(function: async () => await _controller.CalculateExpectValue(lottoType, analyzeType, variableOne, expectValueCount, variableEndValue, variableTwo));

            btnCalculateExpectValue.Enabled = true;

            tbxExpectShoot.Text = result;
        }
    }
}