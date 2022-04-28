Menu();

static void Menu()
{
    int mainChoice;
    int subChoice;
    char option;
    BooksManage books = new BooksManage();
    MembersManage members = new MembersManage();
    LoanCardsManage loanCards = new LoanCardsManage();

    do
    {
        mainChoice = MainMenu();
        switch (mainChoice)
        {
            case 1:
                subChoice = SubMenu_Book();
                switch (subChoice)
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
                                Console.WriteLine("Them moi thanh cong!");
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
                break;

            case 2:
                subChoice = SubMenu_Member();
                switch (subChoice)
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
                                Console.WriteLine("Them moi thanh cong!");
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
                break;

            case 3:
                subChoice = SubMenu_LoanCard();
                switch (subChoice)
                {
                    case 1:
                        while (true)
                        {
                            if (loanCards.Add())
                            {
                                Console.WriteLine("Them moi thanh cong!");
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
                break;

        }
    } while (mainChoice != 4);
}

static int MainMenu()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("---Chao mung den voi thu vien---");
    Console.WriteLine("================================");
    Console.WriteLine("1. Quan ly sach");
    Console.WriteLine("2. Quan ly the thu vien");
    Console.WriteLine("3. Quan ly the muon sach");
    Console.WriteLine("4. Thoat");
    Console.WriteLine("================================");
    int choice = 0;
    do
    {
        Console.Write("#chon: ");
        int.TryParse(Console.ReadLine(), out choice);
    } while (choice < 1 || choice > 4);
    return choice;
}

static int SubMenu_Book()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("Quan ly sach");
    Console.WriteLine("================================");
    Console.WriteLine("1. Xem danh sach sach");
    Console.WriteLine("2. Cap nhat thong tin sach");
    Console.WriteLine("3. Them moi mot quyen sach");
    Console.WriteLine("4. Tro ve menu chinh");
    Console.WriteLine("================================");
    int choice = 0;
    do
    {
        Console.Write("#chon: ");
        int.TryParse(Console.ReadLine(), out choice);
    } while (choice < 1 || choice > 4);
    return choice;
}

static int SubMenu_Member()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("Quan ly the thu vien");
    Console.WriteLine("================================");
    Console.WriteLine("1. Xem danh sach the thu vien");
    Console.WriteLine("2. Cap nhat thong tin the");
    Console.WriteLine("3. Them moi mot the");
    Console.WriteLine("4. Tro ve menu chinh");
    Console.WriteLine("================================");
    int choice = 0;
    do
    {
        Console.Write("#chon: ");
        int.TryParse(Console.ReadLine(), out choice);
    } while (choice < 1 || choice > 4);
    return choice;
}

static int SubMenu_LoanCard()
{
    Console.Clear();
    Console.WriteLine("================================");
    Console.WriteLine("Quan ly the muon sach");
    Console.WriteLine("================================");
    Console.WriteLine("1. Tao moi the muon sach");
    Console.WriteLine("2. Hien thi tat ca the muon sach");
    Console.WriteLine("3. Tro ve menu chinh");
    Console.WriteLine("================================");
    int choice = 0;
    do
    {
        Console.Write("#chon: ");
        int.TryParse(Console.ReadLine(), out choice);
    } while (choice < 1 || choice > 3);
    return choice;
}

static void WaitForButton(string msg)
{
    Console.Write($"{msg}");
    Console.ReadKey();
}