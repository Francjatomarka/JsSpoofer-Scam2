using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Siticone.UI.AnimatorNS;
using Siticone.UI.WinForms;
using Siticone.UI.WinForms.Enums;

namespace KeyAuth
{
	// Token: 0x02000010 RID: 16
	public partial class Main : Form
	{
		// Token: 0x0600008B RID: 139 RVA: 0x000023AC File Offset: 0x000005AC
		public Main()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000023CF File Offset: 0x000005CF
		private void siticoneControlBox1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x0600008D RID: 141 RVA: 0x000044C8 File Offset: 0x000026C8
		private void Main_Load(object sender, EventArgs e)
		{
			this.key.Text = "Username: " + Login.KeyAuthApp.user_data.username;
			this.expiry.Text = "Expiry: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.subscriptions[0].expiry)).ToString();
			this.subscription.Text = "Subscription: " + Login.KeyAuthApp.user_data.subscriptions[0].subscription;
			this.ip.Text = "IP Address: " + Login.KeyAuthApp.user_data.ip;
			this.hwid.Text = "HWID: " + Login.KeyAuthApp.user_data.hwid;
			this.createDate.Text = "Creation date: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.createdate)).ToString();
			this.lastLogin.Text = "Last login: " + this.UnixTimeToDateTime(long.Parse(Login.KeyAuthApp.user_data.lastlogin)).ToString();
			this.numUsers.Text = "Number of users: " + Login.KeyAuthApp.app_data.numUsers;
			this.numOnlineUsers.Text = "Number of online users: " + Login.KeyAuthApp.app_data.numOnlineUsers;
			this.numKeys.Text = "Number of licenses: " + Login.KeyAuthApp.app_data.numKeys;
			this.version.Text = "Current version: " + Login.KeyAuthApp.app_data.version;
			this.customerPanelLink.Text = "Customer panel: " + Login.KeyAuthApp.app_data.customerPanelLink;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00002548 File Offset: 0x00000748
		public DateTime UnixTimeToDateTime(long unixtime)
		{
			DateTime result = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			result = result.AddSeconds((double)unixtime).ToLocalTime();
			return result;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x000046E4 File Offset: 0x000028E4
		private void sendmsg_Click(object sender, EventArgs e)
		{
			bool flag = Login.KeyAuthApp.chatsend(this.chatmsg.Text, this.chatchannel);
			if (flag)
			{
				this.dataGridView1.Rows.Insert(0, new object[]
				{
					Login.KeyAuthApp.user_data.username,
					this.chatmsg.Text,
					this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
				});
			}
			else
			{
				this.chatmsg.Text = "Status: " + Login.KeyAuthApp.response.message;
			}
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00004790 File Offset: 0x00002990
		private void timer1_Tick(object sender, EventArgs e)
		{
			this.dataGridView1.Rows.Clear();
			this.timer1.Interval = 15000;
			bool flag = !string.IsNullOrEmpty(this.chatchannel);
			if (flag)
			{
				List<api.msg> list = Login.KeyAuthApp.chatget(this.chatchannel);
				bool flag2 = list == null || !list.Any<api.msg>();
				if (flag2)
				{
					this.dataGridView1.Rows.Insert(0, new object[]
					{
						"KeyAuth",
						"No Chat Messages",
						this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
					});
				}
				else
				{
					foreach (api.msg msg in list)
					{
						this.dataGridView1.Rows.Insert(0, new object[]
						{
							msg.author,
							msg.message,
							this.UnixTimeToDateTime(long.Parse(msg.timestamp))
						});
					}
				}
			}
			else
			{
				this.dataGridView1.Rows.Insert(0, new object[]
				{
					"KeyAuth",
					"No Chat Messages",
					this.UnixTimeToDateTime(DateTimeOffset.Now.ToUnixTimeSeconds())
				});
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x0000206A File Offset: 0x0000026A
		private void expiry_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000092 RID: 146 RVA: 0x0000206A File Offset: 0x0000026A
		private void subscription_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0400003C RID: 60
		private string chatchannel = "testing";
	}
}
