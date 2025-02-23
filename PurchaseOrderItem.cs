using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.models;

public class PurchaseOrderItem
{
    [Key]
    public int Id { get; set; }

    public required string ItemDescription { get; set; }

    public int Quantity { get; set; }

    [ForeignKey("PurchaseOrder")]
    public int PurchaseOrderId { get; set; }
    public required PurchaseOrder PurchaseOrder { get; set; }

}
