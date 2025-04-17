using ContactsAPI.Models.Entities;

namespace ContactsAPI.Database
{
    public class ContactsDbSeeder(ContactsDbContext dbContext)
    {
        private readonly ContactsDbContext _dbContext = dbContext;

        public void Seed()
        {
            if (!_dbContext.Database.CanConnect())
            {
                //return;
                throw new Exception("Can't establish db connection");
            }

            if (_dbContext.Contacts.Any())
            {
                return;
            }

            IEnumerable<Contact> contacts = getContacts();
            _dbContext.Contacts.AddRange(contacts);
            _dbContext.SaveChanges();
        }

        private IEnumerable<Contact> getContacts()
        {
            // Przykładowe kategorie
            var privateCategory = new Category { Name = "private" };
            var businessCategory = new Category { Name = "business"};
            var otherCategory = new Category { Name = "other" };

            // Przykładowe podkategorie
            var bossSubcategory = new Subcategory
                { Name = "boss", Category = businessCategory };
            var clientSubcategory = new Subcategory
                { Name = "client", Category = businessCategory };
            var hobbySubcategory = new Subcategory
                { Name = "hobby", Category = otherCategory };

            // Lista kontaktów
            var contacts = new List<Contact>
            {
                new Contact
                {
                    FirstName = "Anna",
                    LastName = "Nowak",
                    BirthDate = new DateTime(1995, 5, 12),
                    PhoneNumber = "+48123456789",
                    Category = businessCategory,
                    Subcategory = bossSubcategory,
                },
                new Contact
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    BirthDate = new DateTime(1990, 3, 8),
                    PhoneNumber = "+48987654321",
                    Category = businessCategory,
                    Subcategory = clientSubcategory,
                },
                new Contact
                {
                    FirstName = "Ewa",
                    LastName = "Wiśniewska",
                    BirthDate = new DateTime(2000, 12, 24),
                    PhoneNumber = "+48765432109",
                    Category = otherCategory,
                    Subcategory = hobbySubcategory,
                },
                new Contact
                {
                    FirstName = "Marek",
                    LastName = "Zieliński",
                    BirthDate = new DateTime(1988, 7, 4),
                    PhoneNumber = "+48555123456",
                    Category = privateCategory,
                    Subcategory = null,
                }
            };
            return contacts;
        }
    }
}