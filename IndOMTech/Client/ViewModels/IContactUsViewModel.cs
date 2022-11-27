namespace IndOMTech.Client.ViewModels
{
    public interface IContactUsViewModel
    {
        string Email { get; set; }
        string LastName { get; set; }
        string Message { get; set; }
        string? Mobile { get; set; }
        string Name { get; set; }
        string? Query { get; set; }

        public Task GetContact();
        public Task Get1stContact();
    }
}