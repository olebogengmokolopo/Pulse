using System.Collections.Generic;
using Microsoft.Win32;

namespace Common
{
    class Tenant
    {
        public int tenantId { get; }
        public List<User> allowedUsers { get; }
    }
}
