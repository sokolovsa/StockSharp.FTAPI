using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Futu.OpenApi
{
    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public unsafe struct ProtoHeader
    {
        public fixed byte szHeaderFlag[2];
        public uint nProtoID;
        public byte nProtoFmtType;
        public byte nProtoVer;
        public uint nSerialNo;
        public uint nBodyLen;
        public fixed byte arrBodySHA1[20];
        public fixed byte arrReserved[8];

//         public ProtoHeader(int protoID)
//         {
//             szHeaderFlag = new byte[] { (byte)'F', (byte)'T' };
//             nProtoID = protoID;
//             nProtoFmtType = 0;
//             nProtoVer = 0;
//             nSerialNo = 0;
//             nBodyLen = 0;
//             arrBodySHA1 = new byte[20];
//             arrReserved = new byte[]{ 0, 0, 0, 0, 0, 0, 0, 0 };
//         }
    }

    internal class FTCAPI
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnInitConnectCallback(IntPtr pChannel, long errCode, string desc);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnDisConnectCallback(IntPtr pChannel, long errCode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnReplyCallback(IntPtr pChannel, int enReqReplyType, IntPtr protoHeaderPtr, IntPtr protoData, int nDataLen);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OnPushCallback(IntPtr pChannel, IntPtr protoHeaderPtr, IntPtr protoData, int nDataLen);

        [DllImport("FTAPIChannel", EntryPoint = "CreateFTAPIChannel", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static IntPtr CreateFTAPIChannel();

        [DllImport("FTAPIChannel", EntryPoint = "ReleaseFTAPIChannel", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void ReleaseFTAPIChannel(IntPtr channel);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_Init", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_Init();

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_UnInit", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_UnInit();

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetClientInfo", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetClientInfo(IntPtr channel, string clientID, int clientVer);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetRSAPrivateKey", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetRSAPrivateKey(IntPtr channel, string rsainternalKey);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_InitConnect", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int FTAPIChannel_InitConnect(IntPtr channel, string ipAddr, ushort port, int enableEncrypt);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_GetConnectID", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static ulong FTAPIChannel_GetConnectID(IntPtr pChannel);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SendProto", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static uint FTAPIChannel_SendProto(IntPtr pChannel, uint protoID, byte protoVer, IntPtr data, int dataLen);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_Close", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int FTAPIChannel_Close(IntPtr pChannel);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetOnDisconnectCallback", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetOnDisconnectCallback(IntPtr pChannel, OnDisConnectCallback callback);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetOnInitConnectCallback", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetOnInitConnectCallback(IntPtr pChannel, OnInitConnectCallback callback);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetOnReplyCallback", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetOnReplyCallback(IntPtr pChannel, OnReplyCallback callback);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetOnPushCallback", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetOnPushCallback(IntPtr pChannel, OnPushCallback callback);

        [DllImport("FTAPIChannel", EntryPoint = "FTAPIChannel_SetProgrammingLanguage", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void FTAPIChannel_SetProgrammingLanguage(IntPtr pChannel, string progLang);
    }
}
