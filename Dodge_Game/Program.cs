using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;

namespace Dodge_Game
{
    public class Program
    {
        [DllImport("gotoxy.dll")]
        public extern static void gotoxy(int x, int y);

        static public int Console_width = 100;
        static public int Console_height = 40;
        static float score = 1;
        static public int limit_X = Console_width - 2;
        static public int limit_Y = Console_height - 10;

        //각 오브젝트들의 좌표를 담을 2차원 배열 생성
        static int[,] Map = new int[Console_height, Console_width];

        static void Main(string[] args)
        {

            int SpawnNumber = 0;
            int SpawnMaxNumber = 1000;
            //콘솔 창 사이즈 설정
            InitializeConsole(Console_width, Console_height);

            //프레임 구현
            const int waitTick = 1000 / 120;
            int lastTick = 0;
            int currentTick;
            //플레이어 객체 생성
            Player player = new Player('o', Console_width / 2, (Console_height - 5) / 2);

            //총알 동적배열 생성
            List<Bullet> bullets = new List<Bullet>();

            while (true)
            {
                
                Score();
               // gotoxy(player.X, player.Y);
               // Console.Write(player.Image);

                //경과 시간값 받아와서 저장
                currentTick = System.Environment.TickCount;


                if (currentTick - lastTick < waitTick)
                {
                    continue;
                }
                else
                {
                    lastTick = currentTick;

                    if (SpawnNumber < SpawnMaxNumber)
                    {
                        bullets.Add(new Bullet());
                        InitializeBullet(bullets, SpawnNumber);
                        SpawnNumber++;
                    }



                    // bulletsMove(bullets);
                    //for (int i = 0; i < bullets.Count; i++)
                    // 좌표검사
                    // 삭제
                    // 삽입
                    // 초기화
                    // 이동

                    if (Console.KeyAvailable == true)
                    {

                        //현재 커서위치로 문자이동 디버그시 예외발생
                        //gotoxy(player.X, player.Y);
                        Map[player.Y , player.X] = 0;
                        ConsoleKeyInfo key = Console.ReadKey();
                        player.Move(key);
                        Map[player.Y , player.X] += 3;
                    }

                    for (int i = 0; i < bullets.Count; i++)
                    {
                        Bullet_Check_And_Move(bullets, i);
                    }

                    ShowMap();
                }
 
            }
        }

        static void InitializeConsole(int width, int height)
        {
            Console.Title = "Bullet Avoid";
            Console.SetWindowSize(width, height);
            Console.Clear();
            Console.CursorVisible = false;
        }

        static void Score()
        {
            score += 0.0005f;

            gotoxy((Console_width - 7) / 2, Console_height - 8);
            Console.Write("Score : " + (int)score);
        }

        static void InitializeBullet(List<Bullet> bullets, int Number)
        {
            switch (bullets[Number].SpawnPosition)
            {
                case 0:
                    bullets[Number].X = RandomState.CreateBullet_Xcoordinate();
                    bullets[Number].Y = 1;
                    bullets[Number].Dir = RandomState.Dir_Random_Exclude_Up();
                    break;
                case 1:
                    bullets[Number].X = RandomState.CreateBullet_Xcoordinate();
                    bullets[Number].Y = limit_Y;
                    bullets[Number].Dir = RandomState.Dir_Random_Exclude_Down();
                    break;
                case 2:
                    bullets[Number].X = 1;
                    bullets[Number].Y = RandomState.CreateBullet_Ycoordinate();
                    bullets[Number].Dir = RandomState.Dir_Random_Exclude_Left();
                    break;
                case 3:
                    bullets[Number].X = limit_X;
                    bullets[Number].Y = RandomState.CreateBullet_Ycoordinate();
                    bullets[Number].Dir = RandomState.Dir_Random_Exclude_Right();
                    break;
                default:
                    break;
            }
        }

        static void Bullet_Check_And_Move(List<Bullet> bullets, int i)
        {
            Map[bullets[i].Y, bullets[i].X] = 1;


                if (bullets[i].X == limit_X || bullets[i].Y == limit_Y || bullets[i].X == 0 || bullets[i].Y == 0)
                {
                    Map[bullets[i].Y, bullets[i].X] = 0;

                    bullets.RemoveAt(i);
                    bullets.Insert(i, new Bullet());
                    InitializeBullet(bullets, i);
                    BulletMove(bullets, i);
                }
                else
                {   
                    BulletMove(bullets, i);
                }
        }

        static void BulletMove(List<Bullet> bullets, int i)
        {
            //변경 전 좌표 초기화
            Map[bullets[i].Y, bullets[i].X] = 0;

            //좌표 변경
            switch (bullets[i].Dir)
            {
                case 0: //상 방향
                    --bullets[i].Y;
                    break;
                case 1: //우상 방향
                    ++bullets[i].X;
                    --bullets[i].Y;
                    break;
                case 2: //우 방향
                    ++bullets[i].X;
                    break;
                case 3: //우하 방향
                    ++bullets[i].X;
                    ++bullets[i].Y;
                    break;
                case 4: //하 방향
                    ++bullets[i].Y;
                    break;
                case 5: //좌하 방향
                    --bullets[i].X;
                    ++bullets[i].Y;
                    break;
                case 6: //좌 방향
                    --bullets[i].X;
                    break;
                case 7: //좌상 방향
                    --bullets[i].X;
                    --bullets[i].Y;
                    break;
            }

            //좌표 변경 후 저장
            Map[bullets[i].Y, bullets[i].X] = 1;
        }

        static void InitializeMap()
        {
            for (int i = 0; i < Console_height; ++i)
            {
                for (int j = 0; j < Console_width; ++j)
                {
                    Map[i, j] = 0;
                }
            }
        }

        static void ShowMap()
        {
            //static int[,] Map = new int[Console_width, Console_height];
            for (int i = 0; i < Console_height; ++i)
            {

                for (int j = 0; j < Console_width; ++j)
                {
                    if (Map[i, j] == 1)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('x');
                    }
                    else if (Map[i, j] == 0)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(' ');
                    }
                    else if (Map[i, j] == 3)
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write('o');
                    }
                }
            } 
        }
    }
}
