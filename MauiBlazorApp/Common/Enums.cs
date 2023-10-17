namespace irunsaapp.Common
{
    public class Enums
    {
        public enum EntityType
        {
            Athlete = 1,
            Club = 2,
            Event = 3,
            Coach = 4,
            Province = 5,
            Photographer = 6
        }

        public enum ClubStatus
        {
            Listed = 1,
            ClaimRequested = 2,
            ClaimVerified = 3,
            Disabled = 4,
            Suspended = 5
        }

        public enum RoleType
        {
            SuperUser = 1,
            Admin = 2,
            Proxy = 3,
            Minor = 4,
            OwnerPendingVerification = 5,
            OwnerVerified = 6

        }
    }
}