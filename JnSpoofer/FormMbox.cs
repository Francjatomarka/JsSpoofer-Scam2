﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace JnSpoofer
{
	// Token: 0x02000014 RID: 20
	public partial class FormMbox : Form
	{
		// Token: 0x060000BA RID: 186
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060000BB RID: 187
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060000BC RID: 188
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000BD RID: 189 RVA: 0x0000244C File Offset: 0x0000064C
		public FormMbox()
		{
			this.InitializeComponent();
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000206A File Offset: 0x0000026A
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000BF RID: 191 RVA: 0x00008BC8 File Offset: 0x00006DC8
		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				FormMbox.ReleaseCapture();
				FormMbox.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00002464 File Offset: 0x00000664
		private void button1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x04000085 RID: 133
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000086 RID: 134
		public const int HT_CAPTION = 2;
	}
}
