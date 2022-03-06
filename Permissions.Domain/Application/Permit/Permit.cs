using System;

namespace Permissions.Domain.Application.Permit
{
    public class Permit : BaseEntity
    {
        protected Permit()
        {

        }
        public Permit(string firstName, string lastName, PermitType.PermitType permitType, DateTime permitDate)
        {
            FirstName = firstName;
            LastName = lastName;
            PermitType = permitType;
            PermitDate = permitDate;
        }


        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public virtual PermitType.PermitType PermitType { get; set; }

        public DateTime PermitDate { get; set; }


        public void UpdatePermitInfo(string firstName, string lastName, PermitType.PermitType editPermitType, DateTime permitDate)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentNullException(nameof(firstName));

            FirstName = firstName;
            LastName = lastName;
            PermitType = editPermitType;
            PermitDate = permitDate;
        }
    }
}
