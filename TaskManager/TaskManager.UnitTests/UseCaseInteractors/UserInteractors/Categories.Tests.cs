using Autofac;
using NUnit.Framework;
using System;
using TaskManager.DataAccess;
using TaskManager.Entities;
using TaskManager.UnitTests.Mocks;
using TaskManager.UseCaseInteractors.UserInteractors;

namespace TaskManager.UnitTests
{
    public class Tests
    {
        IContainer _container;

        [SetUp]
        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FakeDataAccess>().As<IDataGateway>();
            builder.RegisterType<CategoryCreation>();
            _container = builder.Build();
        }

        [Test]
        public void CreateCategory_WholeNewCategory_ReturnNewCategory()
        {
            using var scope = _container.BeginLifetimeScope();
            var categoryCreation = scope.Resolve<CategoryCreation>();
            string newCategoryName = "New Category";

            TaskCategory taskCategory = categoryCreation.CreateCategory(newCategoryName);

            Assert.That(taskCategory, Is.Not.Null);
            Assert.That(taskCategory.Name, Is.EqualTo(newCategoryName));
        }

        [Test]
        public void CreateCategory_AlreadyExistingCategory_ThrowException()
        {
            using var scope = _container.BeginLifetimeScope();
            var categoryCreation = scope.Resolve<CategoryCreation>();
            string newCategoryName = "Existing Category";

            Assert.That(() => categoryCreation.CreateCategory(newCategoryName),Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        public void DeleteCategory_DeleteExistingCategory_ReturnsTrue()
        {
            using var scope = _container.BeginLifetimeScope();
            var categoryDeletion = scope.Resolve<CategoryDeletion>();
            var category = new TaskCategory() { Name = "Existing Category" };

            bool result = categoryDeletion.DeleteCategory(category);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DeleteCategory_DeleteNotExistingCategory_ReturnsTrue()
        {
            using var scope = _container.BeginLifetimeScope();
            var categoryDeletion = scope.Resolve<CategoryDeletion>();
            var category = new TaskCategory() { Name = "Not-Existing Category" };

            Assert.That(() => categoryDeletion.DeleteCategory(category), Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}