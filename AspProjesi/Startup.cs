using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace AspProjesi
{
    public class Startup
    {
        public class CustomAntiforgeryAdditionalDataProvider : IAntiforgeryAdditionalDataProvider
        {
            // Bu sınıf şu anda IAntiforgeryAdditionalDataProvider interface'ini implement etmiyor
            // Ancak bu sınıfı kendi özel mantığınızla doldurabilir ve IAntiforgeryAdditionalDataProvider olarak kaydedebilirsiniz.
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Hizmetlerin yapılandırılması ve kaydedilmesi burada gerçekleştirilir
            services.AddSingleton<IAntiforgeryAdditionalDataProvider, CustomAntiforgeryAdditionalDataProvider>();
            // Diğer hizmet kayıtları ve yapılandırmaları da burada gerçekleştirilir
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Uygulama ortamının yapılandırılması burada gerçekleştirilir

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Diğer middleware'ler ve konfigürasyonlar da burada eklenmelidir
        }
    }
}
