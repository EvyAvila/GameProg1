namespace ANNModification
{
    //Code from https://github.com/lschmittalves/simple-neural-network/blob/master/Program.cs
    //for ANN modification
    class NeuralNetWork
    {
        private Random _radomObj;

        public NeuralNetWork(int synapseMatrixColumns, int synapseMatrixLines)
        {
            SynapseMatrixColumns = synapseMatrixColumns;
            SynapseMatrixLines = synapseMatrixLines;

            _Init();
        }

        public int SynapseMatrixColumns { get; }
        public int SynapseMatrixLines { get; }
        public double[,] SynapsesMatrix { get; private set; }

        /// <summary>
        /// Initialize the ramdom object and the matrix of ramdon weights
        /// </summary>
        private void _Init()
        {
            // make sure that for every instance of the neural network we are geting the same radom values
            _radomObj = new Random(1);
            _GenerateSynapsesMatrix();
        }

        /// <summary>
        /// Generate our matrix with the weight of the synapses
        /// </summary>
        private void _GenerateSynapsesMatrix()
        {
            SynapsesMatrix = new double[SynapseMatrixLines, SynapseMatrixColumns];

            for (var i = 0; i < SynapseMatrixLines; i++)
            {
                for (var j = 0; j < SynapseMatrixColumns; j++)
                {
                    SynapsesMatrix[i, j] = (2 * _radomObj.NextDouble()) - 1;
                }
            }
        }

        /// <summary>
        /// Calculate the sigmoid of a value
        /// </summary>
        /// <returns></returns>
        private double[,] _CalculateSigmoid(double[,] matrix)
        {

            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = 1 / (1 + Math.Exp(value * -1));
                }
            }
            return matrix;
        }

        /// <summary>
        /// Calculate the sigmoid derivative of a value
        /// </summary>
        /// <returns></returns>
        private double[,] _CalculateSigmoidDerivative(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    var value = matrix[i, j];
                    matrix[i, j] = value * (1 - value);
                }
            }
            return matrix;
        }

        /// <summary>
        /// Will return the outputs give the set of the inputs
        /// </summary>
        public double[,] Think(double[,] inputMatrix)
        {

            var productOfTheInputsAndWeights = MatrixDotProduct(inputMatrix, SynapsesMatrix);

            return _CalculateSigmoid(productOfTheInputsAndWeights);

        }

        /// <summary>
        /// Train the neural network to achieve the output matrix values
        /// </summary>
        public void Train(double[,] trainInputMatrix, double[,] trainOutputMatrix, int interactions)
        {
            // we run all the interactions
            for (var i = 0; i < interactions; i++)
            {
                // calculate the output
                var output = Think(trainInputMatrix);

                // calculate the error
                var error = MatrixSubstract(trainOutputMatrix, output);
                var curSigmoidDerivative = _CalculateSigmoidDerivative(output);
                var error_SigmoidDerivative = MatrixProduct(error, curSigmoidDerivative);

                // calculate the adjustment :) 
                var adjustment = MatrixDotProduct(MatrixTranspose(trainInputMatrix), error_SigmoidDerivative);

                SynapsesMatrix = MatrixSum(SynapsesMatrix, adjustment);
            }
        }

        /// <summary>
        /// Transpose a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixTranspose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Sum one matrix with another
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixSum(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] + matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Subtract one matrix from another
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixSubstract(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] - matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplication of a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixProduct(double[,] matrixa, double[,] matrixb)
        {
            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var result = new double[rowsA, colsA];

            for (int i = 0; i < rowsA; i++)
            {
                for (int u = 0; u < colsA; u++)
                {
                    result[i, u] = matrixa[i, u] * matrixb[i, u];
                }
            }

            return result;
        }

        /// <summary>
        /// Dot Multiplication of a matrix
        /// </summary>
        /// <returns></returns>
        public static double[,] MatrixDotProduct(double[,] matrixa, double[,] matrixb)
        {

            var rowsA = matrixa.GetLength(0);
            var colsA = matrixa.GetLength(1);

            var rowsB = matrixb.GetLength(0);
            var colsB = matrixb.GetLength(1);

            if (colsA != rowsB)
                throw new Exception("Matrices dimensions don't fit.");

            var result = new double[rowsA, colsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < rowsB; k++)
                        result[i, j] += matrixa[i, k] * matrixb[k, j];
                }
            }
            return result;
        }

    }

    class Program
    {

        static void PrintMatrix(double[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrix[i, j]));
                }
                Console.Write(Environment.NewLine);
            }
        }

        static void Main(string[] args)
        {
            
            var curNeuralNetwork = new NeuralNetWork(1, 4);

            Console.WriteLine("Synaptic weights before training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);

            //Wind speed, cloud patterns, pressure, temperature
            var trainingInputs = new double[,] { { 0, 0, 1,0 }, { 1, 1, 1,1 }, { 1, 0, 1, 1 }, { 0, 1,1, 1 }, { 1, 0, 0,0}, { 1, 1, 0, 1}, { 0, 0, 1, 0 } };
            
            var trainingOutputs = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 1, 1, 0, 1, 0 } }); 

            curNeuralNetwork.Train(trainingInputs, trainingOutputs, 10000); //10000

            Console.WriteLine("\nSynaptic weights after training:");
            PrintMatrix(curNeuralNetwork.SynapsesMatrix);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            double[,] newInput = new double[,] { { 1, 1, 1, 0} }; 

            // testing neural networks against a new problem 
            var output = curNeuralNetwork.Think(newInput);
            Console.WriteLine($"\nConsidering new problem {newInput[0,0]}, {newInput[0,1]}, {newInput[0,2]}, {newInput[0, 3]} => :"); //[1, 1, 1]

            PrintMatrix(output); //Not caring much about this output, just the new inserted input
            
            string canRain = XNORGate(newInput);

            Console.Write(canRain);

            Console.Read();

        }

       


        //Based on XNOR method with alternations
        static string ORGate(double[,] matrix)
        {
            int[] inputs = new int[matrix.GetLength(1)];
            int output = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                inputs[i] = (int)matrix[0, i];
            }

            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j = i + 1; j < inputs.Length; j++)
                {
                    if (inputs[i] > 0 || inputs[j] > 0)
                    {
                        output = 1;
                    }
                    else
                    {
                        output = 0;
                        break;
                    }
                }
                if (output == 0)
                {
                    break;
                }
            }

            if (output == 1)
            {
                return "Most likely to rain";
            }
            else
            {
                return "Least likely to rain"; 
            }            
        }

        //From Chat.GPT with some alternations 
        static string XNORGate(double[,] matrix)
        {
            int[] inputs = new int[matrix.GetLength(1)];
            int output = 1;

            string result = string.Empty;

            for (int i = 0; i < matrix.Length; i++)
            {
                inputs[i] = (int)matrix[0, i];
            }

            for (int i = 0; i < inputs.Length - 1; i++)
            {
                for (int j = i + 1; j < inputs.Length; j++)
                {
                    if (inputs[i] == inputs[j])
                    {
                        output = 1;
                    }
                    else if (inputs[i] != inputs[j])
                    {
                        return ORGate(matrix);
                    }
                    else
                    {
                        output = 0;
                        break;
                    }
                }
                if(output == 1)
                {
                    if (matrix[0, 0] == 0)
                    {
                        result = "Will not rain";
                    }
                    else
                    {
                        result = "Will rain";
                    }
                }
               
            }

            return result;
        }
        
    }
}