using System;
using System.Collections.Generic;
using System.Text;

namespace task_2_messages
{
    public class DESDbStingMes
    {
        public MsgType type { get; set; }
        public byte[] Key { get; set; }
        public byte[] IV { get; set; }
        public byte[] Value { get; set; }

        public DESDbStingMes(byte[] key, byte[] IV, byte[] value)
        {
            this.Key = key;
            this.IV = IV;
            this.Value = value;
            type = MsgType.DES;
        }

        public DESDbStingMes() { }
    }
}
