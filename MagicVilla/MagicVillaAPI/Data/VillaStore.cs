using MagicVillaAPI.Model.Dto;

namespace MagicVillaAPI.Data
{
    public static class VillaStore
    {
        public static List<VillaDto> villalist =  new List<VillaDto>
            {
                new VillaDto{ Id = 1, Name = "Pool View",Occupancy=4,Sqft=100},
                new VillaDto{ Id = 2, Name = "Beach View",Occupancy=3,Sqft=300}
            };
    }
}
