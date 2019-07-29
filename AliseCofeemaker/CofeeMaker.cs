using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace AliseCofeemaker
{
    public enum CofeeStatus
    {
        grinding = 0,
        boiling,
        cleaning,
        artWorking,
        pouring,
        finished,
        outwork
    }

    public interface ICofee
    {
        CofeeStatus status { get; set; }
        int GetCofeeStatus();
    }

    public class CofeeMaker : ICofee
    {
        Timer tmr;
        public CofeeMaker()
        {
            tmr = new Timer();
            tmr.Interval = 3000;
            tmr.Elapsed += new ElapsedEventHandler(CofeeStatusChanged);
            tmr.Start();
        }

        public CofeeStatus status { get => status; set => status = value; }

        public int GetCofeeStatus()
        {
            return (int)status;
        }

        private void CofeeStatusChanged(object sender, ElapsedEventArgs e)
        {
            Random r = new Random(6);
            int statusCode = r.Next();
            status = (CofeeStatus)statusCode;
            if (status == CofeeStatus.finished)
            {
                ((Timer)sender).Stop();
;           }
        }
    }

    
}
