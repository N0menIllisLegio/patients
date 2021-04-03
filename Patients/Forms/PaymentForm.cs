using System;
using System.Windows.Forms;

namespace Patients.Forms
{
  public partial class PaymentForm: Form
  {
    public PaymentForm()
    {
      InitializeComponent();
    }

    public PaymentForm(DateTime date, decimal amount, string diagnosis)
      : this()
    {
      paymentDatePicker.Value = date;
      paymentAmountNumeric.Value = amount;
      diagnosisRichTextBox.Text = diagnosis;
    }

    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public string Diagnosis { get; private set; }

    private void AddPaymentButton_Click(object sender, EventArgs e)
    {
      Date = paymentDatePicker.Value;
      Amount = paymentAmountNumeric.Value;
      Diagnosis = diagnosisRichTextBox.Text;
    }
  }
}
