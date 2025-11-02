using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]

public class VeiculoTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        // Act (testando o set;)
        veiculo.Id = 1;
        veiculo.Nome = "Fiesta";
        veiculo.Marca = "teste123v";
        veiculo.Ano = 1960;

        // Assert (testando o get;)
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Fiesta", veiculo.Nome);
        Assert.AreEqual("teste123v", veiculo.Marca);
        Assert.AreEqual(1960, veiculo.Ano);

    }
}