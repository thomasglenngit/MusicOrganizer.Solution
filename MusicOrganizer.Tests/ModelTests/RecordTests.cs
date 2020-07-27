using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;
using MySql.Data.MySqlClient;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTest : IDisposable
  {

    public void Dispose()
    {
      Record.ClearAll();
    }

    public RecordTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=music_organizer_test;";
    }

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record  newRecord = new Record("title", "artist");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_RecordList()
    {
      // Arrange
      List<Record> newList = new List<Record> { };

      // Act
      List<Record> result = Record.GetAll();

      // Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfTitlesAreTheSame_Record()
    {
      // Arrange, Act
      Record firstRecord = new Record("Rubber Soul", "The Beatles");
      Record secondRecord = new Record("Rubber Soul", "The Beatles");

      // Assert
      Assert.AreEqual(firstRecord, secondRecord);
    } 

    [TestMethod]
    public void Save_SavesToDatabase_RecordList()
    {
      //Arrange
      Record testRecord = new Record("Rubber Soul", "The Beatles");

      //Act
      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record>{testRecord};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      //Arrange
      Record  record1 = new Record("title", "artist");
      record1.Save();
      Record record2 = new Record("Rubber Soul", "The Beatles");
      record2.Save();
      List<Record> newList = new List<Record> {record1, record2};

      //Act
      List<Record> result = Record.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      Record record1 = new Record("title", "artist");
      record1.Save();
      Record record2 = new Record("Rubber Soul", "The Beatles");
      record2.Save();

      Record result = Record.Find(record2.Id);

      Assert.AreEqual(record2, result);
    }
  }
}