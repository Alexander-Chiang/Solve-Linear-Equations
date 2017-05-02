using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

namespace 迭代法求解线性方程组
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        bool isHide = true;

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            txbInput.Text = System.Environment.CurrentDirectory+"\\input";
            txbOutput.Text = System.Environment.CurrentDirectory + "\\output";
            this.Height = this.Height - 240;
            foreach (var item in Enum.GetValues(typeof(GlobalVar.CalcMethods)))
            {
                cmbMethod.Items.Add(item);
            }
            cmbMethod.SelectedIndex = 0;

        }

       

        private void label4_Click(object sender, EventArgs e)
        {
            if (!isHide)
            {
                this.Height = this.Height - 240;
                isHide = true;
                label4.Text = "          ︾          ";
            }
            else
            {
                this.Height = this.Height + 240;
                isHide = false;
                label4.Text = "          ︽          ";
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgOpenFolder = new FolderBrowserDialog();
            dlgOpenFolder.Description = "选择要进行计算的目录";
            dlgOpenFolder.RootFolder = Environment.SpecialFolder.MyComputer;
            dlgOpenFolder.SelectedPath = Environment.CurrentDirectory;
            dlgOpenFolder.ShowNewFolderButton = true;
            DialogResult result = dlgOpenFolder.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txbInput.Text = dlgOpenFolder.SelectedPath;
                log("选择方程组文件存放路径：" + txbInput.Text, GlobalVar.LogType.Info);
            }
        }

        private void btnOutput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlgOpenFolder = new FolderBrowserDialog();
            dlgOpenFolder.Description = "选择结果输出目录";
            dlgOpenFolder.RootFolder = Environment.SpecialFolder.MyComputer;
            dlgOpenFolder.SelectedPath = Environment.CurrentDirectory;
            dlgOpenFolder.ShowNewFolderButton = true;
            DialogResult result = dlgOpenFolder.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                txbOutput.Text = dlgOpenFolder.SelectedPath;
                log("选择方程组解输出文件存放路径：" + txbInput.Text, GlobalVar.LogType.Info);
            }

        }


        //封装求解函数，方便调用
        private int CalcSolution(GlobalVar.CalcMethods method, List<double[]> d, double[] solution)
        {
            int status = 0;
            int t = 0;
            int IterativeTimes =Convert.ToInt32(txbIterativeTimes.Text);
            double Epsilon =Convert.ToDouble(txbEpsilon.Text);
            if(method==GlobalVar.CalcMethods.Jacobi)
            {
                try
                {
                   status = solveLinearEqu.Jacobi(d, IterativeTimes, Epsilon, out t, solution);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if(method==GlobalVar.CalcMethods.SOR)
            {
                double omega =Convert.ToDouble(txbOmega.Text);
                try
                {
                    status = solveLinearEqu.SOR(d, IterativeTimes, Epsilon, omega, out  t, solution);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (method == GlobalVar.CalcMethods.Gauss_Seidel)
            {
                try
                {
                    status = solveLinearEqu.Gauss_Seidel(d, IterativeTimes, Epsilon, out t, solution);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            if (status == 1)
                throw new Exception("超出迭代次数，求解失败！");
            return t;
        }

        private void btnCalc_Click_1(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private void Run()
        {
            DirectoryInfo TheFolder = new DirectoryInfo(txbInput.Text);
            if (!TheFolder.Exists)
            {
                log(TheFolder.FullName + " 路径不存在!", GlobalVar.LogType.Error);
                Framework.MessageBoxUtil.ShowError(TheFolder.FullName + " 路径不存在!");
                return;
            }
            FileInfo[] files = TheFolder.GetFiles("*.txt");
            if(files.Length==0)
            {
                log("错误：文件夹中不存在相应的txt文件！", GlobalVar.LogType.Error);
                return;
            }
            foreach (FileInfo file in files)
            {
                if (!file.Exists)
                    log(file.Name + " 文件不存在!", GlobalVar.LogType.Error);
                List<double[]> d = null;
                try
                {
                    d = readData(file.FullName);
                    log("读取文件：" + file.Name, GlobalVar.LogType.Info);
                    log(displayEqu(d), GlobalVar.LogType.Info);
                }
                catch (Exception ex)
                {
                    log(ex);
                    continue;
                }
                double[] solution = new double[d.Count];
                try
                {
                    int t = CalcSolution((GlobalVar.CalcMethods)Enum.Parse(typeof(GlobalVar.CalcMethods), cmbMethod.SelectedItem.ToString()), d, solution);
                    string str = null;
                    //保留四位小数
                    for (int i = 0; i < solution.Length; i++)
                    {
                        solution[i] = Math.Round(solution[i], 4);
                        str += solution[i] + "\r\n";
                    }
                    str += "迭代方法：" + cmbMethod.SelectedItem.ToString() + "\r\n";
                    str += "迭代次数：" + t;
                    string outFile = txbOutput.Text + "\\" + file.Name.Split('.')[0] + "_solution" + file.Extension;
                    Write(str, outFile);
                    log(displaySolution(solution), GlobalVar.LogType.Info);
                    log("迭代次数：" + t, GlobalVar.LogType.Info);
                }
                catch (Exception ex)
                {
                    log(ex);
                }

            }
        }


        private List<double[]> readData(string filePath)
        {

            StreamReader sr = new StreamReader(filePath, Encoding.Default);
            int lineNum = Convert.ToInt32(sr.ReadLine());
            if (lineNum == 0) throw new Exception("文件错误：" + filePath + "文件为空！");
            List<double []> result = new List<double[]>();
            for (int i = 0; i < lineNum; i++)
            {
                string str = sr.ReadLine();
                if (str == null) 
                    throw new Exception("文件错误："+filePath+"文件不完整！");
                string[] strArr = str.Split(',');
                if (strArr.Length != lineNum + 1) 
                    throw new Exception("文件错误：" + filePath + "(行："+(i + 2) + ")参数个数错误！");
                double[] c = new double[lineNum+1];
                for (int j = 0; j < lineNum+1; j++)
                {
                    if (!double.TryParse(strArr[j], out c[j]))
                        throw new Exception("文件错误：" + filePath + "(行：" + (i + 2) + ")出现非法字符！");
                }
                result.Add(c);
            }
            if(result.Count!=lineNum)
                throw new Exception("文件错误：" + filePath + "读取文件过程中出现未知异常！");
            return result;
        }

        private void Write(string data ,string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(data);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }

        private void txbIterativeTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        private void txbEpsilon_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txbEpsilon.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txbEpsilon.Text, out oldf);
                    b2 = float.TryParse(txbEpsilon.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void txbOmega_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;

            //小数点的处理。
            if ((int)e.KeyChar == 46)                           //小数点
            {
                if (txbOmega.Text.Length <= 0)
                    e.Handled = true;   //小数点不能在第一位
                else
                {
                    float f;
                    float oldf;
                    bool b1 = false, b2 = false;
                    b1 = float.TryParse(txbOmega.Text, out oldf);
                    b2 = float.TryParse(txbOmega.Text + e.KeyChar.ToString(), out f);
                    if (b2 == false)
                    {
                        if (b1 == true)
                            e.Handled = true;
                        else
                            e.Handled = false;
                    }
                }
            }
        }

        private void log(Exception ex)
        {
                Framework.Logger.Error(ex);
                rtxbLog.SelectionColor = Color.Red;
                rtxbLog.AppendText("- - Error " + DateTime.Now.ToString() + " - -\r\n" + ex.Message.ToString() + "\r\n\r\n");
                rtxbLog.Select(rtxbLog.TextLength, 0);
                rtxbLog.ScrollToCaret();
            
        }
        private void log(string mess, GlobalVar.LogType type)
        {
            if (type == GlobalVar.LogType.Error)
            {
                Framework.Logger.Error(mess);
                rtxbLog.SelectionColor = Color.Red;
                rtxbLog.AppendText("- - Error " + DateTime.Now.ToString() + " - -\r\n" + mess + "\r\n\r\n");
                rtxbLog.Select(rtxbLog.TextLength, 0);
                rtxbLog.ScrollToCaret();
            }
            if (type == GlobalVar.LogType.Info)
            {
                Framework.Logger.Info(mess);
                rtxbLog.AppendText("- -  Info " + DateTime.Now.ToString() + " - -\r\n" + mess + "\r\n\r\n");
                rtxbLog.Select(rtxbLog.TextLength, 0);
                rtxbLog.ScrollToCaret();
            }
            if (type == GlobalVar.LogType.Warn)
            {
                Framework.Logger.Warn(mess);
                rtxbLog.AppendText("- -  Warn " + DateTime.Now.ToString() + " - -\r\n" + mess + "\r\n\r\n");
                rtxbLog.Select(rtxbLog.TextLength, 0);
                rtxbLog.ScrollToCaret();
            }
        }

        private string displayEqu(List<double[]> d)
        {
            string result = "求解方程为：\r\n";
            for (int i = 0; i < d.Count; i++)
            {
                double[] equ = d[i];
                result += (equ[0] == 1) ? "X0" : equ[0] + "X0";
                for (int j = 1; j < equ.Length-1; j++)
                {
                    if (equ[j] < 0) result += equ[j] + "X" + j;
                    else if (equ[j] == 0) break;
                    else if (equ[j] == 1) result += "+X" + j;
                    else result += "+" + equ[j] + "X" + j;
                }
                result += "=" + equ[equ.Length - 1]+"\r\n";
            }
            return result;
        }
        private string displaySolution(double[] solution)
        {
            string result = "方程组的解：\r\n";
            for (int i = 0; i < solution.Length; i++)
            {
                result += "X" + i + "=" + solution[i] + "\r\n";
            }
            return result;
        }

        private void cmbMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMethod.SelectedItem.ToString() == GlobalVar.CalcMethods.SOR.ToString())
            {
                labOmega.Enabled = true;
                txbOmega.Enabled = true;
            }
            else
            {
                labOmega.Enabled = false;
                txbOmega.Enabled = false;
            }
        }

        private void 打开输入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnInput_Click(sender, e);
        }

        private void 打开输出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnOutput_Click(sender, e);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {         
                Application.Exit();   
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("请确认是否退出？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox newabout = new AboutBox();
            newabout.ShowDialog();
        }

        private void 查看帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(OpenHelpDoc));
        }
        private void OpenHelpDoc(object obj)
        {
            try
            {
                System.Diagnostics.Process.Start("iexplore.exe", Path.Combine(Application.StartupPath, "操作手册.mht"));
            }
            catch (Exception ex)
            {
                log(ex);
            }
        }

    }
}
