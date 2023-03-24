using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BankAccount
{
    public partial class Form1 : Form
    {
        private decimal balance = 0;
        private int depositCount = 0;
        private decimal depositTotal = 0;
        private int checkCount = 0;
        private decimal checkTotal = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal amount = decimal.Parse(txtAmount.Text);
                if (rd_Deposit.Checked)
                {
                    balance += amount;
                    depositCount++;
                    depositTotal += amount;
                }
                else if (rd_Check.Checked)
                {
                    if (balance >= amount)
                    {
                        balance -= amount;
                        checkCount++;
                        checkTotal += amount;
                    }
                    else
                    {
                        MessageBox.Show("Insufficient Funds");
                        balance -= 10;
                        rd_ServiceChange.Checked = true;
                        rd_ServiceChange.Enabled = false;
                    }
                }
                else if (rd_ServiceChange.Checked)
                {
                    balance -= amount;
                }
                if (balance < 0)
                {
                    MessageBox.Show("New Balance is Negative");
                }


                MessageBox.Show("Balance: ₱" + balance.ToString("#,##0.00"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            rd_Deposit.Checked = true;
            rd_ServiceChange.Enabled = true;
            txtAmount.Clear();
            txtAmount.Focus();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Summary_Click(object sender, EventArgs e)
        {
            string message =
           "Deposit Count: " + depositCount + "\n" +
           "Deposit Total: ₱" + depositTotal.ToString("#,##0.00") + "\n" +
           "Check Count: " + checkCount + "\n" +
           "Check Total: ₱" + checkTotal.ToString("#,##0.00");
            MessageBox.Show(message);
        }
    }
}
