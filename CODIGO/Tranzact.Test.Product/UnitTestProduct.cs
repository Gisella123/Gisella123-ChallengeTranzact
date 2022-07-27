using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tranzact.Aplication.DTO;
using Tranzact.Aplication.Service;
using Tranzact.Persistencia.RepositorioProduct;

namespace Tranzact.Test.Product
{
    [TestClass]
    public class UnitTestProduct
    {
        [TestMethod]
        public void Get_ShouldGetProductByIdAndReturnValue_1()
        {
            //ARRANGE

            var unitofwork = new AppDBTranzactContext(new DbContextOptionsBuilder<AppDBTranzactContext>().UseSqlServer("Data Source=LAPTOP-2NANB88A;Initial Catalog=Tranzact;Trusted_Connection=Yes;").Options);
            var _aplicationServicioProduct = new AplicationServicioProduct(unitofwork);
            var expected = 1;
            var id = 1;
            //ACT
            var result = _aplicationServicioProduct.Get(id);
            
            //ASSERT
            Assert.AreEqual(expected, result.Id);

        }
        
        [TestMethod]
        public void Get_ShouldAddProduct()
        {
            //ARRANGE
            var expected = true;
            var unitofwork = new AppDBTranzactContext(new DbContextOptionsBuilder<AppDBTranzactContext>().UseSqlServer("Data Source=LAPTOP-2NANB88A;Initial Catalog=Tranzact;Trusted_Connection=Yes;").Options);
            var _aplicationServicioProduct = new AplicationServicioProduct(unitofwork);
            var newproduct = new ProductInsertDTO()
            {
                Brand = "Add Test",
                Price = Convert.ToDecimal(String.Format("{0:0.00}", 0.10)),
                ProductName = "Add Test"
            };
            //ACT
            var result = _aplicationServicioProduct.Insert(newproduct);

            //ASSERT
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Get_ShouldUpdateProduct()
        {
            //ARRANGE
            var expected = true;
            var unitofwork = new AppDBTranzactContext(new DbContextOptionsBuilder<AppDBTranzactContext>().UseSqlServer("Data Source=LAPTOP-2NANB88A;Initial Catalog=Tranzact;Trusted_Connection=Yes;").Options);
            var _aplicationServicioProduct = new AplicationServicioProduct(unitofwork);
            var idupdateproduct = 1;
            var updateproduct = new ProductUpdateDTO()
            {
                Brand = "Update Test",
                Price = Convert.ToDecimal(String.Format("{0:0.00}", 0.10)),
                ProductName = "Update Test"
            };
            //ACT
            var result = _aplicationServicioProduct.Update(updateproduct, idupdateproduct);

            //ASSERT
            Assert.AreEqual(expected, result);
        }

    }
}