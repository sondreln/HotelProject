using HotelClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RoomCleaners.Data
{
    public class ApplicationDbContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        public ApplicationDbContext()
        {
            //Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql( "Host=ider-database.westeurope.cloudapp.azure.com; Database=h666949; Port=5432; Username=h666949; Password=pass");
        }

        public DbSet<Customer> Customer { get; set; } 
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<HotelTask> HotelTask { get; set; }
    }
}

//  <Frame Padding="20" Margin="0,10,0,10" BackgroundColor="#ffffff" CornerRadius="10">
                            
//                                 <StackLayout Grid.Column="0" Padding="10,0">
//                                     <Label Text="{Binding Role}" FontSize="22" FontAttributes="Bold" TextColor="#000"/>
//                                     <BoxView Color="Gray"
//                                         HeightRequest="2"
//                                         HorizontalOptions="Fill" />
//                                     <Label Text="{Binding Description}" FontSize="18" TextColor="#333"/>
//                                 </StackLayout>
//                                 <Button Grid.Column="1" Text="Complete" Command="{Binding Source={x:Reference mainPage}, Path=BindingContext.CompleteTaskCommand}" CommandParameter="{Binding}" 
//                                         BackgroundColor="#3498db" TextColor="White" CornerRadius="10" Margin="10,0,0,0"/>
//                         </Frame>