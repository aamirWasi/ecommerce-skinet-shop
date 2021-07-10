namespace ecommerce_skinet_shop.Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string state, string street, string zipcode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            State = state;
            Street = street;
            Zipcode = zipcode;
            City = city;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
    }
}
