using Autofac;
using NUnit.Framework;
using System;
using TaskManager.DataAccess;
using TaskManager.Entities;
using TaskManager.UnitTests.Mocks;
using TaskManager.UseCaseInteractors.UserInteractors;
using FluentAssertions;
using Autofac.Extras.Moq;
using Moq;
using System.Collections.Generic;

namespace TaskManager.UnitTests
{
    public class TaskCategoryTests
    {

        [Test]
        public void CreateCategory_WholeNewCategory_ReturnNewCategory()
        {
            using var mock = AutoMock.GetLoose();
            string categoryName = "New Category";

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(It.IsNotNull<TaskCategory>()))
                .Returns(false);
            mock.Mock<IDataGateway>()
                .Setup(x => x.Write(It.IsNotNull<TaskCategory>()));

            var cls = mock.Create<CategoryCreation>();
            var category = cls.CreateCategory(categoryName);

            mock.Mock<IDataGateway>()
                .Verify(x => x.Write(It.IsNotNull<TaskCategory>()), Times.Exactly(1));
            category.Should().NotBeNull();
            category.Name.Should().Be(categoryName);

        }

        [Test]
        public void CreateCategory_AlreadyExistingCategory_ThrowException()
        {
            using var mock = AutoMock.GetLoose();
            var category = new TaskCategory() { Name = "Existing Category" };
            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(It.IsNotNull<TaskCategory>()))
                .Returns(true);

            var cls = mock.Create<CategoryCreation>();
            Action action = () => cls.CreateCategory(category.Name);

            action.Should().Throw<ArgumentException>();
            mock.Mock<IDataGateway>()
                .Verify(x => x.Write(category), Times.Exactly(0));
        }


        [Test]
        public void DeleteCategory_DeleteExistingCategory_Ret()
        {
            using var mock = AutoMock.GetLoose();
            var category = new TaskCategory() { Name = "Existing Category" };
            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(category))
                .Returns(true);
            mock.Mock<IDataGateway>()
                .Setup(x => x.Delete(category));

            var cls = mock.Create<CategoryDeletion>();
            cls.DeleteCategory(category);

            mock.Mock<IDataGateway>()
                .Verify(x => x.Delete(category), Times.Exactly(1));
        }

        [Test]
        public void DeleteCategory_DeleteNotExistingCategory_Ret()
        {
            using var mock = AutoMock.GetLoose();
            var category = new TaskCategory() { Name = "New Category" };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(category))
                .Returns(false);

            var cls = mock.Create<CategoryDeletion>();
            Action action = () => cls.DeleteCategory(category);

            action.Should().Throw<InvalidOperationException>();

            mock.Mock<IDataGateway>()
                .Verify(x => x.Delete(category), Times.Exactly(0));

        }

        [Test]
        public void EditCategory_ChangeCategoryNameWithLegalSigns_IsSuccessful()
        {
            using var mock = AutoMock.GetLoose();
            var category = new TaskCategory() { Name = "New legal name" };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(category))
                .Returns(true);
            mock.Mock<IDataGateway>()
                .Setup(x => x.Update(category));

            var cls = mock.Create<CategoryEdit>();
            cls.UpdateCategory(category);

            mock.Mock<IDataGateway>()
                .Verify(x => x.Update(category), Times.Exactly(1));
        }

        [Test]
        public void EditCategory_ChangeCategoryNameWithIllegalSigns_ThrowsException()
        {
            Assert.Fail();
        }

        [Test]
        public void FetchCategories_NoCategoriesCreated_ReturnEmptyEnumerable()
        {
            Assert.Fail();
        }

        [Test]
        public void FetchCategories_FewCategoriesCreated_ReturnCorrrectCategories()
        {
            Assert.Fail();
        }

        [Test]
        public void FetchCategoryTasks_NoTasksCreated_ReturnEmptyEnumerable()
        {
            Assert.Fail();
        }

        [Test]
        public void FetchCategoryTasks_FewTasksCreated_ReturnCorrectTasks()
        {
            Assert.Fail();
        }


        private List<TaskCategory> GetSampleCategories()
        {
            return new List<TaskCategory>() { 
                new TaskCategory { Name = "Existing category" }, 
                new TaskCategory { Name = "Another category" } 
            };
        }
    }
}