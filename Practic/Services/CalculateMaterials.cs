using Practic.Models;

namespace Practic.Services
{
    public class CalculateMaterials
    {
        private readonly AppDbContext _context;

        public CalculateMaterials()
        {
            _context = new AppDbContext();
        }

        public int Calculate(int idTypeProduct, int idMaterial, int countProducts, decimal width, decimal length)
        {
            var typeProduct = _context.ProductTypes.FirstOrDefault(p => p.Id == idTypeProduct);
            var material = _context.Materials.FirstOrDefault(m => m.Id == idMaterial);

            if (typeProduct == null || material == null)
                return -1;

            return CalculateMaterialsToproducts(width, length, typeProduct.Coefficient, countProducts, material.Percent);
        }

        public static int CalculateMaterialsToproducts(decimal width, decimal length, decimal coefficient, int countProducts, decimal percent)
        {
            if (width <= 0 || length <= 0 || countProducts <= 0)
                return -1;

            if (coefficient <= 0 || percent < 0)
                return -1;
                
            var countNeededMaterial = width * length * coefficient * countProducts;

            var countNeededMaterialDefect = (percent + 1) * countNeededMaterial;

            Console.WriteLine(countNeededMaterialDefect);

            return Convert.ToInt32(countNeededMaterialDefect);
        }
    }
}
