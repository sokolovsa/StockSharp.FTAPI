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

    class MACDUtil {
    public static void CalcEMA(List<double> input, int n, List<double> output) {
        int inputSize = input.Count;
        if (inputSize > 0) {
            double lastEMA = input[0];
            output.Add(lastEMA);
            for (int i = 1; i < inputSize; i++) {
                double curEMA = (input[i] * 2 + lastEMA * (n - 1)) / (n + 1);
                output.Add(curEMA);
                lastEMA = curEMA;
            }
        }
    }

    public static void CalcMACD(List<double> closeList, int shortPeriod, int longPeriod, int smoothPeriod,
                         List<double> difList, List<double> deaList, List<double> macdList) {
        difList.Clear();
        deaList.Clear();
        macdList.Clear();
        List<double> shortEMA = new List<double>();
        List<double> longEMA = new List<double>();
        CalcEMA(closeList, shortPeriod, shortEMA);
        CalcEMA(closeList, longPeriod, longEMA);
        int shortCount = shortEMA.Count;
        int longCount = longEMA.Count;
        for (int i = 0; i < shortCount && i < longCount; i++) {
            difList.Add(shortEMA[i] - longEMA[i]);
        }

        CalcEMA(difList, smoothPeriod, deaList);
        int difCount = difList.Count;
        int deaCount = deaList.Count;
        for (int i = 0; i < difCount && i < deaCount; i++) {
            macdList.Add((difList[i] - deaList[i]) * 2);
        }
    }
}

    class MACDStrategyDemo : DemoBase
    {
        void Run(ulong trdAcc, String unlockTrdPwdMD5, TrdCommon.TrdMarket trdMarket,
             TrdCommon.TrdEnv trdEnv,
             QotCommon.Security sec) {
        if (sec.Market != (int)QotCommon.QotMarket.QotMarket_HK_Security &&
                sec.Market != (int)QotCommon.QotMarket.QotMarket_US_Security) {
                Console.Error.WriteLine("unsupported stock market");
                return;
            }
            bool ret = InitConnectTrdSync(Config.OpendIP, Config.OpendPort);
            if (!ret) {
                Console.Error.WriteLine("fail to connect trd");
                return;
            }
            ret = InitConnectQotSync(Config.OpendIP, Config.OpendPort);
            if (!ret) {
                Console.Error.WriteLine("fail to connect qot");
                return;
            }

            TrdUnlockTrade.Response unlockTrdRsp = UnlockTradeSync(unlockTrdPwdMD5, true);
            if (unlockTrdRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                Console.Error.Write("fail to unlock trade; retType={0} msg={1}\n", unlockTrdRsp.RetType, unlockTrdRsp.RetMsg);
                return;
            }

            DateTime now = DateTime.Now;
            DateTime startDate = now.Subtract(new TimeSpan(100, 0, 0, 0));
            QotRequestHistoryKL.Response historyKLRsp = RequestHistoryKLSync(sec, QotCommon.KLType.KLType_Day,
                    QotCommon.RehabType.RehabType_Forward,
                    startDate.ToString("yyyy-MM-dd"),
                    now.ToString("yyyy-MM-dd"),
                    1000,
                    null,
                    new byte[]{},
                    false);
            List<double> klCloseList = new List<double>();
            List<double> difList = new List<double>();
            List<double> deaList = new List<double>();
            List<double> macdList = new List<double>();
            foreach (QotCommon.KLine kl in historyKLRsp.S2C.KlListList) {
                klCloseList.Add(kl.ClosePrice);
            }
            MACDUtil.CalcMACD(klCloseList, 12, 26, 9, difList, deaList, macdList);
            int difCount = difList.Count;
            int deaCount = deaList.Count;
            if (difCount > 0 && deaCount > 0) {
                if (difList[difCount - 1] < deaList[deaCount - 1] &&
                difList[difCount - 2] > deaList[deaCount - 2]) {
                    TrdCommon.TrdFilterConditions filterConditions = TrdCommon.TrdFilterConditions.CreateBuilder()
                            .AddCodeList(sec.Code)
                            .Build();
                    TrdGetPositionList.Response getPositionListRsp = GetPositionListSync(trdAcc, trdMarket,
                            trdEnv, filterConditions, null, null, false);
                    if (getPositionListRsp.RetType != (int)Common.RetType.RetType_Succeed) {
                        Console.Error.Write("getPositionListSync err; retType={0} msg={1}\n", getPositionListRsp.RetType,
                                getPositionListRsp.RetMsg);
                        return;
                    }
                    foreach (TrdCommon.Position pstn in getPositionListRsp.S2C.PositionListList) {
                        if (pstn.CanSellQty > 0) {
                            Sell(sec, pstn, trdAcc, trdMarket, trdEnv);
                        }
                    }
                }
                else if (difList[difCount - 1] > deaList[deaCount - 1] &&
                        difList[difCount - 2] < deaList[deaCount - 2]) {
                    Buy(sec, trdAcc, trdMarket, trdEnv);
                }
            }
    }

    void Sell(QotCommon.Security sec, TrdCommon.Position pstn, ulong trdAcc, TrdCommon.TrdMarket trdMarket,
              TrdCommon.TrdEnv trdEnv) {
        QotGetSecuritySnapshot.Response snapshotRsp = GetSecuritySnapshotSync(new List<QotCommon.Security>(){sec});
        if (snapshotRsp.RetType != (int)Common.RetType.RetType_Succeed) {
            Console.Error.Write("getSecuritySnapshotSync err; retType={0} msg={1}\n", snapshotRsp.RetType, snapshotRsp.RetMsg);
            return;
        }
        double price = snapshotRsp.S2C.SnapshotListList[0].Basic.CurPrice;
        TrdCommon.TrdSecMarket secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_Unknown;
        if (sec.Market == (int)QotCommon.QotMarket.QotMarket_HK_Security) {
            secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_HK;
        } else {
            secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_US;
        }
        TrdCommon.TrdHeader trdHeader = MakeTrdHeader(trdEnv, trdAcc, trdMarket);
        TrdPlaceOrder.C2S c2s = TrdPlaceOrder.C2S.CreateBuilder()
                .SetPacketID(trd.NextPacketID())
                .SetHeader(trdHeader)
                .SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Sell)
                .SetOrderType((int)TrdCommon.OrderType.OrderType_Normal)
                .SetCode(sec.Code)
                .SetQty(pstn.CanSellQty)
                .SetPrice(price)
                .SetAdjustPrice(true)
                .SetSecMarket((int)secMarket)
                .Build();
        TrdPlaceOrder.Response placeOrderRsp = PlaceOrderSync(c2s);
        Console.WriteLine(placeOrderRsp);
    }

    void Buy(QotCommon.Security sec, ulong trdAcc, TrdCommon.TrdMarket trdMarket,
             TrdCommon.TrdEnv trdEnv) {
        TrdCommon.TrdSecMarket secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_Unknown;
        if (sec.Market == (int)QotCommon.QotMarket.QotMarket_HK_Security) {
            secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_HK;
        } else {
            secMarket = TrdCommon.TrdSecMarket.TrdSecMarket_US;
        }

        TrdGetFunds.Response getFundsRsp = GetFundsSync(trdAcc, trdMarket, trdEnv, false, TrdCommon.Currency.Currency_Unknown);
        if (getFundsRsp.RetType != (int)Common.RetType.RetType_Succeed) {
            Console.Error.Write("getFundsSync err; retType={0} msg={1}\n", getFundsRsp.RetType, getFundsRsp.RetMsg);
            return;
        }
        QotGetSecuritySnapshot.Response snapshotRsp = GetSecuritySnapshotSync(new List<QotCommon.Security>(){sec});
        if (snapshotRsp.RetType != (int)Common.RetType.RetType_Succeed) {
            Console.Error.Write("getSecuritySnapshotSync err; retType={0} msg={1}\n", snapshotRsp.RetType, snapshotRsp.RetMsg);
            return;
        }
        int lotSize = snapshotRsp.S2C.SnapshotListList[0].Basic.LotSize;
        double curPrice = snapshotRsp.S2C.SnapshotListList[0].Basic.CurPrice;
        double cash = getFundsRsp.S2C.Funds.Cash;
        int qty = (int)Math.Floor(cash / curPrice);
        qty = qty / lotSize * lotSize;
        TrdCommon.TrdHeader trdHeader = MakeTrdHeader(trdEnv, trdAcc, trdMarket);
        TrdPlaceOrder.C2S c2s = TrdPlaceOrder.C2S.CreateBuilder()
                .SetPacketID(trd.NextPacketID())
                .SetHeader(trdHeader)
                .SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Buy)
                .SetOrderType((int)TrdCommon.OrderType.OrderType_Normal)
                .SetCode(sec.Code)
                .SetQty(qty)
                .SetPrice(curPrice)
                .SetAdjustPrice(true)
                .SetSecMarket((int)secMarket)
                .Build();
        TrdPlaceOrder.Response placeOrderRsp = PlaceOrderSync(c2s);
        Console.WriteLine(placeOrderRsp);
    }
    }
}
