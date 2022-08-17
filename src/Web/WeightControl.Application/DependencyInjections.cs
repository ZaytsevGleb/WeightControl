﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WeightControl.Application.Auth;
using WeightControl.Application.Products;
using WeightControl.Application.Products.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplicationDependensies(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddAutoMapper(typeof(Product), typeof(ProductDto));
            services.AddScoped<IValidator<ProductDto>, ProductDtoValidator>();
            
            return services;
        }
    }
}