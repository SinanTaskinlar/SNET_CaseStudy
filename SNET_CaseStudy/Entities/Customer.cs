namespace SNET_CaseStudy.Entities
{
    public class Customer
    {
        public long TCKN { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}