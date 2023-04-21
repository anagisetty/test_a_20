using System;
using System.Linq;
using System.Web.Http;

namespace Test_A_20
{
    public class RenewalDataController : ApiController
    {
        private RenewalDataService _renewalDataService;

        public RenewalDataController(RenewalDataService renewalDataService)
        {
            _renewalDataService = renewalDataService;
        }

        [HttpGet]
        public RenewalData GetRenewalDataById(int id)
        {
            return _renewalDataService.GetRenewalDataById(id);
        }

        [HttpPost]
        public void CreateRenewalData(RenewalData renewalData)
        {
            _renewalDataService.CreateRenewalData(renewalData);
        }

        [HttpPut]
        public void UpdateRenewalData(RenewalData renewalData)
        {
            _renewalDataService.UpdateRenewalData(renewalData);
        }

        [HttpDelete]
        public void DeleteRenewalData(int id)
        {
            _renewalDataService.DeleteRenewalData(id);
        }

        [HttpGet]
        public List<RenewalData> GetAllRenewalData()
        {
            return _renewalDataService.GetAllRenewalData();
        }
    }
}