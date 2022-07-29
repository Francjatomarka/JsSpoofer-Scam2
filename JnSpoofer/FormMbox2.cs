using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace JnSpoofer
{
	// Token: 0x02000015 RID: 21
	public partial class FormMbox2 : Form
	{
		// Token: 0x060000C3 RID: 195
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060000C4 RID: 196
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060000C5 RID: 197
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000C6 RID: 198 RVA: 0x0000246E File Offset: 0x0000066E
		public FormMbox2()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00002464 File Offset: 0x00000664
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000206A File Offset: 0x0000026A
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00009040 File Offset: 0x00007240
		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				FormMbox2.ReleaseCapture();
				FormMbox2.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x0400008C RID: 140
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x0400008D RID: 141
		public const int HT_CAPTION = 2;
	}
}
