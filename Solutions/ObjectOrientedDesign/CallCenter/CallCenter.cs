using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Solutions.ObjectOrientedDesign.CallCenter
{
    class CallCenter
    {
        HashSet<Respondent> respondents = new HashSet<Respondent>();
        HashSet<Manager> managers = new HashSet<Manager>();
        HashSet<Director> Directors = new HashSet<Director>();

        public void DispatchCall(Call call)
        {
            Respondent freeRespondent = respondents.FirstOrDefault(r => !r.IsBusy);
            if(freeRespondent == null)
            {
                Manager freeManager = managers.FirstOrDefault(m => !m.IsBusy);
                if(freeManager == null)
                {
                    Director freeDirector = Directors.FirstOrDefault(d => !d.IsBusy);
                    if(freeDirector != null)
                    {
                        freeDirector.HandleCall(call);
                    } else
                    {
                        throw new Exception("No one could take the call");
                    }
                } else
                {
                    freeManager.HandleCall(call);
                }
            } else
            {
                freeRespondent.HandleCall(call);
            }

        }
    }
}
