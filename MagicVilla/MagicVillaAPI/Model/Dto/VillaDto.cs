using System.ComponentModel.DataAnnotations; // these are used for validation attributes - primary key , not null , foreign key 


namespace MagicVillaAPI.Model.Dto
{
    public class VillaDto
    {
        //What is a DTO?
        //A DTO is a simple object that only carries data between processes(like from your API to the client, or from client to API).
        //It usually doesn’t contain any business logic, only properties.
        //It helps control what data you expose from your models (like your Employee table).

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        // these validation will work due to api controller
        public string Name { get; set; }

        public int Occupancy { get; set; }
        public int Sqft { get; set; }
    }
}
