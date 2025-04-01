namespace Extensions
{
    public static class Helper
    {
        /*
        IsOdd() -- int deyerler üçün həmin obyektin tək ədəd olub olmadığını geri qaytaran (true/false) method
        IsEven() -- int  deyerler  üçün həmin obyektin cüt ədəd olub olmadığını geri qaytaran (true/false) method
        HasDigit() -- string  deyerler  üçün həmin obyektin daxilində digit character olub olmamasını geri qaytaran(true/false) metod
        CheckPassword() -- string  deyerlerini yoxluyub true/false qaytarir Password-da en azi bir boyuk bir kicik herf ve en azi 1 reqem olamilidir. Uzunlugu 8-den kicik olmamalidir. 
        Capitalize() -- String-lər üçün Capitalize adlı extention metod yaradırsınız.Bu metod string dəyərini capitalaize edib geri
        */
        public static bool IsOdd(this int num)
        {
            if (num % 2 == 1) { return true; }
            else { return false; }
        }

        public static bool IsEven(this int num)
        {
            if (num % 2 == 0) { return true; }
            else { return false; }
        }

        public static bool HasDigit(this string text)
        {
            foreach (char c in text)
            {
                if (char.IsDigit(c)) { return true; }
            }
            return false;
        }

        public static bool CheckPassword(this string password)
        {
            bool hasDigit = password.HasDigit();
            bool hasUpper = false;
            bool hasLower = false;

            foreach (char c in password)
            {
                if (char.IsLower(c)) { hasLower = true; }
                else if (char.IsUpper(c)) { hasUpper = true; }
            }

            bool hasValidLength = password.Length > 8;
            bool hasRequireChars = hasDigit && hasUpper && hasLower;

            if (hasValidLength && hasRequireChars) { return true; }
            else { return false; }
        }

        public static string Capitalize(this string text)
        {
            return char.ToUpper(text[0]) + text.ToLower()[1..];
        }
    }
}