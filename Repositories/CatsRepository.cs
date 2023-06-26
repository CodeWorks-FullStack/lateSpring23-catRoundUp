namespace catRoundUp.Repositories;

public class CatsRepository
{
  private List<Cat> dbCats;

  public CatsRepository()
  {
    // NOTE this is fakedb stuff for today
    this.dbCats = new List<Cat> { };
    dbCats.Add(new Cat("Murdoc", 31, "black", true, false, 1));
    dbCats.Add(new Cat("Pretty Kitty", 5, "Tabby", true, false, 2));
    dbCats.Add(new Cat("Sylvester", 52, "black & white", false, false, 3));
  }


  // NOTE internal is a public accessor in the namespace catRoundUp
  internal List<Cat> GetAllCats()
  {
    return dbCats;
  }
  internal Cat GetById(int catId)
  {
    Cat cat = dbCats.Find(c => c.Id == catId);
    return cat;
  }
  internal Cat CreateCat(Cat catData)
  {
    //NOTE weirdness for unique ids today
    int lastId = dbCats[dbCats.Count - 1].Id;
    catData.Id = lastId + 1;
    //
    dbCats.Add(catData);
    return catData;
  }

  internal void RemoveCat(int catId)
  {
    Cat cat = dbCats.Find(c => c.Id == catId);

    dbCats.Remove(cat);
  }

  internal void UpdateCat(Cat updateData)
  {
    // NOTE today you don't have to do anything if you change the original in the service,
    // usually you would swap the data in the db with the new data.
    Cat cat = GetById(updateData.Id);
    cat = updateData;
  }
}
