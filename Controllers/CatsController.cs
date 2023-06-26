// using catRoundUp.Models; works as import, but can be defined globalling in global.cs

namespace catRoundUp.Controllers;


[ApiController]
[Route("api/cats")]
public class CatsController : ControllerBase
{

  // NOTE for the controller to have access to the service, it must define and build one to use
  private readonly CatsService _catsService;

  public CatsController(CatsService catsService)
  {
    _catsService = catsService;
  }

  [HttpGet("test")]
  // accessor, return type, method name
  public ActionResult<string> Test()
  {
    try
    {
      // return "hey";
      // throw new Exception("AHHHHH");
      // "Ok" is an ActionResult and "Hey" is the string.
      return Ok("Hey");
    }
    catch (System.Exception error)
    {
      return BadRequest("I cant do that." + error.Message);
    }
  }

  [HttpGet]
  public ActionResult<List<Cat>> GetAllCats()
  {
    try
    {
      List<Cat> cats = _catsService.GetAllCats();
      return Ok(cats);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPost]
  public ActionResult<Cat> CreateCat([FromBody] Cat catData)
  {
    try
    {
      Cat cat = _catsService.CreateCat(catData);
      return Ok(cat);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{catId}")]
  public ActionResult<string> RemoveCat(int catId)
  {
    try
    {
      string message = _catsService.RemoveCat(catId);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpPut("{catId}")]
  public ActionResult<Cat> UpdateCat(int catId, [FromBody] Cat updateData)
  {
    try
    {
      updateData.Id = catId;
      Cat cat = _catsService.UpdateCat(updateData);
      return Ok(cat);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}

