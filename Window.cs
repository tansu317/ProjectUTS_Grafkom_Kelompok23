using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

namespace Grafkom1
{
    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Window : GameWindow
    {
        Asset3D[] _object3dNicho = new Asset3D[20];
        Asset3D[] _object3dSutan = new Asset3D[20];
        Asset3D[] _object3dKenneth = new Asset3D[20];

        double _time5, _time6 = 0, _time7 = 1.5, _time8 = 1, _time9, _time10;

        bool isNight = false;

        //nicho
        double _time, _time2, _time3, _time4;

        //Nicho

        int turn = 0, turn2 = 0;
        float degr, degr1, degr2 = 0, degr3;

        //Nicho
        Matrix4 temp = Matrix4.Identity;
        Matrix4 temp0 = Matrix4.Identity;
        Matrix4 temp02 = Matrix4.Identity;
        Matrix4 temp1 = Matrix4.Identity;
        Matrix4 temp2 = Matrix4.Identity;
        Matrix4 temp3 = Matrix4.Identity;
        Matrix4 temp4 = Matrix4.Identity;
        Matrix4 temp5 = Matrix4.Identity;
        Matrix4 temp6 = Matrix4.Identity;
        Matrix4 temp7 = Matrix4.Identity;
        Matrix4 temp8 = Matrix4.Identity;

        //SUTAN
        Matrix4 temp9 = Matrix4.Identity;
        Matrix4 temp10 = Matrix4.Identity;
        Matrix4 temp11 = Matrix4.Identity;
        //Matrix4 temp12 = Matrix4.Identity;
        //Matrix4 temp13 = Matrix4.Identity;
        Matrix4 temp14 = Matrix4.Identity;
        Matrix4 temp15 = Matrix4.Identity;
        Matrix4 temp19 = Matrix4.Identity;

        //Kenneth
        Matrix4 temp16 = Matrix4.Identity;
        Matrix4 temp17 = Matrix4.Identity;
        Matrix4 temp18 = Matrix4.Identity;
        Matrix4 temp20 = Matrix4.Identity;
        Matrix4 temp21 = Matrix4.Identity;


        Camera _camera;
        bool _firstMove = true;
        Vector2 _lastPos;
        Vector3 _objectPos = new Vector3(0, 0, 0);
        float _rotationSpeed = 20f;

        //mulut
        Asset2D mouth = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                1.0f, 0, 0
            });

        Asset2D mouth2 = new Asset2D(new float[]
        {

        }, new uint[]
        {

        },
            new float[]
            {
                1.0f, 0, 0
            });
        //corak baju 
        Asset2D shirt = new Asset2D(new float[1080], new uint[]
      {

      },
          new float[]
          {
                1.0f, 0, 1
          });
        Asset2D shirtBezier = new Asset2D(new float[]
       {

       }, new uint[]
       {

       },
           new float[]
           {
                1, 0, 1
           });
        //alis
        Asset2D eyebrow = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                0, 0, 0
            });
        Asset2D eyebrow2 = new Asset2D(new float[1080], new uint[]
        {

        },
            new float[]
            {
                0, 0, 0
            });
        Asset2D eyebrowBezier = new Asset2D(new float[]
       {

       }, new uint[]
       {

       },
           new float[]
           {
                0, 0, 0
           });
        Asset2D eyebrowBezier2 = new Asset2D(new float[]
       {

       }, new uint[]
       {

       },
           new float[]
           {
                0, 0, 0
           });


        //SUTAN
        //les1
        Asset2D moon = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 0, 1.0f });

        Asset2D moonBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 1.0f, 1.0f, 0f });

        //les2
        Asset2D les = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });

        Asset2D lesBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 0, 1.0f, 1.0f });



        //KENNETH
        Asset2D kurva = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 1.0f, 1.5f, 1.0f });

        Asset2D kurvaBeazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 1.0f, 1.5f, 1.0f });

        Asset2D kurva2 = new Asset2D(
            new float[1080],
            new uint[] { },
            new float[] { 1, 1.0f, 1.0f });

        Asset2D kurva2Beazier = new Asset2D(
            new float[] { },
            new uint[] { },
            new float[] { 1, 1.0f, 1.0f });

        Asset2D segitiga = new Asset2D(
           new float[] { 1.0f, 1.0f, 1.0f },
           new uint[] { },
           new float[] { 0, 1.0f, 1.0f });




        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        public Matrix4 generateArbRotationMatrix(Vector3 axis, Vector3 center, float degree)
        {
            var rads = MathHelper.DegreesToRadians(degree);

            var secretFormula = new float[4, 4] {
                { (float)Math.Cos(rads) + (float)Math.Pow(axis.X, 2) * (1 - (float)Math.Cos(rads)), axis.X* axis.Y * (1 - (float)Math.Cos(rads)) - axis.Z * (float)Math.Sin(rads),    axis.X * axis.Z * (1 - (float)Math.Cos(rads)) + axis.Y * (float)Math.Sin(rads),   0 },
                { axis.Y * axis.X * (1 - (float)Math.Cos(rads)) + axis.Z * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Y, 2) * (1 - (float)Math.Cos(rads)), axis.Y * axis.Z * (1 - (float)Math.Cos(rads)) - axis.X * (float)Math.Sin(rads),   0 },
                { axis.Z * axis.X * (1 - (float)Math.Cos(rads)) - axis.Y * (float)Math.Sin(rads),   axis.Z * axis.Y * (1 - (float)Math.Cos(rads)) + axis.X * (float)Math.Sin(rads),   (float)Math.Cos(rads) + (float)Math.Pow(axis.Z, 2) * (1 - (float)Math.Cos(rads)), 0 },
                { 0, 0, 0, 1}
            };
            var secretFormulaMatix = new Matrix4
            (
                new Vector4(secretFormula[0, 0], secretFormula[0, 1], secretFormula[0, 2], secretFormula[0, 3]),
                new Vector4(secretFormula[1, 0], secretFormula[1, 1], secretFormula[1, 2], secretFormula[1, 3]),
                new Vector4(secretFormula[2, 0], secretFormula[2, 1], secretFormula[2, 2], secretFormula[2, 3]),
                new Vector4(secretFormula[3, 0], secretFormula[3, 1], secretFormula[3, 2], secretFormula[3, 3])
            );

            return secretFormulaMatix;
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.Enable(EnableCap.DepthTest);
            //Ganti background warna
            if (isNight == false)
            {
                GL.ClearColor(0.529f, 0.807f, 0.921f, 1.0f);
            }

            //NICHO
            temp3 = temp3 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp3 = temp3 * Matrix4.CreateTranslation(0, 0.3f, -1.35f);
            temp1 = temp1 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp1 = temp1 * Matrix4.CreateTranslation(0, -0.095f, 0.25f);
            temp0 = temp0 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270f));
            temp0 = temp0 * Matrix4.CreateTranslation(-1.15f, -0.45f, 0.125f);
            temp0 = temp0 * Matrix4.CreateScale(1, 1.05f, 1);
            temp02 = temp02 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(270f));
            temp02 = temp02 * Matrix4.CreateTranslation(-1.15f, -0.45f, 0.125f);
            temp02 = temp02 * Matrix4.CreateScale(1, 1.05f, 1);


            //badan
            _object3dNicho[0] = new Asset3D(new Vector3(0, 0, 1.0f));
            _object3dNicho[0].createBoxVertices(0, 0, 0, 0.5f, 0.5f, 0.5f);
            //muka
            _object3dNicho[1] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3dNicho[1].createEllipsoid(0.25f, 0.25f, 0.25f, 0, 0.5f, 0);
            //tangan kiri
            _object3dNicho[2] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3dNicho[2].createEllipsoid(0.05f, 0.35f, 0.15f, -0.3f, -0.15f, 0);
            //tangan kanan
            _object3dNicho[3] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3dNicho[3].createEllipsoid(0.05f, 0.35f, 0.15f, 0.3f, -0.15f, 0);
            //kaki kanan, temp6
            _object3dNicho[4] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3dNicho[4].createEllipsoid(0.05f, 0.3f, 0.15f, 0.1f, -0.5f, 0);
            //kaki kiri, temp5
            _object3dNicho[5] = new Asset3D(new Vector3(0.9f, 0.5f, 0.4f));
            _object3dNicho[5].createEllipsoid(0.05f, 0.3f, 0.15f, -0.1f, -0.5f, 0);
            //tiang kincir
            _object3dNicho[6] = new Asset3D(new Vector3(1f, 1.0f, 1.0f));
            _object3dNicho[6].createBoxVertices(-1.6f, 0.35f, 0.5f, 0.5f, 3.5f, 0.25f);

            //land
            _object3dNicho[7] = new Asset3D(new Vector3(0.427f, 0.211f, 0.211f));
            _object3dNicho[7].createBoxVertices(0, -2f, 0, 15.0f, 2.0f, 8.0f);
            //mata kiri
            _object3dNicho[8] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dNicho[8].createEllipsoid(0.05f, 0.05f, 0.05f, -0.1f, 0.6f, 0.25f);
            //mata kanan
            _object3dNicho[9] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dNicho[9].createEllipsoid(0.05f, 0.05f, 0.05f, 0.1f, 0.6f, 0.25f);
            //bola mata kiri
            _object3dNicho[10] = new Asset3D(new Vector3(0f, 0f, 0f));
            _object3dNicho[10].createEllipsoid(0.01f, 0.01f, 0.01f, -0.1f, 0.6f, 0.3f);
            //bola mata kanan
            _object3dNicho[11] = new Asset3D(new Vector3(0f, 0f, 0f));
            _object3dNicho[11].createEllipsoid(0.01f, 0.01f, 0.01f, 0.1f, 0.6f, 0.3f);

            ///topi
            _object3dNicho[12] = new Asset3D(new Vector3(0.5f, 0.0f, 0.5f));
            _object3dNicho[12].createEllipticCone(0.125f, 0.125f, 0.15f, 0, 1.4f, -0.7f, 1);
            //sepatu kanan, temp0
            _object3dNicho[13] = new Asset3D(new Vector3(0, 0, 0));
            _object3dNicho[13].createEllipticParaboloid(0.125f, 0.125f, 0.125f, 1.25f, 0.025f, 0.2f);
            //sepatu kiri, temp02
            _object3dNicho[14] = new Asset3D(new Vector3(0, 0, 0));
            _object3dNicho[14].createEllipticParaboloid(0.125f, 0.125f, 0.125f, 1, 0.025f, 0.2f);
            //gelang
            _object3dNicho[15] = new Asset3D(new Vector3(1f, 1f, 0));
            _object3dNicho[15].createTorus(0.065f, 0.015f, 0.3f, -0.2f, 0.25f);
            //star
            _object3dNicho[16] = new Asset3D(new Vector3(0.960f, 0.941f, 0.278f));
            _object3dNicho[16].createStar(0.125f, 0.125f, 0.125f, 5.5f, 14.5f, 0f);
            //baling baling
            _object3dNicho[17] = new Asset3D(new Vector3(0.5f, 1.0f, 0.5f));
            _object3dNicho[17].createHyperboloidParaboloid(0.015f, 0.015f, 0.015f, -1.5f, 2f, 0.5f);
            //hidung
            _object3dNicho[18] = new Asset3D(new Vector3(1.0f, 0.5f, 0.4f));
            _object3dNicho[18].createEllipsoid(0.025f, 0.0375f, 0.025f, 0f, 0.5f, 0.25f);

            for (int i = 0; i < 19; i++)
            {
                _object3dNicho[i].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }

            //KENPO
            // roket

            //tengah roket
            _object3dKenneth[0] = new Asset3D(new Vector3(1.0f, 0.0f, 0.0f));
            _object3dKenneth[0].createEllipsoid(0.5f, 0.9f, 0.5f, 7.0f, 1.0f, 0.0f);

            //bawah roket
            _object3dKenneth[1] = new Asset3D(new Vector3(1.0f, 1.0f, 0.0f));
            _object3dKenneth[1].createBoxVertices(7.0f, 0.3f, 0.0f, 0.9f, 0.5f, 0.5f);

            //jendela bulat
            _object3dKenneth[2] = new Asset3D(new Vector3(0.0f, 0.0f, 0.0f));
            _object3dKenneth[2].createEllipsoid(0.2f, 0.2f, 0.2f, 7.0f, 1.5f, 0.25f);

            //yang berubah
            //sirip depan 
            degr1 = MathHelper.DegreesToRadians(180f);
            degr3 = MathHelper.DegreesToRadians(90f);
            _object3dKenneth[3] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dKenneth[3].createEllipticCone(0.125f, 0.125f, 0.25f, 7.0f, 0.5f, -0.6f, 1);

            //sirip belakang
            _object3dKenneth[4] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dKenneth[4].createEllipticCone(0.125f, 0.125f, 0.25f, 7.0f, -0.5f, -0.6f, 1);

            //Sirip kiri
            _object3dKenneth[5] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dKenneth[5].createEllipticCone(0.125f, 0.125f, 0.25f, 0.0f, 0.5f, 6.25f, 1);

            //Sirip kanan
            _object3dKenneth[6] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dKenneth[6].createEllipticCone(0.125f, 0.125f, 0.25f, 0.0f, 0.5f, -7.75f, 1);

            _object3dKenneth[7] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dKenneth[7].createStar(0.0125f, 0.0125f, 0.0125f, 7.0f, 1.0f, 0.75f);



            for (int i = 0; i < 8; i++)
            {
                _object3dKenneth[i].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }



            //SUTAN

            temp11 = temp11 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(90f));
            temp11 = temp11 * Matrix4.CreateTranslation(0, 0.3f, -1.35f);

            //baling" belakang
            _object3dSutan[0] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dSutan[0].createBoxVertices(-3.0f, 5.0f, 0.0f, 0.1f, 2.0f, 0.2f);

            //badan pesawat
            _object3dSutan[1] = new Asset3D(new Vector3(1.0f, 0.411f, 0.705f));
            _object3dSutan[1].createEllipsoid(3.5f, 0.8f, 0.9f, 0.3f, 5.2f, -0.5f);

            //kabin pilot
            _object3dSutan[2] = new Asset3D(new Vector3(1.0f, 1.0f, 0.0f));
            _object3dSutan[2].createBoxVertices(0.8f, 4.0f, -0.3f, 1.0f, 0.8f, 0.5f);

            //Perekat baling-baling atas
            _object3dSutan[3] = new Asset3D(new Vector3(1.5f, 1.0f, 0.5f));
            _object3dSutan[3].createEllipticCone(0.4f, 0.4f, 0.5f, 1.0f, 1.0f, -6.2f, 1);

            //scope
            //scope
            _object3dSutan[4] = new Asset3D(new Vector3(0.58f, 0.29411f, 0.0f));
            _object3dSutan[4].createEllipticParaboloid(0.1f, 0.1f, 2.5f, -0.3f, 4.5f, -1.0f);
            //bulan
            _object3dSutan[5] = new Asset3D(new Vector3(0.81f, 0.81f, 0.81f));
            _object3dSutan[5].createEllipsoid(2.5f, 2.5f, 2.5f, -15.3f, -23.0f, -3.5f);

            //baling-baling atas
            _object3dSutan[6] = new Asset3D(new Vector3(1.0f, 1.0f, 1.0f));
            _object3dSutan[6].createBoxVertices(1.0f, 6.4f, 0.0f, 3.0f, 0.2f, 0.2f);




            for (int i = 0; i < 7; i++)
            {
                _object3dSutan[i].load(Constants.path + "shader.vert", Constants.path + "shader.frag", Size.X, Size.Y);
            }

            temp = temp * Matrix4.CreateScale(0.95f);

            //Kenneth
            temp16 = temp16 * Matrix4.CreateRotationX(degr1);
            temp20 = temp20 * Matrix4.CreateRotationY(degr3);
            temp21 = temp21 * Matrix4.CreateRotationY(-degr3);


            _camera = new Camera(new Vector3(0, 3, 5), Size.X / Size.Y);



            //NICHO
            mouth.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            mouth2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            mouth.createCurve(-0.15f, 0.45f, 0.25f);
            mouth.createCurve(-0.1f, 0.4f, 0.25f);
            mouth.createCurve(0.1f, 0.4f, 0.25f);
            mouth.createCurve(0.15f, 0.45f, 0.25f);
            //alis kiri
            eyebrow.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrowBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrow.createCurve(-0.175f, 0.7f, 0.25f);
            eyebrow.createCurve(-0.125f, 0.75f, 0.25f);
            eyebrow.createCurve(-0.075f, 0.75f, 0.25f);
            eyebrow.createCurve(-0.025f, 0.7f, 0.25f);
            //alis kanan
            eyebrow2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrowBezier2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            eyebrow2.createCurve(0.025f, 0.7f, 0.25f);
            eyebrow2.createCurve(0.075f, 0.75f, 0.25f);
            eyebrow2.createCurve(0.125f, 0.75f, 0.25f);
            eyebrow2.createCurve(0.175f, 0.7f, 0.25f);

            shirt.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            shirtBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            shirt.createCurve(0.1f, 0.25f, 0.26f);
            shirt.createCurve(-0.1f, 0.25f, 0.26f);
            shirt.createCurve(-0.1f, 0.1f, 0.26f);
            shirt.createCurve(0.1f, 0.1f, 0.26f);
            shirt.createCurve(0.1f, -0.05f, 0.26f);
            shirt.createCurve(-0.1f, -0.05f, 0.26f);

            //KENNETH
            kurva.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurvaBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva.createCurve(6.7f, 1.4f, 0.4f);
            kurva.createCurve(6.7f, 1.5f, 0.4f);
            kurva.createCurve(7.3f, 2.0f, 0.4f);
            kurva.createCurve(7.3f, 1.5f, 0.4f);

            kurva2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva2Beazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            kurva2.createCurve(7.3f, 1.4f, 0.4f);
            kurva2.createCurve(7.3f, 1.5f, 0.4f);
            kurva2.createCurve(6.7f, 2.0f, 0.4f);
            kurva2.createCurve(6.7f, 1.5f, 0.4f);

            //SUTAN
            moon.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            moonBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");

            moon.createCurve(-2.5f, 4.8f, 0.4f);
            moon.createCurve(-2.5f, 5.5f, 0.4f);
            moon.createCurve(2.5f, 4.0f, 0.4f);
            moon.createCurve(2.5f, 5.5f, 0.4f);

            les.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            lesBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            les.createCurve(-2.5f, 4.8f, 0.4f);
            les.createCurve(-2.5f, 5.4f, 0.4f);
            les.createCurve(2.5f, 5.4f, 0.4f);
            les.createCurve(2.5f, 5.4f, 0.4f);



        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //NICHO
            _time = 0;
            _time2 = 18f;

            degr += (float)(1500f * args.Time);
            _time3 += 20f;
            temp7 = Matrix4.Identity;
            temp8 = Matrix4.Identity;

            _object3dNicho[7].render(3, _time2, temp2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[1].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[2].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[3].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[4].render(3, _time, temp6, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[5].render(3, _time, temp5, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            _object3dNicho[0].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _object3dNicho[10].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[11].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[12].render(3, _time3, temp3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _object3dNicho[14].render(3, _time3, temp02, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[13].render(3, _time3, temp0, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[18].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[16].render(3, _time4, temp4, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[6].render(3, _time2, temp8, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[17].render(3, _time3, temp7, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[8].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[9].render(3, _time, temp, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dNicho[15].render(3, _time3, temp1, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (mouth.getVertices())
            {

                List<float> _verticesTemp = mouth.createCurveBezier();
                mouth2.setVertices(_verticesTemp.ToArray());
                mouth2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                mouth2.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            mouth.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            if (shirt.getVertices())
            {
                List<float> _verticesTemp = shirt.createCurveBezier();
                shirtBezier.setVertices(_verticesTemp.ToArray());
                shirtBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                shirtBezier.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            }
            shirtBezier.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (eyebrow.getVertices())
            {

                List<float> _verticesTemp = eyebrow.createCurveBezier();
                eyebrowBezier.setVertices(_verticesTemp.ToArray());
                eyebrowBezier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                eyebrowBezier.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            eyebrow.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            if (eyebrow2.getVertices())
            {

                List<float> _verticesTemp = eyebrow2.createCurveBezier();
                eyebrowBezier2.setVertices(_verticesTemp.ToArray());
                eyebrowBezier2.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                eyebrowBezier2.render(_time, temp, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            eyebrow2.render(_time, temp, 2, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            //KENNETH


            _time4 += 1f * args.Time;
            temp16 = temp16 * Matrix4.CreateTranslation(-7.0f, 0.0f, 0.0f);
            temp16 = temp16 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time4));
            temp16 = temp16 * Matrix4.CreateTranslation(7.0f, 0.0f, 0.0f);

            temp18 = temp18 * Matrix4.CreateTranslation(-7.0f, 0.0f, 0.0f);
            temp18 = temp18 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time4));
            temp18 = temp18 * Matrix4.CreateTranslation(7.0f, 0.0f, 0.0f);

            temp20 = temp20 * Matrix4.CreateTranslation(-7.0f, 0.0f, 0.0f);
            temp20 = temp20 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time4));
            temp20 = temp20 * Matrix4.CreateTranslation(7.0f, 0.0f, 0.0f);

            temp21 = temp21 * Matrix4.CreateTranslation(-7.0f, 0.0f, 0.0f);
            temp21 = temp21 * Matrix4.CreateRotationY(MathHelper.DegreesToRadians((float)_time4));
            temp21 = temp21 * Matrix4.CreateTranslation(7.0f, 0.0f, 0.0f);

            _object3dKenneth[3].render(3, _time, temp18, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[4].render(3, _time, temp16, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[5].render(3, _time, temp20, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[6].render(3, _time, temp21, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[1].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[0].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[2].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dKenneth[7].render(3, _time, temp17, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());




            if (kurva.getVertices())
            {

                List<float> _verticesTemp = kurva.createCurveBezier();
                kurvaBeazier.setVertices(_verticesTemp.ToArray());
                kurvaBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                kurvaBeazier.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            kurva.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (kurva2.getVertices())
            {

                List<float> _verticesTemp = kurva2.createCurveBezier();
                kurva2Beazier.setVertices(_verticesTemp.ToArray());
                kurva2Beazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                kurva2Beazier.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            kurva2.render(_time, temp17, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());


            //SUTAN
            _time7 = 1.5;
            _time6 = 0;
            _time8 += 1f * args.Time;
            _time10 += 20f * args.Time;

            _time5 += 1500f * args.Time;
            _time6 += 15000f * args.Time;
            _time7 += 15000f * args.Time;
            _time8 += 15000f * args.Time;


            //Rotasi kincir belakang
            temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
            temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time10));
            temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));







            _object3dSutan[0].render(3, _time, temp9, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _object3dSutan[1].render(1, _time, temp15, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());
            _object3dSutan[2].render(1, _time, temp14, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //perekat baling-baling atas
            _object3dSutan[3].render(3, _time3, temp11, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //scope
            _object3dSutan[4].render(3, _time, temp14, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //bulan
            _object3dSutan[5].render(3, _time, temp19, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            _time10 = 0;
            _object3dSutan[6].render(3, _time, temp10, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            //CursorGrabbed = true;



            if (moon.getVertices())
            {

                List<float> _verticesTemp = moon.createCurveBezier();
                moonBeazier.setVertices(_verticesTemp.ToArray());
                moonBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                moonBeazier.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            moon.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            if (les.getVertices())
            {

                List<float> _verticesTemp = les.createCurveBezier();
                lesBeazier.setVertices(_verticesTemp.ToArray());
                lesBeazier.load(Constants.path + "shader.vert", Constants.path + "shader.frag");
                lesBeazier.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());

            }
            les.render(_time, temp14, 3, _camera.GetViewMatrix(), _camera.GetProjectionMatrix());



            for (int i = 0; i < 19; i++)
            {
                _object3dNicho[i].resetEuler();
            }
            for (int i = 0; i < 5; i++)
            {
                _object3dKenneth[i].resetEuler();
            }
            for (int i = 0; i < 7; i++)
            {
                _object3dSutan[i].resetEuler();
            }

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {//bakal jalan stiap ada perubahan ukuran layar
            base.OnResize(e);
            Console.WriteLine("ini Resize");
            GL.Viewport(0, 0, Size.X, Size.Y);
            _camera.AspectRatio = Size.X / (float)Size.Y;
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {//bakal jalan per beberapa FPS frame
            base.OnUpdateFrame(args);

            var input = KeyboardState;
            var mouse_input = MouseState;

            var key = KeyboardState;
            var mouse = MouseState;

            //SUTAN
            if (KeyboardState.IsKeyDown(Keys.F2))
            {
                _time += 20f * args.Time;
                _time10 += 100f * args.Time;
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
                temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time));
                temp9 = temp9 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));
                temp14 = temp14 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp15 = temp15 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp11 = temp11 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);




                temp10 = temp10 * Matrix4.CreateTranslation(0.05f, 0.0f, 0.0f);

            }


            if (KeyboardState.IsKeyDown(Keys.F1))
            {
                _time += 20f * args.Time;
                _time10 += 100f * args.Time;

                temp14 = temp14 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp15 = temp15 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, -5.0f, 0.0f));
                temp9 = temp9 * Matrix4.CreateRotationX(MathHelper.DegreesToRadians((float)_time));
                temp9 = temp9 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp9 = temp9 * Matrix4.CreateTranslation(new Vector3(0.0f, 5.0f, 0.0f));


                temp11 = temp11 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);



                temp10 = temp10 * Matrix4.CreateTranslation(-0.05f, 0.0f, 0.0f);

            }

            //KENNETH
            if (KeyboardState.IsKeyDown(Keys.U))
            {

                _time += 20f * args.Time;
                temp16 = temp16 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp17 = temp17 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp18 = temp18 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp20 = temp20 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);
                temp21 = temp21 * Matrix4.CreateTranslation(0.0f, 0.5f, 0.0f);

            }
            if (KeyboardState.IsKeyDown(Keys.P))
            {

                _time += 20f * args.Time;
                temp16 = temp16 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp17 = temp17 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp18 = temp18 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp20 = temp20 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);
                temp21 = temp21 * Matrix4.CreateTranslation(0.0f, -0.5f, 0.0f);

            }

            //NICHO
            if (KeyboardState.IsKeyDown(Keys.Down))
            {

                _time += 20f * args.Time;
                temp1 = temp1 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp3 = temp3 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp5 = temp5 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.0f, 0f, -0.05f);
                temp = temp * Matrix4.CreateTranslation(0.0f, 0, -0.05f);
                temp0 = temp0 * Matrix4.CreateTranslation(0.0f, 0, -0.05f);
                temp02 = temp02 * Matrix4.CreateTranslation(0.0f, 0, -0.05f);
                walkingBackwards();


            }

            if (KeyboardState.IsKeyDown(Keys.Up))
            {

                _time += 20f * args.Time;
                temp1 = temp1 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp3 = temp3 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp5 = temp5 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp = temp * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp0 = temp0 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                temp02 = temp02 * Matrix4.CreateTranslation(0.0f, 0f, 0.05f);
                walking();
            }

            if (KeyboardState.IsKeyReleased(Keys.Left))
            {
                _time += 20f * args.Time;
                temp1 = temp1 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp3 = temp3 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp5 = temp5 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp6 = temp6 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);
                temp = temp * Matrix4.CreateTranslation(-0.05f, 0, 0.0f);
                temp0 = temp0 * Matrix4.CreateTranslation(-0.05f, 0, 0.0f);
                temp02 = temp02 * Matrix4.CreateTranslation(-0.05f, 0f, 0.0f);

            }

            if (KeyboardState.IsKeyReleased(Keys.Right))
            {
                _time += 20f * args.Time;
                temp1 = temp1 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp3 = temp3 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp5 = temp5 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp6 = temp6 * Matrix4.CreateTranslation(0.05f, 0f, 0.0f);
                temp = temp * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp0 = temp0 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
                temp02 = temp02 * Matrix4.CreateTranslation(0.05f, 0, 0.0f);
            }

            if (KeyboardState.IsKeyDown(Keys.CapsLock))
            {
                _time += 20f * args.Time;
                temp19 = temp19 * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)_time));
                temp4 = temp4 * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians((float)_time));
            }
            if (KeyboardState.IsKeyReleased(Keys.CapsLock))
            {
                if (isNight == false)
                {
                    GL.ClearColor(0f, 0f, 0f, 1.0f);

                    isNight = true;
                }
                else if (isNight == true)
                {
                    GL.ClearColor(0.529f, 0.807f, 0.921f, 1.0f);

                    isNight = false;
                }

            }

            if (key.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            float cameraSpeed = 5f;

            if (key.IsKeyDown(Keys.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * (float)args.Time;
            }

            if (key.IsKeyDown(Keys.Enter))
            {
                _camera.Position -= _camera.Up * cameraSpeed * (float)args.Time;
            }


            if (KeyboardState.IsKeyDown(Keys.KeyPadAdd))
            {
                _time4 += 18f;

                temp4 = Matrix4.CreateScale(2.0f) * temp4;
                temp19 = Matrix4.CreateScale(2.0f) * temp4;

            }
            if (KeyboardState.IsKeyDown(Keys.KeyPadSubtract))
            {
                _time4 += 18f;

                temp4 = Matrix4.CreateScale(0.5f) * temp4;
                temp19 = Matrix4.CreateScale(0.5f) * temp4;

            }


            var sensitivity = 0.1f;

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse_input.X - _lastPos.X;
                var deltaY = mouse_input.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse_input.X, mouse_input.Y);
                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }

            if (KeyboardState.IsKeyDown(Keys.N))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.Comma))
            {
                var axis = new Vector3(0, 1, 0);
                _camera.Position -= _objectPos;
                _camera.Yaw -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;

                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.K))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch -= _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, _rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
            if (KeyboardState.IsKeyDown(Keys.M))
            {
                var axis = new Vector3(1, 0, 0);
                _camera.Position -= _objectPos;
                _camera.Pitch += _rotationSpeed;
                _camera.Position = Vector3.Transform(_camera.Position,
                    generateArbRotationMatrix(axis, _objectPos, -_rotationSpeed).ExtractRotation());
                _camera.Position += _objectPos;
                _camera._front = -Vector3.Normalize(_camera.Position - _objectPos);
            }
        }

        public async void walking()
        {
            turn++;
            if (turn % 2 == 0)
            {
                degr2 = MathHelper.DegreesToRadians(25f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(degr2);
                await Task.Delay(100);
                temp5 = temp5 * Matrix4.CreateRotationX(-degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(-degr2);

                temp6 = temp6 * Matrix4.CreateRotationX(-degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(-degr2);
                await Task.Delay(100);


                temp6 = temp6 * Matrix4.CreateRotationX(degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(degr2);
            }
            else
            {
                degr2 = MathHelper.DegreesToRadians(25f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(-degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(-degr2);
                await Task.Delay(100);
                temp5 = temp5 * Matrix4.CreateRotationX(degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(degr2);

                temp6 = temp6 * Matrix4.CreateRotationX(degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(degr2);
                await Task.Delay(100);
                temp6 = temp6 * Matrix4.CreateRotationX(-degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(-degr2);

            }
        }
        public async void walkingBackwards()
        {
            turn2++;
            if (turn2 % 2 == 0)
            {
                degr2 = MathHelper.DegreesToRadians(25f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;
                temp5 = temp5 * Matrix4.CreateRotationX(degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(degr2);
                await Task.Delay(100);
                temp5 = temp5 * Matrix4.CreateRotationX(-degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(-degr2);

                temp6 = temp6 * Matrix4.CreateRotationX(-degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(-degr2);
                await Task.Delay(100);
                temp6 = temp6 * Matrix4.CreateRotationX(degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(degr2);

            }
            else
            {
                degr2 = MathHelper.DegreesToRadians(25f);
                Matrix4 temporary = temp5;
                Matrix4 temporary2 = temp6;

                temp5 = temp5 * Matrix4.CreateRotationX(-degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(-degr2);
                await Task.Delay(100);
                temp5 = temp5 * Matrix4.CreateRotationX(degr2);
                temp02 = temp02 * Matrix4.CreateRotationX(degr2);

                temp6 = temp6 * Matrix4.CreateRotationX(degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(degr2);
                await Task.Delay(100);
                temp6 = temp6 * Matrix4.CreateRotationX(-degr2);
                temp0 = temp0 * Matrix4.CreateRotationX(-degr2);

            }
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            _camera.Fov = _camera.Fov - e.OffsetY;
        }


    }
}
