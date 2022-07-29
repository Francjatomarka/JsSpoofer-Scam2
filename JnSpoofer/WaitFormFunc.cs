using System;
using System.Threading;
using System.Windows.Forms;

namespace JnSpoofer
{
	// Token: 0x02000017 RID: 23
	public class WaitFormFunc
	{
		// Token: 0x060000D1 RID: 209 RVA: 0x000024A6 File Offset: 0x000006A6
		public void Show()
		{
			this.loadthread = new Thread(new ThreadStart(this.LoadingProcess));
			this.loadthread.Start();
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000024CC File Offset: 0x000006CC
		public void Show(Form parent)
		{
			this.loadthread = new Thread(new ParameterizedThreadStart(this.LoadingProcess));
			this.loadthread.Start(parent);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000099D8 File Offset: 0x00007BD8
		public void Close()
		{
			bool flag = this.wait != null;
			if (flag)
			{
				this.wait.BeginInvoke(new ThreadStart(this.wait.CloseWaitForm));
				this.wait = null;
				this.loadthread = null;
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000024F3 File Offset: 0x000006F3
		private void LoadingProcess()
		{
			this.wait = new WaitForm();
			this.wait.ShowDialog();
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00009A20 File Offset: 0x00007C20
		private void LoadingProcess(object parent)
		{
			Form parent2 = parent as Form;
			this.wait = new WaitForm(parent2);
			this.wait.ShowDialog();
		}

		// Token: 0x04000098 RID: 152
		private WaitForm wait;

		// Token: 0x04000099 RID: 153
		private Thread loadthread;
	}
}
