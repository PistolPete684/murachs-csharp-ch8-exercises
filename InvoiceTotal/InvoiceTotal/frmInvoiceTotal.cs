namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // TODO: declare class variables for array and list here
        decimal[] arrInvoiceTotal = new decimal[5];
        int currentIndex = 0;
        //List<decimal> totals = new List<decimal>();

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSubtotal.Text == "")
                {
                    MessageBox.Show(
                        "Subtotal is a required field.", "Entry Error");
                }
                else
                {
                    decimal subtotal = Decimal.Parse(txtSubtotal.Text);
                    if (subtotal > 0 && subtotal < 10000)
                    {
                        decimal discountPct = .25m;
                        decimal discountAmt = Math.Round(subtotal * discountPct, 2);
                        decimal invoiceTotal = Math.Round(subtotal - discountAmt, 2);

                        txtDiscountPct.Text = discountPct.ToString("p1");
                        txtDiscountAmt.Text = discountAmt.ToString("c");
                        txtTotal.Text = invoiceTotal.ToString("c");

                        arrInvoiceTotal[currentIndex] = subtotal;

                        currentIndex++;
                    }
                    else
                    {
                        MessageBox.Show(
                            "Subtotal must be greater than 0 and less than 10,000.",
                            "Entry Error"
                            );
                    }
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(
                    ex.Message + " Limit of 5 subtotals per array",
                     ex.GetType() + " Exception"
                    );
            }
            catch
            {
                MessageBox.Show(
                    "Please enter a valid number for the Subtotal field.",
                    "Entry Error"
                    );
            }
            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //Code that sorts the array
            Array.Sort(arrInvoiceTotal);

            // TODO: add code that displays dialog boxes here
            string strSubtotals = "";
            foreach (decimal subtotal in arrInvoiceTotal)
            {
                if (subtotal != 0)
                {
                    strSubtotals += subtotal + "\n"; 
                }

            }



            MessageBox.Show("The subtotals are:\n"
                + strSubtotals + "\n",
                "Subtotal List"
            );

            this.Close();
        }
    }
}