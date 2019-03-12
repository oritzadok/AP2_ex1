using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace Excercise_1 {
    public class SingleMission : IMission {
        public event EventHandler<double> OnCalculate;
        private String name;
		private String type;
		private funcPtr operation;
		
		public SingleMission(funcPtr operation, String name) {
            //initialize fields
            this.name = name;
			type = "Single";
			this.operation = operation;
		}

        public String Name { get { return name; } }
        public String Type { get { return type; } }

        public double Calculate(double value) {
            //compute result
			double result = operation(value);
            //raise events if there are any
			OnCalculate?.Invoke(this, result);
			return result;
		}   
    }
}
