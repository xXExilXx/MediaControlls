using System;
using System.Runtime.InteropServices;
using MelonLoader;
using UnityEngine;
using TextureLoader;


namespace MediaControlls
{
    public static class BuildInfo
    {
        public const string Name = "MediaControlls"; // Name of the Mod.  (MUST BE SET)
        public const string Description = "Let's you controll your pc music from UI"; // Description for the Mod.  (Set as null if none)
        public const string Author = "Exil_S"; // Author of the Mod.  (MUST BE SET)
        public const string Company = null; // Company that made the Mod.  (Set as null if none)
        public const string Version = "1.0.1"; // Version of the Mod.  (MUST BE SET)
        public const string DownloadLink = null; // Download Link for the Mod.  (Set as null if none)
    }

    public class MediaControlls : MelonMod
    {
        private const int KEYEVENTF_EXTENDEDKEY = 1;
        private const int KEYEVENTF_KEYUP = 0;
        private const int VK_MEDIA_NEXT_TRACK = 0xB0;
        private const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        private const int VK_MEDIA_PREV_TRACK = 0xB1;
        private const int VK_VOLUME_UP = 0xAF;
        private const int VK_VOLUME_DOWN = 0xAE;
        private Texture playPause;
        private Texture rewind;
        private Texture skip;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern float GetMasterVolumeLevelScalar();

        private bool isMenuVisible = false;

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.F5))
            {
                isMenuVisible = !isMenuVisible;
            }

            if (isMenuVisible)
            {
                // Adjust volume using the scroll wheel
                float scroll = Input.GetAxis("Mouse ScrollWheel");
                if(scroll > 0)
                {
                    SimulateMediaKey(VK_VOLUME_UP);
                }
                else if(scroll < 0)
                {
                    SimulateMediaKey(VK_VOLUME_DOWN);
                }
            }
        }
        public override void OnInitializeMelon()
        {
            playPause = ResourceManager.GetTexture("PlayPause");
            rewind = ResourceManager.GetTexture("rewind");
            skip = ResourceManager.GetTexture("skip");
        }

        public override void OnGUI()
        {
            if (isMenuVisible)
            {
                GUI.Box(new Rect(10, 10, 220, 190), "Media Controls");

                // Create styled buttons
                GUI.backgroundColor = Color.cyan;

                if (GUI.Button(new Rect(20, 40, 200, 40), "Play/Pause"))
                {
                    TogglePlayback();
                }

                if (GUI.Button(new Rect(20, 90, 200, 40), "Skip"))
                {
                    SkipForward();
                }

                if (GUI.Button(new Rect(20, 140, 200, 40), "Rewind"))
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