using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Loader
{
	// Token: 0x02000004 RID: 4
	public class UserControl3 : UserControl
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000020A1 File Offset: 0x000002A1
		public UserControl3()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000029BC File Offset: 0x00000BBC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000029F4 File Offset: 0x00000BF4
		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Name = "UserControl3";
			base.Size = new Size(516, 411);
			base.ResumeLayout(false);
		}

		// Token: 0x04000007 RID: 7
		private IContainer components = null;
	}
}
