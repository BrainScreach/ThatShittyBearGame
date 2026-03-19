using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThatShittyBearGame.Settings
{
    public static class ValueConverter
    {
        private const int PAPER_LENGTH_METER = 52;
        private const int PIXETL_IN_METER = 200;

        public static float ConvertFromToiletPaper(float value)
        {
            return value * PAPER_LENGTH_METER * PIXETL_IN_METER;
        }
    }
}
