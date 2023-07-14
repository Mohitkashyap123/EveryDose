using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EveryDose.Model
{
    public class Profile
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";


        public string DateOfBirth { get; set; }
    }
}
