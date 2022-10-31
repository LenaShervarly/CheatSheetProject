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

/*CheatSheetProject.Repositories.Migrations.run();
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("While");
//CheatSheetProject.Repositories.TopicRepository.AddNewTopic("If statement");
var topics = CheatSheetProject.Repositories.TopicRepository.GetAllTopics();
var firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].id);
Console.WriteLine(firstTopic);
if(firstTopic != null)
{
    CheatSheetProject.Repositories.TopicRepository.UpdateNameById(firstTopic.id, "Cheat Sheet Project");
}

firstTopic = CheatSheetProject.Repositories.TopicRepository.GetTopic(topics[0].id);
Console.WriteLine(firstTopic);

CheatSheetProject.Repositories.TopicRepository.DeleteTopicByName("If statement");

var cheatSheetItem = new CheatSheetProject.Models.CheetSheetItem()
{
    name = "if else",
    codeSnippet = "if(a < b) {... code} esle { ..some code}",
    additionalInfo = "if statements else"
};
//CheatSheetProject.Repositories.CheatSheetItemRepository.AddNewCheatSheetItem(cheatSheetItem, "1cb29e2a-9cfe-46ae-a14e-7a2fcb4bcf54");
//CheatSheetProject.Repositories.CheatSheetItemRepository.UpdateItemById("22aa995c-d379-44be-a60a-ddb768e7f9f9", cheatSheetItem);
CheatSheetProject.Repositories.CheatSheetItemRepository.DeleteItemById("5fe89220-d9f6-467b-a706-a073c47715ca");
var item = CheatSheetProject.Repositories.CheatSheetItemRepository.GetItem("d3e859c4-d636-48c6-8d72-666be7694b6f");
var allItems = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItems();
var itemsByTopic = CheatSheetProject.Repositories.CheatSheetItemRepository.GetAllItemsByTopicId("1cb29e2a-9cfe-46ae-a14e-7a2fcb4bcf54");

// CheatSheetProject.Repositories.Migrations.run();
var usefulLink = new CheatSheetProject.Models.UsefulLink()
{
    linkAddress = "codeEasy5.io",
    linkOrder = 3,
    cheatSheetItemId = "22aa995c-d379-44be-a60a-ddb768e7f9f9"
};
CheatSheetProject.Repositories.UsefulLinksRepository.AddUsefulLink(usefulLink, "22aa995c-d379-44be-a60a-ddb768e7f9f9");
//CheatSheetProject.Repositories.UsefulLinksRepository.UpdateLinkById("ca19b394-274a-416d-9377-2163850dc804", usefulLink);
CheatSheetProject.Repositories.UsefulLinksRepository.DeleteLinkById("ca19b394-274a-416d-9377-2163850dc804");
var allLinks = CheatSheetProject.Repositories.UsefulLinksRepository.GetAllLinks();
var link = CheatSheetProject.Repositories.UsefulLinksRepository.GetItem("ee2f4e3c-d7f0-4141-ad91-0fad6a0328bd");
var byItem = CheatSheetProject.Repositories.UsefulLinksRepository.GetAllUsefulLinksByItemId("22aa995c-d379-44be-a60a-ddb768e7f9f9");
*/
var topicWithAllData = CheatSheetProject.Repositories.TopicRepository.GetTopicWithAllItems("1cb29e2a-9cfe-46ae-a14e-7a2fcb4bcf54");
app.Run();



