using System;
using System.Data.Entity.Core.Metadata.Edm;
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
            cbxLotteryType.SelectedIndex = 0;
        }

        private void btnInitialSimulate_Click(object sender, System.EventArgs e)
        {
            _controller.BtnInitialSimulate();
        }

        private void btnUpdateData_Click(object sender, System.EventArgs e)
        {
            if (!Enum.TryParse(cbxLotteryType.SelectedItem.ToString(), out LottoType type))
                MessageBox.Show("Type Error!");
            _controller.UpdateData(type);
        }
    }
}