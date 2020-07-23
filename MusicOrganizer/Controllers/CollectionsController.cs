using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class CollectionsController : Controller
  {
    [HttpGet("/collections")]
    public ActionResult Index()
    {
      List<Collection> allCollections = Collection.GetAll();
      return View(allCollections);
    }
    
    [HttpGet("/collections/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/collections")]
    public ActionResult Create(string typeOfCollection)
    {
      Collection newCollection = new Collection(typeOfCollection);
      return RedirectToAction("Index");
    }

    [HttpGet("/collections/records")]
    public ActionResult ShowAll()
    {
      List<List<Record>> allRecords = Collection.GetAllRecords();
      return View(allRecords);
    }

    [HttpGet("/collections/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Collection selectedCollection = Collection.Find(id);
      List<Record> collectionRecords = selectedCollection.Records;
      model.Add("collection", selectedCollection);
      model.Add("records", collectionRecords);
      return View(model);
    }

    [HttpPost("/collections/{collectionId}/records")]
    public ActionResult Create(int collectionId, string recordTitle, string recordArtist)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Collection foundCollection = Collection.Find(collectionId);
      Record newRecord = new Record(recordTitle, recordArtist);
      foundCollection.AddRecord(newRecord);
      List<Record> collectionRecords = foundCollection.Records;
      model.Add("records", collectionRecords);
      model.Add("collection", foundCollection);
      return View("Show", model);
    }
  }
}