using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmoghReports.Library
{
    public class IsomeSumaryMaterialModel
    {
        public int ProjectId { get; set; }
        public string MainMat { get; set; }
        public int IsoReceived { get; set; }
        public int IdfReceived { get; set; }
        public int OnHold { get; set; }
        public int SgDone { get; set; }
        public int BackCheckDone { get; set; }
        public int Transmitted { get; set; }

    }
}
