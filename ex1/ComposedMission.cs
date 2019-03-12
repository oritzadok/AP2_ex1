using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace Excercise_1 {
    public class ComposedMission : IMission {
        public event EventHandler<double> OnCalculate;
        private String name;
		private String type;
		private List<funcPtr> operations;
		
		public ComposedMission(String name) {
            //initialize fields
            this.name = name;
			type = "Composed";
			operations = new List<funcPtr>();
		}

        public String Name { get { return name; } }
        public String Type { get { return type; } }

        public ComposedMission Add(funcPtr operation) {
            //add new function to the list of concatenated functions
			operations.Add(operation);
            return this;
		}
		
		public double Calculate(double value) {
            //compute result by concatenating all the functions in the list
            double result = value;
			foreach (funcPtr func in operations) {
				result = func(result);
			}
            //raise events if there are any
            OnCalculate?.Invoke(this, result);
			return result;
		}   
    }
}
