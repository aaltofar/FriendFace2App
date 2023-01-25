

using FriendFace2;

var service = new UserService();
service.InitUsers(10);
var activeUser = Messages.Register();


Messages.WelcomeMsg(activeUser);

while (true)
{
    while (Messages.ListCommands().ToLower() == "l")
    {
        Console.WriteLine();
        for (int i = 0; i < service.AllUsers.Count; i++)
        {
            Console.WriteLine($"[{i}]" + service.AllUsers[i].FullName());
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("To add any of these to your friend list, type in the number next to their name, or type [exit]");
        Console.Write("Command: ");
        var cmd = Console.ReadLine();
        bool isNum = int.TryParse(cmd, out int cmdNum);
        while (cmd.ToLower() != "exit")
        {
            do
            {
                while (cmdNum > service.AllUsers.Count || cmdNum < 0)
                {
                    Console.WriteLine("Invalid command, please input a corresponding number, or type [exit]");
                    cmd = Console.ReadLine();
                    isNum = int.TryParse(cmd, out cmdNum);
                }
            } while (!isNum);
            activeUser.AddFriend(service.AllUsers[cmdNum]);
            break;
        }
        break;
    }

    while (Messages.ListCommands().ToLower() == "f")
    {
        activeUser.ViewAllFriends(activeUser);
        Console.WriteLine();
        Console.WriteLine("To select a friend, type in the number next to their name, or type [exit]");
        Console.Write("Command: ");
        var cmd = Console.ReadLine();
        bool isNum = int.TryParse(cmd, out int cmdNum);
        while (cmd.ToLower() != "exit")
        {
            do
            {
                while (cmdNum > activeUser.FriendList.Count || cmdNum < 0)
                {
                    Console.WriteLine("Invalid command, please input a corresponding number, or type [exit]");
                    cmd = Console.ReadLine();
                    isNum = int.TryParse(cmd, out cmdNum);
                }
            } while (!isNum);
            Console.Clear();
            Messages.SelectFriend(activeUser, cmdNum);

            cmd = Console.ReadLine();
            if (cmd.ToLower() == "e") break;
            if (cmd.ToLower() == "v")
            {
                activeUser.ViewFriend(activeUser, cmdNum);
            }

            if (cmd.ToLower() == "r")
            {
                activeUser.RemoveFriend(activeUser.FriendList[cmdNum]);
            }

            break;
        }
        break;
    }
}
