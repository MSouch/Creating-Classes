using System;

namespace PersonRelation
{
    public class Person
    {
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string favoriteColour { get; set; }
        public int age { get; set; }
        public bool isWorking { get; set; }

        public void DisplayPersonInfo()
        {
            Console.WriteLine($"Name: {firstName} {lastName}");
            Console.WriteLine($"Person Id: {personId}");
            Console.WriteLine($"{firstName}'s favorite color is {favoriteColour}");
        }

        public void ChangeFavoriteColour()
        {
            favoriteColour = "White";
        }

        public int GetAgeInTenYears()
        {
            return age + 10;
        }

        public override string ToString()
        {
            return $"Person Id: {personId}, Name: {firstName} {lastName}, Favorite Color: {favoriteColour}, Age: {age}, Is Working: {isWorking}";
        }
    }

    public class Relation
    {
        public string RelationshipType { get; set; }

        public void ShowRelationship(Person person1, Person person2)
        {
            if (RelationshipType == "Sister")
            {
                Console.WriteLine($"{person1.firstName} {person1.lastName} and {person2.firstName} {person2.lastName} are sisters.");
            }
            else if (RelationshipType == "Brother")
            {
                Console.WriteLine($"{person1.firstName} {person1.lastName} and {person2.firstName} {person2.lastName} are brothers.");
            }
            else if (RelationshipType == "Mother")
            {
                Console.WriteLine($"{person1.firstName} {person1.lastName} is the mother of {person2.firstName} {person2.lastName}.");
            }
            else if (RelationshipType == "Father")
            {
                Console.WriteLine($"{person1.firstName} {person1.lastName} is the father of {person2.firstName} {person2.lastName}.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person { personId = 1, firstName = "Ian", lastName = "Brooks", favoriteColour = "Red", age = 30, isWorking = true };
            Person person2 = new Person { personId = 2, firstName = "Gina", lastName = "James", favoriteColour = "Green", age = 18, isWorking = false };
            Person person3 = new Person { personId = 3, firstName = "Mike", lastName = "Briscoe", favoriteColour = "Blue", age = 45, isWorking = true };
            Person person4 = new Person { personId = 4, firstName = "Mary", lastName = "Beals", favoriteColour = "Yellow", age = 28, isWorking = true };

            Console.WriteLine($"{person2.firstName}'s information: ");
            person2.DisplayPersonInfo();

            Console.WriteLine($"\n{person3.firstName}'s information: ");
            Console.WriteLine(person3.ToString());

            person1.ChangeFavoriteColour();
            Console.WriteLine($"\n{person1.firstName}'s favorite color is now {person1.favoriteColour}");

            Console.WriteLine($"\n{person4.firstName}'s age in ten years: {person4.GetAgeInTenYears()}");

            Relation relation1 = new Relation { RelationshipType = "Sister" };
            Relation relation2 = new Relation { RelationshipType = "Brother" };
            relation1.ShowRelationship(person2, person4);
            relation2.ShowRelationship(person1, person3);

            List<Person> people = new List<Person> { person1, person2, person3, person4 };
            double averageAge = people.Average(p => p.age);
            Console.WriteLine($"\nThe average age of the people in the list is: {averageAge}");

            Person youngestPerson = people.OrderBy(p => p.age).First();
            Person oldestPerson = people.OrderByDescending(p => p.age).First();
            Console.WriteLine($"The youngest person is: {youngestPerson.firstName} {youngestPerson.lastName}");
            Console.WriteLine($"The oldest person is: {oldestPerson.firstName} {oldestPerson.lastName}");

            var mNames = from person in people
                         where person.firstName[0] == 'M'
                         select person;
            Console.WriteLine("\nThe names of the people whose first names start with M:");
            foreach (var person in mNames)
            {
                Console.WriteLine(person.firstName + " " + person.lastName);
            }

            var blueLiker = from person in people
                            where person.favoriteColour == "Blue"
                            select person;
            Console.WriteLine("\nThe person information of the person that likes the colour blue:");
            foreach (var person in blueLiker)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}