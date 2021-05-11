using DesafioZeDelivery.Core.Models;
using System;

namespace DesafioZeDelivery
{
    public static class PartnerExtension
    {
        public static Partner GeneratePartnerFake(this Partner partner)
        {
            var objFake = new Partner();
            objFake.id = Guid.NewGuid().ToString();
            objFake.tradingName = "Adega da Cerveja - Pinheiros Test";
            objFake.ownerName = "Zé da Silva Test";
            objFake.document = "document -" + Guid.NewGuid().ToString();

            return objFake;
        }
    }
}
