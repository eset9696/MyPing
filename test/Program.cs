using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace test
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Ping pingSender = new Ping();
			PingOptions options = new PingOptions();

			// Use the default Ttl value which is 128,
			// but change the fragmentation behavior.
			options.DontFragment = true;
			options.Ttl = 128;
			// Create a buffer of 32 bytes of data to be transmitted.
			string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
			byte[] buffer = Encoding.ASCII.GetBytes(data);
			int timeout = 120;
			string ipAddress = "1.1.1.1";
			PingReply reply = pingSender.Send(ipAddress, timeout, buffer, options);
			if (reply.Status == IPStatus.Success)
			{
				Console.WriteLine("Address: {0}", reply.Address.ToString());
				Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
				Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
				Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
				Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
			}
		}


	}
}
