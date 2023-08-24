using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Game
{
    public class RandomState : Program
    {
        public static int CreateBullet_Xcoordinate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int X = rand.Next(1, limit_X);

            return X;
        }
        public static int CreateBullet_Ycoordinate()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int Y = rand.Next(1, limit_Y);

            return Y;
        }
        public static int SpawnPosition_RandomNumber()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int Num = rand.Next(4);

            return Num;
        }
        public static int Dir_Random_Exclude_Up()
        {
            Random Firstrand = new Random(DateTime.Now.Millisecond);
            int Firstrand_num = Firstrand.Next(2,7);

            return Firstrand_num;
        }
        public static int Dir_Random_Exclude_Down()
        {
            Random Firstrand = new Random(DateTime.Now.Millisecond);
            int Firstrand_num = Firstrand.Next(0, 100);
            if (Firstrand_num <= 59)
            {
                Random Secondrand = new Random(DateTime.Now.Millisecond);
                int Second_num = Secondrand.Next(0, 3);
                return Second_num;
            }
            else
            {
                Random Secondrand = new Random(DateTime.Now.Millisecond);
                int Second_num = Secondrand.Next(6, 8);
                return Second_num;
            }
        }
        public static int Dir_Random_Exclude_Left()
        {
            Random Firstrand = new Random(DateTime.Now.Millisecond);
            int Firstrand_num = Firstrand.Next(0, 5);

            return Firstrand_num;
        }
        public static int Dir_Random_Exclude_Right()
        {
            Random Firstrand = new Random(DateTime.Now.Millisecond);
            int Firstrand_num = Firstrand.Next(0, 100);
            if (Firstrand_num <= 79)
            {
                Random Secondrand = new Random(DateTime.Now.Millisecond);
                int Second_num = Secondrand.Next(4, 8);
                return Second_num;
            }
            else
            {
                return 0;
            }
        }
    }

}
