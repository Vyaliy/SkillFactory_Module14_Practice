using System.Collections.Generic;

namespace SkillFactory_Module14_Practice
{
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            //  создаём пустой список с типом данных Contact
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            int pageNumber = 0;
            while (true)
            {
                Console.Write("Введите номер страницы...");
                if (Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out pageNumber) == false)
                {
                    Console.Clear();
                    Console.WriteLine("Введенное значение не является числом");
                    continue;
                }
                if (pageNumber > 3)
                {
                    Console.Clear();
                    Console.WriteLine("Введено слишком большое значение");
                    continue;
                }
                //Вот тут сортировка по имени и затем по фамилии
                var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2).OrderBy(c => c.Name).ThenBy(d => d.LastName);
                Console.Clear();

                foreach (var element in pageContent)
                {
                    Console.WriteLine($"{element.Name} {element.LastName}\nPhone number: {element.PhoneNumber}\nE-mail: {element.Email}\n");
                }
            }
        }
    }
}