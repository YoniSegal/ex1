using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        //Members
        private string missionName;
        List<FunctionsContainer.delegateFunction> delegateFunctions { get; }
        public event EventHandler<double> OnCalculate;
        //Methods
        public ComposedMission(string name)
        {
            this.missionName = name;
            delegateFunctions = new List<FunctionsContainer.delegateFunction>();
        }

        string IMission.Name => missionName;

        string IMission.Type => "Composed";

        public double Calculate(double value)
        {
            double ans = value;
            foreach (var func in delegateFunctions)
            {
                ans = func.Invoke(ans);
            }
            OnCalculate?.Invoke(this, ans);
            return ans;
        }

        public ComposedMission Add(FunctionsContainer.delegateFunction func)
        {
            this.delegateFunctions.Add(func);
            return this;
        }
    }
}
