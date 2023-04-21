using System;
using System.Linq;

namespace Test_A_20
{
    public class RenewalDataRepository
    {
        private readonly List<RenewalData> _renewalData;

        public RenewalDataRepository()
        {
            _renewalData = new List<RenewalData>();
        }

        public RenewalData GetById(int id)
        {
            return _renewalData.FirstOrDefault(x => x.Id == id);
        }

        public void Create(RenewalData renewalData)
        {
            if(renewalData.Deadline > DateTime.Now)
            {
                _renewalData.Add(renewalData);
            }
        }

        public void Update(RenewalData renewalData)
        {
            var existingRenewalData = _renewalData.FirstOrDefault(x => x.Id == renewalData.Id);
            if (existingRenewalData != null)
            {
                existingRenewalData.RenewalDate = renewalData.RenewalDate;
                existingRenewalData.Deadline = renewalData.Deadline;
                existingRenewalData.IsRenewed = renewalData.IsRenewed;
            }
        }

        public void Delete(int id)
        {
            var existingRenewalData = _renewalData.FirstOrDefault(x => x.Id == id);
            if (existingRenewalData != null)
            {
                _renewalData.Remove(existingRenewalData);
            }
        }

        public List<RenewalData> GetAll()
        {
            return _renewalData;
        }
    }
}