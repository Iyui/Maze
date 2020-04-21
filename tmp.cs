using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maze
{
    class tmp
    {
        int height = 10;
        int width = 10;
        int[,] map = new int[10, 10];
        //寻路
        private bool Pathfinding(int x, int y)
        {
            if (x == height && y == width)
            {
                string s = "";
                for (int f = 0; f < height + 2; f++)
                {
                    for (int g = 0; g < width + 2; g++) s += map[f, g].ToString();
                    s += "</br>";
                }
                return true;
            }
            else
            {
                for (int i = 0; i <= 3; i++)
                {
                    int m = x;
                    int n = y;
                    switch (i)
                    {
                        case 0:
                            m = x - 1;
                            break;
                        case 1:
                            n = y + 1;
                            break;
                        case 2:
                            m = x + 1;
                            break;
                        case 3:
                            n = y - 1;
                            break;
                    }
                    if (map[m, n] == 0)
                    {
                        map[m, n] = 2;
                        Pathfinding(m, n);
                        map[m, n] = 0;
                    }
                }
                return false;
            }
        }

        //初始化迷宫
        private void btn_init_Click(object sender, EventArgs e)
        {
            for (int m = 0; m < height + 2; m++)
            {
                for (int n = 0; n < width + 2; n++)
                {
                    map[m, n] = 8;
                }
            }
            for (int x = 0; x < height + 2; x++)
            {
                map[x, 0] = 1;
                map[x, width + 1] = 1;
            }
            for (int y = 0; y < width + 2; y++)
            {
                map[0, y] = 1;
                map[height + 1, y] = 1;
            }

            string s = "";
            for (int f = 0; f < height + 2; f++)
            {
                for (int g = 0; g < width + 2; g++) s += map[f, g].ToString();
                s += "\r\n";
            }
        }

        //绘制迷宫
        private void CreateMap(int m, int n)
        {
            map[m, n] = 0;
            List<int> directs = new List<int> { 0, 1, 2, 3 };
            Random rand = new Random();
            while (directs.Count > 0)
            {
                //test
                string s = "";
                for (int f = 0; f < height + 2; f++)
                {
                    for (int g = 0; g < width + 2; g++) s += map[f, g].ToString();
                    s += "\r\n";
                }
                //test
                int x = m;
                int y = n;
                int d = rand.Next(directs.Count);
                switch (directs[d])
                {
                    case 0:
                        x--;
                        break;
                    case 1:
                        y++;
                        break;
                    case 2:
                        x++;
                        break;
                    case 3:
                        y--;
                        break;
                }
                directs.RemoveAt(d);
                if (map[x, y] == 8)
                    CreateMap(x, y);
            }
        }
    }
}
//map = new int[height+2,width+2] ;
//{
//{1,1,1,1,1,1,1,1},
//{1,2,1,1,1,1,1,1},//1
//{1,0,0,0,0,0,1,1},//2
//{1,1,1,0,1,0,0,1},//3
//{1,1,0,0,1,0,1,1},//4
//{1,1,0,1,0,0,0,1},//5
//{1,1,0,0,0,1,0,1},//6
//{1,1,1,1,1,1,1,1}
//};