using MagicVilla_API.Models.DTO;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> villaList = new List<VillaDTO>()
        {
                new VillaDTO {Id = 1, Name = "Beach View", Sqft=100, Occupancy = 4},
                new VillaDTO {Id = 2, Name = "Villa View", Sqft=100, Occupancy = 5 },
        };
    }
}
