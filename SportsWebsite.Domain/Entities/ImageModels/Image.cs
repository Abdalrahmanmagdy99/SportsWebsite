using SprotsWebsite.Domain.Interfaces;

namespace SprotsWebsite.Domain.Entities
{
    public class Image : ISoftDelete
    {
        public Image()
        {
        }

        public Image(string photoName)
        {
            PhotoName = photoName;
        }

        public int Id { get; set; }
        public string PhotoName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
