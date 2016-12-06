using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.AdminSystem.Shared
{
    public class Math2
    {
        public int num3;
        public static int Add1(int i, int j)
        {
            return i + j;
        }
        public int Add2(int i, int j)
        {
            return i + j + num3;
        }


    }



    public class TestClass
    {
     
        public void Test()
        {
            Math2 math = new Math2();

            math.num3 = 6;
            math.Add2(1, 1);


            Math2.Add1(1, 1);
        }
    }
}
