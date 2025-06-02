namespace Entities.Models
{
    public class TenderCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Tender> Tenders { get; set; }
    }
}
