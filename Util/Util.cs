using System;
using System.Globalization;
using Model.Entity;

namespace Util
{
    public static class Util
    {
        public static Pupil GetPupil()
        {
            Pupil pupil = new Pupil();
            Console.Write("Enter surname: ");
            pupil.Surname = Console.ReadLine();
            Console.Write("Enter name: ");
            pupil.Name = Console.ReadLine();
            Console.Write("Enter passport: ");
            pupil.Passport = Console.ReadLine();
            Console.Write("Enter date (yyyy-mm-dd): ");
            pupil.Birthday = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter rating (0-10): ");
            pupil.Rating = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            return pupil;
        }
    }
}