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
                    BirthDate = "1995-05-12",
                    PhoneNumber = "+48123456789",
                    Category = businessCategory,
                    Subcategory = bossSubcategory,
                },
                new Contact
                {
                    FirstName = "Jan",
                    LastName = "Kowalski",
                    BirthDate = "1990-03-08",
                    PhoneNumber = "+48987654321",
                    Category = businessCategory,
                    Subcategory = clientSubcategory,
                },
                new Contact
                {
                    FirstName = "Ewa",
                    LastName = "Wiśniewska",
                    BirthDate = "2000-12-24",
                    PhoneNumber = "+48765432109",
                    Category = otherCategory,
                    Subcategory = hobbySubcategory,
                },
                new Contact
                {
                    FirstName = "Marek",
                    LastName = "Zieliński",
                    BirthDate = "1988-07-04",
                    PhoneNumber = "+48555123456",
                    Category = privateCategory,
                    Subcategory = null,
                }
            };
            return contacts;
        }
    }
}