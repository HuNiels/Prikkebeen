namespace Acupunctuur.Models
{
    public enum CancelStatus
    {
        InTime,
        FourtyEightHours,
        OneHour,
        // Admin is only used for the admin pop-up. You will not see this option in the database
        Admin
    }
}
