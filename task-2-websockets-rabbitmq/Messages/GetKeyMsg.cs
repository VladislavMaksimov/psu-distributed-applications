using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_messages
{
    public class GetKeyMsg
    {
        public MsgType type { get; set; }

        public GetKeyMsg()
        {
            type = MsgType.GetKey;
        }
    }
}
