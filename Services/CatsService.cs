namespace catRoundUp.Services;

public class CatsService
{

  private readonly CatsRepository _repo;

  public CatsService(CatsRepository repo)
  {
    _repo = repo;
  }

  public List<Cat> GetAllCats()
  {
    List<Cat> cats = _repo.GetAllCats();
    return cats;
  }

  internal Cat CreateCat(Cat catData)
  {
    Cat cat = _repo.CreateCat(catData);
    return cat;
  }

  internal string RemoveCat(int catId)
  {
    Cat cat = _repo.GetById(catId);
    if (cat == null) throw new Exception($"No cat at id:{catId}");

    _repo.RemoveCat(catId);

    return $"cat was delorted";
  }

  internal Cat UpdateCat(Cat updateData)
  {
    Cat original = _repo.GetById(updateData.Id);
    if (original == null) throw new Exception($"No cat at id:{updateData.Id}");

    original.Age = updateData.Age != null ? updateData.Age : original.Age;
    original.Name = updateData.Name != null ? updateData.Name : original.Name;
    original.Penned = updateData.Penned != null ? updateData.Penned : original.Penned;

    // TODO save to fakedb
    _repo.UpdateCat(updateData);
    return updateData;
  }
}
