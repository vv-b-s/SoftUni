using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Currency_Converter
{
    public partial class FormConverter : Form
    {
        public FormConverter()
        {
            InitializeComponent();
        }

        private void FormConverter_Load(object sender, EventArgs e)
        {
            label1.Text = "BGN \x2192";
            comboBoxCurrency.SelectedItem = "EUR";
            ConvertCurrency();
        }

        private void moneyBox_ValueChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void comboBoxCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            decimal originalValue = 0;
            switch(comboBoxCurrency.SelectedItem.ToString())
            {
                case "EUR":
                    originalValue = moneyBox.Value;
                    lResult.Text = moneyBox.Value.ToString()+"лв. = "+(Math.Round(originalValue / 1.95583m,2)).ToString()+$" {comboBoxCurrency.SelectedItem}";
                    break;
                case "USD":
                    originalValue = moneyBox.Value;
                    lResult.Text = moneyBox.Value.ToString() + "лв. = " + (Math.Round(originalValue / 1.80810m, 2)).ToString() + $" {comboBoxCurrency.SelectedItem}";
                    break;
                case "GBP":
                    originalValue = moneyBox.Value;
                    lResult.Text = moneyBox.Value.ToString() + "лв. = " + (Math.Round(originalValue / 2.54990m, 2)).ToString() + $" {comboBoxCurrency.SelectedItem}";
                    break;
            }
        }
    }
}
