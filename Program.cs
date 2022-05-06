BooksManage books = new BooksManage();
MembersManage members = new MembersManage();
LoanCardsManage loanCards = new LoanCardsManage();
Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;
char option;

MainMenu();

void MainMenu()
{

    string[] menu = { "Quan ly sach", "Quan ly the thu vien", "Quan ly the muon sach", "Thoat" };
    string name = "---Chao mung den voi thu vien---";
    int choice;
    do
    {
        choice = Menu(menu, name);
        switch (choice)
        {
            case 1:
                MenuBook();
                break;

            case 2:
                MenuMember();
                break;

            case 3:
                MenuLoanCard();
                break;
        }
    } while (choice != menu.Length);
}

void TextColor(ConsoleColor color, string str)
{
    Console.ForegroundColor = color;
    Console.WriteLine(str);
    Console.ResetColor();
}

int Menu(string[] menu, string name)
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine(name);
    Console.WriteLine("================================");
    for (int i = 0; i < menu.Length; i++)
    {
        Console.WriteLine($"{i + 1}. {menu[i]}");
    }
    Console.WriteLine("================================");
    int choice;
    do
    {
        Console.Write("#chon: ");
        int.TryParse(Console.ReadLine(), out choice);
        if (choice < 1 || choice > menu.Length)
        {
            TextColor(ConsoleColor.Red, " *Input invalid!");
        }
    } while (choice < 1 || choice > menu.Length);
    return choice;
}

void MenuBook()
{
    Console.Clear();
    string[] menu = { "Xem danh sach sach", "Cap nhat thong tin sach", "Them moi mot quyen sach", "Tro ve menu chinh" };
    string name = "Quan ly sach";
    int choice;

    do
    {
        choice = Menu(menu, name);
        switch (choice)
        {
            case 1:
                if (books.NumberOfBooks() > 0)
                {
                    books.Display();
                }
                else
                {
                    Console.WriteLine("Danh sach trong!");
                }
                break;

            case 2:
                if (books.NumberOfBooks() > 0)
                {
                    while (true)
                    {
                        string idBook;
                        Console.Write("Nhap ma sach: ");
                        idBook = Console.ReadLine() ?? "";
                        if (books.Update(idBook))
                        {
                            do
                            {
                                Console.Write("Ban co muon cap nhat thong tin?(Y/N): ");
                                option = Convert.ToChar(Console.ReadLine() ?? "");
                                if (option == 'y' || option == 'Y')
                                {
                                    books.CheckUpdate(true);
                                    Console.WriteLine("Thong tin da duoc cap nhat!");
                                    break;
                                }
                                else if (option == 'n' || option == 'N')
                                {
                                    books.CheckUpdate(false);
                                    break;
                                }
                            } while (option == 'y' || option == 'Y' || option == 'n' || option == 'N');
                        }
                        Console.Write("Ban muon tiep tuc?(Y/N): ");
                        option = Convert.ToChar(Console.ReadLine() ?? "");
                        if (option == 'n' || option == 'N')
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Danh sach trong!");
                }
                break;

            case 3:
                while (true)
                {
                    if (books.Add())
                    {
                        TextColor(ConsoleColor.Green, "Them moi thanh cong!");
                    }
                    Console.Write("Ban muon tiep tuc?(Y/N): ");
                    option = Convert.ToChar(Console.ReadLine() ?? "");
                    if (option == 'n' || option == 'N')
                    {
                        break;
                    }
                }
                break;
        }
        WaitForButton("Nhap phim bat ky de quay lai menu chinh...");
    } while (choice != menu.Length);
}

void MenuMember()
{
    Console.Clear();
    string[] menu = { "Xem danh sach the thu vien", "Cap nhat thong tin the", "Them moi mot the", "Tro ve menu chinh" };
    string name = "Quan ly the thu vien";
    int choice;

    do
    {
        choice = Menu(menu, name);
        switch (choice)
        {
            case 1:
                if (members.NumberOfMembers() > 0)
                {
                    members.Display();
                }
                else
                {
                    Console.WriteLine("Danh sach trong!");
                }
                break;

            case 2:
                if (members.NumberOfMembers() > 0)
                {
                    while (true)
                    {
                        string idMember;
                        Console.Write("Nhap ma the: ");
                        idMember = Console.ReadLine() ?? "";
                        if (members.Update(idMember))
                        {
                            do
                            {
                                Console.Write("Ban co muon cap nhat thong tin?(Y/N): ");
                                option = Convert.ToChar(Console.ReadLine() ?? "");
                                if (option == 'y' || option == 'Y')
                                {
                                    members.CheckUpdate(true);
                                    Console.WriteLine("Thong tin da duoc cap nhat!");
                                    break;
                                }
                                else if (option == 'n' || option == 'N')
                                {
                                    members.CheckUpdate(false);
                                    break;
                                }
                            } while (option == 'y' || option == 'Y' || option == 'n' || option == 'N');
                        }
                        Console.Write("Ban muon tiep tuc?(Y/N): ");
                        option = Convert.ToChar(Console.ReadLine() ?? "");
                        if (option == 'n' || option == 'N')
                        {
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Danh sach trong!");
                }
                break;

            case 3:
                while (true)
                {
                    if (members.Add())
                    {
                        TextColor(ConsoleColor.Green, "Them moi thanh cong!");
                    }
                    Console.Write("Ban muon tiep tuc?(Y/N): ");
                    option = Convert.ToChar(Console.ReadLine() ?? "");
                    if (option == 'n' || option == 'N')
                    {
                        break;
                    }
                }
                break;
        }
        WaitForButton("Nhap phim bat ky de quay lai menu chinh...");
    } while (choice != menu.Length);
}

void MenuLoanCard()
{
    Console.Clear();
    string[] menu = { "Tao moi the muon sach", "Hien thi tat ca the muon sach", "Tro ve menu chinh" };
    string name = "Quan ly the muon sach";
    int choice;

    do
    {
        choice = Menu(menu, name);
        switch (choice)
        {
            case 1:
                while (true)
                {
                    if (loanCards.Add())
                    {
                        TextColor(ConsoleColor.Green, "Them moi thanh cong!");
                    }
                    else
                    {
                        break;
                    }
                    Console.Write("Ban muon tiep tuc?(Y/N): ");
                    option = Convert.ToChar(Console.ReadLine() ?? "");
                    if (option == 'n' || option == 'N')
                    {
                        break;
                    }
                }
                break;

            case 2:
                if (loanCards.NumberOfLoanCards() > 0)
                {
                    loanCards.Display();
                }
                else
                {
                    Console.WriteLine("Danh sach trong!");
                }
                break;
        }
        WaitForButton("Nhap phim bat ky de quay lai menu chinh...");
    } while (choice != menu.Length);
}

void WaitForButton(string msg)
{
    Console.Write($"{msg}");
    Console.ReadKey();
    Console.WriteLine();
}