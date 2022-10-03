namespace SortingOlympiads.Logic
{
    public class Olympiad
    {
        public Log[] Logs { get; private set; }
        private int maxWins = 0;
        public Olympiad(Log[] logs)
        {
            Logs = logs;
        }

        public void GetTop(int years, params string[] commands)
        {


            foreach(var team in commands)
            {
                CheckTeam(team.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            }
        }
        private void CheckTeam(string[] persons)
        {
            var team = Logs.LastOrDefault(x => x.WinTeam == new Team(persons));
            if (team == null)
                return;

            if (maxWins < team.WinTeam.WinCount)
                maxWins = team.WinTeam.WinCount;


        }
    }
    public class Log
    {
        public Team WinTeam { get; private set; }
        public DateTime WinDate { get; private set; }
        public Log(Team winTeam, DateTime winDate)
        {
            WinTeam = winTeam;
            WinDate = winDate;
        }
    }

    public class Person
    {
        public string Name { get; private set; }
        public Person(string name)
        {
            Name = name;
        }
    }
    public class Team
    {
        public Person[] Persons { get; private set; }
        public int WinCount { get; private set; }
        public Team(int winCount, params string[] persons)
        {
            Persons = GetPersons(persons);
            WinCount = winCount;
        }
        public Team(params string[] persons)
        {
            Persons = GetPersons(persons);
        }
        private Person[] GetPersons(string[] persons_str)
        {
            Person[] persons = new Person[3];
            for(var i = 0; i < 3; i++)
                persons[i] = new Person(persons_str[i]);

            return persons;
        }
        public static bool operator ==(Team team1, Team team2)
        {
            foreach(var person in team1.Persons)
                if (!team2.Persons.Contains(person))
                    return false;

            return true;
        }
        public static bool operator !=(Team team1, Team team2)
        {
            foreach (var person in team1.Persons)
                if (!team2.Persons.Contains(person))
                    return true;

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }
    }
}