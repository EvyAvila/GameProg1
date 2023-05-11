using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameANN
{
   public class Game
    {
        bool IsPlayerAlive;
        int PlayerScore;

        Player player;
        Enemy monster;

        InputData inputData;
        OutputData outputData;

        int MatrixLinesSize;

        public Game()
        {
            SetNewPlayer();
            inputData = new InputData();
            outputData= new OutputData();
            MatrixLinesSize = 6; //can set it here
        }

        //setting values for the player
        private void SetNewPlayer()
        {
            player = new Player();
            IsPlayerAlive = true;
            PlayerScore = 0;
        }

        //call the neural network for the player and enemies before "playing"
        public void StartGame()
        {
            /* Testing to see the values display for each entity
            foreach (var v in player.PlayerConditions)
            {
                Console.Write(v);
            }

            Console.WriteLine();

            foreach(var e in monster.EnemyConditions)
            {
                Console.Write(e);
            }*/

            var curNeuralNetwork = new NeuralNetWork(1, MatrixLinesSize);
            var enemyNeuralNetwork = new NeuralNetWork(1, MatrixLinesSize);

            Play(curNeuralNetwork, enemyNeuralNetwork);
        }

        //train the player and enemy with their respected data differences
        private void TrainCharacters(NeuralNetWork curNeuralNetwork, NeuralNetWork enemyNeuralNetwork)
        {
            //elements: Helmet, Armor chest, shield, sword, healing potion, pointy boots => damage dealt total

            int collectionSize = inputData.EnemyInputsData.Count / MatrixLinesSize;
            
            var trainPlayerInput = new double[,] { { 0, 0, 0, 0, 0, 0 }, { 1, 1, 1, 1, 1, 1 }, { 1, 0, 1, 1, 0, 1 }, { 0, 0, 1, 0, 0, 1 }, { 1, 1, 1, 0, 1, 1 } };
            
            var trainEnemyInput = new double[collectionSize, MatrixLinesSize]; 
           
            //inserting the values to the training input
            int inputValue = 0;
            for(int i = 0; i < collectionSize; i++)
            {
                for(int j = 0; j < MatrixLinesSize; j++)
                {
                    trainEnemyInput[i, j] = inputData.EnemyInputsData[inputValue];
                    inputValue++;
                }
            }

            //inserting the values to the training output
            var outputSize = outputData.EnemyOutputsData.Count;
            var enemyOutput = new double[1, outputSize];
            int outputValue = 0;
            for(int i = 0; i < 1; i++)
            {
                for(int j =0; j < outputSize; j++)
                {
                    enemyOutput[i, j] = outputData.EnemyOutputsData[outputValue];
                    outputValue++;
                }
            }

            var trainPlayerOutput = NeuralNetWork.MatrixTranspose(new double[,] { { 0, 1, 1, 0, 1 } });
            
            var trainEnemyOutput = NeuralNetWork.MatrixTranspose(enemyOutput); //new double[,] { { 0, 1, 1, 0, 0 } }

            curNeuralNetwork.Train(trainPlayerInput, trainPlayerOutput, 10000);
            enemyNeuralNetwork.Train(trainEnemyInput, trainEnemyOutput, 10000);
        }

        //main activity where the player and enemy battle it out, get the result, and continue until the player is no more
        private void Play(NeuralNetWork curNeuralNetwork, NeuralNetWork enemyNeuralNetwork)
        {
            int difficultyIncrease = outputData.EnemyOutputsData.Count * 3;

            while (IsPlayerAlive)
            {
                double PlayerDamage = 0;
                double MonsterDamage = 0;

                TrainCharacters(curNeuralNetwork, enemyNeuralNetwork);

                monster = new Enemy();

                var playerOutput = curNeuralNetwork.Think(player.PlayerConditions);
                var enemyOutput = enemyNeuralNetwork.Think(monster.EnemyConditions);

                var outputValue = 0;
                if (enemyOutput[0, 0] > 0.55)
                {
                    outputValue = 1;
                }

                playerOutput[0, 0] *= MathF.Round(100 / 2);
                enemyOutput[0, 0] *= MathF.Round(100 / 2);

                PlayerDamage += playerOutput[0, 0];
                MonsterDamage += enemyOutput[0, 0];


                Console.WriteLine("Player's Damage total: " + PlayerDamage);

                Console.WriteLine("Monster's Damage total: " + MonsterDamage);

                if (PlayerDamage > MonsterDamage)
                {
                    PlayerScore++;
                    Console.WriteLine("Player's Score: " + PlayerScore);

                    if (difficultyIncrease < outputData.EnemyOutputsData.Count)
                    {

                        for (int i = 1; i < outputData.EnemyOutputsData.Count; i++)
                        {
                            if (outputData.EnemyOutputsData[i] == 0)
                            {
                                outputData.EnemyOutputsData[i] = 1;
                                break;
                            }
                        }
                    }

                    foreach (var e in monster.EnemyConditions)
                    {
                        inputData.EnemyInputsData.Add(e);
                    }
                    outputData.EnemyOutputsData.Add(outputValue);
                }
                else
                {
                    Console.WriteLine("Monster win");

                    IsPlayerAlive = false;
                }

                //NextScene(); //uncomment if wanting to see each result before moving on
            }

            Console.WriteLine("Game Over");
            Console.WriteLine("Total enemies defeated: " + PlayerScore);
            NextScene();
        }

        //wait for the user's input and clear the screen 
        private static void NextScene()
        {
            Console.ReadKey();
            Console.Clear();
        }

        //Only using to display condition
        /*
        void PrintMatrix(double[,] matrix)
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
        }*/
   }
}
