using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace2;

internal class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<User> FriendList { get; set; }

    public User()
    {
        FriendList = new List<User>();
    }

    public void AddFriend(User FriendToAdd)
    {
        Console.Clear();
        if (!FriendList.Contains(FriendToAdd))
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            FriendList.Add(FriendToAdd);
            Console.WriteLine();
            Console.WriteLine($"You added {FriendToAdd.FullName()} as a friend");
            Console.WriteLine();
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You and {FriendToAdd.FullName()} are already friends.");
            Console.ResetColor();
        }
        Console.WriteLine();
    }

    public void RemoveFriend(User FriendToRemove)
    {
        if (!FriendList.Contains(FriendToRemove))
        {
            Console.WriteLine($"You and {FriendToRemove.FullName()} are not friends");
        }
        FriendList.Remove(FriendToRemove);
        Console.WriteLine();
        Console.WriteLine($"You removed {FriendToRemove.FullName()} as a friend");
    }

    public void ViewAllFriends(User ActiveUser)
    {
        Console.Clear();
        Console.WriteLine("All your friends: ");
        Console.WriteLine();
        for (int i = 0; i < FriendList.Count; i++)
        {
            Console.WriteLine($"[{i}] {FriendList[i].FullName()}");
            Console.WriteLine();
        }
    }

    public void ViewFriend(User ActiveUser, int friendIndex)
    {
        var friend = ActiveUser.FriendList[friendIndex];
        Console.WriteLine();
        Console.WriteLine("Name: " + friend.FullName());
        Console.WriteLine("Age: " + friend.Age);
        Console.WriteLine();
    }

    public string FullName()
    {
        string result = FirstName + " " + LastName;
        return result;
    }
}

