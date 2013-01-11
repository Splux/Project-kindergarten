/*
 * Programmer: Marcus Östlund
 * Description: Class to handle Buttons, both animated and non-animated.
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    class AnimButton
    {
        #region variables
        private System.Drawing.Bitmap _buttonImage;
        private System.Drawing.Bitmap _spriteSheet;

        private System.Drawing.Point _buttonLocation;
        private System.Drawing.Point _animOffset;

        private int _cols;

        private bool _animated = false;
        
        System.Timers.Timer _animateTimer;
        #endregion

        public AnimButton()
        {
            _buttonImage = null;
            _spriteSheet = null;
        }

        public AnimButton(string filepath, System.Drawing.Point location, bool animated, int cols, int rows, int animtime)
        {
            try
            {
                _spriteSheet = new System.Drawing.Bitmap(@filepath);
                _buttonLocation = location;
                _cols = cols;
                _animated = animated;
                if (_animated)
                {
                    // Set initial "frame" for animations
                    int xRowSize = _buttonImage.Size.Width / cols;
                    int yRowSize = _buttonImage.Size.Height / rows;
                    // Loops through and get/set the pixels
                    for (int x = 0; x < xRowSize; x++)
                    {
                        for (int y = 0; y < yRowSize; y++)
                        {
                            _buttonImage.SetPixel(x, y, _spriteSheet.GetPixel(x, y));
                        }
                    }
                    // Activate timer and add Elapsed event.
                    // Possible deadlock in the future?
                    _animateTimer = new System.Timers.Timer(animtime);
                    _animateTimer.AutoReset = true;
                    _animateTimer.Elapsed += new System.Timers.ElapsedEventHandler(handleAnimations);
                }
                else
                {
                    _buttonImage = _spriteSheet;
                    _spriteSheet = null;
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                throw new Exception("File not found: " + filepath + "\n");
            }
        }
        // Draw button on screen
        public void Draw(System.Drawing.Graphics graphic)
        {
            graphic.DrawImage(_buttonImage, _buttonLocation);
        }

        private void handleAnimations(object obj, System.Timers.ElapsedEventArgs evArgs)
        {
            
        }
    }
}