using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates;

namespace Excercise_1 {
    //this class contains an indexer that receives name of a function and returns an appropriate action f:R->R
    public class FunctionsContainer {
		
		private Dictionary<string, funcPtr> dictionary;
		
		public FunctionsContainer() {
            //initialize functions dictionary
            dictionary = new Dictionary<string, funcPtr>();
		}
		
        //operator [] of the indexer
		public funcPtr this[string key] {
	         get {
                //if the key does not exist
				if (!dictionary.ContainsKey(key)) {
                    //add the function f(x) = x
					dictionary.Add(key, x => x);
				}
                //return the function
				return dictionary[key];
	         }
	         set {
                //if the key does not exist
                if (!dictionary.ContainsKey(key)) {
					dictionary.Add(key, value);
                    //else, change the value of the existing key
				} else {
					dictionary[key] = value;
				}	
	         }
      	}
		
        //returns a list of all the functions in the container
		public List<string> getAllMissions() {
            //make a list of all the keys in the dictionary
			List<string> missions = new List<string>();
			foreach (string funcName in dictionary.Keys) {
				missions.Add(funcName);
			}
			return missions;
		}
    }
}
