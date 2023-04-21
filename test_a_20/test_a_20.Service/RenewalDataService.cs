namespace Test_A_20
{
    public interface IRenewalDataRepository
    {
        IEnumerable<RenewalData> GetRenewalDataBefore1stJan2020();
        RenewalData GetRenewalDataById(int id);
        void InsertRenewalData(RenewalData renewalData);
        void UpdateRenewalData(RenewalData renewalData);
        void DeleteRenewalData(int id);
    }

    public class RenewalData
    {
        public DateTime RenewalDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class RenewalDataRepository : IRenewalDataRepository
    {
        private readonly Test_A_20Context _context;

        public RenewalDataRepository(Test_A_20Context context)
        {
            _context = context;
        }

        public IEnumerable<RenewalData> GetRenewalDataBefore1stJan2020()
        {
            return _context.RenewalData.Where(x => x.RenewalDate < new DateTime(2020, 01, 01)).ToList();
        }

        public RenewalData GetRenewalDataById(int id)
        {
            return _context.RenewalData.Find(id);
        }

        public void InsertRenewalData(RenewalData renewalData)
        {
            _context.RenewalData.Add(renewalData);
            _context.SaveChanges();
        }

        public void UpdateRenewalData(RenewalData renewalData)
        {
            _context.Entry(renewalData).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRenewalData(int id)
        {
            RenewalData renewalData = _context.RenewalData.Find(id);
            _context.RenewalData.Remove(renewalData);
            _context.SaveChanges();
        }
    }
}