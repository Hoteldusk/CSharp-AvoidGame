using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge_Game
{
    public class Bullet
    {
        public int X = 1;
        public int Y = 1;
        public int Dir = 0; //0.상,1.우상,2.우,3.우하,4.하,5.좌하,6.좌,7.좌상
        public char image = 'x';

        public int SpawnPosition = RandomState.SpawnPosition_RandomNumber();

    }
}
