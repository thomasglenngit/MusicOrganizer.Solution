using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Id { get; set;}

    public Record(string title, string artist)
    {
      Title = title;
      Artist = artist;
    }

    public Record(int id, string title, string artist)
    {
      Id = id;
      Title = title;
      Artist = artist;
    }

    public override bool Equals(System.Object otherRecord)
    {
      if (!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record) otherRecord;
        bool idEquality = (this.Id == newRecord.Id);
        bool recordEquality = (this.Title == newRecord.Title) && (this.Artist == newRecord.Artist);
        return (recordEquality && idEquality);
      }
    }
  
    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM records;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordTitle = rdr.GetString(1);
        string recordArtist = rdr.GetString(2);
        Record newRecord = new Record(recordId, recordTitle, recordArtist);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRecords;
    }

    public static void ClearAll()
    {
     MySqlConnection conn = DB.Connection();
     conn.Open();
     MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
     cmd.CommandText = @"DELETE FROM records;";
     cmd.ExecuteNonQuery();
     conn.Close();
     if (conn != null)
     {
       conn.Dispose();
     }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO records (title, artist) VALUES (@RecordTitle, @RecordArtist);";
      MySqlParameter title = new MySqlParameter();
      MySqlParameter artist = new MySqlParameter();
      title.ParameterName = "@RecordTitle";
      title.Value = this.Title;
      artist.ParameterName = "@RecordArtist";
      artist.Value = this.Artist;
      cmd.Parameters.Add(title);
      cmd.Parameters.Add(artist);    
      cmd.ExecuteNonQuery();
      Id = (int)cmd.LastInsertedId;

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Record Find(int searchId)
    {
      Record placeholderRecord = new Record("placeholder Title", "placeholder Artist");
      return placeholderRecord;
    }
  }
}