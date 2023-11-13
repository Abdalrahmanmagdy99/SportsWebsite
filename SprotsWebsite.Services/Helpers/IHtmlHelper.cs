using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SprotsWebsite.Services.Helpers
{
    public interface IHtmlHelper
    {
        string GetIframeSrc(string url);
    }
}
