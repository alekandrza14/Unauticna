using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class DatePlus
{
    static public int dayOfEra()
    {
        return DateTime.Now.DayOfYear + (DateTime.Now.Year * 366);
    }
}
