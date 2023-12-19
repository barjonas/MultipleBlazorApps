var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseStaticFiles();
app.MapWhen(ctx => ctx.Request.Host.Port == 5001, 
    first =>
    {
        first.Use((ctx, nxt) =>
        {
            ctx.Request.Path = "/FirstApp" + ctx.Request.Path;
            return nxt();
        });

        first.UseBlazorFrameworkFiles("/FirstApp");
        first.UseStaticFiles();
        first.UseStaticFiles("/FirstApp");
        first.UseRouting();

        first.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("/FirstApp/{*path:nonfile}",
                "FirstApp/index.html");
        });
    });

app.Run();
