namespace HomeWorkLINQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            var sortedPhoneBook = from phone in phoneBook orderby phone.Name, phone.LastName select phone;
            foreach (var phone in sortedPhoneBook)
            {
                Console.WriteLine(phone.Name + " " + phone.LastName + " " + phone.PhoneNumber + " " + phone.Email);
            }

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1 что бы отобразить первые 2 контакта");
                Console.WriteLine("Введите 2 что бы отобразить вторые 2 контакта");
                Console.WriteLine("Введите 3 что бы отобразить третьи 2 контакта");
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            var firstTwo = sortedPhoneBook.Take(2);
                            foreach (var f in firstTwo)
                            {
                                f.PrintContact(f);
                            }
                            break;
                        case 2:
                            var secondTwo = sortedPhoneBook.Skip(2).Take(2);
                            foreach (var f in secondTwo)
                            {
                                f.PrintContact(f);
                            }
                            break;
                        case 3:
                            var thirdTwo = sortedPhoneBook.Skip(4).Take(2);
                            foreach (var f in thirdTwo)
                            {
                                f.PrintContact(f);
                            }
                            break;
                        default:
                            Console.WriteLine("Введено некорректное значение");
                            break;
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine("Введено некорректное значение");
                }

            }
        }
        public class Contact // модель класса
        {
            public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
            {
                Name = name;
                LastName = lastName;
                PhoneNumber = phoneNumber;
                Email = email;
            }

            public String Name { get; }
            public String LastName { get; }
            public long PhoneNumber { get; }
            public String Email { get; }
            public void PrintContact(Contact contact)
            {
                Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);
            }
        }
    }
}
