using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
namespace Maze
{
    public partial class Form1 : Form
    {
        #region 变量和属性

        protected Random rand = new Random(); //随机数对象的实例化
        protected static PictureBox[,] map;  //存放pictureBox，迷宫格子
        protected static int[,] numMap;  //保存迷宫格子的数字状态
        protected static int[,] path;    //保存寻路的数组
        protected int pointX = 0; // 当前所在的位置-行，用于玩游戏时保存玩家所在的位置
        protected int pointY = 0; // 当前所在的位置-列
        protected static List<Image> PathImageList = new List<Image>();  //橘黄色的背景图片
        protected static List<Image> ImageList = new List<Image>();      //白色背景的图片
        protected static List<Image> LineImageList = new List<Image>();  //红线路径图片
        protected static int width = 30;    //迷宫的宽度-列数
        protected static int height = 10;   //迷宫的高度-行数
        protected static Queue<Point> MapCreateProcess = new Queue<Point>();

        protected delegate void SetTextValueCallBack(string strValue);
        //声明回调
        protected static SetTextValueCallBack setCallBack;
        public class Point
        {
            public Point(int x, int y, int b=0)
            {
                X = x;
                Y = y;
                B = b;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int B { get; set; }//没什么用
        }



        //是否搜寻到了终点
        public static bool isCompleted { get; set; } = false;

        public static Point StartingPoing { get; set; }

        public static Point EndingPoing { get; set; }

        public bool bFillPath
        {
            set => FillPath.Checked = value;
            get => FillPath.Checked;
        }
        public bool bLinePath
        {
            set => LinePath.Checked = value;
            get => LinePath.Checked;
        }
        public bool bDFSPath
        {
            set => DFSPath.Checked = value;
            get => DFSPath.Checked;
        }

        public bool bBFSPath
        {
            set => BFSPath.Checked = value;
            get => BFSPath.Checked;
        }

        public static bool bsLinePath
        {
            set;get;
        }
        public static bool bsFillPath 
        {
            set; get;
        } 

        public static bool bsDFSPath
        {
            set; get;
        }

        public static bool bsBFSPath
        {
            set; get;
        }

        public int iShowSpeed
        {
            set => tbarShowSpeed.Value = value;
            get => tbarShowSpeed.Value;
        }

        public static int isShowSpeed
        {
            set;get;
        }
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //白色图片
            ImageList.Add(Properties.Resources._0);
            ImageList.Add(Properties.Resources._1);
            ImageList.Add(Properties.Resources._2);
            ImageList.Add(Properties.Resources._3);
            ImageList.Add(Properties.Resources._4);
            ImageList.Add(Properties.Resources._5);
            ImageList.Add(Properties.Resources._6);
            ImageList.Add(Properties.Resources._7);
            ImageList.Add(Properties.Resources._8);
            ImageList.Add(Properties.Resources._9);
            ImageList.Add(Properties.Resources._10);
            ImageList.Add(Properties.Resources._11);
            ImageList.Add(Properties.Resources._12);
            ImageList.Add(Properties.Resources._13);
            ImageList.Add(Properties.Resources._14);
            ImageList.Add(Properties.Resources._15);
            //橘黄色背景的图片
            PathImageList.Add(Properties.Resources.d0);
            PathImageList.Add(Properties.Resources.d1);
            PathImageList.Add(Properties.Resources.d2);
            PathImageList.Add(Properties.Resources.d3);
            PathImageList.Add(Properties.Resources.d4);
            PathImageList.Add(Properties.Resources.d5);
            PathImageList.Add(Properties.Resources.d6);
            PathImageList.Add(Properties.Resources.d7);
            PathImageList.Add(Properties.Resources.d8);
            PathImageList.Add(Properties.Resources.d9);
            PathImageList.Add(Properties.Resources.d10);
            PathImageList.Add(Properties.Resources.d11);
            PathImageList.Add(Properties.Resources.d12);
            PathImageList.Add(Properties.Resources.d13);
            PathImageList.Add(Properties.Resources.d14);
            PathImageList.Add(Properties.Resources.d15);


            LineImageList.Add(Properties.Resources.p0);
            LineImageList.Add(Properties.Resources.p1);
            LineImageList.Add(Properties.Resources.p2);
            LineImageList.Add(Properties.Resources.p3);
            LineImageList.Add(Properties.Resources.p4);
            LineImageList.Add(Properties.Resources.p5);
            LineImageList.Add(Properties.Resources.p6);
            LineImageList.Add(Properties.Resources.p7);
            LineImageList.Add(Properties.Resources.p8);
            LineImageList.Add(Properties.Resources.p9);
            LineImageList.Add(Properties.Resources.p10);
            LineImageList.Add(Properties.Resources.p11);
            LineImageList.Add(Properties.Resources.p12);
            LineImageList.Add(Properties.Resources.p13);
            LineImageList.Add(Properties.Resources.p14);
            LineImageList.Add(Properties.Resources.p15);

    
            isShowSpeed = tbarShowSpeed.Value ;
            initModel();
        }

        private void ModelChanged(object sender, EventArgs e)
        {
            initModel();
        }

        private void initModel()
        {
            bsLinePath = bLinePath;
            bsFillPath = bFillPath;
            bsDFSPath = bDFSPath;
            bsBFSPath = bBFSPath;
        }

        private void tbarShowSpeed_Scroll(object sender, EventArgs e)
        {
            isShowSpeed = iShowSpeed;
        }



        //按钮-创建迷宫
        private void Btn_createMap_Click(object sender, EventArgs e)
        {
            //btn_createMap.Enabled = false;
            setCallBack = new SetTextValueCallBack(SetTextValue);
            Reset();
            width = (int)nudCol.Value;
            height = (int)nudRow.Value;
            path = new int[height, width];
            map = new PictureBox[height, width];
            numMap = new int[height, width];
            DrawCheckerboar();
            CreateNumMap(height / 2, width / 2, 0);//在迷宫的中间开始遍历
            //CreateNumMap(0, 0, 0);
            if (checkBox1.Checked)
            {
                var show =new PathShow.DFSDelayPathShow();
                show.ShowMap();
            }
            else
                CreateMap();
            SetStartingEndingPoint(0, 0, height - 1, width - 1);
        }

        public void SetTextValue(string strMsg)
        {
            strMsg = $"共经过节点[{strMsg}]个";
            if (bsBFSPath)
                BFSInfo.Text = strMsg;
            else
                DFSInfo.Text = strMsg;
        }

        private void SetStartingEndingPoint(int sX,int sY,int eX,int eY)
        {
            StartingPoing = new Point(sX, sY);
            EndingPoing = new Point(eX, eY);
        }

        //绘制pictureBox，数组数据初始化
        private void DrawCheckerboar()
        {

            int currentPoint = 0;
            int chessLength = 30;
            int initX = 10;
            int initY = 10;
            int _x = initX;
            int _y = initY;
            PictureBox tmpBox;
            for (int x = 0; x < height * width; x++)
            {
                if (currentPoint % width == 0)
                {
                    _x = initX;
                    _y = currentPoint / width * chessLength + initY;
                }
                else
                {
                    _x += chessLength;
                }
                tmpBox = new PictureBox
                {
                    Left = _x,
                    Top = _y,
                    Width = chessLength,
                    Height = chessLength
                };
                map[currentPoint / width, currentPoint % width] = tmpBox;
                numMap[currentPoint / width, currentPoint % width] = -1;   //-1表示未遍历过
                Controls.Add(tmpBox);
                tmpBox.BringToFront();
                tmpBox = null;
                currentPoint++;
            }
        }
       
        //创建迷宫状态数据
        private void CreateNumMap(int m, int n, int o)
        {
            List<int> directs = new List<int> { 0, 1, 2, 3 };   //存储未用的方向。0123分别表示上-右-下-左
            int last = 0;
            //1：左0001
            //2：下0010
            //4：右0100
            //8：上1000
            switch (o)
            {
                case 1:
                    last = 4;
                    break;
                case 2:
                    last = 8;
                    break;
                case 4:
                    last = 1;
                    break;
                case 8:
                    last = 2;
                    break;
            }
            numMap[m, n] = last;
            Point p = new Point(m, n, numMap[m, n]);
            MapCreateProcess.Enqueue(p);
            //test-begin
            string s = "";
            for (int f = 0; f < height; f++)
            {
                for (int g = 0; g < width; g++) s += numMap[f, g].ToString() + ",";
                s += "\r\n";
            }
            txt_str.Text = s;
            //test-end
            while (directs.Count > 0)
            {
                int x = m;
                int y = n;
                int d = rand.Next(directs.Count);
                int t = 0;
                switch (directs[d])
                {
                    case 0:
                        x--;
                        t = 8;
                        break;
                    case 1:
                        y++;
                        t = 4;
                        break;
                    case 2:
                        x++;
                        t = 2;
                        break;
                    case 3:
                        y--;
                        t = 1;
                        break;
                }
                directs.RemoveAt(d);    //删除使用过的方向
                if (x < height && y < width && x >= 0 && y >= 0 && numMap[x, y] == -1)//没有超出数组边界，格子未被遍历过，则为true
                {
                    last = t ^ last;    //异或操作
                    numMap[m, n] = last;
                    //test - begin
                    string ss = "";
                    for (int f = 0; f < height; f++)
                    {
                        for (int g = 0; g < width; g++) ss += numMap[f, g].ToString() + ",";
                        ss += "\r\n";
                    }
                    txt_str.Text = ss;
                    //test - end
                    p = new Point(m, n, numMap[m, n]);
                    MapCreateProcess.Enqueue(p);
                    CreateNumMap(x, y, t);  //递归
                    //p = new Point(m, n, numMap[m, n]);
                    //MapCreateProcess.Enqueue(p);
                }
            }
        }

        //生成迷宫
        private void CreateMap()
        {

            numMap[0, 0] = numMap[0, 0] ^ 8;//打开一个缺口，作为进入口。
            numMap[height - 1, width - 1] = numMap[height - 1, width - 1] ^ 2;//打开一个缺口作为出去口。
            for (int m = 0; m < height; m++)
            {
                for (int n = 0; n < width; n++)
                {
                    int x = numMap[m, n];
                    map[m, n].Image = ImageList[x];
                }
            }
            map[0, 0].Image = PathImageList[numMap[0, 0]]; //给第一格子换成橘黄色的背景
        }


        //按钮
        private void btn_test_Click(object sender, EventArgs e)
        {
            PathShow ps = new PathShow();
            path = new int[height, width];
            CreateMap();
            ps.Pathfinding(StartingPoing.X, StartingPoing.Y);
        }

        //重置当前迷宫
        private void Reset()
        {
            if (map != null)
            {
                for (int m = 0; m < height; m++)
                {
                    for (int n = 0; n < width; n++)
                    {
                        int x = numMap[m, n];
                        map[m, n].Image = null;
                    }
                }
            }
        }

        //重写键盘事件,用于走迷宫
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (numMap != null)
            {
                int m = pointX;
                int n = pointY;
                int direct = 0;
                switch (keyData)
                {
                    case Keys.Up:
                        m--;
                        direct = 8;
                        break;
                    case Keys.Down:
                        m++;
                        direct = 2;
                        break;
                    case Keys.Left:
                        n--;
                        direct = 1;
                        break;
                    case Keys.Right:
                        n++;
                        direct = 4;
                        break;
                }
                if (m < height && n < width && m >= 0 && n >= 0 && (numMap[pointX, pointY] & direct) != 0)
                {
                    map[pointX, pointY].Image = ImageList[numMap[pointX, pointY]];
                    map[m, n].Image = PathImageList[numMap[m, n]];
                    lb_x.Text = m.ToString();
                    lb_y.Text = n.ToString();
                    pointX = m;
                    pointY = n;
                    if (m == height - 1 && n == width - 1)
                        MessageBox.Show("win!");
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
    public class PathShow : Form1
    {
        public static PathShow createOperate(string Operator)
        {
            PathShow show = null;
            switch (Operator)
            {
                case "1":
                    show = new FillPathShow();
                    break;
                case "2":
                    show = new LinePathShow();
                    break;
                case "3":
                    show = new DFSDelayPathShow();
                    break;
                case "4":
                    show = new BFSDelayPathShow();
                    break;
            }
            return show;
        }

        public virtual void ShowLine() { }
        public virtual void FindLine(int x, int y)
        {
            for (int i = 0; i <= 3; i++)
            {
                int m = x;
                int n = y;
                int direct = 0;
                switch (i)
                {
                    case 0:
                        m--;
                        direct = 8;
                        break;
                    case 1:
                        n++;
                        direct = 4;
                        break;
                    case 2:
                        m++;
                        direct = 2;
                        break;
                    case 3:
                        n--;
                        direct = 1;
                        break;
                }
                if (m < height && n < width && m >= 0 && n >= 0 && (numMap[x, y] & direct) != 0 && path[m, n] == 0)
                {
                    path[x, y] = 1;
                    Pathfinding(m, n);
                    path[x, y] = 0;
                }
            }
        }
        public void Pathfinding(int x, int y)
        {
            string z = "0";
            if (bsFillPath)
            {
                z = "1";
            }
            else if (bsLinePath)
            {
                z = "2";
            }
            else if (bsDFSPath)
            {
                z = "3";
            }
            else if (bsBFSPath)
            {
                z = "4";
            }
            var show = createOperate(z);
            
            if (x == EndingPoing.X && y == EndingPoing.Y)
            {    
                show.ShowLine();
            }
            else
            {   
                show.FindLine(x, y);
            }
        }

        public class LinePathShow : PathShow
        {
            //寻路
            public override void FindLine(int x, int y)
            {


            }
            public override void ShowLine()
            {
                for (int f = 0; f < height; f++)
                {
                    for (int g = 0; g < width; g++)
                    {
                        if (path[f, g] != 0)
                        {
                            map[f, g].Image = LineImageList[numMap[f, g]];
                        }
                    }
                }
            }
        }

        public class FillPathShow : PathShow
        {
            //寻路
            public override void ShowLine()
            {
                for (int f = 0; f < height; f++)
                {
                    for (int g = 0; g < width; g++)
                    {
                        if (path[f, g] != 0)
                        {
                            map[f, g].Image = PathImageList[numMap[f, g]];
                        }
                    }
                }
            }
        }

        //DFS
        public class DFSDelayPathShow : PathShow
        {
            private static Queue<Point> DFSpath = new Queue<Point>();    //保存深度搜索的过程数组

            public void ShowMap()
            {
                Thread td = new Thread(new ThreadStart(ShowMap2));
                td.IsBackground = true;
                td.Start();
                //td.Join();
            }

            public void ShowMap2()
            {
                while (MapCreateProcess.Count != 0)
                {
                    var p = MapCreateProcess.Dequeue();
                    var x = numMap[p.X, p.Y];
                    map[p.X, p.Y].Image = PathImageList[numMap[p.X, p.Y]];
                    Thread.Sleep(isShowSpeed);
                    map[p.X, p.Y].Image = ImageList[numMap[p.X, p.Y]];
                    Thread.Sleep(isShowSpeed);
                }
            }

            //寻路
            public override void FindLine(int x, int y)
            {
                for (int i = 0; i <= 3; i++)
                {
                    int m = x;
                    int n = y;
                    int direct = 0;
                    switch (i)
                    {
                        case 0:
                            m--;
                            direct = 8;
                            break;
                        case 1:
                            n++;
                            direct = 4;
                            break;
                        case 2:
                            m++;
                            direct = 2;
                            break;
                        case 3:
                            n--;
                            direct = 1;
                            break;
                    }
                    if (m < height && n < width && m >= 0 && n >= 0 && (numMap[x, y] & direct) == 0)
                    {
                        Point p = new Point(x, y, path[x, y]);
                        DFSpath.Enqueue(p);
                    }
                    if (m < height && n < width && m >= 0 && n >= 0 && (numMap[x, y] & direct) != 0 && path[m, n] == 0 && !isCompleted)
                    {
                        path[x, y] = 1;
                        Point p = new Point(x, y, path[x, y]);
                        DFSpath.Enqueue(p);
                        Pathfinding(m, n);
                        if (isCompleted)
                            return;
                        path[x, y] = 0;
                        p = new Point(x, y, path[x, y]);
                        DFSpath.Enqueue(p);
                    } 
                }
            }

            public override void ShowLine()
            {
                isCompleted = true;
                Thread td = new Thread(new ThreadStart(DelayShow));
                td.IsBackground = true;
                td.Start();
               // td.Join();
            }
            public void DelayShow()
            {
                //DFSInfo.Invoke(setCallBack, DFSpath.Count.ToString());
                while (DFSpath.Count != 0)
                {
                    var p = DFSpath.Dequeue();          
                    map[p.X, p.Y].Image = PathImageList[numMap[p.X, p.Y]];
                    Thread.Sleep(isShowSpeed/2);
                    map[p.X, p.Y].Image = LineImageList[numMap[p.X, p.Y]];
                    Thread.Sleep(isShowSpeed/2);
                }
                isCompleted = false;

            }
        }

        //BFS
        public class BFSDelayPathShow : PathShow
        {
            private Queue<Point> BFSpath = new Queue<Point>();    
            private Queue<Point> BFSDelaypath = new Queue<Point>();//保存广度搜索的过程数组
            public override void FindLine(int x, int y)
            {     
                Pathfinding(EndingPoing.X,EndingPoing.Y);
            }

            public override void ShowLine()
            {
                Thread td = new Thread(new ThreadStart(BFSShow));
                td.IsBackground = true;
                td.Start();
                //td.Join();
            }
            public void BFSShow()
            {
                int x = StartingPoing.X;
                int y = StartingPoing.Y;
                while (true)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        int m = x;
                        int n = y;
                        int direct = 0;
                        switch (i)
                        {
                            case 0:
                                m--;
                                direct = 8;
                                break;
                            case 1:
                                n++;
                                direct = 4;
                                break;
                            case 2:
                                m++;
                                direct = 2;
                                break;
                            case 3:
                                n--;
                                direct = 1;
                                break;
                        }
                        if (m < height && n < width && m >= 0 && n >= 0 && (numMap[x, y] & direct) != 0& path[m, n]==0)
                        {
                            path[x, y] = 1;
                            Point p = new Point(m, n, path[x, y]);
                            BFSpath.Enqueue(p);
                            BFSDelaypath.Enqueue(p);
                        }

                    }
                    var p2 = BFSpath.Dequeue();
                    x = p2.X;
                    y = p2.Y;
                    Thread.Sleep(1);
                    if (x == height - 1 && y == width - 1)
                        break;
                }
               // setCallBack = new SetTextValueCallBack(SetTextValue);
               //if(BFSInfo.IsHandleCreated)
               // BFSInfo.Invoke(setCallBack, BFSDelaypath.Count.ToString());
                while (BFSDelaypath.Count != 0)
                {
                    var p3 = BFSDelaypath.Dequeue();
                    map[p3.X, p3.Y].Image = LineImageList[numMap[p3.X, p3.Y]];
                    Thread.Sleep(isShowSpeed);
                }
            }
        }

        public class Status
        {
            
        }
    }
}