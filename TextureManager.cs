/*
 * Programmer: Marcus Östlund
 * Purpose: Handle textures and make sure they are only loaded once.
 * Date: 2013-03-27
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_kindergarten
{
    class TextureManager
    {
        // Public stuff
        public System.Drawing.Bitmap getTexture(string fileName)
        {
            // Loop through list and return image.
            foreach(_texture t in _textureList)
            {
                if(string.Compare(fileName, t.filename) == 0)
                    return t.Texture;
            }

            // loadTexture either return null or a Bitmap.
            return loadTexture(fileName);
        }
        // Private stuff
        private class _texture
        {
            public System.Drawing.Bitmap Texture;
            public string filename;
            public _texture(string Filename)
            {
                try
                {
                    Texture = new System.Drawing.Bitmap(Filename);
                }
                catch(System.Exception e)
                {
                    Log.Write(e.ToString() + "\n");
                    throw(e);
                }
                filename = Filename;
            }
        }
        private System.Drawing.Bitmap loadTexture(string Filename)
        {
            // Create temp _texture for loading purpose
            _texture temp;
            try
            {
                temp = new _texture(Filename);
            }
            catch(System.Exception e)
            {
                return null;
            }
            // No exception = file was found and loaded into memory and add to list 
            _textureList.Add(temp);

            // Success.
            return temp.Texture;
        }
        static private List<_texture> _textureList;
    }
}
