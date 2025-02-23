using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.models;

public class PurchaseOrder
{
    [Key]
    public int Id { get; set; }

    public required string OrderNumber { get; set; }

    public DateTime OrderDate { get; set; }

    [ForeignKey("Company")]
    public int CompanyId { get; set; }
    public required Company Company { get; set; }


    public required List<PurchaseOrderItem> Items { get; set; }

}
