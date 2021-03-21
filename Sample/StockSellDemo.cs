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
    class StockSellDemo : DemoBase
    {
        void simpleSell(String code, QotCommon.QotMarket qotMarket, TrdCommon.TrdSecMarket secMarket,
                    double price, int volume, TrdCommon.OrderType orderType,
                    TrdCommon.TrdEnv trdEnv,
                    ulong accID,
                    TrdCommon.TrdMarket trdMarket,
                    String trdPwdMD5) {
        bool ret = InitConnectQotSync(Config.OpendIP, Config.OpendPort);
            if (!ret) {
                Console.Error.WriteLine("Fail to connect opend");
                return;
            }
            ret = InitConnectTrdSync(Config.OpendIP, Config.OpendPort);
            if (!ret) {
                Console.Error.WriteLine("Fail to connect opend");
                return;
            }
            int lotSize = 0;
            QotCommon.Security sec = MakeSec(qotMarket, code);
            while (true) {
                Thread.Sleep(1000);
                if (lotSize == 0) {
                    List<QotCommon.Security> secList = new List<QotCommon.Security>();
                    secList.Add(sec);
                    QotGetSecuritySnapshot.Response rsp = GetSecuritySnapshotSync(secList);
                    if (rsp.RetType != (int)Common.RetType.RetType_Succeed) {
                        Console.Error.Write("getSecuritySnapshotSync err; retType={0} msg={1}\n", rsp.RetType,
                                rsp.RetMsg);
                        return;
                    }
                    lotSize = rsp.S2C.SnapshotListList[0].Basic.LotSize;
                    if (lotSize <= 0) {
                        Console.Error.Write("invalid lot size; code={0} lotSize={1}\n", code, lotSize);
                        return;
                    }
                }

                int qty = (volume / lotSize) * lotSize; // 将数量调整为整手的股数
                TrdCommon.TrdHeader trdHeader = MakeTrdHeader(trdEnv, accID, trdMarket);
                TrdPlaceOrder.C2S c2s = TrdPlaceOrder.C2S.CreateBuilder()
                        .SetHeader(trdHeader)
                        .SetPacketID(trd.NextPacketID())
                        .SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Sell)
                        .SetOrderType((int)orderType)
                        .SetCode(code)
                        .SetQty(qty)
                        .SetPrice(price)
                        .SetAdjustPrice(true)
                        .SetSecMarket((int)secMarket)
                        .Build();
                TrdPlaceOrder.Response placeOrderRsp = PlaceOrderSync(c2s);
                if (placeOrderRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("placeOrderSync err; retType={0} msg={1}\n", placeOrderRsp.RetType, placeOrderRsp.RetMsg);
                    return;
                } else {
                    Console.Write("下单成功: {0}\n", placeOrderRsp.S2C);
                }
            }
    }

        void smartSell(String code, QotCommon.QotMarket qotMarket, TrdCommon.TrdSecMarket secMarket,
                       int volume, TrdCommon.OrderType orderType,
                       TrdCommon.TrdEnv trdEnv,
                       ulong accID,
                       TrdCommon.TrdMarket trdMarket,
                       String trdPwdMD5) {
        int lotSize = 0;
            QotCommon.Security sec = MakeSec(qotMarket, code);
            while (true) {
                Thread.Sleep(1000);
                if (lotSize == 0) {
                    List<QotCommon.Security> secList = new List<QotCommon.Security>();
                    secList.Add(sec);
                    QotGetSecuritySnapshot.Response rsp = GetSecuritySnapshotSync(secList);
                    if (rsp.RetType != (int)Common.RetType.RetType_Succeed) {
                        Console.Error.Write("getSecuritySnapshotSync err; retType={} msg={1}\n", rsp.RetType,
                                rsp.RetMsg);
                        return;
                    }
                    lotSize = rsp.S2C.SnapshotListList[0].Basic.LotSize;
                    if (lotSize <= 0) {
                        Console.Error.Write("invalid lot size; code={0} lotSize={1}\n", code, lotSize);
                        return;
                    }
                }
                int qty = (volume / lotSize) * lotSize; // 将数量调整为整手的股数

                QotSub.Response subRsp = SubSync(new List<QotCommon.Security>(){sec},
                        new List<QotCommon.SubType>(){QotCommon.SubType.SubType_OrderBook},
                        true,
                        false);
                if (subRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("subSync er; retType={0}; msg={1}\n", subRsp.RetType, subRsp.RetMsg);
                    return;
                }

                QotGetOrderBook.Response getOrderBookRsp = GetOrderBookSync(MakeSec(qotMarket, code), 1);
                if (getOrderBookRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("getOrderBookSync er; retType={0}; msg={1}\n", subRsp.RetType, subRsp.RetMsg);
                    return;
                }
                double bid1Price = getOrderBookRsp.S2C.OrderBookBidListList[0].Price;
                TrdCommon.TrdHeader trdHeader = MakeTrdHeader(trdEnv, accID, trdMarket);
                TrdPlaceOrder.C2S c2s = TrdPlaceOrder.C2S.CreateBuilder()
                        .SetHeader(trdHeader)
                        .SetPacketID(trd.NextPacketID())
                        .SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Sell)
                        .SetOrderType((int)orderType)
                        .SetCode(code)
                        .SetQty(qty)
                        .SetPrice(bid1Price)
                        .SetAdjustPrice(true)
                        .SetSecMarket((int)secMarket)
                        .Build();
                TrdPlaceOrder.Response placeOrderRsp = PlaceOrderSync(c2s);
                if (placeOrderRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("placeOrderSync err; retType={0} msg={1}\n", placeOrderRsp.RetType, placeOrderRsp.RetMsg);
                    return;
                } else {
                    Console.Write("下单成功: {0}\n", placeOrderRsp.S2C);
                }
            }
    }
    }
}
