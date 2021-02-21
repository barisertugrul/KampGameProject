using KampGameProject.Abstract;
using KampGameProject.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace KampGameProject.Adapters
{
    public class MernisServiceAdapter:IUserValidationService
    {
        public bool Validate(User user)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            Console.WriteLine("Adapter çalıştı");
            var result = client.TCKimlikNoDogrulaAsync(
                new TCKimlikNoDogrulaRequest
                (new TCKimlikNoDogrulaRequestBody(Convert.ToInt64(user.NationalityId), user.FirstName, user.LastName, user.DateOfBirth.Year)))
                .Result.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
