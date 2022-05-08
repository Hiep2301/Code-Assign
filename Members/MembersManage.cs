public class MembersManage
{
    private List<Members> listMembers;
    public MembersManage()
    {
        listMembers = new List<Members>();
    }
    FileIO file = new FileIO();
    const string path = @"data\Members.json";

    public bool Add()
    {
        Console.Clear();
        listMembers = file.ReadFile<Members>(path);
        if (listMembers == null)
        {
            listMembers = new List<Members>();
        }
        Members member = new Members();

        Console.WriteLine("══════════════════════════════════════");
        Console.WriteLine("Them moi mot the");
        Console.WriteLine("══════════════════════════════════════");
        while (true)
        {
            Console.Write("Nhap ma the: ");
            member.idMember = Console.ReadLine() ?? "";
            if (CheckId(member.idMember))
            {
                TextColor(ConsoleColor.Yellow, "Ma the da ton tai, vui long nhap lai!");
            }
            else
            {
                break;
            }
        }
        Console.Write("Nhap ten chu the: ");
        member.nameMember = Console.ReadLine() ?? "";
        while (true)
        {
            Console.Write("Nhap so CMND: ");
            member.idCard = Console.ReadLine() ?? "";
            if (member.idCard.Length == 9)
            {
                if (IsNumber(member.idCard))
                {
                    break;
                }
                else
                {
                    TextColor(ConsoleColor.Yellow, "So CMND khong hop le, vui long nhap lai!");
                }
            }
            else
            {
                TextColor(ConsoleColor.Yellow, "So CMND khong hop le, vui long nhap lai!");
            }
        }
        Console.Write("Nhap ngay tao: ");
        member.dateCreated = Console.ReadLine() ?? "";
        Console.WriteLine("══════════════════════════════════════");

        listMembers.Add(member);
        file.WriteFile<Members>(listMembers, path);
        return true;
    }

    public bool Update(string idMember)
    {
        Members member = FindByIdMember(idMember);
        if (member != null)
        {
            Console.Clear();
            Console.WriteLine("══════════════════════════════════════");
            Console.WriteLine("Cap nhat thong tin the");
            Console.WriteLine("══════════════════════════════════════");
            Console.Write("Sua ten chu the: ");
            member.nameMember = Console.ReadLine() ?? "";
            while (true)
            {
                Console.Write("Sua so CMND: ");
                member.idCard = Console.ReadLine() ?? "";
                if (member.idCard.Length == 9)
                {
                    if (IsNumber(member.idCard))
                    {
                        break;
                    }
                    else
                    {
                        TextColor(ConsoleColor.Yellow, "So CMND khong hop le, vui long nhap lai!");

                    }
                }
                else
                {
                    TextColor(ConsoleColor.Yellow, "So CMND khong hop le, vui long nhap lai!");
                }
            }
            Console.Write("Sua ngay tao: ");
            member.dateCreated = Console.ReadLine() ?? "";
            Console.WriteLine("══════════════════════════════════════");
            return true;
        }
        else
        {
            Console.WriteLine();
            TextColor(ConsoleColor.Yellow, $"Thanh vien co ma the {idMember} khong ton tai!");
            return false;
        }
    }

    public void CheckUpdate(bool check)
    {
        if (check == true)
        {
            file.WriteFile<Members>(listMembers, path);
        }
        else
        {
            return;
        }
    }

    public void Display()
    {
        Console.Clear();
        listMembers = file.ReadFile<Members>(path);

        Console.WriteLine("════════════════════════════════════════════════════════");
        Console.WriteLine("Danh sach the thu vien");
        Console.WriteLine("════════════════════════════════════════════════════════");
        Console.WriteLine($"{"Ma the",-5} | {"Ten chu the",-21} | {"CMND",-10} | {"Ngay tao",-5}");
        Console.WriteLine("────────────────────────────────────────────────────────");
        foreach (Members member in listMembers)
        {
            DateTime dateTime = DateTime.ParseExact(member.dateCreated ?? "", "ddMMyyyy", null);
            Console.WriteLine($"{member.idMember,-8} {member.nameMember,-23} {member.idCard,-12} {dateTime.ToString("dd/MM/yyyy"),-14}");
        }
        Console.WriteLine("════════════════════════════════════════════════════════");

    }

    public Members FindByIdMember(string idMember)
    {
        if (listMembers != null && listMembers.Count > 0)
        {
            foreach (Members member in listMembers)
            {
                if (member.idMember == idMember)
                {
                    return member;
                }
            }
        }
        return null!;
    }

    public bool CheckId(string idMember)
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

    public int NumberOfMembers()
    {
        listMembers = file.ReadFile<Members>(path);
        int Count = 0;
        if (listMembers != null)
        {
            Count = listMembers.Count;
        }
        return Count;
    }

    public bool IsNumber(string idCard)
    {
        bool check = true;
        foreach (char ch in idCard)
        {
            if (!char.IsNumber(ch))
            {
                check = false;
            }
        }
        if (check == false)
        {
            return false;
        }
        return true;
    }

    void TextColor(ConsoleColor color, string str)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(str);
        Console.ResetColor();
    }
}
