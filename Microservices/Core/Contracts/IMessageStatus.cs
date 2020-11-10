namespace Core.Contracts
{
    public interface IMessageStatus
    {
        public string Sender { get;  }
        public string Status { get; }
    }
}
