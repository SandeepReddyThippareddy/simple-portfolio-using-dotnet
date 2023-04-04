using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SandeepThippareddy.Interfaces;
using SandeepThippareddy.Models;
using System;
using System.IO;
using System.Text;

namespace SandeepThippareddy.Services
{
    public class DownloaderService : IDownloaderService
    {


        public bool SaveDownloaderData(DownloaderModel downloaderModel)
        {
            try
            {
                if(downloaderModel == null)
                {
                    return false;
                }

                var fileToStoreDownloaderData = string.Concat(AppDomain.CurrentDomain.BaseDirectory, "\\DownloadedUsers.json");

                if (!File.Exists(fileToStoreDownloaderData))
                {

                    using (FileStream fs = File.Create(fileToStoreDownloaderData))
                    {
                        string jsonData = JsonConvert.SerializeObject(downloaderModel);

                        Byte[] ipaddress = new UTF8Encoding(true).GetBytes(jsonData);

                        fs.Write(ipaddress);
                    }

                    return true;

                }
                else
                {
                    using (FileStream fs = File.Open(fileToStoreDownloaderData, FileMode.Open))
                    {
                        string jsonData = JsonConvert.SerializeObject(downloaderModel);

                        Byte[] data = new UTF8Encoding(true).GetBytes(jsonData);

                        fs.Write(data, (int)fs.Position, data.Length);
                    }

                    return true;
                }

            }
            catch (Exception exception)
            {
                throw new InvalidOperationException(String.Format("Error in function: {0} - \n Error Message:{1} - \n Stack Trace:{2}",
                                                               System.Reflection.MethodBase.GetCurrentMethod().Name,
                                                               exception.Message, exception?.ToString()));
            }
        }
    }
}
