using SQLite;

namespace ContactsSolution.Classes
{
    [Table("Contacts")]

    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = null!;

        [Unique]
        [MaxLength(100)]
        public string Email { get; set; } = null!;

        [MaxLength(20)]
        public string Phone { get; set; } = null!;

        public override string ToString()
        {
            return $"ID : {Id} Name : {Name} Email : {Email} Phone : {Phone}";
        }
    }
}
