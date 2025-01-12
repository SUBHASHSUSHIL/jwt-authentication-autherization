using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT_Authentication_Autherization.CustomFiles
{
    public class CreateUserDTO
    {
        public string Name { get; set; }

        public string MobileNo { get; set; }

        public string EmailId { get; set; }

        public string Password { get; set; }

        public int? RoleId { get; set; }
    }
}
