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

        public string HandleCommand(string command)
        {
            var commands = command.Split(' ');
            
            switch (commands[0])
            {
                case "help":
                    return WelcomeMessage;
                case "liste":
                    string content = String.Empty;
                    
                    for (int i = 0; i < _people.Count; i++)
                    {
                        content += _people[i].getDescription() + "\n";
                    }

                    return content;
                case "vis":
                    string data = String.Empty;
                    bool hack = false;
                    for (int i = 0; i < _people.Count; i++)
                    {
                        if (_people[i].Id == Int32.Parse(commands[1]))
                        {
                            data += _people[i].getDescription();
                            data += "\n";
                            // bool hack = false;
                            for (int j = 0; j < _people.Count; j++)
                            {
                                // if (_people[i].Father.FirstName == _people[j].FirstName + ' ' + _people[j].LastName)
                                // {
                                //     
                                // }
                                if (_people[j].Father != null)
                                {
                                   
                                    if (_people[j].Father.FirstName == _people[i].FirstName)
                                    {
                                        if(hack == false) data += "  Barn:\n"; hack = true;
                                        data += "    ";
                                        if (_people[j].LastName != null)
                                        {
                                            data += $"{_people[j].FirstName} {_people[j].LastName} Født: {_people[j].BirthYear}\n";
                                        }
                                        else
                                        {
                                            data += $"{_people[j].FirstName} (Id={_people[j].Id}) Født: {_people[j].BirthYear}\n";
                                        }
                                    }
                                }
                            }
                                
                        }
                        
                    }

                    return data;
                default:
                    return "Dette er ikke en kommando";
            }
        }
    }
}