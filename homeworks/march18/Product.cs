namespace CodeAcademy.homeworks.march18
{
    class Product
    {
        // Product class: No, Name, Price, Count;
        // No, Name ve Price dəyərləri təyin olunmadan Product obyekti yaradıla bilməz

        public uint No;
        public string Name;
        public float Price;
        public uint Count;

        public Product(uint no, string name, float price)
        {
            No = no;
            Name = name;
            Price = price;
            Count = 0;
        }
    }
}
