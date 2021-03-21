using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Google.ProtocolBuffers;

namespace Futu.OpenApi
{
    public enum ConnectFailType
    {
        Unknown = -1,
        None = 0,
        CreateFailed = 1,
        CloseFailed = 2,
        ShutdownFailed = 3,
        GetHostByNameFailed = 4,
        GetHostByNameWrong = 5,
        ConnectFailed = 6,
        BindFailed = 7,
        ListenFailed = 8,
        SelectReturnError = 9,
        SendFailed = 10,
        RecvFailed = 11,
    }

    public enum ReqReplyType
    {
        SvrReply = 0,       //来自服务器的应答 
        Timeout = -100,     //等待服务器应答超时
        DisConnect = -200   //因连接已断开(被动断开或主动关闭)的应答
    }

    public enum InitFailType
    {
        Unknow = 0,             //未知
        Timeout = 1,            //超时
        DisConnect = 3,         //连接断开
        SeriaNoNotMatch = 4,    //序列号不符
        SendInitReqFailed = 4,  //发送初始化协议失败
        OpenDReject = 5,        //FutuOpenD回包指定错误，具体错误看描述
    }

    public enum ProtoID : uint
    {
		GetGlobalState = 1002, //获取全局状态
		QotSub = 3001, //订阅或者反订阅
		QotRegQotPush = 3002, //注册推送
		QotGetSubInfo = 3003, //获取订阅信息
		QotGetTicker = 3010, //获取逐笔,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Ticker)
		QotGetBasicQot = 3004, //获取基本行情,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Basic)
		QotGetOrderBook = 3012, //获取摆盘,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_OrderBook)
		QotGetKL = 3006, //获取K线，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_KL_XXX)
		QotGetRT = 3008, //获取分时，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_RT)
		QotGetBroker = 3014, //获取经纪队列，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Broker)
		QotGetHistoryKL = 3100, //获取本地历史K线
		QotGetHistoryKLPoints = 3101, //获取多股票多点本地历史K线
		QotGetRehab = 3102, //获取本地历史复权信息
		QotRequestRehab = 3105, //在线请求历史复权信息，不读本地历史数据DB
		QotRequestHistoryKL = 3103, //在线请求历史K线，不读本地历史数据DB
		QotRequestHistoryKLQuota = 3104, //获取历史K线已经用掉的额度
		QotGetTradeDate = 3200, //获取交易日
		QotGetStaticInfo = 3202, //获取静态信息
		QotGetSecuritySnapshot = 3203, //获取股票快照
		QotGetPlateSet = 3204, //获取板块集合下的板块
		QotGetPlateSecurity = 3205, //获取板块下的股票
		QotGetReference = 3206, //获取相关股票
		QotGetOwnerPlate = 3207, //获取股票所属的板块
		QotGetHoldingChangeList = 3208, //获取大股东持股变化列表
		QotGetOptionChain = 3209, //筛选期权
		QotGetWarrant = 3210, //筛选窝轮
		QotGetCapitalFlow = 3211, //获取资金流向
		QotGetCapitalDistribution = 3212, //获取资金分布
		QotGetUserSecurity = 3213, //获取自选股分组下的股票
		QotModifyUserSecurity = 3214, //修改自选股分组下的股票
        QotStockFilter = 3215, // 获取条件选股
        QotGetCodeChange = 3216, // 获取股票代码变化信息
        QotGetIpoList = 3217, //获取新股Ipo
        QotGetFutureInfo = 3218,   //获取期货合约资料
        QotRequestTradeDate = 3219, //在线拉取交易日
        QotSetPriceReminder = 3220,  //设置到价提醒
        QotGetPriceReminder = 3221,  // 获取到价提醒
        QotGetUserSecurityGroup= 3222, //获取自选股分组
        QotGetMarketState = 3223, //获取指定品种的市场状态
		Notify = 1003, //推送通知
		QotUpdateBasicQot = 3005, //推送基本行情
		QotUpdateKL = 3007, //推送K线
		QotUpdateRT = 3009, //推送分时
		QotUpdateTicker = 3011, //推送逐笔
		QotUpdateOrderBook = 3013, //推送买卖盘
		QotUpdateBroker = 3015, //推送经纪队列
		QotUpdateOrderDetail = 3017, //推送委托明细
        QotUpdatePriceReminder = 3019, //到价提醒通知
		TrdGetAccList = 2001, //获取交易账户列表
		TrdUnlockTrade = 2005, //解锁
		TrdSubAccPush = 2008, //订阅接收推送数据的交易账户
		TrdGetFunds = 2101, //获取账户资金
		TrdGetPositionList = 2102, //获取账户持仓
		TrdGetMaxTrdQtys = 2111, //获取最大交易数量
		TrdGetOrderList = 2201, //获取当日订单列表
		TrdPlaceOrder = 2202, //下单
		TrdModifyOrder = 2205, //修改订单
		TrdGetOrderFillList = 2211, //获取当日成交列表
		TrdGetHistoryOrderList = 2221, //获取历史订单列表
		TrdGetHistoryOrderFillList = 2222, //获取历史成交列表
		TrdUpdateOrder = 2208, //订单状态变动通知(推送)
		TrdUpdateOrderFill = 2218, //成交通知(推送)
    }

    /// <summary>
    /// 连接状态的回调
    /// </summary>
    public interface FTSPI_Conn
    {
        /// <summary>
        /// 初始化连接完成
        /// </summary>
        /// <param name="client"></param>
        /// <param name="errCode">当高32位在ConnectFailType取值范围内时，低32位为系统错误码；当高32位等于FTAPI_Conn.InitFail，则低32位为InitFailType类型。</param>
        /// <param name="desc">错误描述</param>
        void OnInitConnect(FTAPI_Conn client, long errCode, string desc);
        /// <summary>
        /// 连接断开
        /// </summary>
        /// <param name="client"></param>
        /// <param name="errCode">高32位为FTAPI_ConnectFailType类型，低32位为系统错误码；</param>
        void OnDisconnect(FTAPI_Conn client, long errCode);
    }

    public class FTAPI
    {
        private static bool isInited = false;
        private static object initLock = new object();

        /// <summary>
        /// 初始化底层库，程序启动时调用一次。
        /// </summary>
        public static void Init()
        {
            lock (initLock)
            {
                if (isInited) return;
                FTCAPI.FTAPIChannel_Init();
                isInited = true;
            }
        }

        /// <summary>
        /// 清理底层库，程序退出时调用一次。
        /// </summary>
        public static void UnInit()
        {
            lock (initLock)
            {
                if (!isInited) return;
                FTCAPI.FTAPIChannel_UnInit();
                isInited = false;
            }
        }
    }

    public class FTAPI_Conn : IDisposable
    {
        /// <summary>
        /// <see cref="FTSPI_Conn.OnInitConnect"/>
        /// </summary>
        public const int InitFail = 100;

		bool disposed = false;
        protected IntPtr channel;
        private FTSPI_Conn connCallback;
        private FTCAPI.OnInitConnectCallback initConnectCallback;
        private FTCAPI.OnReplyCallback replyCallback;
        private FTCAPI.OnPushCallback pushCallback;
        private FTCAPI.OnDisConnectCallback disConnCallback;
        private object connCallbackLock = new object();

        public FTAPI_Conn()
        {
            this.channel = FTCAPI.CreateFTAPIChannel();
            FTCAPI.FTAPIChannel_SetProgrammingLanguage(this.channel, "C#");
            this.initConnectCallback = (IntPtr pChannel, long errCode, string desc) =>
                {
                    this.OnInitConnect(errCode, desc);
                };
            this.replyCallback = (IntPtr pChannel, int enReqReplyType, IntPtr protoHeaderPtr, IntPtr protoData, int nDataLen) =>
                {
                    ProtoHeader protoHeader = (ProtoHeader)Marshal.PtrToStructure(protoHeaderPtr, typeof(ProtoHeader));
                    byte[] data = null;
                    if (nDataLen > 0 && protoData != IntPtr.Zero)
                    {
                        data = new byte[nDataLen];
                        Marshal.Copy(protoData, data, 0, nDataLen);
                    }
                    
                    this.OnReply((ReqReplyType)enReqReplyType, protoHeader, data);
                };
            this.pushCallback = (IntPtr pChannel, IntPtr protoHeaderPtr, IntPtr protoData, int nDataLen) =>
                {
                    ProtoHeader protoHeader = (ProtoHeader)Marshal.PtrToStructure(protoHeaderPtr, typeof(ProtoHeader));
                    byte[] data = new byte[nDataLen];
                    Marshal.Copy(protoData, data, 0, nDataLen);
                    this.OnPush(protoHeader, data);
                };
            this.disConnCallback = (IntPtr pChannel, long errCode) =>
                {
                    this.OnDisConnect(errCode);
                };

            FTCAPI.FTAPIChannel_SetOnInitConnectCallback(channel, initConnectCallback);
            FTCAPI.FTAPIChannel_SetOnDisconnectCallback(channel, disConnCallback);
            FTCAPI.FTAPIChannel_SetOnReplyCallback(channel, replyCallback);
            FTCAPI.FTAPIChannel_SetOnPushCallback(channel, pushCallback);
        }

        public void SetConnCallback(FTSPI_Conn connCallback)
        {
            lock(connCallbackLock)
            {
                this.connCallback = connCallback;
            }
        }

        public void Close()
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    FTCAPI.FTAPIChannel_Close(this.channel);
                }
            }
        }

        public void SetClientInfo(string clientID, int clientVer)
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    FTCAPI.FTAPIChannel_SetClientInfo(this.channel, clientID, clientVer);
                }
            }
        }

        public void SetRSAPrivateKey(string key)
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    FTCAPI.FTAPIChannel_SetRSAPrivateKey(this.channel, key);
                }
            }
        }

        public ulong GetConnectID()
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    return FTCAPI.FTAPIChannel_GetConnectID(this.channel);
                }
            }
            
            return 0;
        }

        public bool InitConnect(string ip, ushort port, bool isEnableEncrypt)
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    int ret = FTCAPI.FTAPIChannel_InitConnect(this.channel, ip, port, isEnableEncrypt ? 1 : 0);
                    return ret == 0;
                }
            }
            
            return false;
        }

        protected uint SendProto<TMessage, TBuilder>(uint protoID, GeneratedMessage<TMessage, TBuilder> req)
            where TMessage : Google.ProtocolBuffers.GeneratedMessage<TMessage, TBuilder>
            where TBuilder : Google.ProtocolBuffers.GeneratedBuilder<TMessage, TBuilder>, new()
        {
            lock(this)
            {
                if (this.channel != null)
                {
                    byte[] data = req.ToByteArray();
                    IntPtr dataPtr = Marshal.AllocHGlobal(data.Length);
                    Marshal.Copy(data, 0, dataPtr, data.Length);
                    uint serialNo = FTCAPI.FTAPIChannel_SendProto(this.channel, protoID, (byte)0, dataPtr, data.Length);
                    Marshal.FreeHGlobal(dataPtr);
                    return serialNo;
                }
            }
            
            return 0;
        }

        protected void OnConnect(long errCode)
        {
            lock (connCallbackLock)
            {
                if (connCallback != null && errCode != 0)
				{
                    connCallback.OnInitConnect(this, errCode, "Connect Failed");
				}
			}
        }

        protected void OnInitConnect(long errCode, string desc)
        {
			lock(connCallbackLock)
            {
				if (connCallback != null)
				{
					connCallback.OnInitConnect(this, errCode, desc);
				}
			}
        }

        protected void OnDisConnect(long errCode)
        {
            lock (connCallbackLock)
            {
				if (connCallback != null)
				{
					connCallback.OnDisconnect(this, errCode);
				}
			}
        }

        protected virtual void OnTimeTicker()
        {

        }

        protected virtual void OnReply(ReqReplyType replyType, ProtoHeader protoHeader, byte[] data)
        {
            
        }

        protected virtual void OnPush(ProtoHeader protoHeader, byte[] data)
        {

        }
		
		public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            FTCAPI.ReleaseFTAPIChannel(channel);
            channel = (IntPtr)0;
            disposed = true;
        }

        ~FTAPI_Conn()
        {
            Dispose(false);
        }
    }
}

