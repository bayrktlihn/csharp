using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev
{
    public interface Operation
    {
        double Apply();
        Task<double> ApplyAsync();
    }


}
