using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2Borovik.Models
{
    internal class Person
    {
        private DateTime birthday;
        private string chineseSign;
        private string sunSign;
        private bool isAdult;
        private bool isBirthday;
        public Person(string firstName,string lastName,string? email, DateTime birthday)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            Birthday = birthday;
        }
        public Person(string firstName, string lastName, string email): this(firstName, lastName, email, DateTime.Today)
        {
        }
        public Person(string firstName, string lastName, DateTime birthday):this(firstName, lastName, null, birthday)
        {
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public DateTime Birthday
        {
            get => birthday;
            set => birthday = value;
        }
        public bool IsAdult
        {
            get => isAdult;
        }
        public bool IsBirthday
        {
            get => isBirthday;
        }
        public string ChineseSign
        {
            get => chineseSign;
            
        }
        public string SunSign
        {
            get => sunSign;
        }
        public int Age()
        {
            
                if (DateTime.Today.Year == Birthday.Year && (DateTime.Today.Month < Birthday.Month ||
                    (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day < Birthday.Day)))
                    return -1;
                if (DateTime.Today.Month < Birthday.Month || (DateTime.Today.Month == Birthday.Month && DateTime.Today.Day < Birthday.Day))
                {
                    return DateTime.Today.Year - Birthday.Year - 1;
                }
                return DateTime.Today.Year - Birthday.Year;
        }
        public void CalculateSunSign()
        {
            if (Birthday.Day >= 21 && Birthday.Month == 1 ||
                Birthday.Day <= 19 && Birthday.Month == 2)
            {
                sunSign = SunSigns.Aquarius.ToString();
                return;
            }
            if (Birthday.Day >= 20 && Birthday.Month == 2 ||
               Birthday.Day <= 20 && Birthday.Month == 3)
            {
                sunSign = SunSigns.Pisces.ToString();
                return;
            }
            if (Birthday.Day >= 21 && Birthday.Month == 3 ||
               Birthday.Day <= 20 && Birthday.Month == 4)
            {
                sunSign = SunSigns.Aries.ToString();
                return;
            }
            if (Birthday.Day >= 21 && Birthday.Month == 4 ||
               Birthday.Day <= 20 && Birthday.Month == 5)
            {
                sunSign = SunSigns.Taurus.ToString();
                return;
            }
            if (Birthday.Day >= 21 && Birthday.Month == 5 ||
               Birthday.Day <= 21 && Birthday.Month == 6)
            {
                sunSign = SunSigns.Gemini.ToString();
                return;
            }
            if (Birthday.Day >= 22 && Birthday.Month == 6 ||
               Birthday.Day <= 22 && Birthday.Month == 7)
            {
                sunSign = SunSigns.Cancer.ToString();
                return;
            }
            if (Birthday.Day >= 23 && Birthday.Month == 7 ||
               Birthday.Day <= 22 && Birthday.Month == 8)
            {
                sunSign = SunSigns.Leo.ToString();
                return;
            }
            if (Birthday.Day >= 23 && Birthday.Month == 8 ||
               Birthday.Day <= 22 && Birthday.Month == 9)
            { 
                sunSign = SunSigns.Virgo.ToString();
                return;
            }
            if (Birthday.Day >= 23 && Birthday.Month == 9 ||
               Birthday.Day <= 22 && Birthday.Month == 10)
            { 
                sunSign = SunSigns.Libra.ToString();
                return;
            }
            if (Birthday.Day >= 23 && Birthday.Month == 10 ||
               Birthday.Day <= 22 && Birthday.Month == 11)
            {
                sunSign = SunSigns.Scorpio.ToString();
                return;
            }
            if (Birthday.Day >= 23 && Birthday.Month == 11 ||
               Birthday.Day <= 21 && Birthday.Month == 12)
            {
                sunSign = SunSigns.Saggitaurus.ToString();
                return;
            }

            sunSign = SunSigns.Capricorn.ToString();

        }
        public void CalculateChineseSign()
        {
            int tmp = Birthday.Year % 12;
            switch (tmp)
            {
                case 0:
                    chineseSign = ChineseSigns.Monkey.ToString();
                    break;
                case 1:
                    chineseSign = ChineseSigns.Roster.ToString();
                    break;
                case 2:
                    chineseSign = ChineseSigns.Dog.ToString();
                    break;
                case 3:
                    chineseSign = ChineseSigns.Pig.ToString();
                    break;
                case 4:
                    chineseSign = ChineseSigns.Rat.ToString();
                    break;
                case 5:
                    chineseSign = ChineseSigns.Ox.ToString();
                    break;
                case 6:
                    chineseSign = ChineseSigns.Tiger.ToString();
                    break;
                case 7:
                    chineseSign = ChineseSigns.Rabbit.ToString();
                    break;
                case 8:
                    chineseSign = ChineseSigns.Dragon.ToString();
                    break;
                case 9:
                    chineseSign = ChineseSigns.Snake.ToString();
                    break;
                case 10:
                    chineseSign = ChineseSigns.Horse.ToString();
                    break;
                default:
                    chineseSign = ChineseSigns.Goat.ToString();
                    break;
            }
        }
        public void CalculateIsAdult()
        {
            isAdult = Age() >= 18;
        }
        public void CalculateIsBirthday()
        {
            isBirthday = Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;
        }
    }

    enum SunSigns
    {
        Aries,
        Taurus,
        Gemini,
        Cancer,
        Leo,
        Virgo,
        Libra,
        Scorpio,
        Saggitaurus,
        Capricorn,
        Aquarius,
        Pisces,
    }
    enum ChineseSigns
    {
        Monkey,
        Roster,
        Dog,
        Pig,
        Rat,
        Ox,
        Tiger,
        Rabbit,
        Dragon,
        Snake,
        Horse,
        Goat,
    }
}

