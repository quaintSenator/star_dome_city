using System.Collections.Generic;
using Config;
using Unity.VisualScripting;

namespace Station
{
    #region 设计意图
    /*
        是一个Model/Info，用于记录瓶子中的各种组分，向反应釜、空间站等持有本类的上级类汇报瓶子中的：
        1. 特定组分浓度
        2. 总体气压
        3. 总比热
        4. 温度
    */
    #endregion
    public abstract class BaseAtmosphereInfo
    {
        private Dictionary<int, float> mData = new();//matterID的物质有多少克
        private double mPressure;
        private double mTemperature;
        private double mQuantityHeat;

        public double CheckMatter(int matterID)
        {
            if (!mData.ContainsKey(matterID))
            {
                return 0;
            }
            return mData[matterID];
        }
        
        //危险的假定： 假定了温度交换总是发生在一瞬间
        public void charge(int matterID, float m, float temperature)
        {
            //刷新温度
            var matterTable = MatterTable.Instance;
            var injectedSHC = matterTable.getTableValue<double>("specific_heat_capacitys", matterID);
            double sumCXM = 0;
            
            foreach (KeyValuePair<int, float> kv in mData)
            {
                var mID = kv.Key;
                var mM = kv.Value;
                var SHC = matterTable.getTableValue<double>("specific_heat_capacitys", mID);
                sumCXM += mM * SHC;
            }

            var QBe4Merge = sumCXM * mTemperature + m * injectedSHC * temperature;
            mTemperature = QBe4Merge / (sumCXM + m * injectedSHC);
            //(c1m1+c2m2+...cnmn+cxmx)Tx = (c1m1+c2m2+...+cnmn)T1 + cxmxT2
            //1..n 原本物质 x新增物质 T1原本温度 T2原本温度
            
            //更新质量表
            if (!mData.ContainsKey(matterID))
            {
                mData[matterID] = m;
            }
            refreshPressure();
        }
        public virtual void refreshPressure()
        {
            
        }

        public void printAllMatterInAtmos()
        {
            
        }
    }
}