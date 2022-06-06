namespace WeightControl.Services.Interfaces
{
    public interface ICurrentUserService
    {
        bool IsSignedIn { get; set; }
        bool IsRegistered { get; set; }
    }
}