using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;

namespace EmguCVFace
{
    public partial class Form1 : Form
    {
        private Capture cap;
        private HaarCascade haar;
        private HaarCascade mthxml;

        public Form1()
        {
            InitializeComponent();
            // passing 0 gets zeroth webcam
            cap = new Capture(0);
            //Pre-trained cascade
            CascadeClassifier haar = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_frontalface_default.xml");
            CascadeClassifier mthxml = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_smile.xml");
            
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txtSmiling.Text = "Unhappy"; //Bu adımda gülmediğimiz zaman üzgün olduğumuzu anlatabilmek için en başa yazdık.

            pictureBox2.Image = Image.FromFile(@"C:\Users\Emre\Desktop\EmguCV Bitirme\EmguCVFace\Moods\unhappy.jpg");
            //Yeni bir çerçeve oluşturduk.
            Image<Bgr, Byte> nextFrame = cap.QueryFrame();
            //Grayscale olarak çerçeveyi değiştiriyoruz.
            Image<Gray, Byte> grayFrame = nextFrame.Convert<Gray, Byte>();
            //Equalization step
            grayFrame._EqualizeHist();
            
            //<!------------------Tanımlacanak kısımları bir listeye atacağımız için listeleri oluşturduk---------------------------!>
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            List<Rectangle> smiles = new List<Rectangle>();


            //Pre-trained cascade
            //XML dosyalarından tanımlanacak kısımların değerleri alınmaktadır.
            CascadeClassifier face = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_frontalface_default.xml");
            CascadeClassifier eye = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_eye.xml");
            CascadeClassifier smile = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_smile.xml");
            
          //<!----------------------------------------------------------!>


            //Verilen Cascadeclassifier tpipindeki imaj grayscale olmak zorunda
            Image<Gray, Byte> gray = nextFrame.Convert<Gray, Byte>(); //Image Gray versiyonda olmak zorunda

            //Yüz tanımlama
            Rectangle[] facesDetected = face.DetectMultiScale(
            gray, //image
            1.1, //scaleFactor
            10, //minNeighbors
            new Size(20, 20), //Minimum Boyut
            Size.Empty); //Maximum Boyut
            faces.AddRange(facesDetected);

            //Eyes detection
            foreach (Rectangle f in facesDetected)
            {
                gray.ROI = f;
                Rectangle[] eyesDetected = eye.DetectMultiScale(
                gray,
                1.9,
                10,
                new Size(20, 20),
                Size.Empty);
                gray.ROI = Rectangle.Empty;
                foreach (Rectangle ey in eyesDetected)
                {
                    Rectangle eyeRect = ey;
                    eyeRect.Offset(f.X, f.Y);
                    eyes.Add(eyeRect);
                }
            }

            //Smile Detection
            foreach (Rectangle f in facesDetected)
            {
                gray.ROI = f;
                Rectangle[] smiledetected = smile.DetectMultiScale(
                gray,
                1.1, //minSize
                200, //maxSize
                Size.Empty,
                Size.Empty);
                gray.ROI = Rectangle.Empty;
                foreach (Rectangle ey in smiledetected)
                {
                    Rectangle smileRect = ey;
                    smileRect.Offset(f.X, f.Y);
                    smiles.Add(smileRect);
                }
            }

            //Draw detected area
            foreach (Rectangle face1 in faces)
                nextFrame.Draw(face1, new Bgr(Color.Red), 2);
            foreach (Rectangle eye1 in eyes)
                nextFrame.Draw(eye1, new Bgr(Color.Blue), 2);
            foreach (Rectangle smile1 in smiles)
            {
                nextFrame.Draw(smile1, new Bgr(Color.Yellow), 2);
                if (smiles != null)
                    txtSmiling.Text = "Happy";
                    pictureBox2.Image = Image.FromFile(@"C:\Users\Emre\Desktop\EmguCV Bitirme\EmguCVFace\Moods\happy.jpg");

            }

            //Show image
            pictureBox1.Image = nextFrame.ToBitmap();

        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            if (txtSmiling.Text == "Happy")
            {
                var soundsRoot = @"C:\Users\Emre\Desktop\FastMotion";
                var rand = new Random();
                var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
                var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(playSound);
                player1.Play();
            }
            else if (txtSmiling.Text == "Unhappy")
            {
                var soundsRoot = @"C:\Users\Emre\Desktop\SlowMotion";
                var rand = new Random();
                var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
                var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(playSound);
                player1.Play();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var currentsound = @listBox1.SelectedItem.ToString();
            if (currentsound != null)
            {
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(currentsound);
                player1.Play();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            if (txtSmiling.Text == "Happy")
            {
                lblMusic.Text = "Happy Musics";
                listBox1.Items.Clear();
                string[] array1 = Directory.GetFiles(@"C:\Users\Emre\Desktop\FastMotion");
                foreach (string name in array1)
                {
                    listBox1.Items.Add(name);
                }
            }
            else if (txtSmiling.Text == "Unhappy")
            {
                lblMusic.Text = "Happy Musics";
                listBox1.Items.Clear();
                string[] array1 = Directory.GetFiles(@"C:\Users\Emre\Desktop\SlowMotion");
                foreach (string name in array1)
                {
                    listBox1.Items.Add(name);
                }
            }
        }
        }
    }