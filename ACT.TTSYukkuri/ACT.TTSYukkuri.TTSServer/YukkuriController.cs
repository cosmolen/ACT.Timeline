namespace ACT.TTSYukkuri.TTSServer
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    using ACT.TTSYukkuri.TTSServer.Properties;

    public class YukkuriController
    {
        private delegate IntPtr AquesTalk_Synthe(string koe, ushort iSpeed, ref uint size);
        private delegate void AquesTalk_FreeWave(IntPtr wave);

        private static YukkuriController instance;

        public static YukkuriController Default
        {
            get
            {
                if (instance == null)
                {
                    instance = new YukkuriController();
                }

                return instance;
            }
        }

        private readonly string DllName = "AquesTalk.dll";

        private UnmanagedLibrary lib;

        private void Initialize()
        {
            if (IsModuleLoaded("AquesTalk"))
            {
                return;
            }

            this.lib = new UnmanagedLibrary(DllName);
        }

        public void Free()
        {
            if (this.lib != null)
            {
                this.lib.Dispose();
                this.lib = null;
            }
        }

        public void OutputWaveToFile(
            string textToSpeak,
            ushort speed,
            string waveFile)
        {
            if (string.IsNullOrWhiteSpace(textToSpeak))
            {
                return;
            }

            this.Initialize();

            var synthesize = lib.GetUnmanagedFunction<AquesTalk_Synthe>("AquesTalk_Synthe");
            var freeWave = lib.GetUnmanagedFunction<AquesTalk_FreeWave>("AquesTalk_FreeWave");

            if (synthesize == null ||
                freeWave == null)
            {
                return;
            }

            var wavePtr = IntPtr.Zero;

            try
            {
                // テキストを音声データに変換する
                uint size = 0;
                wavePtr = synthesize(
                    textToSpeak,
                    speed,
                    ref size);

                if (wavePtr == IntPtr.Zero ||
                    size <= 0)
                {
                    return;
                }

                // 生成したwaveデータを読み出す
                var buff = new byte[size];
                Marshal.Copy(wavePtr, buff, 0, (int)size);

                using (var fs = new FileStream(waveFile, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buff, 0, buff.Length);
                }
            }
            finally
            {
                if (wavePtr != IntPtr.Zero)
                {
                    freeWave(wavePtr);
                }
            }
        }

        #region IsModuleLoaded

        /// <summary>
        /// Check whether or not the specified module is loaded in the 
        /// current process.
        /// </summary>
        /// <param name="moduleName">the module name</param>
        /// <returns>
        /// The function returns true if the specified module is loaded in 
        /// the current process. If the module is not loaded, the function 
        /// returns false.
        /// </returns>
        private static bool IsModuleLoaded(string moduleName)
        {
            // Get the module in the process according to the module name.
            IntPtr hMod = GetModuleHandle(moduleName);
            return (hMod != IntPtr.Zero);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string moduleName);

        #endregion
    }
}
