using System.Reflection.Metadata.Ecma335;

namespace DelegatsEvents
{


   //N1
    static class Check 
    { 
    public  static int SetencesCount(string line)
        {
            string[] sentences = line.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }
        //N2
   public static int WordsCount(string line, char literal)
        {
          
            string[] sentences = line.Split(new char[] { literal }, StringSplitOptions.RemoveEmptyEntries);
           
            return sentences.Length;

        }
    }

    delegate void Put(string message);
    delegate void Take(string massage);

    //N3
    class BackPack
    {
        public event Put PutItem;
        public event Take TakeItem;
        public string Color { get; set; }
        public string Brand { get; set; }
        public double Weight { get; set; }
        public int Size { get; set; }
        public List<string> items = new List<string>();
        public BackPack(string color, string brand, double weight, int size, List<string> item) { 
        
            this.Color = color;
            this.Brand = brand;
            this.Weight = weight;
            this.Size = size;
            items = item;
        }
        public void Print()
        {
            Console.WriteLine("Color: " + Color);
            Console.WriteLine("Brand: " + Brand);
            Console.WriteLine("Weight: " + Weight);
            Console.WriteLine("Size: " + Size);
        }
        public void Put()
        {
            Console.WriteLine("Putting...");
            PutItem?.Invoke($"Items: {string.Join(", ", items)} have been put into the backpack");
        }

        public void Take()
        {
            Console.WriteLine("Taking...");
            TakeItem?.Invoke($"Items: {string.Join(", ", items)} have been taken from the backpack");
        }
    }

    class Person
    {
        public string name { get; set; }

        public double height {  get; set; }
        public double weight { get; set; }
        public int age { get; set; }

        public Person(string name, double height, double weight, int age)
        {
            this.name = name;
            this.height = height;
            this.weight = weight;
            this.age = age;
        }
        public void Print()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Height: " + height);
            Console.WriteLine("Weight: " +  weight);
            Console.WriteLine("Age: " +  age);  
        }
    }
    static class PeopleAverageAge
    {
        public static double AverageAge(Person[] person)
        {
            return person.Average(people => people.age);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           //N1
            string line = "Hello. Hello Hello. Hello.";
            int result = Check.SetencesCount(line);
            Console.WriteLine("Count of sentences " + result);
            //N2
            int res = Check.WordsCount(line, 'H');
            Console.WriteLine("Count of words" + res);
            //N3
            List<string> list = new List<string>() {"Ball", "Shirt", "Bat" }; 
            BackPack obj = new BackPack("Red", "Gucci", 20.90, 10, list);
            obj.Print();
            obj.PutItem += Puted;
            obj.Put();
            obj.TakeItem += Taken;
            obj.Take();
            static void Puted(string text) { Console.WriteLine(text);}
            static void Taken(string text) { Console.WriteLine(text);}
            //N4
            Person[] persons = new Person[] { new Person("Vanya", 6.2, 80.00, 21), new Person("Andrey", 6.5, 89.90, 25), new Person("Tolya", 5.9,75.70, 31)};
            double resultt = PeopleAverageAge.AverageAge(persons);
            Console.WriteLine("Средний возраст всех людей: " + resultt);
        }
    }
}
