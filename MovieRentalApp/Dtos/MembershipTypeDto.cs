
namespace MovieRentalApp.Dtos
{
    public class MembershipTypeDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        /*we only need the Id and Name properties here.
         * If the clients want to know the detail of the membership, they can use the id to send a request to new endpoint for membershiptype detail.f
         */
      }
}