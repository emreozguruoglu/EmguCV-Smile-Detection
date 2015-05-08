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
            // Default web camera başlatılıyor.
            cap = new Capture(0);

            //Önceden tanımlanmış hazır ağız ve yüz yapısı tanımlanılıyor.
            CascadeClassifier haar = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_frontalface_default.xml");
            CascadeClassifier mthxml = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_smile.xml");

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            txtSmiling.Text = "Mutsuz"; // Bu adımda gülmediğimiz zaman üzgün olduğumuzu anlatabilmek için en başa yazdık.

            pictureBox2.Image = Image.FromFile(@"C:\Users\Emre\Desktop\EmguCV Bitirme\EmguCVFace\Images\unhappy.png");//Üzgün simgesi.

            Image<Bgr, Byte> nextFrame = cap.QueryFrame(); //Yeni bir çerçeve oluşturduk.

            Image<Gray, Byte> grayFrame = nextFrame.Convert<Gray, Byte>(); // Image'i grayscale olarak çerçeveyi değiştiriyoruz.

            //Dengeleme Adımı
            grayFrame._EqualizeHist();

            //<!------------------Tanımlacanak kısımları bir listeye atacağımız için listeleri oluşturduk---------------------------!>
            List<Rectangle> faces = new List<Rectangle>(); //Yüzler bu listede tutulacaktır.
            List<Rectangle> eyes = new List<Rectangle>();  //Gözler bu listede tutulacaktır.
            List<Rectangle> smiles = new List<Rectangle>(); //Ağız yapısı bu listede tutulacaktır.


            //XML dosyalarından tanımlanacak kısımların değerleri hazır olarak alınmaktadır.
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

            //Göz Bulma
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

            //Gülücük Bulma
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

            //Bulunan Alanları Karesel olarak göstermek.
            foreach (Rectangle face1 in faces)
                nextFrame.Draw(face1, new Bgr(Color.Red), 2);
            foreach (Rectangle eye1 in eyes)
                nextFrame.Draw(eye1, new Bgr(Color.Blue), 2);
            foreach (Rectangle smile1 in smiles)
            {
                nextFrame.Draw(smile1, new Bgr(Color.Yellow), 2);
                if (smiles != null) //Gülücük istenilen ebattaysa listeye ata.Liste dolusya gülüyor.Boşsa gülmüyor.
                    txtSmiling.Text = "Mutlu";
                pictureBox2.Image = Image.FromFile(@"C:\Users\Emre\Desktop\EmguCV Bitirme\EmguCVFace\Images\happy.png");

            }

            //Show image
            pictureBox1.Image = nextFrame.ToBitmap();

        }

        private void btnSuggest_Click(object sender, EventArgs e)
        {
            if (txtSmiling.Text == "Mutlu") //Gülüyorsa bu dosyadaki müzikler çalıcaktır.
            {
                var soundsRoot = @"C:\Users\Emre\Desktop\FastMotion";
                var rand = new Random();
                var soundFiles = Directory.GetFiles(soundsRoot, "*.wav");
                var playSound = soundFiles[rand.Next(0, soundFiles.Length)];
                System.Media.SoundPlayer player1 = new System.Media.SoundPlayer(playSound);
                player1.Play();
            }
            else if (txtSmiling.Text == "Mutsuz") //Gülmüyorsa bu dosyadaki müzikler çalıcaktır.
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
            if (txtSmiling.Text == "Mutlu")
            {
                lblMusic.Text = "Mutlu Müzikler";
                listBox1.Items.Clear();
                string[] array1 = Directory.GetFiles(@"C:\Users\Emre\Desktop\FastMotion");
                foreach (string name in array1)
                {
                    listBox1.Items.Add(name); //Listbox'a müzikler atandı.
                }
            }
            else if (txtSmiling.Text == "Mutsuz")
            {
                lblMusic.Text = "Mutsuz Müzikler";
                listBox1.Items.Clear();
                string[] array1 = Directory.GetFiles(@"C:\Users\Emre\Desktop\SlowMotion");
                foreach (string name in array1)
                {
                    listBox1.Items.Add(name); //Listbox'a müzikler atandı.
                }
            }
        }
    }
}