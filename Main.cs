using System;
using System.Runtime.InteropServices;
using MelonLoader;
using UnityEngine;


namespace MediaControlls
{
    public static class BuildInfo
    {
        public const string Name = "MediaControlls"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Let's you controll your pc music from UI"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Exil_S"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.0"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class MediaControlls : MelonMod
    {
        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 0;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
        private bool isMenuVisible = false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                isMenuVisible = !isMenuVisible;
            }
        }

        public override void OnGUI()
        {
            if (isMenuVisible)
            {

                if (GUI.Button(new Rect(10, 10, 100, 50), "Play/Pause"))
                {
                    TogglePlayback();
                }

                if (GUI.Button(new Rect(10, 70, 100, 50), "Skip Forward"))
                {
                    SkipForward();
                }

                if (GUI.Button(new Rect(10, 130, 100, 50), "Skip Back"))
                {
                    SkipBack();
                }
            }
        }

        private void SimulateMediaKey(byte virtualKey)
        {
            keybd_event(virtualKey, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
            keybd_event(virtualKey, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
        }

        void TogglePlayback()
        {
            SimulateMediaKey(VK_MEDIA_PLAY_PAUSE);
        }

        void SkipForward()
        {
            SimulateMediaKey(VK_MEDIA_NEXT_TRACK);
        }

        void SkipBack()
        {
            SimulateMediaKey(VK_MEDIA_PREV_TRACK);
        }
    }
}