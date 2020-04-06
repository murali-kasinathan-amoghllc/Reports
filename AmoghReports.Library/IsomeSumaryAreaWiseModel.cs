using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class IsomeSumaryAreaWiseModel
    {
        public int ProjectId { get; set; }
        public string AreaL1 { get; set; }
        public string AreaL2 { get; set; }
        public int IsoReceived { get; set; }
        public int IdfReceived { get; set; }
        public int OnHold { get; set; }
        public int SgDone { get; set; }
        public int BackCheckDone { get; set; }
        public int Transmitted { get; set; }

    }
}
