namespace Interfaces
{
    public interface ICodeAcademy
    {
        // Properties
        string CodeEmail { get; set; }

        // Methods
        string GenerateEmail();
    }
}
