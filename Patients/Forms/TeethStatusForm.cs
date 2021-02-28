using System;
using System.Windows.Forms;
using Patients.Enums;

namespace Patients
{
  public partial class TeethStatusForm: Form
  {
    public TeethStatusForm(ToothStatus toothStatus)
    {
      InitializeComponent();

      switch (toothStatus)
      {
        case ToothStatus.Healthy:
          healthyTooth.Checked = true;
          break;
        case ToothStatus.Caries:
          cariesTooth.Checked = true;
          break;
        case ToothStatus.Seal:
          sealTooth.Checked = true;
          break;
        case ToothStatus.Removed:
          removedTooth.Checked = true;
          break;
        case ToothStatus.Root:
          rootTooth.Checked = true;
          break;
        case ToothStatus.ArtificialCrown:
          artificialCrownTooth.Checked = true;
          break;
        case ToothStatus.Artificial:
          artificialTooth.Checked = true;
          break;
      }
    }

    public string Cause { get; set; }
    public ToothStatus ToothStatus
    {
      get
      {
        if (healthyTooth.Checked)
        {
          return ToothStatus.Healthy;
        }
        else if (cariesTooth.Checked)
        {
          return ToothStatus.Caries;
        }
        else if (sealTooth.Checked)
        {
          return ToothStatus.Seal;
        }
        else if (removedTooth.Checked)
        {
          return ToothStatus.Removed;
        }
        else if (rootTooth.Checked)
        {
          return ToothStatus.Root;
        }
        else if (artificialCrownTooth.Checked)
        {
          return ToothStatus.ArtificialCrown;
        }
        else if (artificialTooth.Checked)
        {
          return ToothStatus.Artificial;
        }

        return ToothStatus.Healthy;
      }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
      Cause = dataTextBox.Text;
    }
  }
}
