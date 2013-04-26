using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project_kindergarten
{
    public partial class Game : Form
    {
        public Game()
        {
            // Seems to be working
            InitializeComponent();
            _pnl_xnaRendering.Paint += RedrawWindow;
            _pnl_xnaRendering.MouseClick += PanelOnClick;
        }

        private void PanelOnClick(object sender, MouseEventArgs e)
        {
            // Seems to be working
            OnMouseClick(e);
        }

        private void RedrawWindow(object sender, PaintEventArgs e)
        {
            // Seems to be working
            _graphicsDevice.Clear(_backgroundColor);

            // Do drawing

            _graphicsDevice.Present();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // This part seems to be working
            RedrawWindow(null, e);
            base.OnPaint(e);
        }

        

        protected override void OnMouseClick(MouseEventArgs e)
        {
            // Testing some stuff for future usage
            base.OnMouseClick(e);
            System.Drawing.Point RealPosition = System.Windows.Forms.Cursor.Position;
            if(RealPosition.X > e.X)
            {
                MessageBox.Show("Inside panel");
            }
            else
            {
                MessageBox.Show("Outside panel");
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            // Seems to be working, too
            if(e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                switch(_random.Next(0, 3))
                {
                    case 0:
                        if(_backgroundColor == Microsoft.Xna.Framework.Color.Black)
                        {
                            _backgroundColor = Microsoft.Xna.Framework.Color.Gray;
                            break;
                        }
                        _backgroundColor = Microsoft.Xna.Framework.Color.Black;
                        break;
                    case 1:
                        if(_backgroundColor == Microsoft.Xna.Framework.Color.Blue)
                        {
                            _backgroundColor = Microsoft.Xna.Framework.Color.PaleVioletRed;
                            break;
                        }
                        _backgroundColor = Microsoft.Xna.Framework.Color.Blue;
                        break;
                    case 2:
                        if(_backgroundColor == Microsoft.Xna.Framework.Color.Green)
                        {
                            _backgroundColor = Microsoft.Xna.Framework.Color.Red;
                            break;
                        }
                        _backgroundColor = Microsoft.Xna.Framework.Color.Green;
                        break;
                }
            }
        }

        public void StartGame()
        {
            this.Show();
            while(true)
            {
                // Logic and stuff goes here
                this.OnPaint(null);
                Application.DoEvents();
            }
        }

        public void InitializeGame()
        {
            // Load unloaded textures and all that great stuff
            // Might be a good idea to also wait for all clients here?
            setupGraphicsDevice();
        }

        private void setupGraphicsDevice()
        {
            PresentationParameters pp = new PresentationParameters();
            pp.BackBufferHeight = _pnl_xnaRendering.Height;
            pp.BackBufferWidth = _pnl_xnaRendering.Width;
            pp.IsFullScreen = false;
            pp.MultiSampleCount = 0;
            pp.DepthStencilFormat = DepthFormat.Depth24;
            pp.DeviceWindowHandle = _pnl_xnaRendering.Handle;
            pp.PresentationInterval = PresentInterval.Immediate;
            pp.BackBufferFormat = SurfaceFormat.Color;

            _graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, pp);
        }

        #region Variables

        private GraphicsDevice _graphicsDevice;
        private Microsoft.Xna.Framework.Color _backgroundColor = Microsoft.Xna.Framework.Color.Green;
        private Random _random = new Random();

        #endregion
    }
}
