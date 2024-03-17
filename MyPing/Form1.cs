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
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MyPing
{
	public partial class Form1 : Form
	{
		Thread updateThread;
		
		int timeout = 120;

		byte[] data = new byte[32];
		List<Node> Nodes = new List<Node>();
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
			lvIpAddresses.Columns.Add("Sent");
			lvIpAddresses.Columns.Add("Received");
			lvIpAddresses.Columns.Add("Lost");

			
		}

		void InitItems()
		{
			for (int i = 0; i < Nodes.Count; i++)
			{
				lvIpAddresses.Items[i].SubItems.Add(data.Length.ToString());
				lvIpAddresses.Items[i].SubItems.Add("0");
				lvIpAddresses.Items[i].SubItems.Add("0");
				lvIpAddresses.Items[i].SubItems.Add("0");
				lvIpAddresses.Items[i].SubItems.Add("0");
				lvIpAddresses.Items[i].SubItems.Add("0");
			}
		}

		void SendData()
		{
			while (lvIpAddresses.Items.Count > 0)
			{
				for (int i = 0; i < lvIpAddresses.Items.Count; i++)
				{
                    Ping pingSender = new Ping();
                    PingOptions options = new PingOptions();
                    PingReply reply = pingSender.Send(Nodes[i].IpAddress.ToString(), timeout, data, options);
					if (reply.Status == IPStatus.Success)
					{
                        if (InvokeRequired)
						{
                            this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems.Add(reply.Buffer.Length.ToString())));
                            this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems[2].Text = reply.RoundtripTime.ToString()));
                            this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems[3].Text = reply.Options.Ttl.ToString()));
                            this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems[4].Text = (Convert.ToInt32(lvIpAddresses.Items[i].SubItems[4].Text) + 1).ToString()));
                            this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems[5].Text = (Convert.ToInt32(lvIpAddresses.Items[i].SubItems[5].Text) + 1).ToString()));
                            
                        }
					}
					if (reply.Status == IPStatus.TimedOut)
					{
						this.Invoke(new Action(() => lvIpAddresses.Items[i].SubItems[6].Text = (Convert.ToInt32(lvIpAddresses.Items[i].SubItems[6].Text) + 1).ToString()));
					}
				}
				Thread.Sleep(1000);
			}
		}

		void Update()
		{
			updateThread = new Thread(SendData);
			updateThread.Start();
		}

		bool ValidateIp()
		{
			if (Regex.IsMatch(rtbIpAddress.Text, @"^[\d{1, 3}]\.[\d{1, 3}]\.[\d{1, 3}]\.[\d{1, 3}]")) return true;
			return false;
		}

		private void btnAddIp_Click(object sender, EventArgs e)
		{
			if (ValidateIp())
			{
				Nodes.Add(new Node(rtbIpAddress.Text));
				lvIpAddresses.Items.Add(rtbIpAddress.Text);
				InitItems();
				if (lvIpAddresses.Items.Count == 1) Update(); 
				rtbIpAddress.Clear();
			}
		}

		private void btnDeleteIp_Click(object sender, EventArgs e)
		{
			DeleteNodeByIp(lvIpAddresses.SelectedItems[0].SubItems[0].Text);
			lvIpAddresses.SelectedItems[0].Remove();
			if (lvIpAddresses.Items.Count == 0) updateThread.Join();
		}

		void DeleteNodeByIp(string ip)
		{
			for(int i = 0; i < Nodes.Count; i++)
			{
				if (Nodes[i].IpAddress.Equals(ip))
				{
					Nodes.Remove(Nodes[i]);
					break;
				}
			}
		}
	}
}
