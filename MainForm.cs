using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Home0409_11_8_Maze
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Graphics _mazeGraph;
        private Color _pathColor;
        private Color _wallColor;
        private int _cellSize = 30;

        //private List<Rectangle> _rectangles = new List<Rectangle>();
        private List<Point> _points = new List<Point>();

        private Point _walker = new Point(0, 30);
        private Point _walkerOld = new Point(0, 30);

        private void MainForm_Shown(object sender, EventArgs e)
        {
            _mazeGraph = mazePanel.CreateGraphics();
            InitMaze();
            CreateMazeBoard();
        }
        private void InitMaze()
        {
            _pathColor = Color.LightGray;
            _wallColor = Color.DarkGray;
        }

        #region Walker

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up)
            {
                if (!CheckPoints(_walker.X, _walker.Y - 30) && (_walker.Y - 30) >= 0)
                {
                    _walker.Y -= 30;
                    DrawWalker();
                }

            }
            else if (e.KeyCode == Keys.Down)
            {
                if (!CheckPoints(_walker.X, _walker.Y + 30) && (_walker.Y + 30) <= 390)
                {
                    _walker.Y += 30;
                    DrawWalker();
                }
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (!CheckPoints(_walker.X - _cellSize, _walker.Y) && (_walker.X - 30) >= 0)
                {
                    _walker.X -= _cellSize;
                    DrawWalker();
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (!CheckPoints(_walker.X + _cellSize, _walker.Y) && (_walker.X + _cellSize) <= 570)
                {
                    _walker.X += 30;
                    DrawWalker();
                }
            }
            
        }
        
        private bool CheckPoints(int x, int y)
        {
            foreach(var p in _points)
            {
                if (p.X == x && p.Y == y) return true;
            }
            return false;
        }

        private bool CheckWin()
        {
            if ((_walker.X == 570 && _walker.Y == 150) || (_walker.X == 240 && _walker.Y == 390)) return true;
            return false;
        }
        private void GameOver()
        {
            MessageBox.Show("You won!");
        }
        #endregion

        #region Board
        private void CreateMazeBoard()
        {
            DrawBoard();
            DrawWalker();
        }

        private void DrawBoard()
        {
            InitPoints();
            foreach (var p in _points)
            {
                _mazeGraph.FillRectangle(Brushes.DarkGray, p.X, p.Y, _cellSize, _cellSize);
                _mazeGraph.DrawRectangle(new Pen(Color.Black, 1), p.X, p.Y, _cellSize, _cellSize);
                //_mazeGraph.DrawString($"{p.X}", SystemFonts.DefaultFont, Brushes.Red, p.X, p.Y);
                //_mazeGraph.DrawString($":{p.Y}", SystemFonts.DefaultFont, Brushes.Red, p.X + 3, p.Y + 15);
            }
            _mazeGraph.FillRectangle(Brushes.LightPink, 570, 150, _cellSize, _cellSize);
            _mazeGraph.FillRectangle(Brushes.LightPink, 240, 390, _cellSize, _cellSize);
        }

        private void DrawWalker()
        {
            _mazeGraph.FillEllipse(Brushes.LightGray, _walkerOld.X + 3, _walkerOld.Y + 3, 24, 24);
            _mazeGraph.FillEllipse(Brushes.Aquamarine, _walker.X + 5, _walker.Y + 5, 20, 20);
            _walkerOld = _walker;
            if (CheckWin()) GameOver();
        }

        private void InitPoints()
        {
            for (int i = 0; i <= 570; i+=30)
            {
                _points.Add(new Point(i, 0));
                if(i != 240) _points.Add(new Point(i, 390));
            }
            for (int i = 30; i <= 390; i+=30)
            {
                if(i!=30) _points.Add(new Point(0, i));
                if(i!=150) _points.Add(new Point(570, i));
            }
            _points.AddRange(new List<Point>()
            {
                new Point(60, 0),
                new Point(60, 30),
                new Point(60, 60),
                new Point(60, 90),
                new Point(60, 120),
                new Point(60, 150),
                new Point(60, 210),
                new Point(60, 240),
                new Point(60, 270),
                new Point(60, 300),
                new Point(60, 330),

                new Point(120, 60),
                new Point(120, 90),
                new Point(120, 120),
                new Point(120, 150),
                new Point(120, 180),

                new Point(180, 30),
                new Point(180, 60),

                new Point(240, 90),
                new Point(240, 60),

                new Point(300, 30),
                new Point(300, 60),

                new Point(360, 90),
                new Point(360, 60),

                new Point(120, 360),
                new Point(120, 330),
                new Point(120, 300),
                new Point(120, 270),
                new Point(90, 210),
                new Point(120, 210),
                new Point(120, 180),
                new Point(120, 150),
                new Point(120, 120),
                new Point(150, 120),
                new Point(180, 120),
                new Point(210, 120),
                new Point(240, 120),
                new Point(270, 120),
                new Point(300, 120),
                new Point(330, 120),
                new Point(360, 120),

                new Point(150, 270),
                new Point(180, 270),
                new Point(180, 240),
                new Point(180, 210),
                new Point(180, 180),

                new Point(210, 270),
                new Point(240, 270),
                new Point(300, 270),
                new Point(330, 270),

                new Point(180, 330),
                new Point(210, 330),
                new Point(240, 330),
                new Point(270, 330),

                new Point(300, 330),
                new Point(330, 330),
                new Point(330, 360),
                
                new Point(390, 330),
                new Point(390, 300),
                new Point(390, 270),
                new Point(390, 240),
                new Point(390, 210),
                new Point(390, 180),
                new Point(420, 150),

                new Point(240, 150),
                new Point(240, 180),

                new Point(240, 210),
                new Point(270, 210),
                new Point(300, 210),
                new Point(300, 150),
                new Point(360, 180),

                new Point(330, 210),
                new Point(360, 210),

                new Point(420, 30),
                new Point(420, 60),
                new Point(420, 90),
                new Point(420, 120),
                new Point(450, 150),

                new Point(420, 270),
                new Point(450, 270),
                new Point(480, 270),

                new Point(480, 60),
                new Point(450, 120),

                new Point(450, 360),
                new Point(450, 330),

                new Point(510, 330),
                new Point(510, 300),
                new Point(510, 270),

                new Point(540, 210),
                new Point(510, 210),
                new Point(480, 210),
                new Point(450, 210),

                new Point(510, 180),
                new Point(510, 150),
                new Point(510, 120),
                new Point(510, 90),
                new Point(510, 60),

                new Point(510, 150)

             });
        }

        #endregion

        private void newButton_Click(object sender, EventArgs e)
        {
            _walker = new Point(0, 30);
            DrawWalker();
            _mazeGraph.FillRectangle(Brushes.LightPink, 570, 150, _cellSize, _cellSize);
            _mazeGraph.FillRectangle(Brushes.LightPink, 240, 390, _cellSize, _cellSize);
        }
    }
}
