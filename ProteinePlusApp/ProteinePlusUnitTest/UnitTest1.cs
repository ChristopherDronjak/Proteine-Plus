using ProteinePlusApp.MVVM.ViewModels;
using ProteinePlusUnitTest;

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
}