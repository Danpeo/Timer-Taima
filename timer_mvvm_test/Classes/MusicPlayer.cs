using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using timer_mvvm_test.Classes;

namespace timer_mvvm_test
{
    public class MusicPlayer
    {
        private static SoundPlayer? Player;

        public static void PlaySound(string fileName)
        {

            string fullPath = Path.GetFullPath($@"Audio\{fileName}");
            string baseDirectory = Directory.GetCurrentDirectory();

            string relativePath = PathManager.GetRelativePath("Audio", fileName);

            Player = new SoundPlayer(relativePath);
            Player.PlayLooping();
        }

        public static void StopSound()
        {
            Player?.Stop();
        }
    }
}
