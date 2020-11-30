using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_messages
{
    public class SendKeyMsg
    {
        public string key { get; set; }
        public MsgType type { get; set; }

        public SendKeyMsg(string key)
        {
            this.key = key;
            type = MsgType.SendKey;
        }
    }
}
