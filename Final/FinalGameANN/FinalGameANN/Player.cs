using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGameANN
{
    //Only need to call once at start
    public class Player : IEntity
    {
        //setting the size of the 2D array
        public double[,] PlayerConditions = new double[1, 6];
        Random rand = new Random();

        public Player()
        {
            SetEntity();
        }

        //randomly set the array between 0 and 1
        public void SetEntity()
        {
            for (int i = 0; i < PlayerConditions.GetLength(0); i++)
            {
                for (int j = 0; j < PlayerConditions.GetLength(1); j++)
                {
                    double var = rand.Next(2);  //a refresher for using random with specific values https://www.tutorialsteacher.com/articles/generate-random-numbers-in-csharp
                    PlayerConditions[i, j] = var;
                }
            }
        }
    }

    //calling every run
    public class Enemy : IEntity
    {
        //similar structure as Player class
        public double[,] EnemyConditions = new double[1, 6];
        Random rand = new Random();

        public Enemy()
        {
            SetEntity();
        }

        public void SetEntity()
        {
            for (int i = 0; i < EnemyConditions.GetLength(0); i++)
            {
                for (int j = 0; j < EnemyConditions.GetLength(1); j++)
                {
                    double val = rand.Next(2);
                    EnemyConditions[i, j] = val;
                }
            }
        }
    }

    //using the same menthod
    public interface IEntity
    {
        public void SetEntity();

    }
}
