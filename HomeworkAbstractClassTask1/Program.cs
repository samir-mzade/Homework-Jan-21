using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Создать класс Student, который
будет содержать информацию о студенте (фамилия, курс обучения, номер зачетной
книги). Реализовать класс Aspirant (аспирант – студент, который готовится к
защите кандидатской диссертации). Класс Aspirant и  класс Student унаследоваться от Абстрактного
класса Person. Класс Person реализовать общими свойствами, полями и методами
классов Student и Aspirant.
Абстрактный класс Person
необходимо реализовать следующие элементы:
конструкторы классов с
соответствующим количеством параметров.
свойства get/set для доступа к
полям класса;
метод Print(), который выводит
информацию о содержимом полей класса и продумать как переопределить их в
производных классах.
Итого: Старое ДЗ переделать под абстрактный класс
Добавить методы для использования методов класса Object*/
namespace HomeworkAbstractClassTask1
{
    abstract class Person
    {
        public string Surname { get; set; }
        public int YearOfEdu { get; set; }
        public int Id { get; set; }
        public abstract Person[] this[int index] { get; set; }
        public Person() { }
        public abstract void Print();
        public abstract Person[] AddStudent();
        public abstract Person[] RemoveStudent();
        public abstract void SearchIndex();
        public abstract void NumberOfStudent();
    }
    static class Validation
    {
        public static int NumValidation()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int num))
                {
                    if (num <= 0)
                    {
                        Console.WriteLine("Please enter valid number");
                    }
                    else
                    {
                        return num;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid data");
                }
            }
        }
        public static int NumYearValidation()
        {
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out int number))
                {
                    if (number <= 0 || number > 8)
                    {
                        Console.WriteLine("Please enter valid year");
                    }
                    else
                    {
                        return number;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter valid number");
                }
            }
        }
        public static string StringValidation()
        {
            int count;
            string validation = "1234567890,.;'<>/-=+?!@`#%$^*~()%{}[]\t  ";
            string name;
            do
            {
                name = Console.ReadLine();

                count = 0;
                if (name.Length == 0)
                {
                    count++;
                }
                foreach (int symbols in validation)
                {
                    foreach (int elements in name)
                    {
                        if (symbols == elements)
                        {
                            count++;
                        }
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("Please enter valid data");
                }
            } while (count != 0);
            return name = name.ToUpper()[0] + name.Substring(1).ToLower();
        }
        public static string StringDefenseValidation()
        {
            int count;
            string validation = "1234567890,.;'<>/-=+?!@`#%$^*~()%{}[]\t  ";
            string name;
            do
            {
                name = Console.ReadLine();
                count = 0;
                if (name.Length == 0)
                {
                    count++;
                }
                else
                {
                   name = name.ToUpper()[0] + name.Substring(1).ToLower();
                if (name == "Passed" || name == "Fail")
                    {
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                foreach (int symbols in validation)
                {
                    foreach (int elements in name)
                    {
                        if (symbols == elements)
                        {
                            count++;
                        }
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("Please enter valid data");
                }
            } while (count != 0);
            return name;
        }

    }
    class Student : Person
    {
        int size;
        int countStudent;
        Student[] arrayStudent;
        public override Person[] this[int index]
        {
            get
            {
                return arrayStudent;
            }
            set
            {
                arrayStudent = (Student[])value;
            }
        }
        public override Person[] AddStudent()
        {
            int num = Validation.NumValidation();
            Array.Resize(ref arrayStudent, size+=num);
            for (int i = 0; i < num; i++)
            {
                arrayStudent[i] = new Student();
                Console.WriteLine($"Please enter surname of the {i + 1} student");
                arrayStudent[i].Surname = Validation.StringValidation();
                Console.WriteLine($"Please enter year of education of the {i + 1} student");
                arrayStudent[i].YearOfEdu=Validation.NumYearValidation();
                Console.WriteLine($"Please enter ID of the {i + 1} student");
                arrayStudent[i].Id = Validation.NumValidation();
                countStudent++;
            }
            return arrayStudent;
        }
        public override Person[] RemoveStudent()
        {
            while (true)
            {
                int num = Validation.NumValidation();
                if (num <= size)
                {
                    arrayStudent[num - 1] = null;
                    for (int i = 0; i < arrayStudent.Length; i++)
                    {
                        if (arrayStudent[i] == null)
                        {
                            arrayStudent[i] = arrayStudent[size - 1];
                            Console.WriteLine("Student is deleted");
                            countStudent--;
                        }
                    }
                    Array.Resize(ref arrayStudent, size-1);
                    break;
                }
                else
                {
                    Console.WriteLine("Student under this number is not exist");
                }
            }
            return arrayStudent;
        }
        public override void SearchIndex()
        {
            int num = Validation.NumValidation();
            for (int i = 0; i < arrayStudent.Length; i++)
            {
                if (arrayStudent[i] == arrayStudent[num - 1])
                {
                    Console.WriteLine($"Surname: { arrayStudent[i].Surname}");
                    Console.WriteLine($"Year of study: { arrayStudent[i].YearOfEdu}");
                    Console.WriteLine($"ID number: { arrayStudent[i].Id}");
                }
            }
        }
        public override void NumberOfStudent()
        {
            Console.WriteLine("\nNumber of students is " + countStudent);
        }
        public override void Print()
        {
            for (int i = 0; i < arrayStudent.Length; i++)
            {
                Console.WriteLine($" Surname: {arrayStudent[i].Surname}\n Year of education: {arrayStudent[i].YearOfEdu}\n ID: {arrayStudent[i].Id}");
            }
        }
    }
     class Aspirant : Person
    {
        int size;
        int countAspirant;
        public string Defense { get; set; }
        Aspirant[] arrayAspirant;
        public override Person[] this[int index]
        {
            get
            {
                return arrayAspirant;
            }
            set
            {
                arrayAspirant = (Aspirant[])value;
            }
        }
        public override Person[] AddStudent()
        {
            int num = Validation.NumValidation();
            Array.Resize(ref arrayAspirant,size+= num);
            for (int i = 0; i < num; i++)
            {
                arrayAspirant[i] = new Aspirant();
                Console.WriteLine($"Please enter surname of the {i + 1} aspirant");
                arrayAspirant[i].Surname = Validation.StringValidation();
                Console.WriteLine($"Please enter year of education of the {i + 1} aspirant");
                arrayAspirant[i].YearOfEdu = Validation.NumYearValidation();
                Console.WriteLine($"Please enter ID of the {i + 1} aspirant");
                arrayAspirant[i].Id = Validation.NumValidation();
                Console.WriteLine($"Please enter Defense result of the {i + 1} aspirant");
                arrayAspirant[i].Defense = Validation.StringDefenseValidation();
                countAspirant++;
            }
            return arrayAspirant;
        }
        public override Person[] RemoveStudent()
        {
            while (true)
            {
                int num = Validation.NumValidation();
                if (num <= size)
                {
                    arrayAspirant[num - 1] = null;
                    for (int i = 0; i < arrayAspirant.Length; i++)
                    {
                        if (arrayAspirant[i] == null)
                        {
                            arrayAspirant[i] = arrayAspirant[size-1];
                            Console.WriteLine("Aspirant is deleted");
                            countAspirant--;
                        }
                    }
                    Array.Resize(ref arrayAspirant, size-1);
                    break;
                }
                else
                {
                    Console.WriteLine("Aspirant under this number is not exist");
                }
            }
            return arrayAspirant;
        }
        public override void SearchIndex()
        {
            int num = Validation.NumValidation();
            for (int i = 0; i < arrayAspirant.Length; i++)
            {
                if (arrayAspirant[i] == arrayAspirant[num - 1])
                {
                    Console.WriteLine($"Surname: { arrayAspirant[i].Surname}");
                    Console.WriteLine($"Year of study: { arrayAspirant[i].YearOfEdu}");
                    Console.WriteLine($"ID number: { arrayAspirant[i].Id}");
                    Console.WriteLine($"Defense result: { arrayAspirant[i].Defense}");
                }
            }
        }
        public override void NumberOfStudent()
        {
            Console.WriteLine("\n Number of aspirants is " + countAspirant);
        }
        public override void Print()
        {
            for (int i = 0; i < arrayAspirant.Length; i++)
            {
                Console.WriteLine($"\n Surname: {arrayAspirant[i].Surname}\n Year of education: {arrayAspirant[i].YearOfEdu}\n ID: {arrayAspirant[i].Id}\n Defense result:{arrayAspirant[i].Defense} ");
            }
        }
      
    }

    internal class Program
    {
        

        static void Main(string[] args)
        {
            Student student = new Student();
            Aspirant aspirant = new Aspirant();
            bool exit = true;
            do
            {
                Console.WriteLine("\n Press '1' in order to add a new student.\n Press '2' in order to delete a student.\n Press '3' in order to see the exact student data.\n Press '4' in order to see how many students are on the list.\n Press '5' to get whole list of students.\n Press '6' in order to add a new aspirant.\n Press '7' in order to delete an aspirant.\n Press '8' in order to see the exact aspirant data.\n Press '9' in order to see how many aspirants are on the list.\n Press '10' to get whole list of aspirants.\n Press '11' to exit.");
                int option = Validation.NumValidation();
                switch (option)
                {
                    case 1:
                        Console.WriteLine("How many students you want to add?");
                        student.AddStudent();
                        student.Print();
                        break;
                    case 2:
                        Console.WriteLine("Which student you want to remove?");
                        student.RemoveStudent();
                        break;
                    case 3:
                        Console.WriteLine("Which student you want to be shown?");
                        student.SearchIndex();
                        break;
                    case 4:
                        student.NumberOfStudent();
                        break;
                    case 5:
                        student.Print();
                        break;
                    case 6:
                        Console.WriteLine("How many aspirant you want to add?");
                        aspirant.AddStudent();
                        aspirant.Print();
                        break;
                    case 7:
                        Console.WriteLine("Which aspirant you want to remove?");
                        aspirant.RemoveStudent();
                        break;
                    case 8:
                        Console.WriteLine("Which aspirant you want to be shown?");
                        aspirant.SearchIndex();
                        break;
                    case 9:
                        aspirant.NumberOfStudent();
                        break;
                    case 10:
                        aspirant.Print();
                        break;
                    case 11:
                        exit = false;
                        Console.WriteLine("Bye");
                        break;
                    default:
                        Console.WriteLine("Please enter numbers between 1-10");
                        break;
                }
            } while (exit);
            Console.ReadKey();
        }
    }
}
