namespace SENAI_Projeto_Web_LH_Pets;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();
        Banco db = new();

        // rotas da API
        app.UseStaticFiles();
        app.MapGet("/", () => "Projeto Web LH Pets version 1");
        app.MapGet("/index", (HttpContext contexto) => {
            contexto.Response.Redirect("index.html", false);
        });
        app.MapGet("/lista_clientes", (HttpContext contexto) => {
            contexto.Response.WriteAsync(db.GetListaString());
        });
        // roda app
        app.Run();
    }
}
