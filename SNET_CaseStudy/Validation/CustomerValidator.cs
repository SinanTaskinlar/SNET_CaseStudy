using KimlikDogrulama;
using SNET_CaseStudy.Entities;

namespace SNET_CaseStudy.Validation
{
    public class CustomerValidator
    {
        public static async void ValidateCustomer(CustomerDto customerDto)
        {
            if (customerDto == null) throw new Exception("TC Kimlik Doğrulama Başarısız");
            if (customerDto.Name == null || customerDto.Surname == null || customerDto.TCKN == null || customerDto.BirthDate == null) throw new Exception("TC Kimlik Doğrulama Başarısız");

            var _tckn = long.Parse(customerDto.TCKN);
            var _name = customerDto.Name;
            var _surname = customerDto.Surname;
            var _birthYear = Convert.ToInt32(customerDto.BirthDate[^4..]);
            var client = new KimlikDogrulama.KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(_tckn, _name, _surname, _birthYear);

            if (response != null)
            {
                if (!response.Body.TCKimlikNoDogrulaResult)
                {
                    throw new Exception("TC Kimlik Doğrulama Başarısız");
                }
            }
        }
        public static void ValidateTcknLength(string TCKN)
        {
            if (TCKN.Length != 11) throw new Exception("TC Kimlik Doğrulama Başarısız");
        }
    }
}