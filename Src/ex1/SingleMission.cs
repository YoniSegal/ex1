using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /*
     * Single Mission Class 
     */
    public class SingleMission : IMission
    {
        //Members
        private string missionName;
        FunctionsContainer.delegateFunction delegateFunction { get; }
        public event EventHandler<double> OnCalculate;

        //Methods
        public SingleMission(FunctionsContainer.delegateFunction func, string missionName)
        {
            this.missionName = missionName;
            delegateFunction = func;
        }
        string IMission.Name => missionName;

        string IMission.Type => "single";

        public double Calculate(double value)
        {
            double val = delegateFunction(value);
            OnCalculate?.Invoke(this, val);
            return val;
        }
    }
}
