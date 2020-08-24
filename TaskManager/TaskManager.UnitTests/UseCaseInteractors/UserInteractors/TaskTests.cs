using Autofac.Extras.Moq;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using TaskManager.DataAccess;
using TaskManager.Entities;
using TaskManager.UseCaseInteractors.UserInteractors;

namespace TaskManager.UnitTests.UseCaseInteractors.UserInteractors
{
    public class TaskTests
    {
        [Test]
        public void TaskCreation_WholeNewTask_ReturnNewTask()
        {
            using var mock = AutoMock.GetLoose();
            string taskName = "New Task";
            string description = "Description";
            var category = new TaskCategory() { Name = "Task category" };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(It.IsNotNull<Task>()))
                .Returns(false);
            mock.Mock<IDataGateway>()
                .Setup(x => x.Write(It.IsNotNull<Task>()));

            var cls = mock.Create<TaskCreation>();
            Task task = cls.CreateTask(taskName, description, category);

            mock.Mock<IDataGateway>()
                .Verify(x => x.Write(It.IsNotNull<Task>()), Times.Exactly(1));

            task.Should().NotBeNull();
            task.Name.Should().Be(taskName);
            task.Description.Should().Be(description);
        }

        [Test]
        public void TaskCreation_AlreadyExistingTask_ThrowException()
        {
            using var mock = AutoMock.GetLoose();
            string taskName = "Existing Task";
            string description = "Description";
            var category = new TaskCategory() { Name = "Task category" };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(It.IsNotNull<Task>()))
                .Returns(true);


            var cls = mock.Create<TaskCreation>();
            Action action = () => cls.CreateTask(taskName, description, category);

            action.Should().Throw<ArgumentException>();
            mock.Mock<IDataGateway>()
                .Verify(x => x.Write(It.IsNotNull<Task>()), Times.Exactly(0));
        }

        [Test]
        public void TaskDeletion_DeleteExistingTask_TaskDeleted()
        {
            using var mock = AutoMock.GetLoose();
            string taskName = "Existing Task";
            string description = "Description";
            var category = new TaskCategory() { Name = "Task category" };
            var task = new Task() { Name = taskName, Description = description, Category = category };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(task))
                .Returns(true);
            mock.Mock<IDataGateway>()
                .Setup(x => x.Delete(task));

            var cls = mock.Create<TaskDeletion>();
            cls.DeleteTask(task);

            mock.Mock<IDataGateway>()
                .Verify(x => x.Delete(task), Times.Exactly(1));
        }

        [Test]
        public void TaskDeletion_DeleteNotExistingTask_ThrowException()
        {
            using var mock = AutoMock.GetLoose();
            string taskName = "New Task";
            string description = "Description";
            var category = new TaskCategory() { Name = "Task category" };
            var task = new Task() { Name = taskName, Description = description, Category = category };

            mock.Mock<IDataGateway>()
                .Setup(x => x.DoesElementExist(task))
                .Returns(false);

            var cls = mock.Create<TaskDeletion>();
            Action action = () => cls.DeleteTask(task);

            action.Should().Throw<InvalidOperationException>();
            mock.Mock<IDataGateway>()
                .Verify(x => x.Delete(task), Times.Exactly(0));
        }
    }
}
