using System.Text.RegularExpressions;

public static class NameValidator
{
    public static bool IsValid(string name, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            errorMessage = "Tên không được để trống.";
            return false;
        }

        if (name.Length > 12)
        {
            errorMessage = "Tên không được dài quá 12 ký tự.";
            return false;
        }

        if (!Regex.IsMatch(name, @"^[a-zA-Z0-9]+$"))
        {
            errorMessage = "Tên chỉ được chứa chữ cái và số, không có ký tự đặc biệt hoặc dấu cách.";
            return false;
        }

        errorMessage = "";
        return true;
    }
}
