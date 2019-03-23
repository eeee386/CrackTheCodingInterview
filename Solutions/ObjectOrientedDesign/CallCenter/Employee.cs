using System;
using System.Collections.Generic;
using System.Text;

namespace Solutions.ObjectOrientedDesign.CallCenter
{
    interface Employee
    {
        string Name { get; set; }
        bool IsBusy { get; set; }
        Call CallToHandle { get; set; }

        void HandleCall(Call call);
    }
}
