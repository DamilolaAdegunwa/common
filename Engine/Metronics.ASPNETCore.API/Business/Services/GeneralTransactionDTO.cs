namespace Metronics.ASPNETCore.API.Business.Services
{
    internal class GeneralTransactionDTO
    {
        public object PayType { get; set; }
        public object PayTypeDiscription { get; set; }
        public object Id { get; set; }
        public object CreationTime { get; set; }
        public object CreatorUserId { get; set; }
        public object IsActive { get; set; }
        public object TransactedBy { get; set; }
        public object TransactionAmount { get; set; }
        public object TransactionDate { get; set; }
        public object TransactionType { get; set; }
        public object TransType { get; set; }
        public object TransDescription { get; set; }
    }
}