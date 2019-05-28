using PoliticsAndWarAPIAccess.API.Interfaces;

namespace PoliticsAndWarAPIAccess.API.Implementation
{
    public abstract class ApiBase
    {
        protected IRestService service;
        public ApiBase(Environment env = Environment.Main)
        {
            this.service = new RestService(Server.GetBaseUrl(env));
        }
        public ApiBase(IRestService _service)
        {
            this.service = _service;
        }
        public ApiBase SetServer(string baseUrl)
        {
            this.service = new RestService(baseUrl);
            return this;
        }
        public ApiBase SetServer(Environment env)
        {
            this.service = new RestService(Server.GetBaseUrl(env));
            return this;
        }
    }
}