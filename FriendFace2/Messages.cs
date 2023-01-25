using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace FriendFace2;

internal class Messages
{
    public static int lines;
    public static void WelcomeMsg(User user)
    {
        Console.Clear();
        Console.WriteLine($@"
 ________  _______   ______  ________  __    __  _______   ________  ______    ______   ________ 
/        |/       \ /      |/        |/  \  /  |/       \ /        |/      \  /      \ /        |
$$$$$$$$/ $$$$$$$  |$$$$$$/ $$$$$$$$/ $$  \ $$ |$$$$$$$  |$$$$$$$$//$$$$$$  |/$$$$$$  |$$$$$$$$/ 
$$ |__    $$ |__$$ |  $$ |  $$ |__    $$$  \$$ |$$ |  $$ |$$ |__   $$ |__$$ |$$ |  $$/ $$ |__    
$$    |   $$    $$<   $$ |  $$    |   $$$$  $$ |$$ |  $$ |$$    |  $$    $$ |$$ |      $$    |   
$$$$$/    $$$$$$$  |  $$ |  $$$$$/    $$ $$ $$ |$$ |  $$ |$$$$$/   $$$$$$$$ |$$ |   __ $$$$$/    
$$ |      $$ |  $$ | _$$ |_ $$ |_____ $$ |$$$$ |$$ |__$$ |$$ |     $$ |  $$ |$$ \__/  |$$ |_____ 
$$ |      $$ |  $$ |/ $$   |$$       |$$ | $$$ |$$    $$/ $$ |     $$ |  $$ |$$    $$/ $$       |
$$/       $$/   $$/ $$$$$$/ $$$$$$$$/ $$/   $$/ $$$$$$$/  $$/      $$/   $$/  $$$$$$/  $$$$$$$$/                                                                                             
");
        Console.WriteLine($"Welcome to FriendFace {user.FirstName}!");
        Console.WriteLine();

    }

    public static string ListCommands()
    {
        Console.WriteLine();
        Console.WriteLine("Here are your options: ");
        Console.WriteLine(@"
- [L] to list all users
- [F] to show your friends
");
        Console.Write("Command: ");
        string cmd = Console.ReadLine();
        return cmd;
    }

    public static User Register()
    {
        ToMid("REGISTER");
        lines += 2;

        ToMid("First name: ");
        var firstName = Console.ReadLine();
        lines += 2;

        ToMid("Last name: ");
        var lastName = Console.ReadLine();

        Console.WriteLine();
        lines += 2;

        ToMid("Age: ");
        var ageTxt = Console.ReadLine();
        bool isNum = int.TryParse(ageTxt, out int age);

        do
        {
            while (age is <= 0 or > 120)
            {
                lines += 2;
                ToMid("Invalid age, please input a number between 1 and 120");
                lines++;
                ToMid("Age: ");
                lines++;
                ageTxt = Console.ReadLine();
                isNum = int.TryParse(ageTxt, out age);
            }
        } while (!isNum);


        var activeUser = new User()
        {
            Age = age,
            FirstName = firstName,
            LastName = lastName
        };
        return activeUser;
    }

    private static void ToMid(string txt)
    {
        Console.CursorLeft = (Console.WindowWidth / 2) - (txt.Length / 2);
        Console.CursorTop = (int)((Console.WindowHeight * 0.25) + Messages.lines);
        Console.Write(txt);
    }

    public static void SelectFriend(User user, int result)
    {
        Console.WriteLine($"You selected {user.FriendList[result].FullName()}");
        Console.WriteLine();
        Console.WriteLine("You have three options: ");
        Console.WriteLine("-[V]iew this friends info");
        Console.WriteLine("-[R]emove this friend");
        Console.WriteLine("-[E]xit");
        Console.WriteLine();
        Console.Write("Command: ");
    }
}

