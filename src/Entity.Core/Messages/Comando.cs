using System;

namespace Entity.Core.Messages
{
    public abstract class Comando : IRequest
    {
        public DateTime TimeStamp { get; private set; }
        public Comando()
        {
            TimeStamp = DateTime.Now;
        }
    }
}