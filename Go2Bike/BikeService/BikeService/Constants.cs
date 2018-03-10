using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeService
{
    public enum SwitchState
    {
        Nepoznato,
        Zakljucano,
        Otkljucano
    }

    public enum TagState
    {
        Nepoznato,
        Prisutan,
        Neprisutan
    }

    public enum LogType
    {
        Info,
        Error
    }

    class Constants
    {
    }
}
