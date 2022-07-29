using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using JnSpoofer.Properties;

namespace JnSpoofer
{
	// Token: 0x02000016 RID: 22
	public partial class WaitForm : Form
	{
		// Token: 0x060000CC RID: 204 RVA: 0x00002486 File Offset: 0x00000686
		public WaitForm()
		{
			this.InitializeComponent();
			base.StartPosition = FormStartPosition.CenterParent;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00009764 File Offset: 0x00007964
		public WaitForm(Form parent)
		{
			this.InitializeComponent();
			bool flag = parent != null;
			if (flag)
			{
				base.StartPosition = FormStartPosition.Manual;
				base.Location = new Point(parent.Location.X + parent.Width / 2 - base.Width / 2, parent.Location.Y + parent.Height / 2 - base.Height / 2);
			}
			else
			{
				base.StartPosition = FormStartPosition.CenterParent;
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x000097F0 File Offset: 0x000079F0
		public void CloseWaitForm()
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
			bool flag = this.label1.Image != null;
			if (flag)
			{
				this.label1.Image.Dispose();
			}
		}
	}
}
