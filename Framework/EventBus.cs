using System;
using System.Collections.Generic;
using System.Text;

namespace Framework
{
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus
    {
        public static EventBus Instance = new EventBus();
        private EventBus()
        {
        }
        public void OnReceiveRfidCardID(string cardid)
        {
            if (this.ReceiveRfidCardID != null)
                this.ReceiveRfidCardID(this, new IDEventArgs(cardid));
        }

        public void OnCheckIsNeedSynchronization()
        {
            if (this.CheckIsNeedSynchronization != null)
                this.CheckIsNeedSynchronization(this, new EventArgs());
        }

        /// <summary>
        /// 从串口接收到ID卡号事件
        /// </summary>
        public event EventHandler<IDEventArgs> ReceiveRfidCardID;

        /// <summary>
        /// 检查是否需要与ID刷卡板同步事件
        /// </summary>
        public event EventHandler CheckIsNeedSynchronization;
    }

    public class IDEventArgs:EventArgs
    {
        /// <summary>
        /// ID卡卡号
        /// </summary>
        public string CardID
        {
            get;
            set;
        }
        public IDEventArgs(string cardid)
        {
            this.CardID = cardid;
        }
    }
 
}
