
namespace MemoKu.POS.Reporting.Models
{
    public class CompanyProfile
    {
        public string OrganizationId { get; private set; }
        public string ClientId { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public byte[] Logo { get; private set; }

        public CompanyProfile(string organizationId, string clientId, string name, string address, byte[] logo)
        {
            this.OrganizationId = organizationId;
            this.ClientId = clientId;
            this.Name = name;
            this.Address = address;
            this.Logo = logo;
        }
    }
}
