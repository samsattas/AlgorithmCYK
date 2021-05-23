using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCYK.Model
{
    class CYK
    {
        public string w;
        public List<List<List<string>>> matrix;
        public List<string> data; 
        //w=abc
        public CYK(string w) {
            matrix = new List<List<List<string>>>();
            data = new List<string>();
            init(w);
        }
        public void init(string w) {
            for (int i =0; i < w.Length; i++) {
                List<List<string>> initList = new List<List<string>>();
                matrix.Add(initList);
            }
        }
        public void addData(string gramathic) {
            data.Add(gramathic);
        }
        public List<string> checkGramathic(string toCheck)
        {
            List<string> arrayReturn = new List<string>();
            for (int i = 0; i < data.Count; i++) {
                string[] auxArray = data.ElementAt(i).Split(',');
                for (int j = 1; j < auxArray.Length; j++){
                    if (data.ElementAt(i).ElementAt(j).Equals(toCheck)){
                        arrayReturn.Add(data.ElementAt(i).ElementAt(0) + "");
                    }
                }
            }
            return arrayReturn;
        }
        public Boolean checkAcceptation() {
            Boolean value = false;
            if (matrix.ElementAt(matrix.Count-1).ElementAt(0).Equals("S")) {
                value = true;
            }
            return value;
        }
    }
}
