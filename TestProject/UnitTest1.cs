using Practic.Services;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateMaterials_CalculateMaterialsToproducts_CorrectData_10340()
        {
            Assert.Equal(10340, CalculateMaterials.CalculateMaterialsToproducts(20, 100, (decimal)2.35, 2, (decimal)0.10));
        }

        [Fact] 
        public void CalculateMaterials_CalculateMaterialsToproducts_IncorrectWidth_minus1()
        {
            Assert.Equal(-1, CalculateMaterials.CalculateMaterialsToproducts(-20, 100, (decimal)2.35, 2, (decimal)0.10));
        }

        [Fact]
        public void CalculateMaterials_CalculateMaterialsToproducts_IncorrectLength_minus1()
        {
            Assert.Equal(-1, CalculateMaterials.CalculateMaterialsToproducts(20, -100, (decimal)2.35, 2, (decimal)0.10));
        }

        [Fact]
        public void CalculateMaterials_CalculateMaterialsToproducts_IncorrectCoefficient_minus1()
        {
            Assert.Equal(-1, CalculateMaterials.CalculateMaterialsToproducts(20, 100, (decimal)-2.35, 2, (decimal)0.10));
        }

        [Fact]
        public void CalculateMaterials_CalculateMaterialsToproducts_IncorrectCount_minus1()
        {
            Assert.Equal(-1, CalculateMaterials.CalculateMaterialsToproducts(20, 100, (decimal)2.35, -2, (decimal)0.10));
        }

        [Fact]
        public void CalculateMaterials_CalculateMaterialsToproducts_IncorrectPercent_minus1()
        {
            Assert.Equal(-1, CalculateMaterials.CalculateMaterialsToproducts(20, 100, (decimal)2.35, 2, (decimal)-0.10));
        }
    }
}