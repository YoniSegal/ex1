using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        private string missionName;
        List<FunctionsContainer.delegateFunction> delegateFunctions { get; }
        public event EventHandler<double> OnCalculate;

        public ComposedMission(string name)
        {
            this.missionName = name;
            delegateFunctions = new List<FunctionsContainer.delegateFunction>();
        }

        string IMission.Name => missionName;

        string IMission.Type => "composed";

        public double Calculate(double value)
        {
            foreach (var func in delegateFunctions)
            {
                func.Invoke(value);
            }
            OnCalculate?.Invoke(this, value);
            return value;
        }

        public ComposedMission Add(FunctionsContainer.delegateFunction func)
        {
            this.delegateFunctions.Add(func);
            return this;
        }
    }
}
