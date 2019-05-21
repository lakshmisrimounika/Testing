using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalLib.Helper
{
    public class ApiCall
    {
        HttpClient httpClient = null;
        public bool GetById(string Uri,int Id)
        {
            return false;
        }
        public bool Get(string Uri)
        {

            return false;
        }
        public async Task<HttpResponseMessage> Post(string Uri,string postData)
        {
            httpClient = new HttpClient();
          

            return await httpClient.PostAsync(Uri,new StringContent(postData));
            
        }
        public bool Put(string Uri)
        {
            return false;
        }
        public bool Delete(string Uri, int Id)
        {
            return false;
        }
       
    }
}
