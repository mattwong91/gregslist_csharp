

namespace gregslist_csharp.Services;

public class HousesService
{
  private readonly HousesRepository _housesRepository;

  public HousesService(HousesRepository housesRepository)
  {
    _housesRepository = housesRepository;
  }

  internal House CreateHouse(House houseData)
  {
    House house = _housesRepository.CreateHouse(houseData);
    return house;
  }

  internal string DeleteHouse(int houseId)
  {
    House house = GetHouseById(houseId);
    _housesRepository.DeleteHouse(houseId);
    return $"House with id: {houseId} has been deleted";
  }

  internal House GetHouseById(int houseId)
  {
    House house = _housesRepository.GetHouseById(houseId);
    if (house == null)
    {
      throw new Exception($"{houseId} is an invalid id");
    }
    return house;
  }

  internal List<House> GetHouses()
  {
    List<House> houses = _housesRepository.GetHouses();
    return houses;
  }

  internal House UpdateHouse(int houseId, House houseData)
  {
    House house = GetHouseById(houseId);

    house.Bedrooms = houseData.Bedrooms;
    house.Bathrooms = houseData.Bathrooms;
    house.Price = houseData.Price;
    house.Description = houseData.Description;

    _housesRepository.UpdateHouse(house);

    return house;
  }
}
