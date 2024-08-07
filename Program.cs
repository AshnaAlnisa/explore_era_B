
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using COMMON_PROJECT_STRUCTURE_API.services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;


WebHost.CreateDefaultBuilder().
ConfigureServices(s=>
{
    IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    s.AddSingleton<login>();
    s.AddSingleton<register>();
     s.AddSingleton<enquiryForm>();
     s.AddSingleton<destination_form>();
     s.AddSingleton<enquiryFormDeleteDetails>();
     s.AddSingleton<signup>();
     s.AddSingleton<myLogin>();
     s.AddSingleton<destination1>();
     s.AddSingleton<destination1View>();
     s.AddSingleton<heading_details>();
     s.AddSingleton<best_time_to_visit>();
     s.AddSingleton<best_view>();
     s.AddSingleton<heading>();
     s.AddSingleton<destination_details>();
     s.AddSingleton<plan_your_trip>();
     s.AddSingleton<plan_your_trip_delete_details>();
     s.AddSingleton<destination_card>();
     s.AddSingleton<destination_card1>();
     s.AddSingleton<imageInsert>();
     s.AddSingleton<dcInsert>();
     s.AddSingleton<homeInsert>();
     s.AddSingleton<homeView>();
     s.AddSingleton<homeView2>();
     s.AddSingleton<homeView3>();
     s.AddSingleton<insertWeekendGateways>();
     s.AddSingleton<viewWeekendGateways1>();
     s.AddSingleton<viewWeekendGateways2>();
     s.AddSingleton<viewWeekendGateways3>();
     s.AddSingleton<generate>();
     s.AddSingleton<updatepassword>();
     s.AddSingleton<verify>();

s.AddAuthorization();
s.AddControllers();
s.AddCors();
s.AddAuthentication("SourceJWT").AddScheme<SourceJwtAuthenticationSchemeOptions, SourceJwtAuthenticationHandler>("SourceJWT", options =>
    {
        options.SecretKey = appsettings["jwt_config:Key"].ToString();
        options.ValidIssuer = appsettings["jwt_config:Issuer"].ToString();
        options.ValidAudience = appsettings["jwt_config:Audience"].ToString();
        options.Subject = appsettings["jwt_config:Subject"].ToString();
    });
}).Configure(app=>
{
app.UseAuthentication();
app.UseAuthorization();
 app.UseCors(options =>
         options.WithOrigins("https://localhost:5002", "http://localhost:5001")
         .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseRouting();
app.UseStaticFiles();

app.UseEndpoints(e=>
{
           var login=  e.ServiceProvider.GetRequiredService<login>();
           var register=  e.ServiceProvider.GetRequiredService<register>();
           var enquiryForm=  e.ServiceProvider.GetRequiredService<enquiryForm>();
           var destination_form=  e.ServiceProvider.GetRequiredService<destination_form>();
           var enquiryFormDeleteDetails=  e.ServiceProvider.GetRequiredService<enquiryFormDeleteDetails>();
           var signup=  e.ServiceProvider.GetRequiredService<signup>();
           var myLogin=  e.ServiceProvider.GetRequiredService<myLogin>();
           var destination1=  e.ServiceProvider.GetRequiredService<destination1>();
           var destination1View=  e.ServiceProvider.GetRequiredService<destination1View>();
           var heading_details=  e.ServiceProvider.GetRequiredService<heading_details>();
           var best_time_to_visit=  e.ServiceProvider.GetRequiredService<best_time_to_visit>();
           var best_view=  e.ServiceProvider.GetRequiredService<best_view>();
           var heading=  e.ServiceProvider.GetRequiredService<heading>();
           var destination_details=  e.ServiceProvider.GetRequiredService<destination_details>();
           var plan_your_trip=  e.ServiceProvider.GetRequiredService<plan_your_trip>();
           var plan_your_trip_delete_details=  e.ServiceProvider.GetRequiredService<plan_your_trip_delete_details>();
           var destination_card=  e.ServiceProvider.GetRequiredService<destination_card>();
           var destination_card1=  e.ServiceProvider.GetRequiredService<destination_card1>();
           var imageInsert=  e.ServiceProvider.GetRequiredService<imageInsert>();
           var dcInsert=  e.ServiceProvider.GetRequiredService<dcInsert>();
           var homeInsert=  e.ServiceProvider.GetRequiredService<homeInsert>();
           var homeView=  e.ServiceProvider.GetRequiredService<homeView>();
           var homeView2=  e.ServiceProvider.GetRequiredService<homeView2>();
           var homeView3=  e.ServiceProvider.GetRequiredService<homeView3>();
           var insertWeekendGateways=  e.ServiceProvider.GetRequiredService<insertWeekendGateways>();
           var viewWeekendGateways1=  e.ServiceProvider.GetRequiredService<viewWeekendGateways1>();
           var viewWeekendGateways2=  e.ServiceProvider.GetRequiredService<viewWeekendGateways2>();
           var viewWeekendGateways3=  e.ServiceProvider.GetRequiredService<viewWeekendGateways3>();
           var generate=  e.ServiceProvider.GetRequiredService<generate>();
           var updatepassword=  e.ServiceProvider.GetRequiredService<updatepassword>();
           var verify=  e.ServiceProvider.GetRequiredService<verify>();
           
           


 e.MapPost("login",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1001") // update
                         await http.Response.WriteAsJsonAsync(await login.Login(rData));

         });
         e.MapPost("plan_your_trip",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await plan_your_trip.Plan_your_trip(rData));

         });
         e.MapPost("plan_your_trip_delete_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await plan_your_trip_delete_details.Plan_your_trip_delete_details(rData));

         });
        e.MapPost("register",
            [AllowAnonymous] async (HttpContext http) =>
            {
                var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
                requestData rData = JsonSerializer.Deserialize<requestData>(body);

                if (rData.eventID == "1002") // getUserByEmail
                {
                    var result = await register.Register(body);
                    await http.Response.WriteAsJsonAsync(result);
                }
            });
        e.MapPost("enquiryForm",
            [AllowAnonymous] async (HttpContext http) =>
            {
                var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
                requestData rData = JsonSerializer.Deserialize<requestData>(body);

                if (rData.eventID == "1002") // getUserByEmail
                {
                    var result = await enquiryForm.EnquiryForm(body);
                    await http.Response.WriteAsJsonAsync(result);
                }
            });
         e.MapPost("enquiryFormDeleteDetails",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // delete
                         await http.Response.WriteAsJsonAsync(await enquiryFormDeleteDetails.EnquiryFormDeleteDetails(rData));

         });
         e.MapPost("signup",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await signup.Signup(rData));

         });
         e.MapPost("myLogin",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await myLogin.MyLogin(rData));

         });
         e.MapPost("destination1",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination1.Destination1(rData));

         });
         e.MapPost("destination1View",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination1View.Destination1View(rData));

         });
         e.MapPost("heading_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await heading_details.Heading_details(rData));

         });
         e.MapPost("best_time_to_visit",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await best_time_to_visit.Best_time_to_visit(rData));

         });
         e.MapPost("best_view",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await best_view.Best_view(rData));

         });
         e.MapPost("heading",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await heading.Heading(rData));

         });
         e.MapPost("destination_details",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination_details.Destination_details(rData));

         });
         e.MapPost("destination_form",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination_form.Destination_form(rData));

         });
         e.MapPost("destination_card",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination_card.Destination_card(rData));

         });
         e.MapPost("destination_card1",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await destination_card1.Destination_card1(rData));

         });
         e.MapPost("imageInsert",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await imageInsert.ImageInsert(rData));

         });
         e.MapPost("dcInsert",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await dcInsert.DcInsert(rData));

         });
         e.MapPost("homeInsert",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await homeInsert.HomeInsert(rData));

         });
         e.MapPost("homeView",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await homeView.HomeView(rData));

         });
         e.MapPost("homeView2",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await homeView2.HomeView2(rData));

         });
         e.MapPost("homeView3",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await homeView3.HomeView3(rData));

         });
         e.MapPost("insertWeekendGateways",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await insertWeekendGateways.InsertWeekendGateways(rData));

         });
         e.MapPost("viewWeekendGateways1",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await viewWeekendGateways1.ViewWeekendGateways1(rData));

         });
         e.MapPost("viewWeekendGateways2",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await viewWeekendGateways2.ViewWeekendGateways2(rData));

         });
         e.MapPost("viewWeekendGateways3",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await viewWeekendGateways3.ViewWeekendGateways3(rData));

         });
         e.MapPost("generate",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await generate.Generate(rData));

         });
         e.MapPost("updatepassword",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await updatepassword.Updatepassword(rData));

         });
         e.MapPost("verify",
         [AllowAnonymous] async (HttpContext http) =>
         {
             var body = await new StreamReader(http.Request.Body).ReadToEndAsync();
             requestData rData = JsonSerializer.Deserialize<requestData>(body);
              if (rData.eventID == "1002") // update
                         await http.Response.WriteAsJsonAsync(await verify.Verifyotp(rData));

         });
         
         



         IConfiguration appsettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
 e.MapGet("/dbstring",
               async c =>
               {
                   dbServices dspoly = new dbServices();
                   await c.Response.WriteAsJsonAsync("{'mongoDatabase':" + appsettings["mongodb:connStr"] + "," + " " + "MYSQLDatabase" + " =>" + appsettings["db:connStrPrimary"]);
               });
          e.MapGet("/bing",
                async c => await c.Response.WriteAsJsonAsync("{'Name':'Anish','Age':'26','Project':'COMMON_PROJECT_STRUCTURE_API'}"));
});
}).Build().Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
public record requestData
{
    [Required]
    public string eventID { get; set; }
    [Required]
    public IDictionary<string, object> addInfo { get; set; }
}

public record responseData
{
    public responseData()
    {
        eventID = "";
        rStatus = 0;
        rData = new Dictionary<string, object>();
    }
    [Required]
    public int rStatus { get; set; } = 0;
    public string eventID { get; set; }
    public IDictionary<string, object> addInfo { get; set; }
    public IDictionary<string, object> rData { get; set; }
}
