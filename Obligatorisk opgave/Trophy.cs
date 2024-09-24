namespace Obligatorisk_opgave
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Competition { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Competition: {Competition}, Year: {Year}";
        }

        public void ValidateCompetition()
        {
            if (Competition == null) 
                    throw new ArgumentNullException("Must assign"); 
            else if (Competition.Length < 3)
                throw new ArgumentOutOfRangeException("Too short, min 3 characters");
        }

        public void ValidateYear()
        {
            if (Year < 1970 || Year > 2024)
                throw new ArgumentOutOfRangeException("Trophies can't be from the furture or older than 1970");
        }
        public void Validate()
        {
            ValidateCompetition();
            ValidateYear();
        }

        public override bool Equals(object? obj)
        {
            Trophy other = obj as Trophy;
            if (obj == null) return false;

            return other.Id == Id && other.Year == Year && other.Competition == Competition;
        }
    }
}
