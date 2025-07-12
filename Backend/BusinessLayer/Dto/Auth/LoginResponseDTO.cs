using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto.Auth
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public UserDTO userDTO{ get; set; }
    }
}
