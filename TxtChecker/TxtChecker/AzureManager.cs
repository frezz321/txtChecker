using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TxtChecker.Model;

namespace TxtChecker
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<BigThingModel> sentimentTable;

        private AzureManager()
        {
            this.client = new MobileServiceClient("http://bigthing.azurewebsites.net");
            this.sentimentTable = this.client.GetTable<BigThingModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }

        public async Task<List<BigThingModel>> GetSentimentInformation()
        {
            return await this.sentimentTable.ToListAsync();
        }
        
    }

}
