namespace Invoice.Data.Entities
{
    public partial class InvoiceDetailsVM
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal? Total { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Net { get; set; }

        public virtual InvoiceVM Invoice { get; set; }
        public virtual ItemsVM Item { get; set; }
        public virtual UnitsVM Unit { get; set; }
    }
}
