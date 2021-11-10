using System;

namespace sio_csa
{
    public class UserType :DataBaseStorageHelper,  IPerson, ICompanyLocation
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateTime { get; set; }
        public int OrganizationUnitID { get; set; }
        public int ZoneID { get; set; }

        public string NameSurname()
        {
            throw new NotImplementedException();
        }
    }
}