using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGBot_WPF
{
    class ChatMessage
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Message { get; private set; }
        public DateTime Time { get; private set; }

        public ChatMessage(long Id, string Name, string Message, DateTime Time)
        {
            this.Id = Id;
            this.Name = Name;
            this.Message = Message;
            this.Time = Time;
        }

        public ChatMessage(Telegram.Bot.Types.Message message)
        {
            Id = message.Chat.Id;
            Name = message.Chat.FirstName + " " + message.Chat.LastName;

            switch (message.Type)
            {
                case Telegram.Bot.Types.Enums.MessageType.Text:
                    Message = message.Text;
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Document:
                    Message = "Document(Confident)";
                    break;
                case Telegram.Bot.Types.Enums.MessageType.Photo:
                    Message = "PhotoConfident()";
                    break;
            }
            Time = DateTime.Now;
        }
    }
}
