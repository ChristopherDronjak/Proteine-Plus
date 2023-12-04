using ProteinePlusApp.MVVM.ViewModels;
using ProteinePlusApp.Services;
using ProteinePlusUnitTest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using ProteinePlusApp;
using ProteinePlusApp.MVVM.Views;
using ProteinePlusApp.MVVM.Models;

namespace ProteinePlusUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Username_Set_PropertyChangedEventRaised()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            bool eventRaised = false;

            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(LoginViewModel.Username))
                {
                    eventRaised = true;
                }
            };

            // Act
            viewModel.Username = "TestUsername";

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("TestUsername", viewModel.Username);
        }

    }

    public class UnitTest2
    {
        [Fact]
        public void Password_Set_PropertyChangedEventRaised()
        {
            // Arrange
            var viewModel = new LoginViewModel();
            bool eventRaised = false;

            viewModel.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(LoginViewModel.Password))
                {
                    eventRaised = true;
                }
            };

            // Act
            viewModel.Password = "TestPassword";

            // Assert
            Assert.True(eventRaised);
            Assert.Equal("TestPassword", viewModel.Password);
        }
    }


}