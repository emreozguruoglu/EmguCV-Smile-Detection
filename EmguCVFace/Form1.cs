﻿using System;
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
            txtSmiling.Text = "UNHAPPY :(";
            //We are acquiring a new frame
            Image<Bgr, Byte> nextFrame = cap.QueryFrame();
            //We convert it to grayscale
            Image<Gray, Byte> grayFrame = nextFrame.Convert<Gray, Byte>();
            //Equalization step
            grayFrame._EqualizeHist();
            
            //<!----------------------------------------------------------!>
            List<Rectangle> faces = new List<Rectangle>();
            List<Rectangle> eyes = new List<Rectangle>();
            List<Rectangle> smiles = new List<Rectangle>();

            //Pre-trained cascade
            CascadeClassifier face = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_frontalface_default.xml");
            CascadeClassifier eye = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_eye.xml");
            CascadeClassifier smile = new CascadeClassifier(@"C:\Users\Emre\Desktop\EmguCV Bitirme\FaceDetectedLive\FaceDetectedLive\XML'S\haarcascade_smile.xml");
            
          //<!----------------------------------------------------------!>


            //The input image of Cascadeclassifier must be grayscale
            Image<Gray, Byte> gray = nextFrame.Convert<Gray, Byte>(); //Image Gray versiyonda olmak zorunda

            //Yüz tanımlama
            Rectangle[] facesDetected = face.DetectMultiScale(
            gray, //image
            1.1, //scaleFactor
            10, //minNeighbors
            new Size(20, 20), //Minimum Boyut
            Size.Empty); //mMaximum Boyut
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
                1.1,
                150,
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
                nextFrame.Draw(face1, new Bgr(Color.Red), 4);
            foreach (Rectangle eye1 in eyes)
                nextFrame.Draw(eye1, new Bgr(Color.Blue), 1);
            foreach (Rectangle smile1 in smiles)
            {
                nextFrame.Draw(smile1, new Bgr(Color.Yellow), 2);
                if (smiles != null)
                    txtSmiling.Text = "HAPPY :)";
            }

            //Show image
            pictureBox1.Image = nextFrame.ToBitmap();

        }
    }
}
