using BookStore.Domain;
using BookStore.Domain.BooksAggregate;
using BookStore.Domain.CatalogueAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BookStore.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<ICatalogueRepository, CatalogueRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            
            services.AddDbContext<BookStoreDbContext>(opt => opt
                .UseSqlServer("Server=ADMIN; Database=BookShopDB;User Id=sa; Password=123456ad;"));
            return services;
        }
    }
}
