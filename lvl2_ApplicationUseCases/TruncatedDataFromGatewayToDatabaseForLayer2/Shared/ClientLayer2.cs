
namespace Layer2_ApplicationUseCases.
    TruncatedDataFromGatewayToDatabaseForLayer2.
    Shared
{
    public class ClientLayer2
    {
        public int IDСlient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }

        public ClientLayer2()
        {
            IDСlient = 1;
        }

    }
}
