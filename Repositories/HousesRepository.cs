




namespace gregslist_csharp.Repositories;
public class HousesRepository
{
  private readonly IDbConnection _db;

  public HousesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal House CreateHouse(House houseData)
  {
    string sqlQuery = @"
    INSERT INTO houses(bedrooms, bathrooms, price, description)
    VALUES (@Bedrooms, @Bathrooms, @Price, @Description);

    SELECT * FROM houses WHERE id = LAST_INSERT_ID();";

    House house = _db.Query<House>(sqlQuery, houseData).FirstOrDefault();
    return house;
  }

  internal void DeleteHouse(int houseId)
  {
    string sqlQuery = "DELETE FROM houses WHERE id = @houseId";
    _db.Execute(sqlQuery, new { houseId });
  }

  internal House GetHouseById(int houseId)
  {
    string sqlQuery = "SELECT * FROM houses WHERE id = @houseId";
    House house = _db.Query<House>(sqlQuery, new { houseId }).FirstOrDefault();
    return house;
  }

  internal List<House> GetHouses()
  {
    string sqlQuery = "SELECT * FROM houses;";
    List<House> houses = _db.Query<House>(sqlQuery).ToList();
    return houses;
  }

  internal void UpdateHouse(House house)
  {
    string sqlQuery = @"
    UPDATE houses
    SET
    bedrooms = @Bedrooms,
    bathrooms = @Bathrooms,
    price = @Price,
    description = @Description
    WHERE id = @Id;";

    _db.Execute(sqlQuery, house);
  }
}
