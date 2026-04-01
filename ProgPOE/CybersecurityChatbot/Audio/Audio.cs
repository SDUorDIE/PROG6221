using System;
using System.IO;
using System.Media;

namespace CybersecurityChatbot.Audio
{
    public class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "greeting.wav");

                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Audio failed: " + ex.Message);
            }
        }
    }
}