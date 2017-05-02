using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 迭代法求解线性方程组
{
    public  class solveLinearEqu
    {

        /// <summary>
        /// 方程组系数增广矩阵等价变换
        /// </summary>
        /// <param name="c">输入增广矩阵</param>
        /// <returns>等价变换后的增广矩阵</returns>
        private static List<double[]>  matTrans(List<double[]> c)
        {
            List<double[]> cTrans = new List<double[]>();
            for (int i = 0; i < c.Count; i++)
            {
                double[] ci = new double[c[i].Length];
                c[i].CopyTo(ci, 0);
                if (ci[i] == 0)
                {
                    ci = c[i];
                    ci[i] = 1;
                    ci[ci.Length - 1] = -ci[ci.Length - 1];
                }
                else
                {
                    for (int j = 0; j < ci.Length ; j++)
                    {
                        ci[j] = -ci[j] / c[i][i];
                    }
                    ci[i] = 0;
                    ci[ci.Length - 1] = -ci[ci.Length - 1];
                }
                cTrans.Add(ci);
            }

            return cTrans;
 
        }

        /// <summary>
        /// Jacobi迭代法求解线性方程组
        /// </summary>
        /// <param name="c">方程组系数的增广矩阵</param>
        /// <param name="IterativeTimes">最大迭代次数</param>
        /// <param name="Epsilon">收敛标准</param>
        /// <param name="t">迭代次数</param>
        /// <param name="solution">求解结果</param>
        /// <returns>执行结果，0表示求解成功</returns>
        public static int Jacobi(List<double[]> c, int IterativeTimes, double Epsilon, out int t, double[] solution)
        {
            List<double[]> cTrans = matTrans(c);
            double[] history = new double[cTrans.Count];
            double[] now = new double[cTrans.Count];
            int times = 0;
            bool isTrueSolution = false;
            while (times <= IterativeTimes && !isTrueSolution)
            {

                //迭代一次
                for (int i = 0; i < cTrans.Count; i++)
                {
                    now[i] = 0;
                    double[] Con = cTrans[i];
                    for (int j = 0; j < Con.Length - 1; j++)
                    {
                        now[i] += Con[j] * history[j];
                    }
                    now[i] += Con[Con.Length - 1];
                    if (Double.IsNaN(now[i]) || Double.IsInfinity(now[i]))
                        throw new Exception("错误：方程解出现NaN或者无穷大,请验证方程组的收敛性！");
                }
                times++;
                //解是否符合条件
                isTrueSolution = true;
                for (int i = 0; i < now.Length; i++)
                {
                    if (Math.Abs(now[i] - history[i]) > Epsilon)
                    {
                        isTrueSolution = false;
                        break;
                    }
                }
                //更新旧解
                now.CopyTo(history, 0);
            }
            t = times;
            now.CopyTo(solution, 0);
            //超出迭代次数求解失败
            if (times > IterativeTimes) return 1;
            else
                return 0;

        }

        /// <summary>
        /// SOR迭代法求解线性方程组
        /// </summary>
        /// <param name="c">方程组系数的增广矩阵</param>
        /// <param name="IterativeTimes">最大迭代次数</param>
        /// <param name="Epsilon">收敛标准</param>
        /// <param name="omega">松弛因子</param>
        /// <param name="t">迭代次数</param>
        /// <param name="solution">求解结果</param>
        /// <returns>执行结果，0表示求解成功</returns>
        public static int SOR(List<double[]> c, int IterativeTimes, double Epsilon,double omega,  out int t, double[] solution)
        {
            List<double[]> cTrans = matTrans(c);
            double[] history = new double[cTrans.Count];
            double[] now = new double[cTrans.Count];
            int times = 0;
            bool isTrueSolution = false;
            while (times <= IterativeTimes && !isTrueSolution)
            {

                //一次迭代
                for (int i = 0; i < cTrans.Count; i++)
                {
                    now.CopyTo(history, 0);
                    now[i] = (1-omega)*history[i];
                    double[] Con = cTrans[i];
                    for (int j = 0; j < Con.Length - 1; j++)
                    {
                        now[i] += omega * Con[j] * history[j];
                    }
                    now[i] += omega * Con[Con.Length - 1];
                    if (Double.IsNaN(now[i]) || Double.IsInfinity(now[i]))
                        throw new Exception("错误：方程解出现NaN或者无穷大,请验证方程组的收敛性！");
                    
                }
                times++;
                //解是否符合条件
                isTrueSolution = true;
                for (int i = 0; i < now.Length; i++)
                {
                    if (Math.Abs(now[i] - history[i]) > Epsilon)
                    {
                        isTrueSolution = false;
                        break;
                    }
                }
                //更新旧解
                now.CopyTo(history, 0);
            }
            //超出迭代次数求解失败
            t = times;
            now.CopyTo(solution, 0);
            if (times > IterativeTimes) return 1;
            else
                return 0;

        }
       
        /// <summary>
        /// Gauss-Seidel迭代法求解线性方程组
        /// </summary>
        /// <param name="c">方程组系数的增广矩阵</param>
        /// <param name="IterativeTimes">最大迭代次数</param>
        /// <param name="Epsilon">收敛标准</param>
        /// <param name="t">迭代次数</param>
        /// <param name="solution">求解结果</param>
        /// <returns>执行结果，0表示求解成功</returns>
        public static int Gauss_Seidel(List<double[]> c, int IterativeTimes, double Epsilon, out int t, double[] solution)
        {
            return SOR(c, IterativeTimes, Epsilon, 1, out t, solution);
        }
    }
}
