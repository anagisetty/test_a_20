using System;
using System.Linq;
using System.Collections.Generic;

namespace test_a_20
{
    public class RenewalDataRepository 
    {
        private List<RenewalData> _renewalData;

        public RenewalDataRepository()
        {
            _renewalData = new List<RenewalData>();
        }

        // CRUD Operations

        // Create
        public void CreateRenewalData(RenewalData renewalData)
        {
            if (renewalData.ReceiveRenewalDate < new DateTime(2020, 1, 1))
            {
                _renewalData.Add(renewalData);
            }
            else
            {
                throw new Exception("Renewal Data must be received before 1st Jan 2020 to ensure timely completion of the renewal process");
            }
        }

        // Read
        public List<RenewalData> GetRenewalData()
        {
            return _renewalData;
        }

        // Update
        public void UpdateRenewalData(RenewalData renewalData)
        {
            var index = _renewalData.FindIndex(x => x.ReceiveRenewalDate == renewalData.ReceiveRenewalDate);

            if (index >= 0)
            {
                _renewalData[index] = renewalData;
            }
            else
            {
                throw new Exception("Renewal Data not found");
            }
        }

        // Delete
        public void DeleteRenewalData(RenewalData renewalData)
        {
            var index = _renewalData.FindIndex(x => x.ReceiveRenewalDate == renewalData.ReceiveRenewalDate);

            if (index >= 0)
            {
                _renewalData.RemoveAt(index);
            }
            else
            {
                throw new Exception("Renewal Data not found");
            }
        }
    }
}