using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    interface IMapper<TS,TD> where TS: new() where TD: new()
    {
        TD Map(TS source);
        TS MapBack(TD source);
    }
}
