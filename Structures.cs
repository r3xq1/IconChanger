namespace IconChanger
{
    using System.Runtime.InteropServices;

    public static class Structures
    {
        [StructLayout(LayoutKind.Sequential)]
        public partial struct ICONDIR
        {
            public ushort Reserved;
            public ushort Type;
            public ushort Count;
        }

        [StructLayout(LayoutKind.Sequential)]
        public partial struct ICONDIRENTRY
        {
            public byte Width;
            public byte Height;
            public byte ColorCount;
            public byte Reserved;
            public ushort Planes;
            public ushort BitCount;
            public int BytesInRes;
            public int ImageOffset;
        }

        [StructLayout(LayoutKind.Sequential)]
        public partial struct BITMAPINFOHEADER
        {
            public uint Size;
            public int Width;
            public int Height;
            public ushort Planes;
            public ushort BitCount;
            public uint Compression;
            public uint SizeImage;
            public int XPelsPerMeter;
            public int YPelsPerMeter;
            public uint ClrUsed;
            public uint ClrImportant;
        }

        /// <summary>
        /// A hardware-independent icon directory resource header.
        /// http://msdn.microsoft.com/en-us/library/ms997538.aspx
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public struct GRPICONDIR
        {
            /// <summary>
            /// Reserved, must be zero.
            /// </summary>
            public ushort wReserved;
            /// <summary>
            /// Resource type, 1 for icons.
            /// </summary>
            public ushort wType;
            /// <summary>
            /// Number of images.
            /// </summary>
            public ushort wImageCount;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        public partial struct GRPICONDIRENTRY
        {
            public byte Width;
            public byte Height;
            public byte ColorCount;
            public byte Reserved;
            public ushort Planes;
            public ushort BitCount;
            public int BytesInRes;
            public ushort ID;
        }
    }
}