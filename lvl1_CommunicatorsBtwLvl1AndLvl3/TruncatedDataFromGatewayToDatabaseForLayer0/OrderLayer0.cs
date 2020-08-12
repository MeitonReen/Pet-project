using System;

namespace Layer1_CommunicatorsBtwLay0AndLay2.
    TruncatedDataFromGatewayToDatabaseForLayer0
{
	public class OrderLayer0 : ICloneable
    {
        public int IDOrder { get; set; }
        public int IDClient { get; set; }
        public DateTime? DateTimeCreate { get; set; }
        public string ReceiptNumberOfOrder { get; set; }
        public bool IsSelected;

		public object Clone()
		{
            OrderLayer0 OrderLayer0 = new OrderLayer0()
            {
                IDOrder = this.IDOrder,
                IDClient = this.IDClient,
                DateTimeCreate = this.DateTimeCreate,
                ReceiptNumberOfOrder = this.ReceiptNumberOfOrder,
                IsSelected = false
            };
            return OrderLayer0;
		}
	}
}
