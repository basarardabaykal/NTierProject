using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto.Auth
{
    public class RegisterResponseDTO
    {
        public UserDTO userDTO { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
