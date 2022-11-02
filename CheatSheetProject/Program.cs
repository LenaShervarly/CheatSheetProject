var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//If you're running migrations for the first time, please comment all "Drop tables" rows before starting the application
CheatSheetProject.Repositories.Migrations.run();
var topicWithAllData = CheatSheetProject.Repositories.TopicRepository.GetTopicWithAllItems("1cb29e2a-9cfe-46ae-a14e-7a2fcb4bcf54");
app.Run();



