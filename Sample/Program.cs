using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Futu.OpenApi;
using Futu.OpenApi.Pb;
using System.Security.Cryptography;
using Google.ProtocolBuffers;

namespace FTAPI4NetSample
{
    class Program 
    {     
        class SampleConnCallback : FTSPI_Conn
        {
            public void OnInitConnect(FTAPI_Conn client, long errCode, string desc)
            {
                Console.WriteLine("InitConnected");
                if  (errCode == 0)
                {
                    FTAPI_Qot qot = client as FTAPI_Qot;

                    QotGetUserSecurity.C2S c2s = QotGetUserSecurity.C2S.CreateBuilder()
                .SetGroupName("港股")
            .Build();
                    QotGetUserSecurity.Request req = QotGetUserSecurity.Request.CreateBuilder().SetC2S(c2s).Build();
                    uint seqNo = qot.GetUserSecurity(req);
                    Console.Write("Send QotGetUserSecurity: {0}\n", seqNo);
                }

            }

            public void OnDisconnect(FTAPI_Conn client, long errCode)
            {
                Console.WriteLine("DisConnected");
            }

            void SendGetGlobalState(FTAPI_Qot qot)
            {
                GetGlobalState.Request req = GetGlobalState.Request.CreateBuilder().SetC2S(GetGlobalState.C2S.CreateBuilder().SetUserID(900019)).Build();
                uint serialNo = qot.GetGlobalState(req);
                Console.WriteLine("SendGetGlobalState: {0}", serialNo);
            }

            void SendSub(FTAPI_Qot qot)
            {
                QotSub.Request.Builder reqBuilder = QotSub.Request.CreateBuilder();
                QotSub.C2S.Builder csReqBuilder = QotSub.C2S.CreateBuilder();
                QotCommon.Security.Builder stock = QotCommon.Security.CreateBuilder();
                stock.SetCode("00700");
                stock.SetMarket((int)QotCommon.QotMarket.QotMarket_HK_Security);
                csReqBuilder.AddSecurityList(stock);
                csReqBuilder.AddSubTypeList((int)QotCommon.SubType.SubType_Ticker);
                csReqBuilder.SetIsSubOrUnSub(true);
                csReqBuilder.SetIsRegOrUnRegPush(true);
                reqBuilder.SetC2S(csReqBuilder);
                uint serialNo = qot.Sub(reqBuilder.Build());
                Console.WriteLine("SendSub: {0}", serialNo);
            }

            void SendStockFilter(FTAPI_Qot qot)
            {
                QotStockFilter.BaseFilter baseFilter = QotStockFilter.BaseFilter.CreateBuilder()
                    .SetFieldName((int)QotStockFilter.StockField.StockField_MarketVal)
                    .SetFilterMin(10000)
                    .SetFilterMax(10000000000)
                    .SetIsNoFilter(false)
                    .SetSortDir((int)QotStockFilter.SortDir.SortDir_Descend)
                    .Build();
                QotStockFilter.C2S c2s = QotStockFilter.C2S.CreateBuilder()
                    .SetBegin(0)
                    .SetNum(100)
                    .SetMarket((int)QotCommon.QotMarket.QotMarket_HK_Security)
                    .AddBaseFilterList(baseFilter)
                    .Build();
                uint serialNo = qot.StockFilter(QotStockFilter.Request.CreateBuilder().SetC2S(c2s).Build());
                Console.WriteLine("SendQotStockFilter: {0}", serialNo);
            }

            void SendSetPriceReminder(FTAPI_Qot qot)
            {
                QotCommon.Security sec = QotCommon.Security.CreateBuilder().SetCode("00700")
                .SetMarket((int)QotCommon.QotMarket.QotMarket_HK_Security)
                .Build();
                QotSetPriceReminder.C2S c2s = QotSetPriceReminder.C2S.CreateBuilder().SetSecurity(sec)
                        .SetOp((int)QotSetPriceReminder.SetPriceReminderOp.SetPriceReminderOp_Add)
                        .SetType((int)QotCommon.PriceReminderType.PriceReminderType_PriceUp)
                        .SetFreq((int)QotCommon.PriceReminderFreq.PriceReminderFreq_Always)
                        .SetValue(380)
                        .Build();
                QotSetPriceReminder.Request req = QotSetPriceReminder.Request.CreateBuilder().SetC2S(c2s).Build();
                qot.SetPriceReminder(req);
            }

            void SendGetMarketState(FTAPI_Qot qot)
            {
                QotCommon.Security sec = QotCommon.Security.CreateBuilder().SetCode("00700")
                 .SetMarket((int)QotCommon.QotMarket.QotMarket_HK_Security)
                 .Build();
                QotGetMarketState.C2S c2s = QotGetMarketState.C2S.CreateBuilder().AddSecurityList(sec)
                    .Build();
                QotGetMarketState.Request req = QotGetMarketState.Request.CreateBuilder().SetC2S(c2s).Build();
                qot.GetMarketState(req);
            }
        }

        class SampleQotCallback : FTSPI_Qot
        {
            public void OnReply_GetGlobalState(FTAPI_Conn client, uint nSerialNo, GetGlobalState.Response rsp)
            {
                Console.WriteLine("OnReply_GetGlobalState: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_Sub(FTAPI_Conn client, uint nSerialNo, QotSub.Response rsp)
            {
                
            }

            public void OnReply_RegQotPush(FTAPI_Conn client, uint nSerialNo, QotRegQotPush.Response rsp)
            {
                
            }

            public void OnReply_GetSubInfo(FTAPI_Conn client, uint nSerialNo, QotGetSubInfo.Response rsp)
            {
                
            }

            public void OnReply_GetTicker(FTAPI_Conn client, uint nSerialNo, QotGetTicker.Response rsp)
            {
                
            }

            public void OnReply_GetBasicQot(FTAPI_Conn client, uint nSerialNo, QotGetBasicQot.Response rsp)
            {
                
            }

            public void OnReply_GetOrderBook(FTAPI_Conn client, uint nSerialNo, QotGetOrderBook.Response rsp)
            {
                
            }

            public void OnReply_GetKL(FTAPI_Conn client, uint nSerialNo, QotGetKL.Response rsp)
            {
                
            }

            public void OnReply_GetRT(FTAPI_Conn client, uint nSerialNo, QotGetRT.Response rsp)
            {
                
            }

            public void OnReply_GetBroker(FTAPI_Conn client, uint nSerialNo, QotGetBroker.Response rsp)
            {
                
            }

            public void OnReply_GetHistoryKL(FTAPI_Conn client, uint nSerialNo, QotGetHistoryKL.Response rsp)
            {
                
            }

            public void OnReply_GetHistoryKLPoints(FTAPI_Conn client, uint nSerialNo, QotGetHistoryKLPoints.Response rsp)
            {
                
            }

            public void OnReply_GetRehab(FTAPI_Conn client, uint nSerialNo, QotGetRehab.Response rsp)
            {
                
            }

            public void OnReply_RequestRehab(FTAPI_Conn client, uint nSerialNo, QotRequestRehab.Response rsp)
            {
                
            }

            public void OnReply_RequestHistoryKL(FTAPI_Conn client, uint nSerialNo, QotRequestHistoryKL.Response rsp)
            {
                
            }

            public void OnReply_RequestHistoryKLQuota(FTAPI_Conn client, uint nSerialNo, QotRequestHistoryKLQuota.Response rsp)
            {
                
            }

            public void OnReply_GetTradeDate(FTAPI_Conn client, uint nSerialNo, QotGetTradeDate.Response rsp)
            {
                
            }

            public void OnReply_GetStaticInfo(FTAPI_Conn client, uint nSerialNo, QotGetStaticInfo.Response rsp)
            {
                
            }

            public void OnReply_GetSecuritySnapshot(FTAPI_Conn client, uint nSerialNo, QotGetSecuritySnapshot.Response rsp)
            {
                
            }

            public void OnReply_GetPlateSet(FTAPI_Conn client, uint nSerialNo, QotGetPlateSet.Response rsp)
            {
                
            }

            public void OnReply_GetPlateSecurity(FTAPI_Conn client, uint nSerialNo, QotGetPlateSecurity.Response rsp)
            {
                
            }

            public void OnReply_GetReference(FTAPI_Conn client, uint nSerialNo, QotGetReference.Response rsp)
            {
                
            }

            public void OnReply_GetOwnerPlate(FTAPI_Conn client, uint nSerialNo, QotGetOwnerPlate.Response rsp)
            {
                
            }

            public void OnReply_GetHoldingChangeList(FTAPI_Conn client, uint nSerialNo, QotGetHoldingChangeList.Response rsp)
            {
                
            }

            public void OnReply_GetOptionChain(FTAPI_Conn client, uint nSerialNo, QotGetOptionChain.Response rsp)
            {
                
            }

            public void OnReply_GetWarrant(FTAPI_Conn client, uint nSerialNo, QotGetWarrant.Response rsp)
            {
                
            }

            public void OnReply_GetCapitalFlow(FTAPI_Conn client, uint nSerialNo, QotGetCapitalFlow.Response rsp)
            {
                
            }

            public void OnReply_GetCapitalDistribution(FTAPI_Conn client, uint nSerialNo, QotGetCapitalDistribution.Response rsp)
            {
                
            }

            public void OnReply_GetUserSecurity(FTAPI_Conn client, uint nSerialNo, QotGetUserSecurity.Response rsp)
            {
                Console.WriteLine(rsp.S2C.ToJson());
            }

            public void OnReply_SetPriceReminder(FTAPI_Conn client, uint nSerialNo, QotSetPriceReminder.Response rsp)
            {
                Console.WriteLine("OnReply_SetPriceReminder: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_GetPriceReminder(FTAPI_Conn client, uint nSerialNo, QotGetPriceReminder.Response rsp)
            {
                Console.WriteLine("OnReply_GetPriceReminder: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_ModifyUserSecurity(FTAPI_Conn client, uint nSerialNo, QotModifyUserSecurity.Response rsp)
            {
                
            }

            public void OnReply_Notify(FTAPI_Conn client, uint nSerialNo, Notify.Response rsp)
            {
                
            }


            public void OnReply_UpdateBasicQot(FTAPI_Conn client, uint nSerialNo, QotUpdateBasicQot.Response rsp)
            {
                
            }

            public void OnReply_UpdateKL(FTAPI_Conn client, uint nSerialNo, QotUpdateKL.Response rsp)
            {
                
            }

            public void OnReply_UpdateRT(FTAPI_Conn client, uint nSerialNo, QotUpdateRT.Response rsp)
            {
                
            }

            public void OnReply_UpdateTicker(FTAPI_Conn client, uint nSerialNo, QotUpdateTicker.Response rsp)
            {
                Console.WriteLine("OnReply_UpdateTicker: {0} {1}", nSerialNo, rsp.S2C.ToJson());
            }

            public void OnReply_UpdateOrderBook(FTAPI_Conn client, uint nSerialNo, QotUpdateOrderBook.Response rsp)
            {
                
            }

            public void OnReply_UpdateBroker(FTAPI_Conn client, uint nSerialNo, QotUpdateBroker.Response rsp)
            {
                
            }

            public void OnReply_UpdateOrderDetail(FTAPI_Conn client, uint nSerialNo, QotUpdateOrderDetail.Response rsp)
            {
                
            }

            public void OnReply_UpdatePriceReminder(FTAPI_Conn client, uint nSerialNo, QotUpdatePriceReminder.Response rsp)
            {
                Console.WriteLine("OnReply_UpdatePriceReminder: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_StockFilter(FTAPI_Conn client, uint nSerialNo, QotStockFilter.Response rsp)
            {
                Console.WriteLine("OnReply_StockFilter: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_GetCodeChange(FTAPI_Conn client, uint nSerialNo, QotGetCodeChange.Response rsp)
            {
                
            }


            public void OnReply_GetIpoList(FTAPI_Conn client, uint nSerialNo, QotGetIpoList.Response rsp)
            {
                throw new NotImplementedException();
            }

            public void OnReply_GetFutureInfo(FTAPI_Conn client, uint nSerialNo, QotGetFutureInfo.Response rsp)
            {
                throw new NotImplementedException();
            }

            public void OnReply_RequestTradeDate(FTAPI_Conn client, uint nSerialNo, QotRequestTradeDate.Response rsp)
            {
                throw new NotImplementedException();
            }


            public void OnReply_GetUserSecurityGroup(FTAPI_Conn client, uint nSerialNo, QotGetUserSecurityGroup.Response rsp)
            {
                Console.WriteLine("OnReply_GetUserSecurityGroup: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_GetMarketState(FTAPI_Conn client, uint nSerialNo, QotGetMarketState.Response rsp)
            {
                Console.WriteLine("OnReply_GetMarketState: {0} {1}", nSerialNo, rsp);
            }
        }


        class SampleTrdConnCallback : FTSPI_Conn
        {
            public void OnInitConnect(FTAPI_Conn client, long errCode, string desc)
            {
                Console.WriteLine("InitConnected");
                if (errCode == 0)
                {
                    FTAPI_Trd trd = client as FTAPI_Trd;
                    {
                        TrdGetAccList.Request req = TrdGetAccList.Request.CreateBuilder().SetC2S(TrdGetAccList.C2S.CreateBuilder().SetUserID(0)).Build();
                        uint serialNo = trd.GetAccList(req);
                        Console.WriteLine("Send GetAccList: {0}", serialNo);
                    }
                }           
            }

            public void OnDisconnect(FTAPI_Conn client, long errCode)
            {
                Console.WriteLine("DisConnected");
            }
        }

        class SampleTrdCallback : FTSPI_Trd
        {
            private ulong accID;

            public void OnReply_GetAccList(FTAPI_Conn client, uint nSerialNo, TrdGetAccList.Response rsp)
            {
                Console.WriteLine("Recv GetAccList: {0} {1}", nSerialNo, rsp);
                if (rsp.RetType != (int)Common.RetType.RetType_Succeed)
                {
                    Console.WriteLine("error code is {0}", rsp.RetMsg);
                }
                else
                {
                    this.accID = rsp.S2C.AccListList[0].AccID;
                    FTAPI_Trd trd = client as FTAPI_Trd;
                    MD5 md5 = MD5.Create();
                    byte[] encryptionBytes = md5.ComputeHash(Encoding.UTF8.GetBytes("123123"));
                    string unlockPwdMd5 = BitConverter.ToString(encryptionBytes).Replace("-", "").ToLower();
                    TrdUnlockTrade.Request req = TrdUnlockTrade.Request.CreateBuilder().SetC2S(TrdUnlockTrade.C2S.CreateBuilder().SetUnlock(true).SetPwdMD5(unlockPwdMd5)).Build();
                    uint serialNo = trd.UnlockTrade(req);
                    Console.WriteLine("Send UnlockTrade: {0}", serialNo);

                }
            }

            public void OnReply_UnlockTrade(FTAPI_Conn client, uint nSerialNo, TrdUnlockTrade.Response rsp)
            {
                Console.WriteLine("Recv UnlockTrade: {0} {1}", nSerialNo, rsp);
                if (rsp.RetType != (int)Common.RetType.RetType_Succeed)
                {
                    Console.WriteLine("error code is {0}", rsp.RetMsg);
                }
                else
                {
                    FTAPI_Trd trd = client as FTAPI_Trd;

                    TrdPlaceOrder.Request.Builder req = TrdPlaceOrder.Request.CreateBuilder();
                    TrdPlaceOrder.C2S.Builder cs = TrdPlaceOrder.C2S.CreateBuilder();
                    Common.PacketID.Builder packetID = Common.PacketID.CreateBuilder().SetConnID(trd.GetConnectID()).SetSerialNo(0);
                    TrdCommon.TrdHeader.Builder trdHeader = TrdCommon.TrdHeader.CreateBuilder().SetAccID(this.accID).SetTrdEnv((int)TrdCommon.TrdEnv.TrdEnv_Real).SetTrdMarket((int)TrdCommon.TrdMarket.TrdMarket_HK);
                    cs.SetPacketID(packetID).SetHeader(trdHeader).SetTrdSide((int)TrdCommon.TrdSide.TrdSide_Sell).SetOrderType((int)TrdCommon.OrderType.OrderType_AbsoluteLimit).SetCode("01810").SetQty(100.00).SetPrice(10.2).SetAdjustPrice(true);
                    req.SetC2S(cs);                   
                    
                    uint serialNo = trd.PlaceOrder(req.Build());
                    Console.WriteLine("Send PlaceOrder: {0}, {1}", serialNo, req);
                }

            }

            public void OnReply_SubAccPush(FTAPI_Conn client, uint nSerialNo, TrdSubAccPush.Response rsp)
            {
                
            }

            public void OnReply_GetFunds(FTAPI_Conn client, uint nSerialNo, TrdGetFunds.Response rsp)
            {
                
            }

            public void OnReply_GetPositionList(FTAPI_Conn client, uint nSerialNo, TrdGetPositionList.Response rsp)
            {
                
            }

            public void OnReply_GetMaxTrdQtys(FTAPI_Conn client, uint nSerialNo, TrdGetMaxTrdQtys.Response rsp)
            {
                
            }

            public void OnReply_GetOrderList(FTAPI_Conn client, uint nSerialNo, TrdGetOrderList.Response rsp)
            {
                
            }

            public void OnReply_GetOrderFillList(FTAPI_Conn client, uint nSerialNo, TrdGetOrderFillList.Response rsp)
            {
                
            }

            public void OnReply_GetHistoryOrderList(FTAPI_Conn client, uint nSerialNo, TrdGetHistoryOrderList.Response rsp)
            {
                
            }

            public void OnReply_GetHistoryOrderFillList(FTAPI_Conn client, uint nSerialNo, TrdGetHistoryOrderFillList.Response rsp)
            {
                
            }

            public void OnReply_UpdateOrder(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrder.Response rsp)
            {
                Console.WriteLine("Recv UpdateOrder: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_UpdateOrderFill(FTAPI_Conn client, uint nSerialNo, TrdUpdateOrderFill.Response rsp)
            {
                Console.WriteLine("Recv UpdateOrderFill: {0} {1}", nSerialNo, rsp);
            }

            public void OnReply_PlaceOrder(FTAPI_Conn client, uint nSerialNo, TrdPlaceOrder.Response rsp)
            {
                Console.WriteLine("Recv PlaceOrder: {0} {1}", nSerialNo, rsp);
                if (rsp.RetType != (int)Common.RetType.RetType_Succeed)
                {
                    Console.WriteLine("error code is {0}", rsp.RetMsg);
                }
            }

            public void OnReply_ModifyOrder(FTAPI_Conn client, uint nSerialNo, TrdModifyOrder.Response rsp)
            {
            }
        }

        static void Main(string[] args)
        {
            FTAPI.Init();
            FTAPI_Qot client = new FTAPI_Qot();
            client.SetConnCallback(new SampleConnCallback());
            client.SetQotCallback(new SampleQotCallback());
            client.SetClientInfo("FTAPI4NET_Sample", 1);
            //client.SetRSAPrivateKey(System.IO.File.ReadAllText(@"d:\rsa1024", Encoding.UTF8));
            //client.InitConnect("127.0.0.1", 11111, false);
            {
                GetSecuritySnapshotDemo demo = new GetSecuritySnapshotDemo();
                demo.Run(QotCommon.QotMarket.QotMarket_HK_Security);
            }
            {
                //QuoteAndTradeDemo demo = new QuoteAndTradeDemo();
                //demo.TradeHkTest();
            }
            

            //FTAPI_Trd trd = new FTAPI_Trd();
            //trd.SetConnCallback(new SampleTrdConnCallback());
            //trd.SetTrdCallback(new SampleTrdCallback());
            //trd.SetClientInfo("FTAPI4NET_Sample", 1);
            //trd.InitConnect("127.0.0.1", 11111, false);
            while (true)
            {
                Thread.Sleep(1000 * 60);
            }
        }
    }
}
