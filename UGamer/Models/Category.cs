namespace UGamer.Models
{
    public class Category: BaseEntity
    {
        //according to MS Documentation for one to many relation
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
