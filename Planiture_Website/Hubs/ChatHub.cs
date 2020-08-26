using Microsoft.AspNetCore.SignalR;
using Planiture_Website.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Planiture_Website.Hubs
{
    public class ChatHub : Hub
    {
        public ApplicationDbContext _context;
        private static ConcurrentDictionary<string, Agent> _agents;
        private static ConcurrentDictionary<string, string> _chatSessions;

        public ChatHub(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public string ToHash(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";

            var provider = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
        }

        public async Task AgentConnect(string name, string pass)
        {
            var test = _context.ConfigFiles.ToList();
            string hashPass = ToHash(pass);

            if (_agents == null)
                _agents = new ConcurrentDictionary<string, Agent>();
            if (_chatSessions == null)
                _chatSessions = new ConcurrentDictionary<string, string>();

            SqlConnection con = new SqlConnection(@"Data Source=MSI;Initial Catalog=LiveChat;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select AdminPass, AgentPass from ConfigFiles", con);
            List<string> str = new List<string>();
            SqlDataReader da = cmd.ExecuteReader();
            while (da.Read())
            {
                str.Add(da.GetValue(0).ToString());
                str.Add(da.GetValue(1).ToString());
            }
            con.Close();

            if (test == null)
            {
                await Clients.All.SendAsync("LoginResult", false, "config", "");
            }
            else if(str[0] == hashPass || str[1] == hashPass)
            {
                var agent = new Agent
                {
                    Id = Context.ConnectionId,
                    Name = name,
                    IsOnline = true
                };
                if(_agents.Any(x => x.Key == name))
                {
                    agent = _agents[name];
                    await Clients.Caller.SendAsync("loginResult", true, agent.Id, agent.Name);
                    await Clients.All.SendAsync("onlineStatus", _agents.Count(x => x.Value.IsOnline) > 0);

                }
                else if (_agents.TryAdd(name, agent))
                {

                    await Clients.Caller.SendAsync("loginResult", true, agent.Id, agent.Name);

                    await Clients.All.SendAsync("onlineStatus", _agents.Count(x => x.Value.IsOnline) > 0);
                }
                else
                {
                    await Clients.Caller.SendAsync("loginResult", false, "error", "");
                }

            }
            else
                await Clients.Caller.SendAsync("loginResult", false, "pass", "");
        }


    }
}
