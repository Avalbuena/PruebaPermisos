using System;

namespace Permissions.Domain.Application.Permit
{
    public class PermitInfoDto
    {

        public int PermitId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PermitDate { get; set; }

        public int PermitTypeId { get; set; }

        public string PermitTypeName { get; set; }
    }
}
