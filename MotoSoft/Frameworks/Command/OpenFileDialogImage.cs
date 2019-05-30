using System.Windows.Forms;

namespace MotoSoft.Frameworks.Command
{
    public class OpenFileDialogImage
    {
        public string ShowDialog()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.png)|*.png|(*.bitmap)|*.bitmap|(*.jpeg)|*.jpeg";
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return string.Empty;
            }
            return dialog.FileName;
        }
    }
}
