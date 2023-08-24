using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Dodge_Game
{
    public class Player : Program
    {

        public int x;  // 플레이어 x 좌표
        public int y;  // 플레이어 y 좌표
        private readonly char images; // 플레이어 이미지 문자

        // 플레이어 초기좌표, 이미지 설정 생성자
        public Player(char inImages, int inX, int inY)
        {
            x = inX;
            y = inY;
            images = inImages;
        }

        // 각 값들을 읽기전용으로 제공
        public char Image => images;
        public int X => x;
        public int Y => y;

        // 플레이어 방향따라 움직여주는 메서드
        public void Move(ConsoleKeyInfo inkey)
        {
            switch (inkey.Key)
            {
                //1개 입력
                case ConsoleKey.UpArrow:
                    if (y <= 0) break; //제한값 이탈시 값 변경 불가
                    --y;
                    break;
                case ConsoleKey.DownArrow:
                    if (y >= limit_Y) break;
                    ++y;
                    break;
                case ConsoleKey.LeftArrow:
                    if (x <= 0) break;
                    --x;
                    break;
                case ConsoleKey.RightArrow:
                    if (x >= limit_X) break;
                    ++x;
                    break;

                default:
                    return;
            }
            
        }
    }
}
