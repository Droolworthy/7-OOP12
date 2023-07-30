//Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать, к какому вольеру подойти.При приближении к вольеру,
//пользователю выводится информация о том, что это за вольер, сколько животных там обитает, их пол и какой звук издает животное.
//Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера..
namespace OOP12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            CreateAviaries();
        }

        public void Work()
        {
            bool isWork = true;

            int aviaryTigers = 0;
            int aviaryBears = 1;
            int aviaryWolfs = 2;
            int aviaryLynxs = 3;
            int commandExit = 4;

            Console.WriteLine($"Вольер с тиграми - {aviaryTigers}");
            Console.WriteLine($"Вольер с медведями - {aviaryBears}");
            Console.WriteLine($"Вольер с волками - {aviaryWolfs}");
            Console.WriteLine($"Вольер с рысью - {aviaryLynxs}");
            Console.WriteLine($"Выход - {commandExit}");

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int numberCage))
                {
                    if (numberCage == aviaryTigers)
                    {
                        Console.WriteLine("\nПеред вами вольер с тиграми. \n\nТигр — хищное млекопитающее семейства кошачьих, " +
                            "один из пяти видов рода пантер, принадлежащего к подсемейству больших кошек.");
                        Console.WriteLine($"\nКолличество тигров: {_aviaries[0].GetAnimalsCount()}\n");

                        ShowAviaries(numberCage);
                    }
                    else if (numberCage == aviaryBears)
                    {
                        Console.WriteLine("\nПеред вами вольер с медведями. \n\nМедведь - крупное хищное всеядное млекопитающее с большим " +
                            "грузным, покрытым густой шерстью телом и короткими ногами.");
                        Console.WriteLine($"\nКолличество медведей: {_aviaries[1].GetAnimalsCount()}\n");

                        ShowAviaries(numberCage);
                    }
                    else if (numberCage == aviaryWolfs)
                    {
                        Console.WriteLine("\nПеред вами вольер с волками. \n\nВолк – это хищное животное из класса млекопитающих. " +
                            "Множественные исследования показывают, что это предок собаки.");
                        Console.WriteLine($"\nКолличество волков: {_aviaries[2].GetAnimalsCount()}\n");

                        ShowAviaries(numberCage);
                    }
                    else if (numberCage == aviaryLynxs)
                    {
                        Console.WriteLine("\nПеред вами вольер с рысью. \n\nХищное животное из семейства кошачьих, " +
                            "с заостренной мордой и очень острым зрением.");
                        Console.WriteLine($"\nКолличество рысей: {_aviaries[3].GetAnimalsCount()}\n");

                        ShowAviaries(numberCage);
                    }
                    else if (numberCage == commandExit)
                    {
                        isWork = false;
                    }
                    else
                    {
                        Console.WriteLine($"Такого вольера не существует. Введите номер вольера {aviaryTigers}, {aviaryBears}, {aviaryWolfs}, " +
                            $"{aviaryLynxs} или {commandExit} - для выхода из приложения.");
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка. Попробуйте ещё раз.");
                }
            }
        }

        private void CreateAviaries()
        {
            int numberAviaries = 4;

            for (int i = 0; i < numberAviaries; i++)
            {
                _aviaries.Add(new Aviary(i));
            }
        }

        private void ShowAviaries(int index)
        {
            _aviaries[index].ShowAnimals();
        }
    }

    class UserUtils
    {
        private static Random _random = new Random();

        internal static string GenerateRandomArrayWord(string[] word)
        {
            return word[_random.Next(word.Length)];
        }

        public static int GenerateRandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public Aviary(int index)
        {
            CreateAnimals(index);
        }

        public void ShowAnimals()
        {
            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].ShowInfoBeasts();
            }
        }

        public int GetAnimalsCount()
        {
            return _animals.Count;
        }

        private void CreateAnimals(int index)
        {
            int minimumNumberAnimals = 3;
            int maximumNumberAnimals = 8;

            for (int i = 0; i < UserUtils.GenerateRandomNumber(minimumNumberAnimals, maximumNumberAnimals); i++)
            {
                _animals.Add(GetAnimalByIndex(index));
            }
        }

        private Animal GetAnimalByIndex(int index)
        {
            string[] genders = new string[] { "Женский", "Мужской" };
            string[] beasts = new string[] { "Тигр", "Медведь", "Волк", "Рысь" };
            string[] soundTigers = new string[] { "Фррр! Фррр!", "Грр! Грр!", "Арр! Арр!", "Мурр! Мурр!" };
            string[] soundBears = new string[] { "Ааа! Ааа!", "Ррр! Ррр!", "Фрр! Фрр!", "Мааа! Мааа!" };
            string[] soundWolfs = new string[] { "Ууу! Ууу!", "Аууу! Аууу!", "Ммм! Ммм!", "Грр! Грр!" };
            string[] soundLynxs = new string[] { "Ав! Ав!", "Мрр! Мрр!", "Кхх! Кхх!", "Кхх! Кхх!" };

            switch (beasts[index])
            {
                case "Тигр":
                    return new Animal("Тигр", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundTigers));
                case "Медведь":
                    return new Animal("Медведь", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundBears));
                case "Волк":
                    return new Animal("Волк", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundWolfs));
                case "Рысь":
                    return new Animal("Рысь", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundLynxs));
            }

            return null;
        }
    }

    class Animal
    {
        public Animal(string appellation, string genus, string sound)
        {
            Name = appellation;
            Gender = genus;
            Noise = sound;
        }

        public string Name { get; private set; }

        public string Gender { get; private set; }

        public string Noise { get; private set; }

        public void ShowInfoBeasts()
        {
            Console.WriteLine("Имя - " + Name + " Пол - " + Gender + " Звук - " + Noise);
        }
    }
}
