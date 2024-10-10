using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Services
{
	public class ChatService
	{
		// Key, value eg: {"abc", "abc@123"}, {"fff", "fafafa212"}
		private static readonly Dictionary<string, string> Users = new Dictionary<string, string>();

		public bool AddUserToList (string userToAdd)
		{
			lock(Users)
			{
				foreach(var users in Users)
				{
					if(users.Key.ToLower() == userToAdd.ToLower())
					{
						return false;
					}
				}

				Users.Add(userToAdd, null);
				return true;
			}
		}

		public void AddUserConnectinId(string user, string connectionId)
		{
			lock(Users)
			{
				if(Users.ContainsKey(user))
				{
					Users[user] = connectionId;
				}
			}
		}

		public string GetUserByConnectionId(string connectionId)
		{
			lock(Users)
			{
				return Users.Where(x => x.Value == connectionId).Select(x => x.Key).FirstOrDefault();
			}
		}

        public string GetConnectionIdByUser(string user)
        {
            lock (Users)
            {
                return Users.Where(x => x.Key == user).Select(x => x.Value).FirstOrDefault();
            }
        }

		public void RemoveUserFromList(string user)
		{
			lock(Users)
			{
				if (Users.ContainsKey(user))
				{
					Users.Remove(user);
				}
			}
		}

		public string[] GetOnlineUsers()
		{
			lock(Users)
			{
				return Users.OrderBy(x => x.Key).Select(x => x.Key).ToArray();
			}
		}
    }
	
}

