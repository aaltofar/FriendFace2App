

using FriendFace2;



var activeUser = Messages.Register();
List<User> AllUsers = new List<User>();

var user1 = new User()
{
    Age = 47,
    FirstName = "Tore",
    LastName = "PaaSporet",
};
var user2 = new User()
{

    Age = 88,
    FirstName = "Kjell",
    LastName = "Elvis",
};
AllUsers.Add(user1);
AllUsers.Add(user2);

Messages.WelcomeMsg(activeUser);

while (true)
{
    switch (Messages.ListCommands().ToLower())
    {

        case "l":
            Console.WriteLine();
            for (int i = 0; i < AllUsers.Count; i++)
            {
                Console.WriteLine($"[{i}]" + AllUsers[i].FullName());
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
                    while (cmdNum > AllUsers.Count || cmdNum < 0)
                    {
                        Console.WriteLine("Invalid command, please input a corresponding number, or type [exit]");
                        cmd = Console.ReadLine();
                        isNum = int.TryParse(cmd, out cmdNum);
                    }
                } while (!isNum);
                activeUser.AddFriend(AllUsers[cmdNum]);
                break;
            }
            break;

        case "f":
            activeUser.ViewAllFriends(activeUser);
            Console.WriteLine();
            Console.WriteLine("To select a friend, type in the number next to their name, or type [exit]");
            Console.Write("Command: ");
            cmd = Console.ReadLine();
            isNum = int.TryParse(cmd, out cmdNum);
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