public class BooksManage
{
    private List<Books> listBooks;
    public BooksManage()
    {
        listBooks = new List<Books>();
    }
    FileIO file = new FileIO();
    const string path = @"data\Books.json";

    public bool Add()
    {
        Console.Clear();
        listBooks = file.ReadFile<Books>(path);
        if (listBooks == null)
        {
            listBooks = new List<Books>();
        }
        Books book = new Books();

        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine("Them moi mot quyen sach");
        Console.WriteLine("══════════════════════════════════════");
        while (true)
        {
            Console.Write("Nhap ma sach: ");
            book.idBook = Console.ReadLine() ?? "";
            if (CheckId(book.idBook))
            {
                TextColor(ConsoleColor.Yellow, " *Ma sach da ton tai, vui long nhap lai!");
            }
            else
            {
                break;
            }
        }
        Console.Write("Nhap ten sach: ");
        book.nameBook = Console.ReadLine() ?? "";
        Console.Write("Nhap ten tac gia: ");
        book.authorName = Console.ReadLine() ?? "";
        Console.Write("Nhap so luong: ");
        int.TryParse(Console.ReadLine(), out book.qtyInStock);
        Console.Write("Nhap danh muc: ");
        book.category = Console.ReadLine() ?? "";
        Console.WriteLine("══════════════════════════════════════");

        listBooks.Add(book);
        file.WriteFile<Books>(listBooks, path);
        return true;
    }

    public bool Update(string idBook)
    {
        Books book = FindByIdBook(idBook);
        if (book != null)
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("Cap nhat thong tin sach");
            Console.WriteLine("══════════════════════════════════════");
            Console.Write("Sua ten sach: ");
            book.nameBook = Console.ReadLine() ?? "";
            Console.Write("Sua ten tac gia: ");
            book.authorName = Console.ReadLine() ?? "";
            Console.Write("Sua so luong: ");
            book.qtyInStock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Sua danh muc: ");
            book.category = Console.ReadLine() ?? "";
            Console.WriteLine("══════════════════════════════════════");
            return true;
        }
        else
        {
            TextColor(ConsoleColor.Yellow, $"Sach co ma {idBook} khong ton tai!");
            return false;
        }
    }

    public void CheckUpdate(bool check)
    {
        if (check == true)
        {
            file.WriteFile<Books>(listBooks, path);
        }
        else
        {
            return;
        }
    }

    public void Display()
    {
        Console.Clear();
        listBooks = file.ReadFile<Books>(path);

        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine("Danh sach sach");
        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine($"{"Ma sach",-5} | {"Ten sach",-20} | {"Ten tac gia",-15} | {"So luong",-5} | {"Danh muc",-15}");
        Console.WriteLine("--------------------------------------");
        foreach (Books book in listBooks)
        {
            Console.WriteLine($"{book.idBook,-9} {book.nameBook,-22} {book.authorName,-17} {book.qtyInStock,-10} {book.category,-10}");
        }
        Console.WriteLine("══════════════════════════════════════");
    }

    public Books FindByIdBook(string idBook)
    {
        if (listBooks != null && listBooks.Count > 0)
        {
            foreach (Books book in listBooks)
            {
                if (book.idBook == idBook)
                {
                    return book;
                }
            }
        }
        return null!;
    }

    public bool CheckId(string idBook)
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

    public int NumberOfBooks()
    {
        listBooks = file.ReadFile<Books>(path);
        int Count = 0;
        if (listBooks != null)
        {
            Count = listBooks.Count;
        }
        return Count;
    }

    void TextColor(ConsoleColor color, string str)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ResetColor();
    }
}