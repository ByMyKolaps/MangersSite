using MangersBL;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MangersTests
{
    public class UnitTest1
    {
        [Fact]
        public void IsPremiumTest()
        {
            MangaLogic.SetMockRepo();
            var result = MangaLogic.IsPremium(2);
            Assert.True(result == true);
        }

        [Fact]
        public void GetMangaByIdTest()
        {
            MangaLogic.SetMockRepo();
            var result = MangaLogic.GetMangaById(1);
            Assert.True(result.Id == 1);
        }


    }
}
