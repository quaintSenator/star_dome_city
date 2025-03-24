namespace Station
{
    #region 设计意图
    /*
        是一个Model/Info，用于记录瓶子中的各种组分，向反应釜、空间站等持有本类的上级类汇报瓶子中的：
        1. 特定组分浓度
        2. 总体气压
        3. 总比热
        4. 温度
        
        Balloon的特性是可以自由膨胀，气压=外界的压强 可以假定在charge、react等过程中外部的气压都并不显著改变
    */
    #endregion

    public class BalloonAtmosphereInfo : BaseAtmosphereInfo
    {
        public BalloonAtmosphereInfo(float outerPressure)
        {
            
        }
        public override void refreshPressure()
        {
            
        }
    }
}