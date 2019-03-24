using System;

namespace Excercise_1
{
    /*
     * Single Mission Class 
     */
    public class SingleMission : IMission
    {
        //Members
        private string missionName;
        FunctionsContainer.delegateFunction delegateFunc { get; }
        public event EventHandler<double> OnCalculate;

        //Methods
        public SingleMission(FunctionsContainer.delegateFunction func, string missionName)
        {
            this.missionName = missionName;
            delegateFunc = func;
        }
        string IMission.Name => missionName;

        string IMission.Type => "Single";

        public double Calculate(double value)
        {
            double val = delegateFunc(value);
            OnCalculate?.Invoke(this, val);
            return val;
        }
    }
}
