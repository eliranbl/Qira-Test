using AutoMapper;
using Qira.Common.Paging;
using Qira.Domain.Invoices;

namespace Qira.WebApi;

public class QiraAutoMapperProfile : Profile
{
    public QiraAutoMapperProfile()
    {
        CreateCommonMaps();
        CrateInvoiceMaps();
    }

    private void CreateCommonMaps()
    {
        CreateMap(typeof(Page<>), typeof(Page<>));
    }

    private void CrateInvoiceMaps()
    {
        CreateMap<Invoice, InvoiceResponse>();
        CreateMap<AddInvoiceRequest, Invoice>();
        CreateMap<UpdateInvoiceRequest, Invoice>();
    }
}