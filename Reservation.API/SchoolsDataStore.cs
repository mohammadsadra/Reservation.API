using Reservation.API.Model;

namespace Reservation.API
{
    public class SchoolsDataStore
    {
        public List<SchoolDTO> Schools { get; set; }

        public static SchoolsDataStore current { get; } = new SchoolsDataStore();

        public SchoolsDataStore()
        {
            Schools = new List<SchoolDTO>()
            {
                new SchoolDTO() {
                    Id = 1,
                    SchoolName="Nikan",
                    Address="Tehran"
                },
                new SchoolDTO() {
                    Id = 2,
                    SchoolName="Hamed",
                    Address="Shiraz"
                },
            };
        }
    }
}

