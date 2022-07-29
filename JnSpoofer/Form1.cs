﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using JnSpoofer.Properties;
using KeyAuth;
using Loader;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace JnSpoofer
{
	// Token: 0x02000013 RID: 19
	public partial class Form1 : Form
	{
		// Token: 0x060000A3 RID: 163
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		// Token: 0x060000A4 RID: 164
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060000A5 RID: 165
		[DllImport("Gdi32.dll")]
		private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

		// Token: 0x060000A6 RID: 166 RVA: 0x00007D54 File Offset: 0x00005F54
		public Form1()
		{
			this.InitializeComponent();
			base.FormBorderStyle = FormBorderStyle.None;
			base.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, base.Width, base.Height, 20, 20));
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x00002425 File Offset: 0x00000625
		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Spoofing...");
			MessageBox.Show("Spoofed!");
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x00002085 File Offset: 0x00000285
		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("You don't have a subscription to use executor");
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000243E File Offset: 0x0000063E
		private void pictureBox6_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/BjmkTFSKgY");
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000206A File Offset: 0x0000026A
		private void pictureBox3_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000206A File Offset: 0x0000026A
		private void pictureBox4_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000023CF File Offset: 0x000005CF
		private void pictureBox5_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000206A File Offset: 0x0000026A
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000206A File Offset: 0x0000026A
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00007DB0 File Offset: 0x00005FB0
		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Form1.ReleaseCapture();
				Form1.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x00007DEC File Offset: 0x00005FEC
		private void button1_Click_1(object sender, EventArgs e)
		{
			try
			{
				this.waitForm.Show(this);
				Thread.Sleep(5000);
				FormMbox formMbox = new FormMbox();
				formMbox.Show();
				this.waitForm.Close();
			}
			catch
			{
			}
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000243E File Offset: 0x0000063E
		private void button4_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/BjmkTFSKgY");
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000243E File Offset: 0x0000063E
		private void pictureBox4_Click_1(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/BjmkTFSKgY");
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x000023CF File Offset: 0x000005CF
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x000023FF File Offset: 0x000005FF
		private void siticoneControlBox2_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x00007E44 File Offset: 0x00006044
		private void button5_Click(object sender, EventArgs e)
		{
			this.waitForm.Show(this);
			Thread.Sleep(5000);
			FormMbox2 formMbox = new FormMbox2();
			formMbox.Show();
			this.waitForm.Close();
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x00007E84 File Offset: 0x00006084
		private void expiry_Click(object sender, EventArgs e)
		{
			this.expiry.Text = "Expiry: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToString();
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x00002548 File Offset: 0x00000748
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x04000073 RID: 115
		public const int WM_NCLBUTTONDOWN = 161;

		// Token: 0x04000074 RID: 116
		public const int HT_CAPTION = 2;

		// Token: 0x04000075 RID: 117
		private WaitFormFunc waitForm = new WaitFormFunc();
	}
}
