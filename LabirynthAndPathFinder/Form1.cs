namespace LabirynthAndPathFinder
{
    public partial class Form1 : Form
    {

        private Board _board;
        private int _tileSize;

        public Form1()
        {
            InitializeComponent();

            _tileSize = 20;
            _board = new Board(pictureBox.Width, pictureBox.Height, _tileSize);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _board.Draw(e.Graphics);
        }

        private void pictureBox_DoubleClick(object sender, MouseEventArgs e)
        {
            _board.HandleClick(e.Location, e.Button);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None) return;
            _board.HandleMove(e.Location, e.Button);
            pictureBox.Invalidate();
        }

        private void genMazeBtn_Click(object sender, EventArgs e)
        {
            _board.CreateMaze();
            pictureBox.Invalidate();
        }

        private void solveBtn_Click(object sender, EventArgs e)
        {
            _board.Solve();
            pictureBox.Invalidate();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            _board.ClearScreen();
            pictureBox.Invalidate();
        }
    }
}