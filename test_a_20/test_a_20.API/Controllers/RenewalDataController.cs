using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http;

namespace test_a_20
{
    public class RenewalDataController : ApiController
    {
        private RenewalDataRepository _renewalDataRepository;

        public RenewalDataController()
        {
            _renewalDataRepository = new RenewalDataRepository();
        }

        [HttpPost]
        public void CreateRenewalData(RenewalData renewalData)
        {
            if (renewalData.ReceiveRenewalDate < new DateTime(2020, 1, 1))
            {
                _renewalDataRepository.CreateRenewalData(renewalData);
            }
            else
            {
                throw new Exception("Renewal Data must be received before 1st Jan 2020 to ensure timely completion of the renewal process");
            }
        }

        [HttpGet]
        public List<RenewalData> GetRenewalData()
        {
            return _renewalDataRepository.GetRenewalData();
        }

        [HttpPut]
        public void UpdateRenewalData(RenewalData renewalData)
        {
            _renewalDataRepository.UpdateRenewalData(renewalData);
        }

        [HttpDelete]
        public void DeleteRenewalData(RenewalData renewalData)
        {
            _renewalDataRepository.DeleteRenewalData(renewalData);
        }
    }
}