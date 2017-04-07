namespace UtfUnknown.Core
{
    public class Koi8rModel : CyrillicModel
    {
        private readonly static byte[] KOI8R_CHAR_TO_ORDER_MAP = {
            255,255,255,255,255,255,255,255,255,255,254,255,255,254,255,255,  //00
            255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,255,  //10
            +253,253,253,253,253,253,253,253,253,253,253,253,253,253,253,253,  //20
            252,252,252,252,252,252,252,252,252,252,253,253,253,253,253,253,  //30
            253,142,143,144,145,146,147,148,149,150,151,152, 74,153, 75,154,  //40
            155,156,157,158,159,160,161,162,163,164,165,253,253,253,253,253,  //50
            253, 71,172, 66,173, 65,174, 76,175, 64,176,177, 77, 72,178, 69,  //60
            67,179, 78, 73,180,181, 79,182,183,184,185,253,253,253,253,253,  //70
            191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,  //80
            207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,  //90
            223,224,225, 68,226,227,228,229,230,231,232,233,234,235,236,237,  //a0
            238,239,240,241,242,243,244,245,246,247,248,249,250,251,252,253,  //b0
            27,  3, 21, 28, 13,  2, 39, 19, 26,  4, 23, 11,  8, 12,  5,  1,  //c0
            15, 16,  9,  7,  6, 14, 24, 10, 17, 18, 20, 25, 30, 29, 22, 54,  //d0
            59, 37, 44, 58, 41, 48, 53, 46, 55, 42, 60, 36, 49, 38, 31, 34,  //e0
            35, 43, 45, 32, 40, 52, 56, 33, 61, 62, 51, 57, 47, 63, 50, 70,  //f0
        };
        
        public Koi8rModel() : base(KOI8R_CHAR_TO_ORDER_MAP, "KOI8-R")
        {
        }
    }
}