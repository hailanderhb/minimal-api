using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Infraestrutura.Db;

namespace Test.Domain.Entidades;

[TestClass]

public class AdministradorServicoTest
{
    private DbContexto CriarContextoTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", ".."));

        //Configurar o configurationBuilder
        var builder = new ConfigurationBuilder()
            .SetBasePath(path ?? Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        var configuration = builder.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestandoSalvarAdministrador()
    {
        //Arrange
        var context = CriarContextoTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste123";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act (Criação dos dados)

        administradorServico.Incluir(adm);


        // Assert (testando o get;)
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        Assert.AreEqual("teste@teste.com", adm.Email);
        Assert.AreEqual("teste123", adm.Senha);
        Assert.AreEqual("Adm", adm.Perfil);

    }
    [TestMethod]
        
    public void TestandoBuscaPorId()
    {
        //Arrange
        var context = CriarContextoTeste();
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();        
        adm.Email = "teste@teste.com";
        adm.Senha = "teste123";
        adm.Perfil = "Adm";

        var administradorServico = new AdministradorServico(context);

        // Act (Criação dos dados)
        administradorServico.Incluir(adm);
        var admDoBanco = administradorServico.BuscaPorId(adm.Id);


        // Assert (testando o get;)
        Assert.AreEqual(1, administradorServico.Todos(1).Count());
        Assert.AreEqual(1, admDoBanco?.Id);


    }
}