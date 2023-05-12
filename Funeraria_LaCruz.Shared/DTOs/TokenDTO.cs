using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Funeraria_LaCruz.Shared.Entities;

namespace Funeraria_LaCruz.Shared.DTOS
{
    public class TokenDTO
    {

        public string Token { get; set; } = null!;

        public DateTime Expiration { get; set; }

    }
}
