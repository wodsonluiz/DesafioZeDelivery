using DesafioZeDelivery.Domain.Models.Dto;
using System;

namespace DesafioZeDelivery
{
    public static class PartnerExtension
    {
        public static Partner GeneratePartnerFake(this Partner partner)
        {
            partner.id = Guid.NewGuid().ToString();
            partner.tradingName = "Adega da Cerveja - Pinheiros Test";
            partner.ownerName = "Zé da Silva Test";
            partner.document = "document -" + Guid.NewGuid().ToString();

            return partner;
        }
    }
}
