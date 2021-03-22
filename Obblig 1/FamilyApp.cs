using System;
using System.Collections.Generic;
using System.Linq;

namespace Obblig_1
{
    public class FamilyApp
    {
        private List<Person> _people;
        
        public FamilyApp(params Person[] people)
        {
            _people = new List<Person>(people);
        }

        public string WelcomeMessage
        {
           get
           {
               return @$"
hjelp => viser en hjelpetekst som forklarer alle kommandoene
liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)
            ";
           }
        }

        public string CommandPrompt
        {
            get
            {
                return ">";
            }
        }

        private string ListPeople()
        {
            var people = String.Empty;
            
            foreach (var person in _people)
            {
                people += person.getDescription() + "\n";
            }
            
            return people;
        }

        private string childDescription(Person child)
        {
            return $"{child.FirstName} {child.LastName}(Id={child.Id}) Født: {child.BirthYear}\n";
        }
        
        private string GetPerson(int personId)
        {
            string data = String.Empty;
            var children = new List<Person>();
            foreach (var person in _people)
            {
                if (person.Id == personId)
                {
                    data += person.getDescription();
                    data += "\n";
                    foreach (var child in _people)
                    {
                        if (child.Father != null)
                        {
                            if (child.Father.FirstName == person.FirstName)
                            {
                                children.Add(child);
                                
                                // if(hack == false) data += "  Barn:\n"; hack = true;
                                // data += "    ";
                                // if (child.LastName != null)
                                // {
                                //     data += $"{child.FirstName} {child.LastName} Født: {child.BirthYear}\n";
                                // }
                                // else
                                // {
                                //     data += $"{child.FirstName} (Id={child.Id}) Født: {child.BirthYear}\n";
                                // }
                            }
                        }
                        if(child.Mother != null) 
                        { 
                            if (child.Mother.FirstName == person.FirstName)
                            {
                                children.Add(child);
                                
                                // if(hack == false) data += "  Barn:\n"; hack = true;
                                // data += "    ";
                                // if (child.LastName != null)
                                // {
                                //     data += $"{child.FirstName} {child.LastName} Født: {child.BirthYear}\n";
                                // }
                                // else
                                // {
                                //     data += $"{child.FirstName} (Id={child.Id}) Født: {child.BirthYear}\n";
                                // }
                                
                            }
                        }
                    }
                        
                }
            }

            if (children.Count != 0)
            {
                data += "  Barn:\n";
                foreach (var child in children)
                {
                    data += "    ";
                    data += childDescription(child);
                }
                
            }

            return data;
        }
        
        public string HandleCommand(string command)
        {
            var commands = command.Split(' ');
            int personId = 0;

            
            switch (commands[0])
            {
                case "help":
                    return WelcomeMessage;
                case "liste":
                    return ListPeople(); 
                case "vis":
                    if (!String.IsNullOrEmpty(commands[1])) personId = Convert.ToInt32(commands[1]);
                    return GetPerson(personId);
                case "exit":
                    Environment.Exit(0);
                    return "exit";
                default:
                    return "Dette er ikke en kommando";
            }
        }
    }
}