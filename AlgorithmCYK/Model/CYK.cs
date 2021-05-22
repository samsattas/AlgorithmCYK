using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCYK.Model
{
    class CYK
    {
        public List<List<string>> matrix;
        public List<string> data; 
        //public String dataEntered;

        public CYK() {
            matrix = new List<List<string>>();
            data = new List<string>();
        }
        public void addData(string gramathic) {
            data.Add(gramathic);
        }
        public string checkGramathic(string toCheck) {
            string representative = "";
            List<string> lineArray = new List<string>();
            string[] auxArray = toCheck.Split(',');
            for (int i = 0; i < auxArray.Length; i++) {
                lineArray.Add(auxArray[i]);
            }
            for (int i = 0; i < lineArray.Count; i++) {
                for (int j = 1; j < auxArray.Length; j++) {
                    if (lineArray.ElementAt(i).ElementAt(j).Equals(toCheck)) {
                        representative += lineArray.ElementAt(i).ElementAt(0) + ","; //REVISAR QUE NO QUEDE ASI POR EJEMPLO AB,AX, SI NO AB,AX
                    }
                }
            }
            return representative;
        }

    }
}
