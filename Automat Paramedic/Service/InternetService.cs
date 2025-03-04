using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Automat_Paramedic.Service
{
    public static class InternetService
    {
        public static async Task<bool> CheckInternetConnectionAsync()
        {
            try
            {
                using (var ping = new Ping())
                {
                    
                        var reply = await ping.SendPingAsync("8.8.8.8", 1000);
                        return reply.Status == IPStatus.Success;
                }
                    
            }
            catch
            {
                return false;
            }
        }
    }
}
