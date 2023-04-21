using System;
using System.Linq;

namespace Test_A_20
{
    public class RenewalDataService
    {
        private RenewalDataRepository _renewalDataRepository;

        public RenewalDataService(RenewalDataRepository renewalDataRepository)
        {
            _renewalDataRepository = renewalDataRepository;
        }

        public RenewalData GetRenewalDataById(int id)
        {
            return _renewalDataRepository.GetById(id);
        }

        public void CreateRenewalData(RenewalData renewalData)
        {
            if (renewalData.Deadline > DateTime.Now.AddDays(-1))
            {
                _renewalDataRepository.Create(renewalData);
            }
        }

        public void UpdateRenewalData(RenewalData renewalData)
        {
            if (renewalData.Deadline > DateTime.Now.AddDays(-1))
            {
                _renewalDataRepository.Update(renewalData);
            }
        }

        public void DeleteRenewalData(int id)
        {
            _renewalDataRepository.Delete(id);
        }

        public List<RenewalData> GetAllRenewalData()
        {
            return _renewalDataRepository.GetAll().Where(x => x.Deadline > DateTime.Now.AddDays(-1)).ToList();
        }
    }
}