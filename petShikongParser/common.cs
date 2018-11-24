using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace petShikongParser
{
    public class propInfo
    {
        public string propId { get; set; }

        public string propName { get; set; }

        public string propPrice { get; set; }

        public string propIcon { get; set; }
    }

    public class petInfo
    {
        public string petId { get; set; }

        public string petName { get; set; }

        public string petDept { get; set; }

        public string petClass { get; set; }

        public string petSkills { get; set; }
    }

    public class equipInfo
    {
        public string equipId { get; set; }

        public string equipName { get; set; }

        public string equipType { get; set; }

        public string equipIcon { get; set; }
    }

    public enum versionOptions
    {
        notset = -1,
        Version4 = 0,
        Version5 = 1,
        Version6 = 2,
    }

    public enum dbTableOptions
    {
        notset,
        propDataView,
        propDefineTable,
        propDetailTable,
        equipTable,
        petTable,
        taskTable
    }
}
