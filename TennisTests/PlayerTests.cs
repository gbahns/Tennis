using System;
using Xunit;
using TennisModel;

namespace TennisTests
{
    public class PlayerTests
    {
        [Fact]
        public void GivenFirstNameGetFirstNameMatches()
        {
            string value = "Jim";
            Player player = new Player();
            player.FirstName = value;
            Assert.Equal(value, player.FirstName);
        }

        [Fact]
        public void GivenLastNameGetLastNameMatches()
        {
            string value = "Reynolds";
            Player player = new Player();
            player.LastName = value;
            Assert.Equal(value, player.LastName);
        }

        [Theory]
        [InlineData("Jim", "Reynolds")]
        [InlineData("Jerk", "Johns")]
        [InlineData("Rutherford", "Crane")]
        [InlineData("Jiminy", "Christmas")]
        public void GiveFirstAndLastNameGetFullNameMatches(string firstName, string lastName)
        {
            string fullName = firstName + " " + lastName;
            Player player = new Player();
            player.FirstName = firstName;
            player.LastName = lastName;
            Assert.Equal(fullName, player.FullName);
        }

        [Fact]
        public void GivenNoNameFullNameIsEmpty()
        {
            Player player = new Player();
            Assert.Equal("", player.FullName);
        }

        [Fact]
        public void GivenOnlyFirstNameFullNameHasNoTrailingSpace()
        {
            string firstName = "Jim";
            Player player = new Player();
            player.FirstName = firstName;
            Assert.Equal(firstName, player.FullName);
        }

        [Fact]
        public void GivenOnlyLastNameFullNameHasNoLeadingSpace()
        {
            string lastName = "Reynolds";
            Player player = new Player();
            player.LastName = lastName;
            Assert.Equal(lastName, player.FullName);
        }

        [Fact]
        public void GivenFullNameGetFirstLastAndFullNameMatches()
        {
            string firstName = "Jimmy";
            string lastName = "Johnson";
            string fullName = firstName + " " + lastName;
            Player player = new Player();
            player.FullName = fullName;
            Assert.Equal(firstName, player.FirstName);
            Assert.Equal(lastName, player.LastName);
            Assert.Equal(fullName, player.FullName);
        }

        [Fact]
        public void GivenPartialFullNameItGoesIntoFirstName()
        {
            string fullName = "Fred";
            Player player = new Player();
            player.FullName = fullName;
            Assert.Equal(fullName, player.FirstName);
            Assert.Equal("", player.LastName);
            Assert.Equal(fullName, player.FullName);
        }

        [Fact]
        public void GivenNewPlayerNamesAreNotNull()
        {
            Player player = new Player();
            Assert.NotNull(player.FirstName);
            Assert.NotNull(player.LastName);
        }

        [Fact]
        public void GivenFullNameWithMultipleBlanksAllExtrasGoInLastName()
        {
            string firstName = "Jimmy";
            string lastName = "Johnson (Queen City Red)";
            string fullName = firstName + " " + lastName;
            Player player = new Player();
            player.FullName = fullName;
            Assert.Equal(firstName, player.FirstName);
            Assert.Equal(lastName, player.LastName);
            Assert.Equal(fullName, player.FullName);
        }
    }
}
