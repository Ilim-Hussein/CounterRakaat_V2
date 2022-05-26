using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace CounterRakaat_V2
{
    public partial class MainPage : ContentPage
    {
        public float num1 = 0.8f;
        public float num2 = 0.9f;
        public float num3 = 0.2f;
        public float num4 = 0.1f;

        public float num_1 = -0.8f;
        public float num_2 = -0.9f;
        public float num_3 = -0.2f;
        public float num_4 = -0.1f;

        public float Aceler_dataX = 0.0f;
        public float Aceler_dataY = 0.0f;
        public float Aceler_dataZ = 0.0f;

        public bool a;
        public bool b;
        public bool c;
        public bool d;

        private int counter;
        private int result;
        bool Vib_Controll = true;

        public MainPage()
        {
            InitializeComponent();
            Task.Run(AnimateBackground);
            Accelerometer_Stop();
            Accelerometer.ReadingChanged += Accelerometer_ReadingChanged;
            IfReady_main.Text = Recource.Resource.IfReady_main;
            Table_main.Text = Recource.Resource.Table_main;
            Rakaat_main.Text = Recource.Resource.Rakaat_main;

        }


        void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
        {
            var data = e.Reading;
            result = counter / 2;
            dataX.Text = Convert.ToString($"X - {data.Acceleration.X}");
            dataY.Text = Convert.ToString($"Y - { data.Acceleration.Y}");
            dataZ.Text = Convert.ToString($"Z - {result}");

            Aceler_dataX = data.Acceleration.X;
            Aceler_dataY = data.Acceleration.Y;
            Aceler_dataZ = data.Acceleration.Z;
            Result_Condition();

            Rakaat_1.Text = Convert.ToString(ResultRakaat(result));

        }
        private bool ResultCounter_X_1(bool condition) //проверка условя X 1 - 0,8 до 0,9
        {
            if (Aceler_dataX <= num1 && Aceler_dataX >= num2)
            {
                condition = true;
            }
            else 
            {
                condition = false;
            }
            return condition;
        }

        private bool ResultCounter_X_2(bool condition) // проверка условия X 2 - 0,2 до 0,1
        {
            if (Aceler_dataX >= num3 && Aceler_dataX <= num4)
            {
                condition = true;
            }

            else
            {
                condition = false;
            }
            return condition;
        }

        private bool ResultCounter_X_3(bool condition) //проверка условя X 3 - -0,8 до -0,9
        {
            if (Aceler_dataX >= num_1 && Aceler_dataX <= num_2)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
            return condition;
        }

        private bool ResultCounter_X_4(bool condition) // проверка условия X 4 - -0,2 до -0,1
        {
            if (Aceler_dataX <= num_3 && Aceler_dataX >= num_4)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
            return condition;
        }


        public bool ResultCounter_Y_1 (bool condition) // проверка условия Y 1 - 0,8 до 0,9
        {
            if (Aceler_dataY >= num1 && Aceler_dataY <= num2)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
            return condition;
        }

        public bool ResultCounter_Y_2(bool condition) // проверка условия Y 2 - 0,2 до 0,1
        {
            if (Aceler_dataY <= num3 && Aceler_dataY >= num4)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
            return condition;
        }


        private bool ResultCounter_Y_3(bool condition) // проверка условия Y 3 - -0,8 до -0,9
        {
            if (Aceler_dataY <= num_1 && Aceler_dataY >= num_2)
            {
                condition = true;
            }

            else
            {
                condition = false;
            }
            return condition;
        }



        private bool ResultCounter_Y_4(bool condition) // проверка условия Y 4 - -0,2 до -0,1
        {
            if (Aceler_dataY >= num_3 && Aceler_dataY <= num_4)
            {
                condition = true;
            }
            else
            {
                condition = false;
            }
            return condition;
        }




        public  void Result_Condition () // Проверка выполенение условий с Акселирометров и вывод констакнты +1 в случае true true 
        {
           
            if (ResultCounter_X_1(false) == true) { a = true; }
            if (ResultCounter_X_2(false) == true) { b = true; }
            if (ResultCounter_X_3(false) == true) { a = true; }
            if (ResultCounter_X_4(false) == true) { b = true; }

            if (ResultCounter_Y_1(false) == true) { c = true; }
            if (ResultCounter_Y_2(false) == true) { d = true; }
            if (ResultCounter_Y_3(false) == true) { c = true; }
            if (ResultCounter_Y_4(false) == true) { d = true; }

            if (a == true && b == true || c == true && d == true)
            {
                a = false;
                b = false;
                c = false;
                d = false;
                counter += 1;
            }
        }



        public  int ResultRakaat (int result)
        {
            int itog = 1;
            if (result <= 4)                  { itog = 1;  while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 8 && result >= 5)   { itog = 2;  while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 12 && result >= 9)  { itog = 3;  while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }  
            if (result <= 16 && result >= 13) { itog = 4;  while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 20 && result >= 17) { itog = 5;  while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 24 && result >= 21) { itog = 6;  while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 28 && result >= 25) { itog = 7;  while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 32 && result >= 29) { itog = 8;  while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 36 && result >= 33) { itog = 9;  while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 40 && result >= 37) { itog = 10; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 44 && result >= 41) { itog = 11; while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 48 && result >= 45) { itog = 12; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 52 && result >= 49) { itog = 13; while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 56 && result >= 53) { itog = 14; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 60 && result >= 57) { itog = 15; while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 64 && result >= 61) { itog = 16; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 68 && result >= 65) { itog = 17; while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 72 && result >= 69) { itog = 18; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result <= 76 && result >= 73) { itog = 19; while (Vib_Controll == true)  { Vibtate_Controll(itog); Vib_Controll = false; } }
            if (result <= 80 && result >= 77) { itog = 20; while (Vib_Controll == false) { Vibtate_Controll(itog); Vib_Controll = true;  } }
            if (result > 81 ) { counter = 0;}
            return itog;
        }


        private async void Vibtate_Controll(int count_vibr)
        {
            var durition = TimeSpan.FromSeconds(0.3);
            for (int i = 0; i < count_vibr; i++)
            {
                Vibration.Vibrate(durition);
                await Task.Delay(700);
            }
        }


        public async void Button_Click(object sender, EventArgs e)
        {
            try
            {
                if (ButtonStart_1.Text == "Start")
                {
                   // DependencyService.Get<IServiceDroid>().StartService();

                    await DisplayAlert("Внимание", "Положите телефон в карман", "Ок");
                    ButtonStart_1.Text = "Stop";
                    await Task.Delay(2000);
                    Accelerometer.Start(SensorSpeed.UI);
                }
            
                else if (ButtonStart_1.Text == "Stop")
                {
                  //  DependencyService.Get<IServiceDroid>().StopService();


                    Accelerometer_Stop();
                        ButtonStart_1.Text = "Start";
                        counter = 0;
                }
            }


            catch (System.InvalidOperationException) 
            {
                Accelerometer_Stop();
            }

        }


        public void Accelerometer_Stop() 
        {
            Accelerometer.Stop();
        }


        private async void AnimateBackground() 
        {
            Action <double> forward = input => bdGradient.AnchorY = input;
            Action <double> backward = input => bdGradient.AnchorY = input;

            while (true)
            {
                bdGradient.Animate(name: "forward", callback: forward, start: 0, end: 1, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);
                bdGradient.Animate(name: "backward", callback: backward, start: 1, end: 0, length: 5000, easing: Easing.SinIn);
                await Task.Delay(5000);
            }
        }
    }
}
