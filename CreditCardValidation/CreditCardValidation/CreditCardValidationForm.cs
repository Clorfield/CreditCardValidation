﻿using System;
using System.Linq;
using System.Windows.Forms;

namespace CreditCardValidation
{
    public partial class CreditCardValidationForm : Form
    {
        public CreditCardValidationForm()
        {
            InitializeComponent();
        }

        private void numberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public string GenerateNextCreditCardNumber(string cardNumber, string cardVendor)
        {
            ulong integerСardnumber = Convert.ToUInt64(cardNumber);
            int cardNumberLength = cardNumber.Length;
                while (true)
                {
                    integerСardnumber++;
                    cardNumber = integerСardnumber.ToString();

                    if (IsCreditCardNumberValid(cardNumber) && GetCreditCardVendor(cardNumber) == cardVendor)
                    {
                        return cardNumber;
                    }
                    if (cardNumber.Length > cardNumberLength)
                        break;
                }
            return "There is no more card numbers availaible!";
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            string cardNumber = GetCreditCardNumberWithoutSpace(numberInput.Text);
            if (IsCreditCardNumberValid(cardNumber))
            {
                string vendor = GetCreditCardVendor(cardNumber);

                if (vendor != "unknown")
                {
                    string nextCard = GenerateNextCreditCardNumber(cardNumber, vendor);
                    MessageBox.Show("Credit card vendor is: " + vendor + "\nNext card number is: " + nextCard);
                }
                else
                    MessageBox.Show("Credit card vendor is: " + vendor);
            }
            else
                MessageBox.Show("Incorrect card number!");
        }

        private string GetCreditCardNumberWithoutSpace(string creditCardNumber)
        {
            return creditCardNumber.Replace(" ", "");
        }

        public static bool IsCreditCardNumberValid(string creditCardNumber)
        {
            bool hasOnlyNumbers = creditCardNumber.All(Char.IsDigit);
            if (!hasOnlyNumbers)
                return false;

            int sum = 0;
            int n;
            bool alternate = false;
            char[] nx = creditCardNumber.ToArray();
            for (int i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                n = int.Parse(nx[i].ToString());
                if (alternate)
                {
                    n *= 2;
                    if (n > 9)
                    {
                        n = (n % 10) + 1;
                    }
                }
                sum += n;
                alternate = !alternate;
            }
            return (sum % 10 == 0) && creditCardNumber.Length > 0 && creditCardNumber.Length <= 19;
        }
        //IIN - issuer identification number
        public string GetCreditCardVendor(string cardNumber)
        {
            string IIN1 = cardNumber.Substring(0, 1);
            string IIN2 = cardNumber.Substring(0, 2);
            string IIN4 = cardNumber.Substring(0, 4);

            int convIIN1 = Convert.ToInt32(IIN1);
            int convIIN2 = Convert.ToInt32(IIN2);
            int convIIN4 = Convert.ToInt32(IIN4);

            string vendor = "";

            if (convIIN1 == 4 && cardNumber.Length == 16)
            {
                vendor = "Visa";
            }
            else if ((convIIN2 == 34 || convIIN2 == 37) && cardNumber.Length == 15)
            {
                vendor = "American Express";
            }
            else if ((convIIN2 == 50 || (convIIN2 >= 56 && convIIN2 <= 69)) && cardNumber.Length <= 19 && cardNumber.Length >= 12)
            {
                vendor = "Maestro";
            }
            else if (((convIIN2 >= 51 && convIIN2 <= 55) || (convIIN4 >= 2221 && convIIN4 <= 2720)) && cardNumber.Length == 16)
            {
                vendor = "Mastercard";
            }
            else if (convIIN4 >= 3528 && convIIN4 <= 3589 && cardNumber.Length >= 16 && cardNumber.Length <= 19)
            {
                vendor = "JCB";
            }
            else
                vendor = "unknown";

            return vendor;
        }

        private void CreditCardValidationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
