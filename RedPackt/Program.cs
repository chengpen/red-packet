using System;
namespace RedPackt
{
    class Program
    {
        static void Main(string[] args)
        {

            ShareMoney(50, 7);
            Console.ReadKey();
        }

        public static void ShareMoney(float total,int people)
        {
            //当前参与随机金额的人数
            int currentPeople = people;
            //当前随机金额
            float currentTotal = total;
            //当前第几位记录
            int peoples=0;
            //确认所有获得金额加起来的总数等于初始金额
            float allmoney = 0;
            //循环给每个人分钱
            for(int i=1;i<=currentPeople;i++)
            {
                //确保当前随机金额必须为两位数内
                currentTotal = (float)Math.Round(currentTotal, 2);
                
                if (i == currentPeople)
                {
                    //最后一个人获取剩余总额
                    peoples++;
                    allmoney += currentTotal;
                    Console.WriteLine("第{0}个人获得{1}钱",peoples,currentTotal);
                    break;
                }        
                //平均值        
                float avg = currentTotal / currentPeople;     
                //计算获得金额           
                float money=CaculateMoney(avg);   
                      
                //更新随机金额       
                currentTotal -= money;
                //减去已参与人员
                currentPeople--;
                i = 0;

                peoples ++;
                allmoney += money;

                Console.WriteLine("第{0}个人获得{1}钱", peoples, money);
            }
            Console.WriteLine(allmoney);

        }
        public static float CaculateMoney(float avg)
        {
            //期望值
            float hopvalue = avg * 2;
            //取期望值整数部分
            int hopvalueint = (int)hopvalue;
            //取期望值小数部分
            float hopvaluefloat = hopvalue - hopvalueint;
            
            float total;
            do
            {
                Random rd = new Random(Guid.NewGuid().GetHashCode());
                //整数随机
                float mInt;
                mInt = rd.Next(0, hopvalueint + 1);                
                //小数位随机
                float mfloat;
                mfloat = (float)rd.NextDouble();
                //整数和小数相加得出最终金额
                total = mInt + mfloat;
                total = (float)Math.Round(total, 2);
            } while (total>hopvalue||total<0.01f);//区间，大于1分钱小于期望值

            return total;    
        }
    }
}
