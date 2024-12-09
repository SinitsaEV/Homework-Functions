using System;
using System.Text;

namespace Functions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string AddDossierCommand = "1";
            const string RemoveDossierCommand = "2";
            const string FindDossiersCommand = "3";
            const string ShowDossiersCommand = "4";
            const string ExitCommand = "5";

            string addDossierText = $"{AddDossierCommand} - Добывить досье.\n";
            string removeDossierText = $"{RemoveDossierCommand} - Удалить досье.\n";
            string findDossiersText = $"{FindDossiersCommand} - Найти досье по фамилии.\n";
            string showDossiersText = $"{ShowDossiersCommand} - Показать все досье.\n";
            string exitText = $"{ExitCommand} - Выйти из программы.\n";
            string emptyDossiersText = "Список досье пуст, добавте досье.";

            char symbolSeparating = ' ';
            char symbolSeparatingDossiers = '-';

            string[] fullNames = new string[] { "Синица Евгений Владимирович", "Бурван Илья Викторович" };
            string[] posts = new string[] { "Системный администратор", "Безработный" };

            bool isWorking = true;

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (isWorking)
            {
                Console.WriteLine(addDossierText + removeDossierText + findDossiersText + showDossiersText + exitText);
                Console.Write("Введите номер команды: ");

                switch (Console.ReadLine())
                {
                    case AddDossierCommand:
                        AddDossier(ref fullNames, ref posts);
                        break;

                    case RemoveDossierCommand:
                        RemoveDossier(ref fullNames, ref posts, emptyDossiersText);
                        break;

                    case FindDossiersCommand:
                        FindDossierByLastName(fullNames, posts, symbolSeparating, emptyDossiersText);
                        break;

                    case ShowDossiersCommand:
                        ShowDossiers(fullNames, posts, symbolSeparatingDossiers, emptyDossiersText);
                        break;

                    case ExitCommand:
                        isWorking = false;
                        break;

                    default:
                        Console.WriteLine("Неверная команда.");
                        break;
                }
            }
        }

        private static void AddDossier(ref string[] fullNames, ref string[] posts)
        {
            Console.Write("Введите ФИО. ");
            fullNames = AddElementToArray(fullNames, Console.ReadLine());
            Console.Write("Введите должность. ");
            posts = AddElementToArray(posts, Console.ReadLine());
        }

        private static string[] AddElementToArray(string[] array, string element)
        {
            array = IncreaseArray(array);
            array[array.Length - 1] = element;

            return array;
        }

        private static string[] IncreaseArray(string[] array)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            return array = tempArray;
        }

        private static void RemoveDossier(ref string[] fullNames, ref string[] posts, string emptyText)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine(emptyText);
                return;
            }

            Console.Write("Введите номер досье: ");
            int removeElementIndex;
            bool isNumber = int.TryParse(Console.ReadLine(), out removeElementIndex);
            removeElementIndex--;

            if (isNumber && removeElementIndex < fullNames.Length)
            {
                fullNames = RemoveArrayElement(fullNames, removeElementIndex);
                posts = RemoveArrayElement(posts, removeElementIndex);
            }
            else
            {
                Console.WriteLine("Неверный номер досье.");
            }
        }

        private static string[] RemoveArrayElement(string[] array,int removeElementIndex)
        {
            string[] tempArray = new string[array.Length - 1];
            
            for(int i = 0; i < removeElementIndex; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = removeElementIndex + 1; i < array.Length; i++)
            {
                tempArray[i - 1] = array[i];
            }

            return array = tempArray;
        }

        private static void ShowDossiers(string[] fullNames, string[] posts, char symbolSeparating, string emptyText)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine(emptyText);
                return;
            }

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write(symbolSeparating);
                ShowDossier(i + 1, fullNames[i], posts[i]);
            }

            Console.WriteLine();
        }

        private static void ShowDossier(int dossierID, string fullName, string post)
        {
            Console.Write(dossierID + " " + fullName + " " + post);
        }

        private static void FindDossierByLastName(string[] fullNames, string[] posts, char symbolSeparating, string emptyText)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine(emptyText);
                return;
            }

            Console.Write("Введите фамилию для поиска: ");
            string input = Console.ReadLine();
                 
            for(int i = 0;i < fullNames.Length;i++)
            {
                string[] temp = fullNames[i].Split(symbolSeparating);

                if (temp[0].ToLower() == input.ToLower())
                {
                    ShowDossier(i + 1, fullNames[i], posts[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}
