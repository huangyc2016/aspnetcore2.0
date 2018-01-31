using System;

namespace HYC.Model.swagger
{
    public class SwaggerParamIgnore : Attribute
    {
    }
    public class RequiredParams : Attribute
    {
        public string ParmaArr = "";

        public RequiredParams(string paramArr)
        {
            ParmaArr = paramArr;
        }
    }
}
