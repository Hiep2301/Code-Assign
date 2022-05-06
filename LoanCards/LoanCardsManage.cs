public class LoanCardsManage
{
    private List<LoanCards> listLoanCards;
    private List<Members> listMembers;
    private List<Books> listBooks;

    public LoanCardsManage()
    {
        listLoanCards = new List<LoanCards>();
        listMembers = new List<Members>();
        listBooks = new List<Books>();
    }
    FileIO file = new FileIO();
    const string path = @"data\LoanCards.json";

    public bool Add()
    {
        Console.Clear();
        listLoanCards = file.ReadFile<LoanCards>(path);
        listMembers = file.ReadFile<Members>(@"data\Members.json");
        listBooks = file.ReadFile<Books>(@"data\Books.json");
        if (listLoanCards == null)
        {
            listLoanCards = new List<LoanCards>();
        }
        LoanCards loanCard = new LoanCards();

        Console.WriteLine("======================================================================");
        Console.WriteLine("Tao moi the muon sach");
        Console.WriteLine("======================================================================");
        Console.Write("Nhap ma phieu muon: ");
        loanCard.idLoanCard = Console.ReadLine() ?? "";
        while (true)
        {
            try
            {
                Console.Write("Nhap ma the thu vien: ");
                loanCard.idMember = Console.ReadLine() ?? "";
                if (CheckIdMember(loanCard.idMember))
                {
                    break;
                }
                else
                {
                    TextColor(ConsoleColor.Yellow, "Ma the thu vien khong ton tai, vui long nhap lai!");
                }
            }
            catch (System.Exception)
            {
                TextColor(ConsoleColor.Red, "Loi chua co ma the thu vien, vui long tao moi!");
                return false;
            }
        }
        Console.Write("Nhap ten sach muon: ");
        loanCard.nameBook = Console.ReadLine() ?? "";
        while (true)
        {
            try
            {
                Console.Write("Nhap ma sach: ");
                loanCard.idBook = Console.ReadLine() ?? "";
                if (CheckIdBook(loanCard.idBook))
                {
                    break;
                }
                else
                {
                    TextColor(ConsoleColor.Yellow, "Ma sach khong ton tai, vui long nhap lai!");
                }
            }
            catch (System.Exception)
            {
                TextColor(ConsoleColor.Red, "Loi chua co ma sach, vui long tao moi!");
                return false;
            }
        }
        Console.Write("Nhap ngay gio tao: ");
        loanCard.dateCreated = Console.ReadLine() ?? "";
        Console.Write("Nhap ngay gio huy: ");
        loanCard.dateCanceled = Console.ReadLine() ?? "";
        Console.WriteLine("======================================================================");

        listLoanCards.Add(loanCard);
        file.WriteFile<LoanCards>(listLoanCards, path);
        return true;
    }

    public void Display()
    {
        Console.Clear();
        listLoanCards = file.ReadFile<LoanCards>(path);

        Console.WriteLine("======================================================================");
        Console.WriteLine("Danh sach phieu muon sach");
        Console.WriteLine("======================================================================");
        Console.WriteLine($"{"Ma phieu",-5} | {"Ma the thu vien",-20} | {"Ngay gio muon",-15} | {"Ngay gio tra",-5} | {"Ten sach",-10}");
        Console.WriteLine("----------------------------------------------------------------------");
        foreach (LoanCards loanCard in listLoanCards)
        {
            DateTime dateTimeCreated = DateTime.ParseExact(loanCard.dateCreated ?? "", "ddMMyyyy", null);
            DateTime dateTimeCanceled = DateTime.ParseExact(loanCard.dateCanceled ?? "", "ddMMyyyy", null);
            Console.WriteLine($"{loanCard.idLoanCard,-10} {loanCard.idMember,-22} {dateTimeCreated.ToString("dd/MM/yyyy"),-17} {dateTimeCanceled.ToString("dd/MM/yyyy"),-14} {loanCard.nameBook,-20}");
        }
        Console.WriteLine("======================================================================");
    }

    public int NumberOfLoanCards()
    {
        listLoanCards = file.ReadFile<LoanCards>(path);
        int Count = 0;
        if (listLoanCards != null)
        {
            Count = listLoanCards.Count;
        }
        return Count;
    }

    public bool CheckIdMember(string idMember)
    {
        foreach (Members member in listMembers)
        {
            if (member.idMember == idMember)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckIdBook(string idBook)
    {
        foreach (Books book in listBooks)
        {
            if (book.idBook == idBook)
            {
                return true;
            }
        }
        return false;
    }

    void TextColor(ConsoleColor color, string str)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ResetColor();
    }
}
