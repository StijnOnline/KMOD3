using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    class BlackBoard {
        public Dictionary<string, object> values;
        public T getData<T>(string name) {
            return (T) values[name];
        }
        public void setData(string name, object data) {
            if(values.ContainsKey(name)) {
                values[name] = data;
            } else {
                values.Add(name, data);
            }
        }
    }
}
