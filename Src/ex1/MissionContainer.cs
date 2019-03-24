using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    public class FunctionsContainer
    {
        public delegate double delegateFunction(double value);
        private Dictionary<string, delegateFunction> functions;

        public FunctionsContainer()
        {
            functions = new Dictionary<string, delegateFunction>();
        }

        public List<string> getAllMissions()
        {
            List<string> missions = new List<string>();
            foreach (var mission in functions)
            {
                missions.Add(mission.Key);
            }
            return missions;
        }

        public delegateFunction this[string name]
        {
            get
            {
                if (functions.ContainsKey(name))
                {
                    return functions[name];
                }
                else
                {
                    functions[name] = val => val;
                    return functions[name];
                }
            }
            set
            {
                functions[name] = value;
            }
        }

    }
}
