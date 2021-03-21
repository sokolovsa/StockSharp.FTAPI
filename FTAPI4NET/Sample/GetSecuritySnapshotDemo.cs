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
    class GetSecuritySnapshotDemo : DemoBase
    {
        public void Run(QotCommon.QotMarket market) 
        {
        bool ret = InitConnectQotSync("127.0.0.1", (ushort)11111);
            if (ret) {
                Console.WriteLine("qot connected");
            } else {
                Console.WriteLine("fail to connect opend");
                return;
            }

            int[] stockTypes = {(int)QotCommon.SecurityType.SecurityType_Eqty,
                    (int)QotCommon.SecurityType.SecurityType_Index,
            (int)QotCommon.SecurityType.SecurityType_Trust,
                    (int)QotCommon.SecurityType.SecurityType_Warrant,
            (int)QotCommon.SecurityType.SecurityType_Bond};
            List<QotCommon.Security> stockCodes = new List<QotCommon.Security>();
            foreach (int stockType in stockTypes) {
                QotGetStaticInfo.C2S c2s = QotGetStaticInfo.C2S.CreateBuilder()
                        .SetMarket((int)market)
                        .SetSecType(stockType)
                        .Build();
                QotGetStaticInfo.Response rsp = GetStaticInfoSync(c2s);
                if (rsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("getStaticInfoSync fail: {0}\n", rsp.RetMsg);
                    return;
                }
                foreach (QotCommon.SecurityStaticInfo info in rsp.S2C.StaticInfoListList) {
                    stockCodes.Add(info.Basic.Security);
                }
            }

            if (stockCodes.Count == 0) {
                Console.Error.Write("Error market:'{0}' can not get stock info ", market);
                return;
            }

            for (int i = 0; i < stockCodes.Count; i += 200) {
                int count = i + 200 <= stockCodes.Count ? 200 : stockCodes.Count - i;
                List<QotCommon.Security> codes = stockCodes.GetRange(i, count);
                QotGetSecuritySnapshot.Response rsp = GetSecuritySnapshotSync(codes);
                if (rsp.RetType != (int)Common.RetType.RetType_Succeed) {
                    Console.Error.Write("getSecuritySnapshotSync err: retType={0} msg={1}\n", rsp.RetType, rsp.RetMsg);
                } else {
                    foreach (QotGetSecuritySnapshot.Snapshot snapshot in rsp.S2C.SnapshotListList) {
                        Console.WriteLine(snapshot);
                    }
                }
                Thread.Sleep(3000);
            }
        }
    }
}
