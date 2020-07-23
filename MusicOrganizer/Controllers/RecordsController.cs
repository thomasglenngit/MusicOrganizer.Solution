using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;
using System.Collections.Generic;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/collections/{collectionId}/records/new")]
    public ActionResult New(int collectionId)
    {
      Collection collection = Collection.Find(collectionId);
      return View(collection);
    }

    [HttpPost("/records/delete")]
    public ActionResult DeleteAll()
    {
      Record.ClearAll();
      return View();
    }

    [HttpGet("/collections/{collectionId}/records/{recordId}")]
    public ActionResult Show(int collectionId, int recordId)
    {
      Record record = Record.Find(recordId);
      Collection collection = Collection.Find(collectionId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("record", record);
      model.Add("collection", collection);
      return View(model);
    }
  }
}