using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Futu.OpenApi.Pb;
using Google.ProtocolBuffers;

namespace Futu.OpenApi
{
    public interface FTSPI_Trd
    {
        void OnReply_GetAccList(FTAPI_Conn client, uint nSerialNo, TrdGetAccList.Response rsp); //获取交易账户列表回调
        void OnReply_UnlockTrade(FTAPI_Conn client, uint nSerialNo, TrdUnlockTrade.Response rsp); //解锁回调
        void OnReply_SubAccPush(FTAPI_Conn client, uint nSerialNo, TrdSubAccPush.Response rsp); //订阅接收推送数据的交易账户回调
        void OnReply_GetFunds(FTAPI_Conn client, uint nSerialNo, TrdGetFunds.Response rsp); //获取账户资金回调
        void OnReply_GetPositionList(FTAPI_Conn client, uint nSerialNo, TrdGetPositionList.Response rsp); //获取账户持仓回调
        void OnReply_GetMaxTrdQtys(FTAPI_Conn client, uint nSerialNo, TrdGetMaxTrdQtys.Response rsp); //获取最大交易数量回调
        void OnReply_GetOrderList(FTAPI_Conn client, uint nSerialNo, TrdGetOrderList.Response rsp); //获取当日订单列表回调
        void OnReply_PlaceOrder(FTAPI_Conn client, uint nSerialNo, TrdPlaceOrder.Response rsp); //下单回调
        void OnReply_ModifyOrder(FTAPI_Conn client, uint nSerialNo, TrdModifyOrder.Response rsp); //修改订单回调
        void OnReply_GetOrderFillList(FTAPI_Conn client, uint nSerialNo, TrdGetOrderFillList.Response rsp); //获取当日成交列表回调
        void OnReply_GetHistoryOrderList(FTAPI_Conn client, uint nSerialNo, TrdGetHistoryOrderList.Response rsp); //获取历史订单列表回调
        void OnReply_GetHistoryOrderFillList(FTAPI_Conn client, uint nSerialNo, TrdGetHistoryOrderFillList.Response rsp); //获取历史成交列表回调
        void OnReply_UpdateOrder(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrder.Response rsp); //订单状态变动通知(推送)回调
        void OnReply_UpdateOrderFill(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrderFill.Response rsp); //成交通知(推送)回调
    }

    public class FTAPI_Trd : FTAPI_Conn
    {
        private FTSPI_Trd trdCallback;
        private uint trdSerialNo = 100;
        private object trdCallbackLock = new object();

        public void SetTrdCallback(FTSPI_Trd callback)
        {
            lock (trdCallbackLock)
            {
                trdCallback = callback;
            }
        }

        public Common.PacketID NextPacketID()
        {
            lock (this)
            {
                Common.PacketID packetID = Common.PacketID.CreateBuilder().SetConnID(GetConnectID()).SetSerialNo(++trdSerialNo).Build();
                return packetID;
            }
        }

        /***
         * 获取交易账户列表，具体字段请参考Trd_GetAccList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetAccList(TrdGetAccList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetAccList, req);
        }
        /***
         * 解锁，具体字段请参考Trd_UnlockTrade.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint UnlockTrade(TrdUnlockTrade.Request req)
        {
            return SendProto((uint)ProtoID.TrdUnlockTrade, req);
        }
        /***
         * 订阅接收推送数据的交易账户，具体字段请参考Trd_SubAccPush.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint SubAccPush(TrdSubAccPush.Request req)
        {
            return SendProto((uint)ProtoID.TrdSubAccPush, req);
        }
        /***
         * 获取账户资金，具体字段请参考Trd_GetFunds.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetFunds(TrdGetFunds.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetFunds, req);
        }
        /***
         * 获取账户持仓，具体字段请参考Trd_GetPositionList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetPositionList(TrdGetPositionList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetPositionList, req);
        }
        /***
         * 获取最大交易数量，具体字段请参考Trd_GetMaxTrdQtys.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetMaxTrdQtys(TrdGetMaxTrdQtys.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetMaxTrdQtys, req);
        }
        /***
         * 获取当日订单列表，具体字段请参考Trd_GetOrderList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetOrderList(TrdGetOrderList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetOrderList, req);
        }
        /***
         * 下单，具体字段请参考Trd_PlaceOrder.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint PlaceOrder(TrdPlaceOrder.Request req)
        {
            if (req.HasC2S)
            {
                Common.PacketID packetID = NextPacketID();
                req = req.ToBuilder().SetC2S(req.C2S.ToBuilder().SetPacketID(packetID)).Build();
            }
            return SendProto((uint)ProtoID.TrdPlaceOrder, req);
        }
        /***
         * 修改订单，具体字段请参考Trd_ModifyOrder.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint ModifyOrder(TrdModifyOrder.Request req)
        {
            if (req.HasC2S)
            {
                Common.PacketID packetID = NextPacketID();
                req = req.ToBuilder().SetC2S(req.C2S.ToBuilder().SetPacketID(packetID)).Build();
            }
            return SendProto((uint)ProtoID.TrdModifyOrder, req);
        }
        /***
         * 获取当日成交列表，具体字段请参考Trd_GetOrderFillList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetOrderFillList(TrdGetOrderFillList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetOrderFillList, req);
        }
        /***
         * 获取历史订单列表，具体字段请参考Trd_GetHistoryOrderList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetHistoryOrderList(TrdGetHistoryOrderList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetHistoryOrderList, req);
        }
        /***
         * 获取历史成交列表，具体字段请参考Trd_GetHistoryOrderFillList.proto协议
         * @param req
         * @return 请求的序列号
         */
        public uint GetHistoryOrderFillList(TrdGetHistoryOrderFillList.Request req)
        {
            return SendProto((uint)ProtoID.TrdGetHistoryOrderFillList, req);
        }

        protected override void OnReply(ReqReplyType replyType, ProtoHeader protoHeader, byte[] data)
        {
            ProtoID protoID = (ProtoID)protoHeader.nProtoID;
            uint serialNo = protoHeader.nSerialNo;
            FTSPI_Trd trdCallback = null;

            lock (trdCallbackLock)
            {
                trdCallback = this.trdCallback;
            }

            if (trdCallback == null)
            {
                return;
            }

            switch (protoID)
            {
                case ProtoID.TrdGetAccList://获取交易账户列表
                    {
                        Futu.OpenApi.Pb.TrdGetAccList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetAccList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetAccList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetAccList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetAccList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdUnlockTrade://解锁
                    {
                        Futu.OpenApi.Pb.TrdUnlockTrade.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdUnlockTrade.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdUnlockTrade.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdUnlockTrade.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_UnlockTrade(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdSubAccPush://订阅接收推送数据的交易账户
                    {
                        Futu.OpenApi.Pb.TrdSubAccPush.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdSubAccPush.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdSubAccPush.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdSubAccPush.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_SubAccPush(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetFunds://获取账户资金
                    {
                        Futu.OpenApi.Pb.TrdGetFunds.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetFunds.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetFunds.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetFunds.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetFunds(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetPositionList://获取账户持仓
                    {
                        Futu.OpenApi.Pb.TrdGetPositionList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetPositionList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetPositionList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetPositionList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetPositionList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetMaxTrdQtys://获取最大交易数量
                    {
                        Futu.OpenApi.Pb.TrdGetMaxTrdQtys.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetMaxTrdQtys.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetMaxTrdQtys.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetMaxTrdQtys.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetMaxTrdQtys(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetOrderList://获取当日订单列表
                    {
                        Futu.OpenApi.Pb.TrdGetOrderList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetOrderList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetOrderList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetOrderList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetOrderList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdPlaceOrder://下单
                    {
                        Futu.OpenApi.Pb.TrdPlaceOrder.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdPlaceOrder.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdPlaceOrder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdPlaceOrder.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_PlaceOrder(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdModifyOrder://修改订单
                    {
                        Futu.OpenApi.Pb.TrdModifyOrder.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdModifyOrder.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdModifyOrder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdModifyOrder.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_ModifyOrder(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetOrderFillList://获取当日成交列表
                    {
                        Futu.OpenApi.Pb.TrdGetOrderFillList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetOrderFillList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetOrderFillList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetOrderFillList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetOrderFillList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetHistoryOrderList://获取历史订单列表
                    {
                        Futu.OpenApi.Pb.TrdGetHistoryOrderList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetHistoryOrderList(this, serialNo, rsp);
                    }
                    break;

                case ProtoID.TrdGetHistoryOrderFillList://获取历史成交列表
                    {
                        Futu.OpenApi.Pb.TrdGetHistoryOrderFillList.Response rsp;
                        if (replyType == ReqReplyType.SvrReply)
                        {
                            try
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderFillList.Response.ParseFrom(data);
                            }
                            catch (InvalidProtocolBufferException)
                            {
                                rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderFillList.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                            }
                        }
                        else
                        {
                            rsp = Futu.OpenApi.Pb.TrdGetHistoryOrderFillList.Response.CreateBuilder().SetRetType((int)replyType).Build();
                        }

                        trdCallback.OnReply_GetHistoryOrderFillList(this, serialNo, rsp);
                    }
                    break;
            }
        }

        protected override void OnPush(ProtoHeader protoHeader, byte[] data)
        {
            ProtoID protoID = (ProtoID)protoHeader.nProtoID;
            uint serialNo = protoHeader.nSerialNo;
            FTSPI_Trd trdCallback = null;

            lock (trdCallbackLock)
            {
                trdCallback = this.trdCallback;
            }

            if (trdCallback == null)
            {
                return;
            }
            
            switch (protoID)
            {
                case ProtoID.TrdUpdateOrder://订单状态变动通知(推送)
                    {
                        Futu.OpenApi.Pb.TrdUpdateOrder.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.TrdUpdateOrder.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.TrdUpdateOrder.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        trdCallback.OnReply_UpdateOrder(this, serialNo, rsp);
                    }
                    break;
                case ProtoID.TrdUpdateOrderFill://成交通知(推送)
                    {
                        Futu.OpenApi.Pb.TrdUpdateOrderFill.Response rsp;
                        try
                        {
                            rsp = Futu.OpenApi.Pb.TrdUpdateOrderFill.Response.ParseFrom(data);
                        }
                        catch (InvalidProtocolBufferException)
                        {
                            rsp = Futu.OpenApi.Pb.TrdUpdateOrderFill.Response.CreateBuilder().SetRetType((int)Common.RetType.RetType_Invalid).Build();
                        }
                        trdCallback.OnReply_UpdateOrderFill(this, serialNo, rsp);
                    }
                    break;
            }
        }
    }
}

