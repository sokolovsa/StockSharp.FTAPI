using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Futu.OpenApi;
using Futu.OpenApi.Pb;
using Google.ProtocolBuffers;

namespace FTAPI4NetSample
{
    class QuoteAndTradeDemo : DemoBase
    {
        public void QuoteTest()
        {
            bool ret = InitConnectQotSync(Config.OpendIP, Config.OpendPort);
            if (!ret)
            {
                Console.Error.WriteLine("Fail to connect opend");
                return;
            }
            List<QotCommon.Security> secArr = new List<QotCommon.Security>() {
                    MakeSec(QotCommon.QotMarket.QotMarket_HK_Security, "00388"),
                    MakeSec(QotCommon.QotMarket.QotMarket_HK_Security, "00700"),
                    MakeSec(QotCommon.QotMarket.QotMarket_HK_Security, "HSImain")
            };
            List<QotCommon.SubType> subTypes = new List<QotCommon.SubType>() {
                    QotCommon.SubType.SubType_Basic,
                    QotCommon.SubType.SubType_Broker,
                    QotCommon.SubType.SubType_OrderBook,
                    QotCommon.SubType.SubType_RT,
                    QotCommon.SubType.SubType_KL_Day,
                    QotCommon.SubType.SubType_Ticker
            };
            QotSub.Response subRsp = SubSync(secArr, subTypes, true, true);
            if (subRsp.RetType != (int)Common.RetType.RetType_Succeed)
            {
                Console.Error.Write("subSync err; retType={0} msg={1}\n", subRsp.RetType, subRsp.RetMsg);
            }
        }

        public void TradeHkTest()
        {
            bool ret = InitConnectTrdSync(Config.OpendIP, Config.OpendPort);
            if (!ret)
            {
                Console.Error.WriteLine("Fail to connect opend");
                return;
            }
            else
            {
                Console.WriteLine("trd connected");
            }

            TrdUnlockTrade.Response unlockTradeRsp = UnlockTradeSync(Config.UnlockTradePwdMd5, true);
            if (unlockTradeRsp.RetType != (int)Common.RetType.RetType_Succeed)
            {
                Console.Error.Write("unlockTradeSync err; retType={0} msg={1}\n", unlockTradeRsp.RetType, unlockTradeRsp.RetMsg);
            }
            else
            {
                Console.WriteLine("unlock succeed");
            }

            TrdGetFunds.Response getFundsRsp = GetFundsSync(Config.TrdAcc, TrdCommon.TrdMarket.TrdMarket_HK, TrdCommon.TrdEnv.TrdEnv_Real,
                    false, TrdCommon.Currency.Currency_Unknown);
            Console.Write("getFundsSync: {0}\n", getFundsRsp);

            TrdGetAccList.Response getAccListRsp = GetAccListSync(Config.UserID);
            Console.Write("getAccList: {0}\n", getAccListRsp);

            {
                TrdGetPositionList.Response getPositionListRsp = GetPositionListSync(Config.TrdAcc,
                        TrdCommon.TrdMarket.TrdMarket_HK,
                        TrdCommon.TrdEnv.TrdEnv_Real, null,
                        -50.0, 50.0, false);
                Console.Write("getPositionList: {0}\n", getPositionListRsp);
            }

            {
                TrdGetOrderList.Response getOrderListRsp = GetOrderListSync(Config.TrdAcc, TrdCommon.TrdMarket.TrdMarket_HK,
                        TrdCommon.TrdEnv.TrdEnv_Real, false, null,
                        new List<TrdCommon.OrderStatus> { TrdCommon.OrderStatus.OrderStatus_Submitted });
                Console.Write("getOrderList: {0}\n", getOrderListRsp);
            }

            {
                TrdCommon.TrdHeader header = TrdCommon.TrdHeader.CreateBuilder()
                        .SetTrdEnv((int)TrdCommon.TrdEnv.TrdEnv_Real)
                        .SetAccID(Config.TrdAcc)
                        .SetTrdMarket((int)TrdCommon.TrdMarket.TrdMarket_HK)
                        .Build();
                TrdPlaceOrder.C2S c2s = TrdPlaceOrder.C2S.CreateBuilder()
                        .SetPacketID(trd.NextPacketID())
                        .SetHeader(header)
                        .SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Sell)
                        .SetOrderType((int)TrdCommon.OrderType.OrderType_Normal)
                        .SetCode("00700")
                        .SetQty(100)
                        .SetPrice(700)
                        .SetAdjustPrice(true)
                        .SetSecMarket((int)TrdCommon.TrdSecMarket.TrdSecMarket_HK)
                        .Build();
                TrdPlaceOrder.Response placeOrderRsp = PlaceOrderSync(c2s);
                Console.Write("placeOrder: {0}\n", placeOrderRsp);
            }

            {
                TrdCommon.TrdFilterConditions filterConditions = TrdCommon.TrdFilterConditions.CreateBuilder()
                        .AddCodeList("00700")
                        .Build();
                TrdGetOrderFillList.Response getOrderFillListRsp = GetOrderFillListSync(Config.TrdAcc,
                        TrdCommon.TrdMarket.TrdMarket_HK,
                        TrdCommon.TrdEnv.TrdEnv_Real, false, filterConditions);
                Console.Write("getOrderFillList: {0}\n", getOrderFillListRsp);
            }
        }


        public override void OnReply_UpdateOrderBook(FTAPI_Conn client, uint nSerialNo, QotUpdateOrderBook.Response rsp)
        {
            Console.Write("OnReply_UpdateOrderBook: {0}\n", rsp);
        }


        public override void OnReply_UpdateBasicQot(FTAPI_Conn client, uint nSerialNo, QotUpdateBasicQot.Response rsp)
        {
            Console.Write("OnReply_UpdateBasicQuote: {0}\n", rsp);
        }


        public override void OnReply_UpdateKL(FTAPI_Conn client, uint nSerialNo, QotUpdateKL.Response rsp)
        {
            Console.Write("OnReply_UpdateKL: {0}\n", rsp);
        }


        public override void OnReply_UpdateRT(FTAPI_Conn client, uint nSerialNo, QotUpdateRT.Response rsp)
        {
            Console.Write("OnReply_UpdateRT: {0}\n", rsp);
        }


        public override void OnReply_UpdateTicker(FTAPI_Conn client, uint nSerialNo, QotUpdateTicker.Response rsp)
        {
            Console.Write("OnReply_UpdateTicker: {0}\n", rsp);
        }


        public override void OnReply_UpdateBroker(FTAPI_Conn client, uint nSerialNo, QotUpdateBroker.Response rsp)
        {
            Console.Write("OnReply_UpdateBroker: {0}\n", rsp);
        }


        public override void OnReply_UpdateOrder(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrder.Response rsp)
        {
            Console.Write("OnReply_UpdateOrder: {}\n", rsp);
        }


        public override void OnReply_UpdateOrderFill(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrderFill.Response rsp)
        {
            Console.Write("OnReply_UpdateOrderFill: {}\n", rsp);
        }
    }
}
