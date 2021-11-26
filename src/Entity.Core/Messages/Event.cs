using System;
namespace Entity.Core.Messages
{
    public abstract class Evento : INotificacao
    {
        public DateTime TimeStamp { get; set; }

        public Evento()
        {
            TimeStamp = DateTime.Now;
        }
    }
}