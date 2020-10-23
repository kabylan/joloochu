using System;
using System.Collections.Generic;

namespace Joloochu
{
    public class Region
    {

        public int id { get; set; }

        public string NameRus { get; set; }
        public string NameKyrg { get; set; }
        public string NameEng { get; set; }

        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }

    }
}
