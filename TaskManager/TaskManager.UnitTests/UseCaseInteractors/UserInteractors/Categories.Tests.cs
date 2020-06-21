using NUnit.Framework;
using System;
using TaskManager.Entities;
using TaskManager.UseCaseInteractors.UserInteractors;

namespace TaskManager.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateCategory_WholeNewCategory_ReturnNewCategory()
        {
            string newCategoryName = "New Category";
            TaskCategory taskCategory = CategoryCreation.CreateCategory(newCategoryName);

            Assert.That(taskCategory, Is.Not.Null);
            Assert.That(taskCategory.Name, Is.EqualTo(newCategoryName));
        }

        [Test]
        public void CreateCategory_AlreadyExistingCategory_ThrowException()
        {
            string newCategoryName = "Exisiting Category";
            Assert.That(() => CategoryCreation.CreateCategory(newCategoryName),Throws.Exception.TypeOf<ArgumentException>());
        }
    }
}