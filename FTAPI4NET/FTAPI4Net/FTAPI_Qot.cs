using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futu.OpenApi.Pb;
using Google.ProtocolBuffers;

namespace Futu.OpenApi
{
    public interface FTSPI_Qot
    {
        void OnReply_GetGlobalState(FTAPI_Conn client, uint nSerialNo, GetGlobalState.Response rsp); //获取全局状态回调
        void OnReply_Sub(FTAPI_Conn client, uint nSerialNo, QotSub.Response rsp); //订阅或者反订阅回调
        void OnReply_RegQotPush(FTAPI_Conn client, uint nSerialNo, QotRegQotPush.Response rsp); //注册推送回调
        void OnReply_GetSubInfo(FTAPI_Conn client, uint nSerialNo, QotGetSubInfo.Response rsp); //获取订阅信息回调
        void OnReply_GetTicker(FTAPI_Conn client, uint nSerialNo, QotGetTicker.Response rsp); //获取逐笔,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Ticker)回调
        void OnReply_GetBasicQot(FTAPI_Conn client, uint nSerialNo, QotGetBasicQot.Response rsp); //获取基本行情,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Basic)回调
        void OnReply_GetOrderBook(FTAPI_Conn client, uint nSerialNo, QotGetOrderBook.Response rsp); //获取摆盘,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_OrderBook)回调
        void OnReply_GetKL(FTAPI_Conn client, uint nSerialNo, QotGetKL.Response rsp); //获取K线，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_KL_XXX)回调
        void OnReply_GetRT(FTAPI_Conn client, uint nSerialNo, QotGetRT.Response rsp); //获取分时，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_RT)回调
        void OnReply_GetBroker(FTAPI_Conn client, uint nSerialNo, QotGetBroker.Response rsp); //获取经纪队列，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Broker)回调
        void OnReply_GetHistoryKL(FTAPI_Conn client, uint nSerialNo, QotGetHistoryKL.Response rsp); //获取本地历史K线回调
        void OnReply_GetHistoryKLPoints(FTAPI_Conn client, uint nSerialNo, QotGetHistoryKLPoints.Response rsp); //获取多股票多点本地历史K线回调
        void OnReply_GetRehab(FTAPI_Conn client, uint nSerialNo, QotGetRehab.Response rsp); //获取本地历史复权信息回调
        void OnReply_RequestRehab(FTAPI_Conn client, uint nSerialNo, QotRequestRehab.Response rsp); //在线请求历史复权信息，不读本地历史数据DB回调
        void OnReply_RequestHistoryKL(FTAPI_Conn client, uint nSerialNo, QotRequestHistoryKL.Response rsp); //在线请求历史K线，不读本地历史数据DB回调
        void OnReply_RequestHistoryKLQuota(FTAPI_Conn client, uint nSerialNo, QotRequestHistoryKLQuota.Response rsp); //获取历史K线已经用掉的额度回调
        void OnReply_GetTradeDate(FTAPI_Conn client, uint nSerialNo, QotGetTradeDate.Response rsp); //获取交易日回调
        void OnReply_GetStaticInfo(FTAPI_Conn client, uint nSerialNo, QotGetStaticInfo.Response rsp); //获取静态信息回调
        void OnReply_GetSecuritySnapshot(FTAPI_Conn client, uint nSerialNo, QotGetSecuritySnapshot.Response rsp); //获取股票快照回调
        void OnReply_GetPlateSet(FTAPI_Conn client, uint nSerialNo, QotGetPlateSet.Response rsp); //获取板块集合下的板块回调
        void OnReply_GetPlateSecurity(FTAPI_Conn client, uint nSerialNo, QotGetPlateSecurity.Response rsp); //获取板块下的股票回调
        void OnReply_GetReference(FTAPI_Conn client, uint nSerialNo, QotGetReference.Response rsp); //获取相关股票回调
        void OnReply_GetOwnerPlate(FTAPI_Conn client, uint nSerialNo, QotGetOwnerPlate.Response rsp); //获取股票所属的板块回调
        void OnReply_GetHoldingChangeList(FTAPI_Conn client, uint nSerialNo, QotGetHoldingChangeList.Response rsp); //获取大股东持股变化列表回调
        void OnReply_GetOptionChain(FTAPI_Conn client, uint nSerialNo, QotGetOptionChain.Response rsp); //筛选期权回调
        void OnReply_GetWarrant(FTAPI_Conn client, uint nSerialNo, QotGetWarrant.Response rsp); //筛选窝轮回调
        void OnReply_GetCapitalFlow(FTAPI_Conn client, uint nSerialNo, QotGetCapitalFlow.Response rsp); //获取资金流向回调
        void OnReply_GetCapitalDistribution(FTAPI_Conn client, uint nSerialNo, QotGetCapitalDistribution.Response rsp); //获取资金分布回调
        void OnReply_GetUserSecurity(FTAPI_Conn client, uint nSerialNo, QotGetUserSecurity.Response rsp); //获取自选股分组下的股票回调
        void OnReply_ModifyUserSecurity(FTAPI_Conn client, uint nSerialNo, QotModifyUserSecurity.Response rsp); //修改自选股分组下的股票回调
        void OnReply_GetIpoList(FTAPI_Conn client, uint nSerialNo, QotGetIpoList.Response rsp); //获取新股Ipo
        void OnReply_GetFutureInfo(FTAPI_Conn client, uint nSerialNo, QotGetFutureInfo.Response rsp); //获取新股Ipo
        void OnReply_RequestTradeDate(FTAPI_Conn client, uint nSerialNo, QotRequestTradeDate.Response rsp); //在线拉取交易日
        void OnReply_Notify(FTAPI_Conn client, uint nSerialNo, Notify.Response rsp); //推送通知回调
        void OnReply_StockFilter(FTAPI_Conn client, uint nSerialNo, QotStockFilter.Response rsp); //条件选股
        void OnReply_GetCodeChange(FTAPI_Conn client, uint nSerialNo, QotGetCodeChange.Response rsp); //获取股票代码变化信息
        void OnReply_SetPriceReminder(FTAPI_Conn client, uint nSerialNo, QotSetPriceReminder.Response rsp); //设置到价提醒
        void OnReply_GetPriceReminder(FTAPI_Conn client, uint nSerialNo, QotGetPriceReminder.Response rsp); //获取到价提醒
        void OnReply_GetUserSecurityGroup(FTAPI_Conn client, uint nSerialNo, QotGetUserSecurityGroup.Response rsp); //获取自选股分组
        void OnReply_GetMarketState(FTAPI_Conn client, uint nSerialNo, QotGetMarketState.Response rsp); //获取自选股分组
        void OnReply_UpdateBasicQot(FTAPI_Conn client, uint nSerialNo, QotUpdateBasicQot.Response rsp); //推送基本行情回调
        void OnReply_UpdateKL(FTAPI_Conn client, uint nSerialNo, QotUpdateKL.Response rsp); //推送K线回调
        void OnReply_UpdateRT(FTAPI_Conn client, uint nSerialNo, QotUpdateRT.Response rsp); //推送分时回调
        void OnReply_UpdateTicker(FTAPI_Conn client, uint nSerialNo, QotUpdateTicker.Response rsp); //推送逐笔回调
        void OnReply_UpdateOrderBook(FTAPI_Conn client, uint nSerialNo, QotUpdateOrderBook.Response rsp); //推送买卖盘回调
        void OnReply_UpdateBroker(FTAPI_Conn client, uint nSerialNo, QotUpdateBroker.Response rsp); //推送经纪队列回调
        void OnReply_UpdateOrderDetail(FTAPI_Conn client, uint nSerialNo, QotUpdateOrderDetail.Response rsp); //推送委托明细回调
        void OnReply_UpdatePriceReminder(FTAPI_Conn client, uint nSerialNo, QotUpdatePriceReminder.Response rsp); //到价提醒通知
    }

    public class FTAPI_Qot : FTAPI_Conn
    {
        private FTSPI_Qot qotCallback;
        private object qotCallbackLock = new object();

        //设置回调函数
        public void SetQotCallback(FTSPI_Qot callback)
        {
            lock (qotCallbackLock)
            {
                qotCallback = callback;
            }
        }

        /***
         * 获取全局状态，具体字段请参考GetGlobalState.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetGlobalState(GetGlobalState.Request req)
        {
            return SendProto((uint)ProtoID.GetGlobalState, req);
        }
        /***
         * 订阅或者反订阅，具体字段请参考Qot_Sub.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint Sub(QotSub.Request req)
        {
            return SendProto((uint)ProtoID.QotSub, req);
        }
        /***
         * 注册推送，具体字段请参考Qot_RegQotPush.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint RegQotPush(QotRegQotPush.Request req)
        {
            return SendProto((uint)ProtoID.QotRegQotPush, req);
        }
        /***
         * 获取订阅信息，具体字段请参考Qot_GetSubInfo.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetSubInfo(QotGetSubInfo.Request req)
        {
            return SendProto((uint)ProtoID.QotGetSubInfo, req);
        }
        /***
         * 获取逐笔,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Ticker)，具体字段请参考Qot_GetTicker.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetTicker(QotGetTicker.Request req)
        {
            return SendProto((uint)ProtoID.QotGetTicker, req);
        }
        /***
         * 获取基本行情,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Basic)，具体字段请参考Qot_GetBasicQot.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetBasicQot(QotGetBasicQot.Request req)
        {
            return SendProto((uint)ProtoID.QotGetBasicQot, req);
        }
        /***
         * 获取摆盘,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_OrderBook)，具体字段请参考Qot_GetOrderBook.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetOrderBook(QotGetOrderBook.Request req)
        {
            return SendProto((uint)ProtoID.QotGetOrderBook, req);
        }
        /***
         * 获取K线，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_KL_XXX)，具体字段请参考Qot_GetKL.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetKL(QotGetKL.Request req)
        {
            return SendProto((uint)ProtoID.QotGetKL, req);
        }
        /***
         * 获取分时，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_RT)，具体字段请参考Qot_GetRT.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetRT(QotGetRT.Request req)
        {
            return SendProto((uint)ProtoID.QotGetRT, req);
        }
        /***
         * 获取经纪队列，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Broker)，具体字段请参考Qot_GetBroker.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetBroker(QotGetBroker.Request req)
        {
            return SendProto((uint)ProtoID.QotGetBroker, req);
        }
        /***
         * 获取本地历史K线，具体字段请参考Qot_GetHistoryKL.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetHistoryKL(QotGetHistoryKL.Request req)
        {
            return SendProto((uint)ProtoID.QotGetHistoryKL, req);
        }
        /***
         * 获取多股票多点本地历史K线，具体字段请参考Qot_GetHistoryKLPoints.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetHistoryKLPoints(QotGetHistoryKLPoints.Request req)
        {
            return SendProto((uint)ProtoID.QotGetHistoryKLPoints, req);
        }
        /***
         * 获取本地历史复权信息，具体字段请参考Qot_GetRehab.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetRehab(QotGetRehab.Request req)
        {
            return SendProto((uint)ProtoID.QotGetRehab, req);
        }
        /***
         * 在线请求历史复权信息，不读本地历史数据DB，具体字段请参考Qot_RequestRehab.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint RequestRehab(QotRequestRehab.Request req)
        {
            return SendProto((uint)ProtoID.QotRequestRehab, req);
        }
        /***
         * 在线请求历史K线，不读本地历史数据DB，具体字段请参考Qot_RequestHistoryKL.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint RequestHistoryKL(QotRequestHistoryKL.Request req)
        {
            return SendProto((uint)ProtoID.QotRequestHistoryKL, req);
        }
        /***
         * 获取历史K线已经用掉的额度，具体字段请参考Qot_RequestHistoryKLQuota.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint RequestHistoryKLQuota(QotRequestHistoryKLQuota.Request req)
        {
            return SendProto((uint)ProtoID.QotRequestHistoryKLQuota, req);
        }
        /***
         * 获取交易日，具体字段请参考Qot_GetTradeDate.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetTradeDate(QotGetTradeDate.Request req)
        {
            return SendProto((uint)ProtoID.QotGetTradeDate, req);
        }
        /***
         * 获取静态信息，具体字段请参考Qot_GetStaticInfo.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetStaticInfo(QotGetStaticInfo.Request req)
        {
            return SendProto((uint)ProtoID.QotGetStaticInfo, req);
        }
        /***
         * 获取股票快照，具体字段请参考Qot_GetSecuritySnapshot.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetSecuritySnapshot(QotGetSecuritySnapshot.Request req)
        {
            return SendProto((uint)ProtoID.QotGetSecuritySnapshot, req);
        }
        /***
         * 获取板块集合下的板块，具体字段请参考Qot_GetPlateSet.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetPlateSet(QotGetPlateSet.Request req)
        {
            return SendProto((uint)ProtoID.QotGetPlateSet, req);
        }
        /***
         * 获取板块下的股票，具体字段请参考Qot_GetPlateSecurity.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetPlateSecurity(QotGetPlateSecurity.Request req)
        {
            return SendProto((uint)ProtoID.QotGetPlateSecurity, req);
        }
        /***
         * 获取相关股票，具体字段请参考Qot_GetReference.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetReference(QotGetReference.Request req)
        {
            return SendProto((uint)ProtoID.QotGetReference, req);
        }
        /***
         * 获取股票所属的板块，具体字段请参考Qot_GetOwnerPlate.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetOwnerPlate(QotGetOwnerPlate.Request req)
        {
            return SendProto((uint)ProtoID.QotGetOwnerPlate, req);
        }
        /***
         * 获取大股东持股变化列表，具体字段请参考Qot_GetHoldingChangeList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetHoldingChangeList(QotGetHoldingChangeList.Request req)
        {
            return SendProto((uint)ProtoID.QotGetHoldingChangeList, req);
        }
        /***
         * 筛选期权，具体字段请参考Qot_GetOptionChain.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetOptionChain(QotGetOptionChain.Request req)
        {
            return SendProto((uint)ProtoID.QotGetOptionChain, req);
        }
        /***
         * 筛选窝轮，具体字段请参考Qot_GetWarrant.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetWarrant(QotGetWarrant.Request req)
        {
            return SendProto((uint)ProtoID.QotGetWarrant, req);
        }
        /***
         * 获取资金流向，具体字段请参考Qot_GetCapitalFlow.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetCapitalFlow(QotGetCapitalFlow.Request req)
        {
            return SendProto((uint)ProtoID.QotGetCapitalFlow, req);
        }
        /***
         * 获取资金分布，具体字段请参考Qot_GetCapitalDistribution.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetCapitalDistribution(QotGetCapitalDistribution.Request req)
        {
            return SendProto((uint)ProtoID.QotGetCapitalDistribution, req);
        }
        /***
         * 获取自选股分组下的股票，具体字段请参考Qot_GetUserSecurity.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetUserSecurity(QotGetUserSecurity.Request req)
        {
            return SendProto((uint)ProtoID.QotGetUserSecurity, req);
        }
        /***
         * 修改自选股分组下的股票，具体字段请参考Qot_ModifyUserSecurity.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint ModifyUserSecurity(QotModifyUserSecurity.Request req)
        {
            return SendProto((uint)ProtoID.QotModifyUserSecurity, req);
        }
        /***
	    * @brief 条件选股
	    * @param [in] stReq 请求包，具体字段请参考Qot_StockFilter.proto协议
	    * @return Futu::u32_t 包序列号， 0表示请求发送失败
	    */
        public uint StockFilter(QotStockFilter.Request req)
        {
            return SendProto((uint)ProtoID.QotStockFilter, req);
        }
        /***
	    * @brief 获取股票代码变化
	    * @param [in] stReq 请求包，具体字段请参考Qot_GetCodeChange.proto协议
	    * @return Futu::u32_t 包序列号， 0表示请求发送失败
	    */
        public uint GetCodeChange(QotGetCodeChange.Request req)
        {
            return SendProto((uint)ProtoID.QotGetCodeChange, req);
        }
        /***
	    * @brief 获取新股IPO
	    * @param [in] stReq 请求包，具体字段请参考Qot_GetIpoList.proto协议
	    * @return Futu::u32_t 包序列号， 0表示请求发送失败
	    */
        public uint GetIpoList(QotGetIpoList.Request req)
        {
            return SendProto((uint)ProtoID.QotGetIpoList, req);
        }
        /***
	    * @brief 获取期货合约资料
	    * @param [in] stReq 请求包，具体字段请参考Qot_GetFutureInfo.proto协议
	    * @return Futu::u32_t 包序列号， 0表示请求发送失败
	    */
        public uint GetFutureInfo(QotGetFutureInfo.Request req)
        {
            return SendProto((uint)ProtoID.QotGetFutureInfo, req);
        }
        /***
       * @brief 在线拉取交易日
       * @param [in] stReq 请求包，具体字段请参考Qot_RequestTradeDate.proto协议
       * @return Futu::u32_t 包序列号， 0表示请求发送失败
       */
        public uint RequestTradeDate(QotRequestTradeDate.Request req)
        {
            return SendProto((uint)ProtoID.QotRequestTradeDate, req);
        }
        /***
        * 设置到价提醒, 具体字段请参考QotSetPriceReminder.proto协议
        * @param req
        * @return 请求的序列号
        */
        public uint SetPriceReminder(QotSetPriceReminder.Request req) 
        {
            return SendProto((uint)ProtoID.QotSetPriceReminder, req);
        }

        /***
         * 获取到价提醒, 具体字段请参考QotGetPriceReminder.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetPriceReminder(QotGetPriceReminder.Request req) 
        { 
            return SendProto((uint)ProtoID.QotGetPriceReminder, req); 
        }

        /***
         * 获取自选股分组，具体字段请参考Qot_GetUserSecurityGroup.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetUserSecurityGroup(QotGetUserSecurityGroup.Request req)
        {
            return SendProto((uint)ProtoID.QotGetUserSecurityGroup, req);
        }

        /***
         * 获取自选股分组，具体字段请参考Qot_GetMarketState.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetMarketState(QotGetMarketState.Request req)
        {
            return SendProto((uint)ProtoID.QotGetMarketState, req);
        }

        protected override void OnReply(ReqReplyType replyType, ProtoHeader protoHeader, byte[] data)
        {
            ProtoID protoID = (ProtoID)protoHeader.nProtoID;
            uint serialNo = protoHeader.nSerialNo;
            FTSPI_Qot qotCallback = null;
            lock(qotCallbackLock)
            {
                qotCallback = this.qotCallback;
            }
            if (qotCallback == null)
            {
                return;
            }

            switch (protoID)
            {
                case ProtoID.GetGlobalState://获取全局状态
                    {
                        Futu.OpenApi.Pb.GetGlobalState.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.GetGlobalState.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.GetGlobalState.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.GetGlobalState.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetGlobalState(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotSub://订阅或者反订阅
                    {
                        Futu.OpenApi.Pb.QotSub.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotSub.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotSub.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotSub.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_Sub(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotRegQotPush://注册推送
                    {
                        Futu.OpenApi.Pb.QotRegQotPush.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotRegQotPush.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotRegQotPush.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotRegQotPush.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_RegQotPush(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetSubInfo://获取订阅信息
                    {
                        Futu.OpenApi.Pb.QotGetSubInfo.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetSubInfo.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetSubInfo.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetSubInfo.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetSubInfo(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetTicker://获取逐笔,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Ticker)
                    {
                        Futu.OpenApi.Pb.QotGetTicker.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetTicker.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetTicker.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetTicker.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetTicker(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetBasicQot://获取基本行情,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Basic)
                    {
                        Futu.OpenApi.Pb.QotGetBasicQot.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetBasicQot.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetBasicQot.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetBasicQot.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetBasicQot(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetOrderBook://获取摆盘,调用该接口前需要先订阅(订阅位：Qot_Common.SubType_OrderBook)
                    {
                        Futu.OpenApi.Pb.QotGetOrderBook.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOrderBook.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOrderBook.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetOrderBook.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetOrderBook(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetKL://获取K线，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_KL_XXX)
                    {
                        Futu.OpenApi.Pb.QotGetKL.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetKL.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetKL.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetKL.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetKL(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetRT://获取分时，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_RT)
                    {
                        Futu.OpenApi.Pb.QotGetRT.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetRT.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetRT.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetRT.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetRT(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetBroker://获取经纪队列，调用该接口前需要先订阅(订阅位：Qot_Common.SubType_Broker)
                    {
                        Futu.OpenApi.Pb.QotGetBroker.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetBroker.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetBroker.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetBroker.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetBroker(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetHistoryKL://获取本地历史K线
                    {
                        Futu.OpenApi.Pb.QotGetHistoryKL.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHistoryKL.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHistoryKL.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetHistoryKL.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetHistoryKL(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetHistoryKLPoints://获取多股票多点本地历史K线
                    {
                        Futu.OpenApi.Pb.QotGetHistoryKLPoints.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHistoryKLPoints.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHistoryKLPoints.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetHistoryKLPoints.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetHistoryKLPoints(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetRehab://获取本地历史复权信息
                    {
                        Futu.OpenApi.Pb.QotGetRehab.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetRehab.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetRehab.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetRehab.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetRehab(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotRequestRehab://在线请求历史复权信息，不读本地历史数据DB
                    {
                        Futu.OpenApi.Pb.QotRequestRehab.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestRehab.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestRehab.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotRequestRehab.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_RequestRehab(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotRequestHistoryKL://在线请求历史K线，不读本地历史数据DB
                    {
                        Futu.OpenApi.Pb.QotRequestHistoryKL.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestHistoryKL.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestHistoryKL.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotRequestHistoryKL.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_RequestHistoryKL(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotRequestHistoryKLQuota://获取历史K线已经用掉的额度
                    {
                        Futu.OpenApi.Pb.QotRequestHistoryKLQuota.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestHistoryKLQuota.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestHistoryKLQuota.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotRequestHistoryKLQuota.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_RequestHistoryKLQuota(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetTradeDate://获取交易日
                    {
                        Futu.OpenApi.Pb.QotGetTradeDate.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetTradeDate.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetTradeDate.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetTradeDate.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetTradeDate(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetStaticInfo://获取静态信息
                    {
                        Futu.OpenApi.Pb.QotGetStaticInfo.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetStaticInfo.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetStaticInfo.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetStaticInfo.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetStaticInfo(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetSecuritySnapshot://获取股票快照
                    {
                        Futu.OpenApi.Pb.QotGetSecuritySnapshot.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetSecuritySnapshot.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetSecuritySnapshot.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetSecuritySnapshot.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetSecuritySnapshot(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetPlateSet://获取板块集合下的板块
                    {
                        Futu.OpenApi.Pb.QotGetPlateSet.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPlateSet.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPlateSet.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetPlateSet.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetPlateSet(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetPlateSecurity://获取板块下的股票
                    {
                        Futu.OpenApi.Pb.QotGetPlateSecurity.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPlateSecurity.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPlateSecurity.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetPlateSecurity.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetPlateSecurity(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetReference://获取相关股票
                    {
                        Futu.OpenApi.Pb.QotGetReference.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetReference.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetReference.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetReference.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetReference(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetOwnerPlate://获取股票所属的板块
                    {
                        Futu.OpenApi.Pb.QotGetOwnerPlate.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOwnerPlate.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOwnerPlate.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetOwnerPlate.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetOwnerPlate(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetHoldingChangeList://获取大股东持股变化列表
                    {
                        Futu.OpenApi.Pb.QotGetHoldingChangeList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHoldingChangeList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetHoldingChangeList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetHoldingChangeList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetHoldingChangeList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetOptionChain://筛选期权
                    {
                        Futu.OpenApi.Pb.QotGetOptionChain.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOptionChain.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetOptionChain.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetOptionChain.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetOptionChain(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetWarrant://筛选窝轮
                    {
                        Futu.OpenApi.Pb.QotGetWarrant.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetWarrant.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetWarrant.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetWarrant.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetWarrant(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetCapitalFlow://获取资金流向
                    {
                        Futu.OpenApi.Pb.QotGetCapitalFlow.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCapitalFlow.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCapitalFlow.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetCapitalFlow.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetCapitalFlow(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetCapitalDistribution://获取资金分布
                    {
                        Futu.OpenApi.Pb.QotGetCapitalDistribution.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCapitalDistribution.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCapitalDistribution.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetCapitalDistribution.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetCapitalDistribution(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetUserSecurity://获取自选股分组下的股票
                    {
                        Futu.OpenApi.Pb.QotGetUserSecurity.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetUserSecurity.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetUserSecurity.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetUserSecurity.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetUserSecurity(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotModifyUserSecurity://修改自选股分组下的股票
                    {
                        Futu.OpenApi.Pb.QotModifyUserSecurity.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotModifyUserSecurity.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotModifyUserSecurity.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotModifyUserSecurity.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_ModifyUserSecurity(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotStockFilter:
                    {
                        Futu.OpenApi.Pb.QotStockFilter.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotStockFilter.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotStockFilter.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotStockFilter.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_StockFilter(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.QotGetCodeChange:
                    {
                        Futu.OpenApi.Pb.QotGetCodeChange.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCodeChange.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetCodeChange.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetCodeChange.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetCodeChange(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotGetIpoList:
                    {
                        Futu.OpenApi.Pb.QotGetIpoList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetIpoList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetIpoList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetIpoList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetIpoList(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotGetFutureInfo:
                    {
                        Futu.OpenApi.Pb.QotGetFutureInfo.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetFutureInfo.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetFutureInfo.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetFutureInfo.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetFutureInfo(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotRequestTradeDate:
                    {
                        Futu.OpenApi.Pb.QotRequestTradeDate.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestTradeDate.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotRequestTradeDate.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotRequestTradeDate.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_RequestTradeDate(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotSetPriceReminder:
                    {
                        Futu.OpenApi.Pb.QotSetPriceReminder.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotSetPriceReminder.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotSetPriceReminder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotSetPriceReminder.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_SetPriceReminder(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotGetPriceReminder:
                    {
                        Futu.OpenApi.Pb.QotGetPriceReminder.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPriceReminder.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetPriceReminder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetPriceReminder.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetPriceReminder(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotGetUserSecurityGroup:
                    {
                        Futu.OpenApi.Pb.QotGetUserSecurityGroup.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetUserSecurityGroup.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetUserSecurityGroup.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetUserSecurityGroup.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetUserSecurityGroup(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotGetMarketState:
                    {
                        Futu.OpenApi.Pb.QotGetMarketState.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.QotGetMarketState.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.QotGetMarketState.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.QotGetMarketState.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        qotCallback.OnReply_GetMarketState(this, serialNo, rsp);
                    }
                    break;
                }
        }

        protected override void OnPush(ProtoHeader protoHeader, byte[] data)
        {
            ProtoID protoID = (ProtoID)protoHeader.nProtoID;
            uint serialNo = protoHeader.nSerialNo;
            FTSPI_Qot qotCallback = null;
            lock(qotCallbackLock)
            {
                qotCallback = this.qotCallback;
            }
            if (qotCallback == null)
            {
                return;
            }

            switch (protoID)
            {
                case ProtoID.Notify://推送通知
                    {
                        Futu.OpenApi.Pb.Notify.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.Notify.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.Notify.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_Notify(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateBasicQot://推送基本行情
                    {
                        Futu.OpenApi.Pb.QotUpdateBasicQot.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateBasicQot.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateBasicQot.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateBasicQot(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateKL://推送K线
                    {
                        Futu.OpenApi.Pb.QotUpdateKL.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateKL.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateKL.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateKL(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateRT://推送分时
                    {
                        Futu.OpenApi.Pb.QotUpdateRT.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateRT.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateRT.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateRT(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateTicker://推送逐笔
                    {
                        Futu.OpenApi.Pb.QotUpdateTicker.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateTicker.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateTicker.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateTicker(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateOrderBook://推送买卖盘
                    {
                        Futu.OpenApi.Pb.QotUpdateOrderBook.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateOrderBook.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateOrderBook.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateOrderBook(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateBroker://推送经纪队列
                    {
                        Futu.OpenApi.Pb.QotUpdateBroker.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateBroker.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateBroker.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateBroker(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdateOrderDetail://推送委托明细
                    {
                        Futu.OpenApi.Pb.QotUpdateOrderDetail.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateOrderDetail.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdateOrderDetail.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdateOrderDetail(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.QotUpdatePriceReminder://推送到价提醒通知
                    {
                        Futu.OpenApi.Pb.QotUpdatePriceReminder.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdatePriceReminder.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.QotUpdatePriceReminder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        qotCallback.OnReply_UpdatePriceReminder(this, serialNo, rsp);
                    }
                    break;
            }
        }
    }
}

