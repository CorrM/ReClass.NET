using System.Windows.Forms;

namespace ReClassNET
{
    public class IconForm : Form
	{
		public IconForm()
		{
			Icon = Properties.Resources.ReClassNet;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // IconForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "IconForm";
            this.Load += new System.EventHandler(this.IconForm_Load);
            this.ResumeLayout(false);

        }

        private void IconForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
