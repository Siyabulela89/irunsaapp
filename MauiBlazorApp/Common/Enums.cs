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
    }
}