using System.Collections.Generic;

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
    public class BaseAtmosphereInfo
    {
        private Dictionary<int, float> mMatterTable = new();
        private float mPressure;
        private float mTemperature;

        public void charge(int mattherID, float amount, float temperature)
        {
            
        }
    }
}