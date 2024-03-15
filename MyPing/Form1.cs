using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPing
{
	public partial class Form1 : Form
	{
		Thread updateThread;
		Ping pingSender = new Ping();
		PingOptions options = new PingOptions();
		int timeout = 120;

		byte[] data = new byte[32];
		List<string> ipAddresses = new List<string>();
		public Form1()
		{
			InitializeComponent();
			InitListView();
		}

		void InitListView()
		{
			lvIpAddresses.Columns.Add("Ip address");
			lvIpAddresses.Columns.Add("Bytes");
			lvIpAddresses.Columns.Add("Time");
			lvIpAddresses.Columns.Add("TTL");
		}

		void StartSend()
		{
			while (lvIpAddresses.Items.Count > 0)
			{
				for (int i = 0; i < ipAddresses.Count; i++)
				{
					PingReply reply = pingSender.Send(ipAddresses[i], timeout, data, options);
					if (reply.Status == IPStatus.Success)
					{
						lvIpAddresses.Items[i].SubItems.Add(reply.Buffer.Length.ToString());
						lvIpAddresses.Items[i].SubItems.Add(reply.RoundtripTime.ToString());
						lvIpAddresses.Items[i].SubItems.Add(reply.Options.Ttl.ToString());
					}
				} 
			}
		}

		void Update()
		{
			updateThread = new Thread(StartSend);
			updateThread.Start();
		}

		private void btnAddIp_Click(object sender, EventArgs e)
		{
			ipAddresses.Add(rtbIpAddress.Text);
			lvIpAddresses.Items.Add(rtbIpAddress.Text);
			Update();
		}

		private void btnDeleteIp_Click(object sender, EventArgs e)
		{
			//dgvIpAddresses.Rows.Remove(dgvIpAddresses.SelectedRows[0]);
		}
	}
}
