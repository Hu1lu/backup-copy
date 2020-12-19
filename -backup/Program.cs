using System;
using static System.Console;
using System.Collections.Generic;

namespace Disks
{
    abstract class Storage
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public double Free { get; set; }
        protected double Speed { get; set; }
        public Storage(string name, string model)
        {
            Name = name; Model = model;
        }
        protected abstract void Memory();
        public abstract void Copy(double value, string name);
        protected abstract void FreeMemory();
        public abstract void GetInfo();
        protected void Line()
        {
            WriteLine("============================================\n");
        }
        public abstract override bool Equals(Object obj);

        public abstract override int GetHashCode();
    }

    class Flash : Storage
    {
        public Flash(string name, string model) : base(name, model)
        {
            Free = 549755813888;// бит объём
            Speed = 42949672960;// бит скорость
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Flash p = (Flash)obj;
                return (Name == p.Name) && (Speed == p.Speed) && (Model == p.Model) && (Free == p.Free);
            }
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Speed, Model, Free).GetHashCode();
        }
        protected override void Memory()
        {
            WriteLine("Общий объём: 64 Гб");
        }
        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "байт":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
            }
            Write($"\t\tFlash-память\nСкопировано удачно!\nВремя: ");
            if (value / Speed < 60)
                WriteLine(value / Speed + " сек");
            else if (value / Speed < 3600) WriteLine(value / Speed / 60 + " мин");
            else WriteLine(value / Speed / 3600 + " часов");
            FreeMemory();
            Line();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("\nНазвание устройства: " + Name);
            WriteLine("Модель устройства: " + Model);
            Memory();
            FreeMemory();
            WriteLine("Скорость интерфейса: 5 Гб/сек");
            Line();
        }
    }
    abstract class DVD : Storage
    {
        public DVD(string name, string model) : base(name, model)
        {
            Speed = 176947200;
        }
    }
    class SingleSidedDVD : DVD
    {
        public SingleSidedDVD(string name, string model) : base(name, model)
        {
            Free = 40372692582.4;
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                SingleSidedDVD p = (SingleSidedDVD)obj;
                return (Name == p.Name) && (Speed == p.Speed) && (Model == p.Model) && (Free == p.Free);
            }
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Speed, Model, Free).GetHashCode();
        }
        protected override void Memory()
        {
            WriteLine("Общий объём: 4.7 Гб");
        }
        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "байт":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
            }
            Write($"\tОднослойный односторонний\nСкопировано удачно!\nВремя: ");
            if (value / Speed < 60)
                WriteLine(value / Speed + " сек");
            else if (value / Speed < 3600) WriteLine(value / Speed / 60 + " мин");
            else WriteLine(value / Speed / 3600 + " часов");
            FreeMemory();
            Line();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный односторонний");
            Memory();
            FreeMemory();
            WriteLine("Скорость чтения/записи: 21,09 Мб/сек");
            Line();
        }
    }
    class TwoWayDVD : DVD
    {
        public TwoWayDVD(string name, string model) : base(name, model)
        {
            Free = 77309411328;//77 309 411 328 бит
        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                TwoWayDVD p = (TwoWayDVD)obj;
                return (Name == p.Name) && (Speed == p.Speed) && (Model == p.Model) && (Free == p.Free);
            }
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Speed, Model, Free).GetHashCode();
        }
        protected override void Memory()
        {
            WriteLine("Общий объём: 9 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "байт":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
            }
            Write($"\tОднослойный двусторонний\nСкопировано удачно!\nВремя: ");
            if (value / Speed < 60)
                WriteLine(value / Speed + " сек");
            else if (value / Speed < 3600) WriteLine(value / Speed / 60 + " мин");
            else WriteLine(value / Speed / 3600 + " часов");
            FreeMemory();
            Line();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model + " однослойный двусторонний");
            Memory();
            FreeMemory();
            WriteLine("Скорость чтения/записи: 21,09 Мб/сек");
            Line();
        }
    }
    class HDD : Storage
    {
        private int number = 2;//кол-во разделов
        public HDD(string name, string model) : base(name, model)
        {
            Speed = 4026531840;// бит(скорость)
            Tom[] mass = new Tom[number];
            for (int i = 0; i < number; i++)
            {
                mass[i] = new Tom();
                Free += mass[i].Space;
            }
        }
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                HDD p = (HDD)obj;
                return (Name == p.Name) && (Speed == p.Speed) && (Model == p.Model) && (Free == p.Free);
            }
        }
        public override int GetHashCode()
        {
            return Tuple.Create(Name, Speed, Model, Free).GetHashCode();
        }
        protected override void Memory()
        {
            WriteLine("Общий объём: 128 Гб");
        }

        public override void Copy(double value, string name)
        {
            switch (name)
            {
                case "бит":
                    Free -= value;
                    break;
                case "б":
                    value *= 8;
                    Free -= value;
                    break;
                case "байт":
                    value *= 8;
                    Free -= value;
                    break;
                case "Кб":
                    value *= 8; value *= 1024;
                    Free -= value;
                    break;
                case "Мб":
                    value *= 8; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
                case "Гб":
                    value *= 8; value *= 1024; value *= 1024; value *= 1024;
                    Free -= value;
                    break;
            }
            Write($"\t\tСъёмный HDD\nСкопировано удачно!\nВремя: ");
            if (value / Speed < 60)
                WriteLine(value / Speed + " сек");
            else if (value / Speed < 3600) WriteLine(value / Speed / 60 + " мин");
            else WriteLine(value / Speed / 3600 + " часов");
            FreeMemory();
            Line();
        }

        protected override void FreeMemory()
        {
            Free /= 8;
            Free /= 1024;
            Free /= 1024;
            Free /= 1024;
            WriteLine($"Свободное место на диске: {Free} Гб");
            Free *= 1024;
            Free *= 1024;
            Free *= 1024;
            Free *= 8;
        }

        public override void GetInfo()
        {
            WriteLine("Название устройства: " + Name);
            WriteLine("Модель устройства: " + Model);
            WriteLine($"Кол-во томов: {number}");
            Tom[] mass = new Tom[number];
            for (int i = 0; i < number; i++)
            {
                mass[i] = new Tom();
                WriteLine($"Название {i + 1} тома: {mass[i].Name}" + (i + 1));
                WriteLine($"Размер {i + 1} тома: 64 Гб");
            }
            Memory();
            FreeMemory();
            WriteLine("Скорость интерфейса: 480 Мб/сек");
            Line();
        }
    }
    class Tom
    {
        public string Name { get; } = "Tom";
        public double Space { get; } = 549755813888;
    }

    class Program
    {
        static double ToBit(double value, string msg)
        {
            switch (msg)
            {
                case "б":
                    return value *= 8;
                case "байт":
                    return value *= 8;
                case "Кб":
                    value *= 1024; return value *= 8;
                case "Мб":
                    value *= 1024; value *= 1024; return value *= 8;
                case "Гб":
                    value *= 1024; value *= 1024; value *= 1024; return value *= 8;
            }
            return value;
        }

        static double FromBit(double value, string msg)
        {
            switch (msg)
            {
                case "б":
                    return value /= 8;
                case "байт":
                    return value /= 8;
                case "Кб":
                    value /= 1024; return value /= 8;
                case "Мб":
                    value /= 1024; value /= 1024; return value /= 8;
                case "Гб":
                    value /= 1024; value /= 1024; value /= 1024; return value /= 8;
            }
            return value;
        }

        static void Main(string[] args)
        {
            List<Storage> storages = new List<Storage>();
            storages.Add(new Flash("Flash", "A114mb_0"));
            storages.Add(new SingleSidedDVD("DVD", "139669"));
            storages.Add(new TwoWayDVD("DVD+R DL", "13288_7734r"));
            storages.Add(new HDD("HDD", "130524"));
            int choice;
            while (true)
            {
                WriteLine("Выберите цифру");
                WriteLine("1.Просмотреть информацию о доступных устройствах");
                WriteLine("2.Скопировать данные на устройства");
                WriteLine("3.Выход из программы\n");
                choice = Convert.ToInt32(ReadLine());
                switch (choice)
                {
                    case 1:
                        foreach (Storage storage in storages)
                        { storage.GetInfo(); }
                        break;
                    case 2:
                        while (true)
                        {
                            WriteLine("Введите, какой объём информации будете копировать(например 102 Гб, 68 Мб, 10 Кб, 8 бит, 1024 б, 2 байта, 5,841 Гб)");
                            var data = ReadLine();
                            WriteLine("\n============================================");
                            string[] mass = data.Split(' ');
                            if (mass[1] != "Гб" && mass[1] != "Мб" && mass[1] != "Кб" && mass[1] != "б" && mass[1] != "байт" && mass[1] != "бит")
                            {
                                WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                            }
                            else
                            {
                                if (mass.Length == 2)
                                {
                                    try
                                    {
                                        double number = Convert.ToDouble(mass[0]);
                                        int flash = 1, sDVD = 1, twoDVD = 1, hdd = 1;
                                        Flash a = new Flash("Flash", "A114mb_0");
                                        SingleSidedDVD b = new SingleSidedDVD("DVD", "139669");
                                        TwoWayDVD c = new TwoWayDVD("DVD+R DL", "13288_7734r");
                                        for (int i = 0; i < storages.Count; i++)
                                        {
                                            if (ToBit(number, mass[1]) > storages[i].Free)
                                            {
                                                if (storages[i].Equals(a))
                                                {
                                                    storages.Insert(i + 1, new Flash($"Flash{i}", $"A114mb_0{i}"));
                                                    a.Name = $"Flash{i}"; a.Model = $"A114mb_0{i}"; flash++;
                                                }
                                                else if (storages[i].Equals(b))
                                                {
                                                    storages.Insert(i + 1, new SingleSidedDVD($"DVD{i}", $"139669{i}"));
                                                    b.Name = $"DVD{i}"; b.Model = $"139669{i}"; sDVD++;
                                                }
                                                else if (storages[i].Equals(c))
                                                {
                                                    storages.Insert(i + 1, new TwoWayDVD($"DVD+R DL{i}", $"13288_7734r{i}"));
                                                    c.Name = $"DVD+R DL{i}"; c.Model = $"48288_8254a{i}";
                                                    twoDVD++;
                                                }
                                                else
                                                {
                                                    storages.Insert(i + 1, new HDD($"HDD{i}", $"130524{i}"));
                                                    c.Name = $"HDD{i}"; c.Model = $"130524{i}";
                                                    hdd++;
                                                }

                                                number -= FromBit(storages[i].Free, mass[1]);
                                                storages[i].Copy(FromBit(storages[i].Free, "Гб"), "Гб");
                                            }
                                            else
                                            {
                                                storages[i].Copy(number, mass[1]);
                                                number = Convert.ToDouble(mass[0]);
                                            }
                                        }
                                        WriteLine("\n============================================");
                                        WriteLine($"Для того чтобы скопировать {data} потребовалось:");
                                        WriteLine($"{flash} Flash-памяти объёмом 64 Гб");
                                        WriteLine($"{sDVD} однослойных односторонних DVD-дисков объёмом 4,7 Гб");
                                        WriteLine($"{twoDVD} однослойных двусторонних DVD-дисков объёмом 9 Гб");
                                        WriteLine($"{hdd} съёмных HDD объёмом 128 Гб");
                                        WriteLine("============================================\n");
                                        break;
                                    }
                                    catch (Exception e)
                                    {
                                        WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                                        WriteLine(e.Message);
                                    }
                                }
                                else WriteLine("Извините, неверно указан тип данных\nОбратите внимание на пример ввода единиц измерения");
                            }
                        }
                        break;
                    case 3:
                        return;
                    default:
                        WriteLine("Извините, такой команды нет");
                        break;
                }
            }
        }
    }
}
