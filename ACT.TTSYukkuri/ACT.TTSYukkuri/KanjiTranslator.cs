namespace ACT.TTSYukkuri
{
    using System;
    using System.Runtime.InteropServices;

    using Advanced_Combat_Tracker;

    /// <summary>
    /// 漢字翻訳
    /// </summary>
    public class KanjiTranslator : IDisposable
    {
        /// <summary>
        /// ロックオブジェクト
        /// </summary>
        private static object lockObject = new object();

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        private static KanjiTranslator instance;

        /// <summary>
        /// シングルトンinstance
        /// </summary>
        public static KanjiTranslator Default
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new KanjiTranslator();
                    }
                }

                return instance;
            }
        }

        /// <summary>
        /// IFE言語オブジェクト
        /// </summary>
        public IFELanguage IFELang
        {
            get;
            private set;
        }

        /// <summary>
        /// 初期化する
        /// </summary>
        public void Initialize()
        {
            lock (lockObject)
            {
                if (this.IFELang == null)
                {
                    this.IFELang = Activator.CreateInstance(Type.GetTypeFromProgID("MSIME.Japan")) as IFELanguage;

                    var hr = IFELang.Open();
                    if (hr != 0)
                    {
                        ActGlobals.oFormActMain.WriteInfoLog(
                            "ACT.TTSYukkuri IFELANG IMEに接続できません");

                        this.IFELang = null;
                    }

                    ActGlobals.oFormActMain.WriteDebugLog(
                        "ACT.TTSYukkuri IFELANG 接続OK");
                }
            }
        }

        /// <summary>
        /// 読みがなを取得する
        /// </summary>
        /// <param name="text">変換対象のテキスト</param>
        /// <returns>読みがなに変換したテキスト</returns>
        public string GetYomigana(
            string text)
        {
            var yomigana = text;

            var ifelang = this.IFELang;

            if (ifelang != null)
            {
                string t;
                var hr = ifelang.GetPhonetic(text, 1, -1, out t);
                if (hr != 0)
                {
                    ActGlobals.oFormActMain.WriteInfoLog(
                        "ACT.TTSYukkuri IFELANG Phoneticを取得できません");

                    return yomigana;
                }

                yomigana = t;

                ActGlobals.oFormActMain.WriteDebugLog(
                    "ACT.TTSYukkuri IFELANG 変換前:" + text + ", 変換後:" + yomigana);
            }

            return yomigana;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (this.IFELang != null)
            {
                this.IFELang.Close();
                this.IFELang = null;
            }

            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// IFELanguage Interface
    /// </summary>
    [ComImport]
    [Guid("019F7152-E6DB-11d0-83C3-00C04FDDB82E")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IFELanguage
    {
        int Open();
        int Close();
        int GetJMorphResult(uint dwRequest, uint dwCMode, int cwchInput, [MarshalAs(UnmanagedType.LPWStr)] string pwchInput, IntPtr pfCInfo, out object ppResult);
        int GetConversionModeCaps(ref uint pdwCaps);
        int GetPhonetic([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
        int GetConversion([MarshalAs(UnmanagedType.BStr)] string @string, int start, int length, [MarshalAs(UnmanagedType.BStr)] out string result);
    }
}
