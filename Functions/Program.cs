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
            const string WriteDossiersCommand = "4";
            const string ExitCommand = "5";

            string addDossierText = $"{AddDossierCommand} - Добывить досье.\n";
            string removeDossierText = $"{RemoveDossierCommand} - Удалить досье.\n";
            string findDossiersText = $"{FindDossiersCommand} - Найти досье по фамилии.\n";
            string writeDossiersText = $"{WriteDossiersCommand} - Показать все досье.\n";
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
                Console.WriteLine(addDossierText + removeDossierText + findDossiersText + writeDossiersText + exitText);
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

                    case WriteDossiersCommand:
                        WriteDossiers(fullNames, posts, symbolSeparatingDossiers, emptyDossiersText);
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
            AddElementToArray(ref fullNames, Console.ReadLine());
            Console.Write("Введите должность. ");
            AddElementToArray(ref posts, Console.ReadLine());
        }

        private static void AddElementToArray(ref string[] array, string element)
        {
            IncreaseArray(ref array);
            array[array.Length - 1] = element;
        }

        private static void IncreaseArray(ref string[] array)
        {
            string[] temp = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                temp[i] = array[i];
            }

            array = temp;
        }

        private static void RemoveDossier(ref string[] fullNames, ref string[] posts, string emptyText)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine(emptyText);
                return;
            }

            Console.Write("Введите номер досье: ");
            int removeElementIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            RemoveArrayElement(ref fullNames, removeElementIndex);
            RemoveArrayElement(ref posts, removeElementIndex);
        }

        private static void RemoveArrayElement(ref string[] array,int removeElementIndex)
        {
            string[] tempArray = new string[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (i < removeElementIndex)
                {
                    tempArray[i] = array[i];
                }
                else if (i > removeElementIndex)
                {
                    tempArray[i - 1] = array[i];
                }
            }

            array = tempArray;
        }

        private static void WriteDossiers(string[] fullNames, string[] posts, char symbolSeparating, string emptyText)
        {
            if (fullNames.Length == 0)
            {
                Console.WriteLine(emptyText);
                return;
            }

            for (int i = 0; i < fullNames.Length; i++)
            {
                Console.Write(symbolSeparating);
                WriteDossier(i + 1, fullNames[i], posts[i]);
            }

            Console.WriteLine();
        }

        private static void WriteDossier(int dossierID, string fullName, string post)
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
                    WriteDossier(i + 1, fullNames[i], posts[i]);
                    Console.WriteLine();
                }
            }
        }
    }
}