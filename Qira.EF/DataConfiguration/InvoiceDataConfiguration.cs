using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qira.Domain.Invoices;
using Qira.Domain.PaymentMethods;
using Qira.Domain.ProcessingStatuses;

namespace Qira.EF.DataConfiguration;

/// <summary>
/// Invoice data configuration.
/// </summary>
public class InvoiceDataConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        builder.HasData(Create(0001, 100, PaymentMethod.CreditCard, ProcessingStatus.New, DateTime.UtcNow),
            Create(25, 10.50, PaymentMethod.DebitCard, ProcessingStatus.Paid, DateTime.UtcNow),
            Create(3, 25.9, PaymentMethod.ElectronicCheck, ProcessingStatus.New, DateTime.UtcNow.AddDays(1)),
            Create(14, 50.05, PaymentMethod.CreditCard, ProcessingStatus.Canceled, DateTime.UtcNow.AddDays(2).AddHours(2)),
            Create(315, 864.50, PaymentMethod.CreditCard, ProcessingStatus.New, DateTime.UtcNow.AddDays(-5)));
    }

    private Invoice Create(int id, double amount, PaymentMethod paymentMethod, ProcessingStatus status, DateTime createdDateTime)
    {
        return new Invoice
        {
            Id = id,
            Amount = Math.Round(amount, 2),
            PaymentMethod = paymentMethod,
            ProcessingStatus = status,
            CreatedDateTime = createdDateTime
        };
    }
}