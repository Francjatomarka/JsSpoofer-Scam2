using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Loader
{
	// Token: 0x02000003 RID: 3
	public class UserControl2 : UserControl
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000206D File Offset: 0x0000026D
		public UserControl2()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000206A File Offset: 0x0000026A
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002085 File Offset: 0x00000285
		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You don't have a subscription to use executor");
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002093 File Offset: 0x00000293
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/TNkaG9rZ3f");
		}

		// Token: 0x0600000D RID: 13 RVA: 0x0000206A File Offset: 0x0000026A
		private void timer1_Tick(object sender, EventArgs e)
		{
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000028D4 File Offset: 0x00000AD4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000290C File Offset: 0x00000B0C
		private void InitializeComponent()
		{
			this.components = new Container();
			this.timer1 = new Timer(this.components);
			base.SuspendLayout();
			this.timer1.Enabled = true;
			this.timer1.Tick += this.timer1_Tick;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.FromArgb(27, 27, 27);
			base.Name = "UserControl2";
			base.Size = new Size(504, 422);
			base.ResumeLayout(false);
		}

		// Token: 0x04000005 RID: 5
		private IContainer components = null;

		// Token: 0x04000006 RID: 6
		private Timer timer1;
	}
}
