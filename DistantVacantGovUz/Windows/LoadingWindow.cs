using System.Windows.Forms;

namespace DistantVacantGovUz.Windows
{
    public partial class LoadingWindow : Form
    {

        public LoadingWindow()
        {
            InitializeComponent();
        }

        public void SetOperationName(string name)
        {
            if (name != "")
                Text = string.Format("{0} [{1}] ...", language.strings.frmLoadingCaption, name);
        }

        public void SetStatus(string statusMessage)
        {
            lblStatus.Text = statusMessage;
        }
    }
}
