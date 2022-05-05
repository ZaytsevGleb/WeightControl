namespace WeightControl.Services
{
    public interface ICurrentUserService
    {
        bool IsSignedIn { get; set; }
        bool IsRegistered { get; set; }
    }
}