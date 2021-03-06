using Center.Server.Statics;
using Game.Base.Packets;
using log4net;
using SqlDataProvider.Data;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace Center.Server
{
    public class CenterService : ICenterService
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static ServiceHost host;

        static CenterService()
        {
        }

        public List<ServerData> GetServerList()
        {
            ServerInfo[] servers = ServerMgr.Servers;
            List<ServerData> list = new List<ServerData>();
            foreach (ServerInfo serverInfo in servers)
                list.Add(new ServerData()
                {
                    Id = serverInfo.ID,
                    Name = serverInfo.Name,
                    Ip = serverInfo.IP,
                    Port = serverInfo.Port,
                    State = serverInfo.State,
                    MustLevel = serverInfo.MustLevel,
                    LowestLevel = serverInfo.LowestLevel,
                    Online = serverInfo.Online
                });
            return list;
        }

        public bool ChargeMoney(int userID, string chargeID)
        {
            ServerClient serverClient = LoginMgr.GetServerClient(userID);
            if (serverClient == null)
                return false;
            serverClient.SendChargeMoney(userID, chargeID);
            return true;
        }

        public bool SystemNotice(string msg)
        {
            bool flag;
            try
            {
                CenterServer.Instance.SendSystemNotice(msg);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool KitoffUser(int playerID, string msg)
        {
            try
            {
                ServerClient serverClient = LoginMgr.GetServerClient(playerID);
                if (serverClient != null)
                {
                    msg = string.IsNullOrEmpty(msg) ? "You are kicking out by GM!" : msg;
                    serverClient.SendKitoffUser(playerID, msg);
                    LoginMgr.RemovePlayer(playerID);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public bool ReLoadServerList()
        {
            return ServerMgr.ReLoadServerList();
        }

        public bool MailNotice(int playerID)
        {
            try
            {
                ServerClient serverClient = LoginMgr.GetServerClient(playerID);
                if (serverClient != null)
                {
                    GSPacketIn pkg = new GSPacketIn((short)117);
                    pkg.WriteInt(playerID);
                    pkg.WriteInt(1);
                    serverClient.SendTCP(pkg);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public bool AASUpdateState(bool state)
        {
            try
            {
                return CenterServer.Instance.SendAAS(state);
            }
            catch
            {
            }
            return false;
        }

        public int AASGetState()
        {
            try
            {
                return CenterServer.Instance.ASSState ? 1 : 0;
            }
            catch
            {
            }
            return 2;
        }

        public int ExperienceRateUpdate(int serverId)
        {
            try
            {
                return CenterServer.Instance.RateUpdate(serverId);
            }
            catch
            {
            }
            return 2;
        }

        public int NoticeServerUpdate(int serverId, int type)
        {
            try
            {
                return CenterServer.Instance.NoticeServerUpdate(serverId, type);
            }
            catch
            {
            }
            return 2;
        }

        public bool UpdateConfigState(int type, bool state)
        {
            try
            {
                return CenterServer.Instance.SendConfigState(type, state);
            }
            catch
            {
            }
            return false;
        }

        public int GetConfigState(int type)
        {
            try
            {
                switch (type)
                {
                    case 1:
                        return CenterServer.Instance.ASSState ? 1 : 0;
                    case 2:
                        return CenterServer.Instance.DailyAwardState ? 1 : 0;
                }
            }
            catch
            {
            }
            return 2;
        }

        public bool Reload(string type)
        {
            try
            {
                return CenterServer.Instance.SendReload(type);
            }
            catch
            {
            }
            return false;
        }

        public bool ActivePlayer(bool isActive)
        {
            try
            {
                if (isActive)
                {
                    LogMgr.AddRegCount();
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public bool CreatePlayer(int id, string name, string password, bool isFirst)
        {
            try
            {
                LoginMgr.CreatePlayer(new Player()
                {
                    Id = id,
                    Name = name,
                    Password = password,
                    IsFirst = isFirst
                });
                return true;
            }
            catch
            {
            }
            return false;
        }

        public bool ValidateLoginAndGetID(string name, string password, ref int userID, ref bool isFirst)
        {
            try
            {
                Player[] allPlayer = LoginMgr.GetAllPlayer();
                if (allPlayer != null)
                {
                    foreach (Player player in allPlayer)
                    {
                        if (player.Name == name && player.Password == password)
                        {
                            userID = player.Id;
                            isFirst = player.IsFirst;
                            return true;
                        }
                    }
                }
            }
            catch
            {
            }
            return false;
        }

        public static bool Start()
        {
            bool flag;
            try
            {
                CenterService.host = new ServiceHost(typeof(CenterService), new Uri[0]);
                CenterService.host.Open();
                CenterService.log.Info((object)"Center Service started!");
                flag = true;
            }
            catch (Exception ex)
            {
                CenterService.log.ErrorFormat("Start center server failed:{0}", (object)ex);
                flag = false;
            }
            return flag;
        }

        public static void Stop()
        {
            try
            {
                if (CenterService.host == null)
                    return;
                CenterService.host.Close();
                CenterService.host = (ServiceHost)null;
            }
            catch
            {
            }
        }
    }
}
