using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tao.OpenGl;
using Tao.Platform.Windows;
using ObjLoader.Loader.Loaders;
using Tao.FreeGlut;
namespace Deneme2
{
    public partial class Form1 : Form
    {
        private bool invert = false;
        private uint[] texture;
        private string textName = null;
        private float alfa = 0;
        private float beta = 0;
        private float gamma = 0;
        private LoadResult result;

        public Form1()
        {
            InitializeComponent();
            OpenGlControl.InitializeContexts();
            int height = OpenGlControl.Height;
            int width = OpenGlControl.Width;

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[4] { 1, 0.5F, 1, 0 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glDepthFunc(Gl.GL_LEQUAL);
            Gl.glHint(Gl.GL_PERSPECTIVE_CORRECTION_HINT, Gl.GL_NICEST);
            Gl.glClearColor(0, 0, 0, 1);

            Gl.glViewport(0, 0, width, height);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluPerspective(45.0f, (double)width / (double)height, 0.01f, 5000.0f);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);

            var objLoaderFactory = new ObjLoaderFactory();
            var objLoader = objLoaderFactory.Create();

            var fileStream = new FileStream("bardak.obj", FileMode.Open, FileAccess.Read);
            result = objLoader.Load(fileStream);
        }


        private void LoadTexture(string filename)
        {

            texture = new uint[1];
            Bitmap image = new Bitmap(filename);
            image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bitmapdata;
            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

            bitmapdata = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            Gl.glGenTextures(1, texture);
            Gl.glBindTexture(Gl.GL_TEXTURE_2D, texture[0]);
            Gl.glTexImage2D(Gl.GL_TEXTURE_2D, 0, (int)Gl.GL_RGB8, image.Width, image.Height,
                0, Gl.GL_BGR_EXT, Gl.GL_UNSIGNED_BYTE, bitmapdata.Scan0);
            Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MIN_FILTER, (int)Gl.GL_LINEAR);
            Gl.glTexParameteri((int)Gl.GL_TEXTURE_2D, (int)Gl.GL_TEXTURE_MAG_FILTER, (int)Gl.GL_LINEAR);

            image.UnlockBits(bitmapdata);
            image.Dispose();
        }

        private void buttonKeyDown(object sender, KeyEventArgs e)
        {
            invert = false;
            if (e.KeyCode == Keys.ShiftKey)
                invert = true;
        }

        private void buttonKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                invert = false;
        }

        private void buttonX_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert)
                alfa -= 5;
            else
                alfa += 5;
            alfa = (alfa + 360) % 360;
            labelX.Text = alfa.ToString();
            OpenGlControl.Refresh();
        }

        private void buttonY_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert)
                beta -= 5;
            else
                beta += 5;
            beta = (beta + 360) % 360;
            labelY.Text = beta.ToString();
            OpenGlControl.Refresh();
        }

        private void buttonZ_MouseClick(object sender, MouseEventArgs e)
        {
            if (invert)
                gamma -= 5;
            else
                gamma += 5;
            gamma = (gamma + 360) % 360;
            labelZ.Text = gamma.ToString();
            OpenGlControl.Refresh();
        }
        private void myPaint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Glu.gluLookAt(2, 2, 2, 0, 0, 0, 0, 1, 0);

            Gl.glRotatef(alfa, 1, 0, 0);
            Gl.glRotatef(beta, 0, 1, 0);
            Gl.glRotatef(gamma, 0, 0, 1);

            for (int i = 0; i < result.Groups.Count; i++)
            {
                var g = result.Groups[i];
                if (result.Textures.Count > 0)
                    Gl.glEnable(Gl.GL_TEXTURE_2D);
                else
                    Gl.glDisable(Gl.GL_TEXTURE_2D);

                for (int j = 0; j < g.Faces.Count; j++)
                {
                    var f = g.Faces[j];
                    var m = g.Material;
                    if (m != null)
                    {
                        float[] av = { m.AmbientColor.X, m.AmbientColor.Y, m.AmbientColor.Z, 1 };
                        Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, av);
                        float[] dv = { m.DiffuseColor.X, m.DiffuseColor.Y, m.DiffuseColor.Z, 1 };
                        Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, dv);
                        float[] sv = { m.SpecularColor.X, m.SpecularColor.Y, m.SpecularColor.Z, 1 };
                        Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_SPECULAR, sv);
                        float sh = m.SpecularCoefficient;
                        Gl.glMaterialf(Gl.GL_FRONT, Gl.GL_SHININESS, sh);
                        if (m.DiffuseTextureMap != null)
                        {
                            if (textName != m.DiffuseTextureMap)
                                LoadTexture(m.DiffuseTextureMap);
                        }
                        textName = m.DiffuseTextureMap;
                    }


                    Gl.glBegin(Gl.GL_POLYGON);
                    for (int k = 0; k < f.Count; k++)
                    {
                        int x = f[k].VertexIndex;
                        var v = result.Vertices[x - 1];
                        int y = f[k].NormalIndex;
                        var n = result.Normals[y - 1];

                        if (textName != null)
                        {
                            int z = f[k].TextureIndex;
                            var t = result.Textures[z - 1];
                            Gl.glTexCoord2f(t.X, t.Y);
                        }
                        Gl.glNormal3f(n.X, n.Y, n.Z);
                        Gl.glVertex3f(v.X, v.Y, v.Z);
                    }
                    Gl.glEnd();
                }
            }
        }
    }
}