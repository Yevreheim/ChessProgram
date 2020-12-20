using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using ClassesLibrary;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Board GameBoard;
        private GameState GS = new GameState();
        private int TurnCount = new int();
        private readonly MoveChecker MoveCheck = new MoveChecker();
        private static readonly PieceSet BlackHolder = new PieceSet();
        private static readonly PieceSet WhiteHolder = new PieceSet();
        private Player PlayerOne = new Player("Player 1", Color.White);
        private Player PlayerTwo = new Player("Player 2", Color.Black);
        private readonly string[] XArray = new string[] { "h", "a", "b", "c", "d", "e", "f", "g" };
        private enum PlayerColour
        {
            Black,
            White
        }
        private static PlayerColour PC = PlayerColour.White;
        private SolidBrush BlackFill = new SolidBrush(Color.Black);
        private SolidBrush WhiteFill = new SolidBrush(Color.White);
        private SolidBrush RedFill = new SolidBrush(Color.Red);
        private SolidBrush BlueFill = new SolidBrush(Color.Aquamarine);
        private SolidBrush DarkBlueFill = new SolidBrush(Color.BlueViolet);
        private SolidBrush DarkRedFill = new SolidBrush(Color.RosyBrown);
        private SolidBrush DeepRedFill = new SolidBrush(Color.DarkSalmon);

        private Font Font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
        private Font Font2 = new Font("Times New Roman", 16, FontStyle.Bold, GraphicsUnit.Pixel);

        public Form1()
        {
            GameBoard = new Board();
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }
        public void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            RefreshForm();
        }
        public void TextRefresh()
        {
            button2.Text = "Player Turn: " + PC.ToString();
            button2.Refresh();

            button3.Text = "GameState: " + GS.GameStateCheck;
            button3.Refresh();

            TurnCount = GS.Turn;
            button4.Text = "Turn: " + TurnCount.ToString();
            button4.Refresh();
            
            richTextBox1.Refresh();
            richTextBox2.Refresh();
        }
        private void RefreshForm()
        {
            //Initiliaising Things
            Bitmap BitMapping = new Bitmap(1000, 800);
            Graphics G = Graphics.FromImage(BitMapping);
            PieceSet BlackHolder = GameBoard.FetchPieceSet("BlackSet");
            PieceSet WhiteHolder = GameBoard.FetchPieceSet("WhiteSet");
            PieceSet[] SetHolder = new PieceSet[] { BlackHolder, WhiteHolder };
            Player[] Players = new Player[] { PlayerOne, PlayerTwo };
            int MouseX = PointToClient(Cursor.Position).X;
            int MouseY = PointToClient(Cursor.Position).Y;
            BoardDraw(G, WhiteFill, BlackFill, BitMapping);
            AxesDraw(G, Font1, BlackFill);
            PieceSelection(MouseX, MouseY, G, Font1, BlueFill, DeepRedFill, SetHolder, GameBoard, Players);
            CheckCheck(SetHolder);
            PieceDraw(G, Font2, DarkRedFill,DarkBlueFill,SetHolder);
            TextRefresh();

        }
        public void PieceSelection(int MouseX, int MouseY, Graphics G,Font F,SolidBrush B1, SolidBrush B2,PieceSet[] P, Board GB, Player[] Players)
        {
            foreach (Player Player in Players)
            {
                for (int i = 0; i < P.Length; i++)
                {
                    CollisionMoveCheck CMC = new CollisionMoveCheck();
                    PieceSet PieceSetTemp = new PieceSet();
                    if (P[i].ColourTag == Color.Black)
                    {
                        PieceSetTemp = P.Last();
                    }
                    else if (P[i].ColourTag == Color.White)
                    {
                        PieceSetTemp = P.First();
                    }
                    foreach (Piece Piece in P[i].PieceList())
                    {

                        if (Player.PlayerColour.ToString().Contains(PC.ToString()) && Player.PlayerColour == P[i].ColourTag)
                        {
                            //Move Piece After Selection
                            if (Piece.Selected == true)
                            {
                                foreach (Moves M in Piece.MoveList())
                                {
                                    int MX = M.RowSpace * 80 - 80;
                                    int MY = M.ColumnSpace * 80 - 80;
                                    if (MouseX > MX && MouseX < MX + 80 && MouseY > MY && MouseY < MY + 80)
                                    {
                                        //If Movement Worked
                                        if (Piece.PieceName.Contains("Pawn"))
                                        {
                                            Piece.HasMoved = true;
                                            P[i].FetchPawn(Piece.PieceName).PawnDiagonalNW = false;
                                            P[i].FetchPawn(Piece.PieceName).PawnDiagonalNE = false;
                                            P[i].FetchPawn(Piece.PieceName).PawnDiagonalSW = false;
                                            P[i].FetchPawn(Piece.PieceName).PawnDiagonalSE = false;
                                        }
                                        if (Piece.PieceName.Contains("Rook") || Piece.PieceName.Contains("King"))
                                        {
                                            Piece.HasMoved = true;
                                        }
                                        //Swap Player Controls
                                        if (P[i].ColourTag == Color.Black)
                                        {
                                            PC = PlayerColour.White;
                                            int Y1 = (Piece.ColumnSpace - 40) / 80 * -1 + 8;
                                            int Y2 = MY / 80 * -1 + 8;
                                            richTextBox1.Text += "\n" + XArray[Piece.SquareAssignment % 8] + Y1 + Piece.PieceName.Substring(0, 1) + XArray[M.SquareAssignment % 8] + Y2;
                                        }
                                        else if (P[i].ColourTag == Color.White)
                                        {
                                            PC = PlayerColour.Black;
                                            int Y1 = (Piece.ColumnSpace - 40) / 80 * -1 + 8;
                                            int Y2 = MY / 80 * -1 + 8;
                                            richTextBox2.Text += "\n" + XArray[Piece.SquareAssignment%8] + Y1 + Piece.PieceName.Substring(0,1) + XArray[M.SquareAssignment%8] + Y2;

                                        }
                                        //Movement
                                        Piece.Selected = false;
                                        Piece.RowSpace = MX + 40;
                                        Piece.ColumnSpace = MY + 40;
                                        Piece.SquareAssignment = M.SquareAssignment;
                                        //Delete Piece
                                        foreach (Piece P2 in PieceSetTemp.PieceList())
                                        {
                                            if (Piece.RowSpace == P2.RowSpace && Piece.ColumnSpace == P2.ColumnSpace)
                                            {
                                                if (P2.PieceName.Contains("King"))
                                                {
                                                    GS.CheckMate = true;
                                                    GS.C = P[i].ColourTag;
                                                    return;
                                                }
                                                PieceSetTemp.RemovePiece(PieceSetTemp.FetchPiece(P2.PieceName));
                                                Console.WriteLine("Piece is getting eaten: " + P2.PieceName);
                                            }
                                        }

                                        //TurnUpdater
                                        GS.Turn = GS.Turn + 1;

                                        Console.WriteLine(Piece.PieceName + " Has Moved to: " + Piece.RowSpace + "," + Piece.ColumnSpace);
                                    }
                                }
                                Piece.Selected = false;
                               // break;
                            }
                            //If Mouse clicks on piece
                            else if (MouseX < Piece.RowSpace + 40 && MouseX > Piece.RowSpace - 40 && MouseY < Piece.ColumnSpace + 40 && MouseY > Piece.ColumnSpace - 40)
                            {
                                Console.WriteLine("==============");
                                Console.WriteLine("Piece Selected");
                                Console.WriteLine("Piece Square: " + Piece.SquareAssignment);
                                Console.WriteLine("Piece Colour: " + Piece.PieceColour);
                                Console.WriteLine("Piece Name:" + Piece.PieceName);
                                Console.WriteLine("X Position: " + Piece.RowSpace);
                                Console.WriteLine("Y Position: " + Piece.ColumnSpace);
                                G.FillRectangle(B1, Piece.RowSpace - 40, Piece.ColumnSpace - 40, 80, 80);
                                int[] MoveHolder = new int[] { };
                                Piece.ListofMoves = new List<Moves>();
                                Piece.Selected = true;

                                //PawnCheck, checks current state of pawns
                                PawnCheck(Piece, PieceSetTemp, P, i);
                                int[] ShownMoves = Piece.MovementShow();
                                MoveHolder = ShownMoves;

                                //Draws Possible Moves
                                foreach (int j in MoveHolder)
                                {
                                    if (Piece.PieceName.Contains("Pawn"))
                                    {
                                        foreach (Moves Ma in Piece.MoveList())
                                        {
                                            Console.WriteLine("DesignationTest: " + Ma.SquareAssignment);
                                        }
                                    }
                                    if (j > 0 && j < 65)
                                    {
                                        int GBX = GB.Squares[j - 1].RowSpace * 80 - 80;
                                        int GBY = GB.Squares[j - 1].ColumnSpace * 80 - 80;
                                        //Add Moves to Piece
                                        int cGBX = GB.Squares[j - 1].RowSpace;
                                        int cGBY = GB.Squares[j - 1].ColumnSpace;
                                        int DesignationOverride = GB.Squares[j - 1].SquareAssignment + 1;
                                        //Stops OverLap
                                        bool Limit = false;
                                        Piece.CanSeeAttack = false;
                                        // Opposite COlour
                                        Color C = new Color();
                                        if (Piece.Colour == P[i].ColourTag)
                                        {
                                            C = P[i].OppositeColour();
                                        }
                                        //Move Filter
                                        foreach (Piece P2 in P[i].PieceList())
                                        {
                                            //If Move is beyond possible moves, skip to next move
                                            if (CMC.CollisionCheck(P[i].PieceList(), Piece, cGBX, cGBY, DesignationOverride, C))
                                            {
                                                Limit = true;
                                                break;
                                            }
                                            //Scans if Enemy Piece is seen on Board
                                            else if (CMC.CollisionCheck(PieceSetTemp.PieceList(), Piece, cGBX, cGBY, DesignationOverride, C))
                                            {
                                                Piece.CanSeeAttack = true;
                                                foreach (Piece P3 in PieceSetTemp.PieceList())
                                                {
                                                    if (CMC.CollisionAttackCheck(PieceSetTemp.PieceList(), Piece, cGBX, cGBY, DesignationOverride, C))
                                                    {
                                                        Limit = true;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        //If an illegal possible move was found, skip it
                                        if (Limit)
                                        {
                                            continue;
                                        }
                                        //Checks if Piece on other side is on the move
                                        Console.WriteLine("Moves to: " + cGBX.ToString() + "," + cGBY.ToString());
                                        Console.WriteLine("Designation Square: " + DesignationOverride);
                                        //ADD MOVE POST FILTER
                                        Piece.AddMove(cGBX, cGBY, DesignationOverride);
                                        if (Piece.CanSeeAttack)
                                        {
                                            G.FillRectangle(B2, GBX, GBY, 80, 80);
                                        }
                                        else if (Piece.CanSeeAttack == false)
                                        {
                                            G.FillRectangle(B1, GBX, GBY, 80, 80);
                                        }
                                        Pen BlackPen = new Pen(Color.Black, 1);
                                        G.DrawRectangle(BlackPen, GBX, GBY, 80, 80);
                                    }
                                }
                            }
                            else
                            {
                                Piece.Selected = false;
                            }

                        }
                    }
                }
            }
            Console.WriteLine("MouseX: " + MouseX);
            Console.WriteLine("MouseY: " + MouseY);
            
        }
        public void CheckCheck(PieceSet[] P)
        {
            CollisionMoveCheck CMC = new CollisionMoveCheck();
            PieceSet PieceSetTemp = new PieceSet();
            foreach (PieceSet PS in P)
            {
                if (PS.ColourTag == Color.Black)
                {
                    PieceSetTemp = P.Last();
                }
                else if (PS.ColourTag == Color.White)
                {
                    PieceSetTemp = P.First();
                }
                if (CMC.CheckinCheckSet(PS,PieceSetTemp))
                {
                    GS.GameStateHolder = PieceSetTemp.ColourTag + " In Check";
                    Console.WriteLine("YA IN CHECK");
                    break;
                }
                else
                {
                    GS.GameStateHolder = null;
                }
            }
            TextRefresh();
        }
        public void PawnCheck(Piece Piece, PieceSet PieceSet, PieceSet[] P, int i)
        {
            foreach (Piece P3 in PieceSet.PieceList())
            {
                if (Piece.PieceName.Contains("Pawn"))
                {
                    //Up
                    if (Piece.SquareAssignment - 9 == P3.SquareAssignment)
                    {
                        P[i].FetchPawn(Piece.PieceName).PawnDiagonalNW = true;
                    }
                    if (Piece.SquareAssignment - 7 == P3.SquareAssignment)
                    {
                        P[i].FetchPawn(Piece.PieceName).PawnDiagonalNE = true;
                    }
                    //Down
                    if (Piece.SquareAssignment + 9 == P3.SquareAssignment)
                    {
                        P[i].FetchPawn(Piece.PieceName).PawnDiagonalSE = true;
                    }
                    if (Piece.SquareAssignment + 7 == P3.SquareAssignment)
                    {
                        P[i].FetchPawn(Piece.PieceName).PawnDiagonalSW = true;
                    }
                }
            }
        }
        public void BoardDraw(Graphics G, SolidBrush Fill1, SolidBrush Fill2, Bitmap BM)
        {
            for (int b = 0; b < 8; b++)
            {
                for (int h = 0; h < 8; h++)
                {
                    if ((h % 2 == 0 && b % 2 == 0) || (h % 2 != 0 && b % 2 != 0))
                        G.FillRectangle(Fill1, b * 80, h * 80, 80, 80);
                    else if ((h % 2 == 0 && b % 2 != 0) || (h % 2 != 0 && b % 2 == 0))
                        G.FillRectangle(Fill2, b * 80, h * 80, 80, 80);
                }
            }
            G.FillRectangle(Fill1, 0, 640, 1000, 160);
            BackgroundImage = BM;
        }
        public void PieceDraw(Graphics G, Font F, SolidBrush B1, SolidBrush B2, PieceSet[] SetHolder)
        {
            //Prints Black Set and White Set
            for (int i = 0; i < 2; i++)
            {
                foreach (Piece P in SetHolder[i].PieceList())
                {
                    if (P.PieceColour == Color.Black)
                    {
                        G.DrawString(P.PieceName, F, B1, P.RowSpace - 30, P.ColumnSpace);

                    }
                    else if (P.PieceColour == Color.White)
                    {
                        G.DrawString(P.PieceName, F, B2, P.RowSpace - 30, P.ColumnSpace);
                    }
                }
            }
        }
        public void AxesDraw(Graphics G,Font F, SolidBrush B)
        {
            int Y = 1;
            string[] Alphabet = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };
            for (int i = 600; i > 0; i = i - 80)
            {
                G.DrawString(Y.ToString(), F, B, 650, i);
                G.DrawString(Alphabet[Alphabet.Length-Y],F,B,i,650);
                Y++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GameBoard = new Board();
            GS = new GameState();
            richTextBox1.Clear();
            richTextBox2.Clear();
            RefreshForm();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
