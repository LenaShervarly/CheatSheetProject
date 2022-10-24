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

//CheatSheetProject.Repositories.Migrations.run();
CheatSheetProject.Repositories.TopicRepository.AddNewTopic("While");
CheatSheetProject.Repositories.TopicRepository.AddNewTopic("If statement");
var topics = CheatSheetProject.Repositories.TopicRepository.GetAllTopics();
var firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].id);
Console.WriteLine(firstTopic);

app.Run();



