using SQLite;

namespace DesktopContactsApp.Classes
{
    [Table("Contacts")]
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [Unique]
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Email} - {PhoneNumber}";
        }
    }
}