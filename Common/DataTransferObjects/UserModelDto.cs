using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Common.DataTransferObjects
{
    public class UserModelDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<TenancyDto> Tenancies { get; set; }
    }
}