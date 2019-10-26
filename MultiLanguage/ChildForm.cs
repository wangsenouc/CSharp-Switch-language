using System.Windows.Forms;
namespace MultiLanguage
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
            ML.LoadFormLanguage(this);
        }
    }
}
