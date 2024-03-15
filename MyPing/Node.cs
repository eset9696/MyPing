using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPing
{
    internal class Node
    {
        public string IpAddress { get; set; }
        public uint Sent { get; set; }
        public uint Received { get; set; }
        public uint Lost { get; set; }
        public Node(string ipAddress) 
        { 
            IpAddress = ipAddress; 
            Sent = 0;
            Received = 0;
            Lost = 0;
        }
    }
}
