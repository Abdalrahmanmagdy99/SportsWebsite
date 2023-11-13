using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Validations
{
    public static class IdValidations
    {
        public static bool IsIdValidForUpdate(int? id) => id is not null && id > 0 ? true : false;
    }
}
