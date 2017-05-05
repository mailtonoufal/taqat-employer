using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArabWaha.Enums
{
    public enum SortByEnum
    {
        NULL = 0,
        DISTANCE,
        RELEVANCE,
        SCORE_HIGH,
        SCORE_LOW,
        STARTDATE_RECENT,
        STARTDATE_FUTURE,
        GENDER_MALEFIRST,
        GENDER_FEMALEFIRST
    }
}
