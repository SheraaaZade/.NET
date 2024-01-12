var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/bank/tva/{price}/{country}", (int price, string country) =>
{
    if (country == "BE")
    {
        return price * 1.21;
    }
    else if (country == "FR")
    {
        return price * 1.20;
    }
    return price;
});

// Ici en cas d'erreur sur le code du pays on recoit un code HTTP 400 (erreur)
app.MapGet("/bank/tva2/{valueToConvert}/{country}", (int price, string country) =>
{
    double vatCalculation = 0;
    switch (country)
    {
        case "BE":
            vatCalculation = price * 1.21;
            return Results.Ok("Prix calcul : " + vatCalculation);

        case "FR":
            vatCalculation = price * 1.20;
            return Results.Ok("Prix calcul : " + vatCalculation);
        default:
            return Results.BadRequest("Code de pays non valide. Utilisez 'BE' ou 'FR'.");
    }

});




app.Run(); // pas oublié cette foutue ligne!!!!