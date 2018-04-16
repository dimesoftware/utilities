using System;
using System.Linq;
using Xunit;
using static Xunit.Assert;

namespace Dime.Utilities.Core.Tests
{
    public class StringUtilitiesTests
    {
        [Theory]
        [Trait("Category", "String")]
        [InlineData("Supercalifragilisticexpialidocious", false)]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData(" ", false)]
        public void NullIfEmpty(string sub, bool mustBeNull)
        {
            string nullIfEmptyString = sub.NullIfEmpty();
            True(nullIfEmptyString == null == mustBeNull);
        }

        [Theory]
        [Trait("Category", "String")]
        [InlineData("Supercalifragilisticexpialidocious", false)]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData(" ", true)]
        public void NullIfEmptyOrWhiteSpace(string sub, bool mustBeNull)
        {
            string nullIfEmptyString = sub.NullIfEmptyOrWhiteSpace();
            True(nullIfEmptyString == null == mustBeNull);
        }

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Null_Text_ReturnsText()
            => True(StringUtilities.Coalesce("", null, "Hi") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Empty_Text_ReturnsText()
            => True(StringUtilities.Coalesce("", "", "Hi") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Empty_Empty_Text_Text_ReturnsFirstText()
            => True(StringUtilities.Coalesce("", "", "Hi", "Ho") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Coalesce_Text_Null_Text_ReturnsFirstText()
            => True(StringUtilities.Coalesce("Hi", "", "Ha", "Ho") == "Hi");

        [Fact]
        [Trait("Category", "String")]
        public void Truncate_StringIsNull_ReturnsNull()
        {
            string str = null;
            Null(str.Truncate(100));
        }

        [Fact]
        [Trait("Category", "String")]
        public void Truncate_StringIsEmpty_ReturnsEmpty()
        {
            string str = string.Empty;
            Empty(str.Truncate(100));
        }

        [Fact]
        [Trait("Category", "String")]
        public void Truncate_StringIsLongerThanChunk_ReturnsChunk()
        {
            string str = "I am so lonely I even paid a hobo to spoon with me";
            True(str.Truncate(14) == "I am so lonely");
        }

        [Fact]
        [Trait("Category", "String")]
        public void Truncate_StringIsShorterThanChunk_ReturnsString()
        {
            string str = "I am so lonely I even paid a hobo to spoon with me";
            True(str.Truncate(255) == "I am so lonely I even paid a hobo to spoon with me");
        }

        [Fact]
        [Trait("Category", "String")]
        public void Split_StringIsNull_ThrowsNullReferenceException()
        {
            string str = null;
            Throws<NullReferenceException>(() => str.Split(5));
        }

        [Fact]
        [Trait("Category", "String")]
        public void Split_StringIsEmpty_ReturnsEmptyCollection()
        {
            string str = string.Empty;
            True(!str.Split(1).Any());
        }

        [Theory]
        [InlineData("Superfragilisticexpialidocious", 10, 3)]
        [InlineData("Superfragilisticexpialidocious", 3, 10)]
        [InlineData("Superfragilisticexpialidocious", 5, 6)]
        [InlineData("123456789", 2, 4)]
        [Trait("Category", "String")]
        public void Split_StringIsNotEmpty_ReturnsCollection(string text, int chunk, int collectionSize) 
            => True(text.Split(chunk).Count() == collectionSize);

        [Theory]
        [InlineData("Superfragilisticexpialidocious", 10, 3)]
        [InlineData("Superfragilisticexpialidocious", 3, 10)]
        [InlineData("Superfragilisticexpialidocious", 5, 6)]
        [InlineData("123456789", 2, 5)]
        [Trait("Category", "String")]
        public void SplitUpTo_StringIsNotEmpty_ReturnsCollection(string text, int chunk, int collectionSize)
            => True(text.SplitUpTo(chunk).Count() == collectionSize);
    }
}