using UserService.Core;
using Xunit;

namespace UserService.Test
{
    public class UserProcessorTest
    {
        private readonly IUserProcessor _userProcessor;

        public UserProcessorTest()
        {
            _userProcessor = new UserProcessor();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("iamAdmin")]
        [InlineData("excuser")]
        [InlineData("userAndAdmin")]
        [InlineData("martrin15")]
        [InlineData("martin-test")]
        [InlineData("martin test2")]
        public void Username_invalid(string value)
        {

            var user = new User { Id = "1", Name = value };
            var result = _userProcessor.IsValidUser(user);

            Assert.False(result);
        }


        [Fact]
        public void Username_valid()
        {
            var user = new User { Id = "1", Name = "martin" };
            var result = _userProcessor.IsValidUser(user);

            Assert.True(result);
        }

        [Fact]
        public void Username_space_valid()
        {
            var user = new User { Id = "1", Name = "martin test" };
            var result = _userProcessor.IsValidUser(user);

            Assert.True(result);
        }


    }

}