using System;

namespace Model.Entity
{
    public class Pupil
    {
        private float rating;
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Passport { get; set; }
        public DateTime Birthday { get; set; }
        public float Rating
        {
            get => rating;
            set
            {
                if (rating >= 0 && rating <= 10) rating = value;
            }
        }
        public Pupil()
        {
            
        }
        public Pupil(string surname, string name, string passport, DateTime birthday, float rating)
        {
            Surname = surname;
            Name = name;
            Passport = passport;
            Birthday = birthday;
            Rating = rating;
        }
        public override string ToString()
        {
            return "Surname: " + Surname +
                   ", Name: " + Name +
                   ", Passport: " + Passport +
                   ", Birthday: " + Birthday.ToString("dd:MM:yyyy") +
                   ", Rating: " + Rating.ToString("F1");
        }
    }
}