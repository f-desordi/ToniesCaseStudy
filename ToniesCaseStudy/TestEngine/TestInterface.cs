using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Text;

namespace TestEngine
{
    public class TestInterface
    {
        private IPEndPoint EndPoint;
        
        public TestInterface(string hostname = "localhost", int port= 65432)
        {
            if (hostname == "localhost")
            {
                EndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            }
            else
            {
                var vHost = Dns.GetHostEntry(hostname);
                EndPoint = new IPEndPoint(vHost.AddressList.First(), port);
            }
        }

        public TestInterface(IPEndPoint endPoint)
        {
            EndPoint = endPoint;
        }

        private string QueryGeneric(string command)
        {
            string vResult = string.Empty;
            using (var vClient = new TcpClient() { ReceiveTimeout = 2000 })
            {
                vClient.Connect(EndPoint);
                using (var vStream = vClient.GetStream())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(command);

                    vStream.Write(buffer);

                    buffer = new byte[512];

                    var vTimeout = DateTime.Now + TimeSpan.FromSeconds(3);
                    while(!vStream.DataAvailable && DateTime.Now <= vTimeout )
                    {
                        Thread.Sleep(10);
                    }

                    if (!vStream.DataAvailable)
                    {
                        throw new TimeoutException($"Waiting for reply on command \"{command}\" timed out after 3s.");
                    }

                    int vBytesRead = vStream.Read(buffer, 0, buffer.Length);

                    vResult = Encoding.UTF8.GetString(buffer, 0, vBytesRead);
                }
                vClient.Close();
            }
            return vResult;
        }

        public bool Write(char c, out string response)
        {
            response = this.QueryGeneric($"write {c}");
            return response == "Writing successful";
        }

        public bool Write(string entry, out string response)
        {
            response = string.Empty;
            IEnumerable<char> buffer = entry.ToCharArray();

            while(buffer.Any() && this.Write(buffer.First(), out string vResponse))
            {
                response += ";" + vResponse;
                buffer = buffer.Skip(1);
            }

            return !buffer.Any();
        }

        public bool Read(out string LabelText, out string EntryText, out string response)
        {
            response = QueryGeneric("read");
            var vMatch = Regex.Match(response, @"Label text:\s*(.*)\nEntry text:\s*(.*)");
            if (vMatch.Success)
            {
                LabelText = vMatch.Groups[1].Value.Trim();
                EntryText = vMatch.Groups[2].Value.Trim();
                return true;
            }
            else
            {
                LabelText = string.Empty;
                EntryText = string.Empty;
                return false;
            }
        }

        public bool Delete(out string response)
        {
            response = this.QueryGeneric("delete");
            return response == "Deleting successful";
        }

        public bool ClearEntry(out string response)
        {
            response = this.QueryGeneric("clear");
            return response == "Clearing successful";
        }

        public bool SendConfirm(out string response)
        {
            response = this.QueryGeneric("confirm");
            return response == "Confirmation successful";
        }

    }
}
