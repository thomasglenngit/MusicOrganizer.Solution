using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Collection
  {
    private static List<Collection> _collections = new List<Collection> {};
    public string TypeOfCollection { get; set; }
    public int Id { get; }
    public List<Record> Records { get; set; }

    public Collection(string collectionType)
    {
      TypeOfCollection = collectionType;
      _collections.Add(this);
      Id = _collections.Count;
      Records = new List<Record>{};
    }
    public static void ClearAll()
    {
      _collections.Clear();
    }
    public static List<Collection> GetAll()
    {
      return _collections;
    }
    public static Collection Find(int searchId)
    {
      return _collections[searchId-1];
    }
    public void AddRecord(Record record)
    {
      Records.Add(record);
    }
  }
}