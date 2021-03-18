using System;
using System.IO.Compression;

namespace Obblig_1
{
    public class Person
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

        public string getDescription()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();    
            
            // if (FirstName != null &&
            //     LastName != null &&
            //     BirthYear != 0 &&
            //     DeathYear != 0 &&
            //     Father != null &&
            //     Mother != null)
            //     return
            //         $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {Father.FirstName} (Id={Father.Id}) Mor: {Mother.FirstName} (Id={Mother.Id})";
            //
            var description = String.Empty;
            if (FirstName != null) builder.Append($"{FirstName} ") ;
            if (LastName != null) builder.Append($"{LastName} ");

            builder.Append($"(Id={Id})");

            builder.Append(' ');
            
            if (BirthYear != 0) builder.Append($"Født: {BirthYear} ");

            if (DeathYear != 0) builder.Append($"Død: {DeathYear} ");

            if (Father != null)
            {
                builder.Append("Far: ");
                if (Father.FirstName != null) builder.Append($"{Father.FirstName} ");
                if (Father.Id != 0) builder.Append($"(Id={Father.Id}) ");
            }
            
            if (Mother != null)
            {
                builder.Append("Mor: ");
                if (Mother.FirstName != null) builder.Append($"{Mother.FirstName} ");
                if (Mother.Id != 0) builder.Append($"(Id={Mother.Id})");
            }
            
            return builder.ToString().Trim();
        }
        public static bool isEmpty(string s)

        {
            return string.IsNullOrEmpty(s);
        }
    }   
    
}