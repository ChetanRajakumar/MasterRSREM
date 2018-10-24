using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;
using System.Threading.Tasks;

namespace MasterRSREM.Helper
{
    public class RecordHelper : INotificationReceiver
    {
        //static string filePath = "/sdcard/Music/testAudio.mp3";
        //Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "testAudio.mp4")
        public static string audioFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "testAudio.mp4");
        MediaRecorder recorder = null;

        public void StartRecorder()
        {
            try
            {
                if (File.Exists(audioFilePath))
                    File.Delete(audioFilePath);

               
                if (recorder == null)
                    recorder = new MediaRecorder(); // Initial state.
                else
                    recorder.Reset();

                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Mpeg4);
                recorder.SetAudioEncoder(AudioEncoder.AmrNb); // Initialized state.
                recorder.SetOutputFile(audioFilePath); // DataSourceConfigured state.
                recorder.Prepare(); // Prepared state
                recorder.Start(); // Recording state.

            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.StackTrace);
            }
        }

        public void StopRecorder()
        {
            if (recorder != null)
            {
                recorder.Stop();
                recorder.Release();
                recorder = null;
            }
        }

        public void PauseRecorder()
        {
            if (recorder != null)
            {
                recorder.Pause();
            }
        }

        public Task StartAsync()
        {
            StartRecorder();

            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            return tcs.Task;
        }

        public void Stop()
        {
            StopRecorder();
        }
    }
}