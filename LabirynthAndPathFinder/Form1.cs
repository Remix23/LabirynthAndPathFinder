namespace LabirynthAndPathFinder
{
    public partial class Form1 : Form
    {

        private Board _board;
        private int _tileSize;

        public Form1()
        {
            InitializeComponent();

            _tileSize = 50;
            _board = new Board(pictureBox.Width, pictureBox.Height, _tileSize);
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            _board.Draw(e.Graphics);
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            _board.HandleClick(e.Location, e.Button);
            pictureBox.Invalidate();
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.None) return;
            _board.HandleClick(e.Location, e.Button);
            pictureBox.Invalidate();
        }
    }
}