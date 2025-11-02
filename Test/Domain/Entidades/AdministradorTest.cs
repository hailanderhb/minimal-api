using minimal_api.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]

public class AdministradorTest
{
    [TestMethod]
    public void TestarGetSetPropriedades()
    {
        //Arrange
        var adm = new Administrador();

        // Act (testando o set;)
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste123";
        adm.Perfil = "Adm";

        // Assert (testando o get;)
        Assert.AreEqual(1, adm.Id);
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste123", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }
}