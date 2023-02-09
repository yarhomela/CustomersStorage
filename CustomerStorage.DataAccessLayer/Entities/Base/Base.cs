
namespace CustomerStorage.DataAccessLayer.Entities.Base
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsRemoved { get; set; }

        public Base()
        {
            CreationDate = DateTime.UtcNow;
        }
    }
}
