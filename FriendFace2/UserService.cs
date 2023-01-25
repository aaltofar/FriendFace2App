using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace2;

internal class UserService
{
    Random r = new Random();
    List<string> _possibleFirstNames = new List<string>()
    {
        "Herman",
        "Tore",
        "Pål",
        "Jens",
        "Dag",
        "Sofie",
        "Maria",
        "Marius",
        "Simen",
        "Robert",
        "David",
        "Fredrik",
        "Thomas",
        "Siri",
        "Torhild",
        "Anne"
    };
    List<string> _possibleLastNames = new List<string>()
    {
        "Hansen",
        "Jensen",
        "Aalto",
        "Løvall",
        "Torp",
        "Karlsen",
        "Melsom",
        "Rasmussen",
        "Harring",
        "Andersen",
        "Ellingsen",
        "Lund"
    };
    public List<User> AllUsers = new List<User>();
    public void InitUsers(int userCount)
    {
        for (int i = 0; i < userCount; i++)
        {
            var newUser = new User()
            {
                Age = r.Next(1, 120),
                FirstName = _possibleFirstNames[r.Next(0, _possibleFirstNames.Count - 1)],
                LastName = _possibleLastNames[r.Next(0, _possibleLastNames.Count - 1)]
            };
            AllUsers.Add(newUser);
        }
    }
}

