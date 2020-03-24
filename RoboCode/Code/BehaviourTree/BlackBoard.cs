using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVD.BehaviourTree {
    abstract class BlackBoard{

        private object[] values;

        public BlackBoard(Type e){
            values = new object[Enum.GetNames(e).Length];
        }
            
        /// <summary>
        /// HANDLE OWN CASTING
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public object getData(Enum variable) {
            return values[(int)Enum.Parse(variable.GetType(), variable.ToString())];
        }
        public void setData(Enum variable, object data) {
            /*if(values.ContainsKey(variable)) {
                values[name] = data;
            } else {
                values.Add(name, data);
            }*/
            values[(int)Enum.Parse(variable.GetType(), variable.ToString())] = data;
        }
    }
}
