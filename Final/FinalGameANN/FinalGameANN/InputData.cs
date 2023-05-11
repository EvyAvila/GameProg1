using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameANN
{
    public class InputData : IData
    {
        //get the file name of the input data
        public string ExternalEnemyDataFile { get => "EnemyInputData.txt"; set => ExternalEnemyDataFile = value; }
        
        //hold the data from every line of the file
        public string[] GetEnemyFile { get => File.ReadAllLines(ExternalEnemyDataFile); set { } }

        //a dynamic containment to hold the input data 
        public List<double> EnemyInputsData = new List<double>();

        public InputData()
        {
            //inputs = new List<double>(GetEnemyFile.Length);
            InsertData();
        }

        //adding the data from the file into the list
        public void InsertData()
        {
            for (int i = 0; i < GetEnemyFile.Length; i++)
            {
                double data = double.Parse(GetEnemyFile[i]);

                EnemyInputsData.Add(data);
            }
        }
    }

    public class OutputData : IData
    {
        //similar concept to InputData class, the only difference being holding the output data
        public string ExternalEnemyDataFile { get => "EnemyOutputData.txt"; set => ExternalEnemyDataFile = value; }
        public string[] GetEnemyFile { get => File.ReadAllLines(ExternalEnemyDataFile); set { } }

        public List<double> EnemyOutputsData = new List<double>();

        public OutputData()
        {
            InsertData();
        }

        public void InsertData()
        {
            for (int i = 0; i < GetEnemyFile.Length; i++)
            {
                double data = double.Parse(GetEnemyFile[i]);

                EnemyOutputsData.Add(data);
            }
        }
    }

    //usign the same method and properties 
    public interface IData
    {
        //Interface from my algorithms portfolio
        public string ExternalEnemyDataFile { get; set; } //Get the name of the external file

        public string[] GetEnemyFile { get; set; } //Setting the External file name into the containment

        public void InsertData(); //A method to insert the external data file to list containment



    }

}
