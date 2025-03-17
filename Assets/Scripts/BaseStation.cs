using UnityEngine;

namespace Station
{
    public class BaseStation : MonoBehaviour
    {
        #region 设计意图
        /*
            空间站这个类为所有反应装置的承载。其有两点基本考量，
            1是空间站大气环境的维持，2是承载反应容器
            设计了基类，是为了防止未来出现多个不同特性的空间站
            未来要加入新的空间站的时候，再考虑把基类中的一部分内容提出来
        */
        #endregion
    }
}