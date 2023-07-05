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
            int aviaryBirds = 3;
            int commandExit = 4;

            Console.WriteLine($"Вольер с тиграми - {aviaryTigers}");
            Console.WriteLine($"Вольер с медведями - {aviaryBears}");
            Console.WriteLine($"Вольер с волками - {aviaryWolfs}");
            Console.WriteLine($"Вольер с рысью - {aviaryBirds} \nВыход - {commandExit}");

            while (isWork)
            {
                Console.Write("\nВвод: ");
                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out int numberCage))
                {
                    if (numberCage == commandExit)
                    {
                        isWork = false;
                    }
                    else
                    {
                        ShowAviaries(numberCage);
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
            if (index >= 0 && index < _aviaries.Count)
            {
                _aviaries[index].ShowAnimals();
            }
            else
            {
                Console.WriteLine("Ошибка. Попробуйте ещё раз.");
            }
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

        private void CreateAnimals(int index)
        {
            int minimumNumberAnimals = 3;
            int maximumNumberAnimals = 8;

            for (int i = 0; i < UserUtils.GenerateRandomNumber(minimumNumberAnimals, maximumNumberAnimals); i++)
            {
                _animals.Add(GetAnimalsByIndex(index));
            }
        }

        private Animal GetAnimalsByIndex(int index)
        {
            string[] genders = Array.Empty<string>();
            string[] beasts = Array.Empty<string>();
            string[] soundTigers = Array.Empty<string>();
            string[] soundBears = Array.Empty<string>();
            string[] soundWolfs = Array.Empty<string>();
            string[] soundLynxs = Array.Empty<string>();

            string descriptionAviaryTigers = "";
            string descriptionAviaryBears = "";
            string descriptionAviaryWolfs = "";
            string descriptionAviaryLynxs = "";

            DescribeAnimals(ref genders, ref beasts, ref soundTigers, ref soundBears, ref soundWolfs, ref soundLynxs, ref descriptionAviaryTigers,
                ref descriptionAviaryBears, ref descriptionAviaryWolfs, ref descriptionAviaryLynxs);

            switch (beasts[index])
            {
                case "Тигр":
                    return new Animal(descriptionAviaryTigers, "Тигр", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundTigers));
                case "Медведь":
                    return new Animal(descriptionAviaryBears, "Медведь", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundBears));
                case "Волк":
                    return new Animal(descriptionAviaryWolfs, "Волк", UserUtils.GenerateRandomArrayWord(genders), UserUtils.GenerateRandomArrayWord(soundWolfs));
                case "Рысь":
                    return new Animal(descriptionAviaryLynxs, "Рысь", UserUtils.GenerateRandomArrayWord(genders),UserUtils.GenerateRandomArrayWord(soundLynxs));
            }

            return null;
        }

        private void DescribeAnimals(ref string[] genders, ref string[] beasts, ref string[] soundTigers, ref string[] soundBears, ref string[] soundWolfs, 
            ref string[] soundLynxs, ref string descriptionAviaryTigers, ref string descriptionAviaryBears, ref string descriptionAviaryWolfs, ref string descriptionAviaryLynxs)
        {
            genders = new string[] { "Женский", "Мужской" };
            beasts = new string[] { "Тигр", "Медведь", "Волк", "Рысь" };
            soundTigers = new string[] { "Фррр! Фррр!", "Грр! Грр!", "Арр! Арр!", "Мурр! Мурр!" };
            soundBears = new string[] { "Ааа! Ааа!", "Ррр! Ррр!", "Фрр! Фрр!", "Мааа! Мааа!" };
            soundWolfs = new string[] { "Ууу! Ууу!", "Аууу! Аууу!", "Ммм! Ммм!", "Грр! Грр!" };
            soundLynxs = new string[] { "Ав! Ав!", "Мрр! Мрр!", "Кхх! Кхх!", "Кхх! Кхх!" };

            descriptionAviaryTigers = "Перед вами вольер с тиграми. Тигр — хищное млекопитающее семейства кошачьих, " +
                "один из пяти видов рода пантер, принадлежащего к подсемейству больших кошек.";
            descriptionAviaryBears = "Перед вами вольер с медведями. Медведь - крупное хищное всеядное млекопитающее с большим грузным, " +
                "покрытым густой шерстью телом и короткими ногами.";
            descriptionAviaryWolfs = "Перед вами вольер с волками. Волк – это хищное животное из класса млекопитающих. " +
                "Множественные исследования показывают, что это предок собаки.";
            descriptionAviaryLynxs = "Перед вами вольер с рысью. Хищное животное из семейства кошачьих, " +
                "с заостренной мордой и очень острым зрением.";
        }
    }

    class Animal
    {
        public Animal(string parameter, string appellation, string genus, string sound)
        {
            Characteristic = parameter;
            Name = appellation;
            Gender = genus;
            Noise = sound;
        }

        public string Name { get; private set; }

        public string Gender { get; private set; }

        public string Noise { get; private set; }

        public string Characteristic { get; private set; }

        public void ShowInfoBeasts()
        {
            Console.WriteLine("Имя - " + Name + " Пол - " + Gender + " Звук - " + Noise);
        }
    }
}
