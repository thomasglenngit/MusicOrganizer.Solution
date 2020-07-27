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

    /*[TestMethod]
    public void GetAll_ReturnsItems_ItemList()
    {
      //Arrange
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);
      List<Item> newList = new List<Item> { newItem1, newItem2 };

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      int result = newItem.Id;

      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItem_Item()
    {
      string description01 = "Walk the dog";
      string description02 = "Wash the dishes";
      Item newItem1 = new Item(description01);
      Item newItem2 = new Item(description02);

      Item result = Item.Find(2);

      Assert.AreEqual(newItem2, result);
    }*/
  }
}