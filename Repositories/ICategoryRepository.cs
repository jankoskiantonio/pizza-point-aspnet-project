﻿using PizzaPointProject.Models;

namespace PizzaPointProject.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Categories> Categories { get; }

        Categories GetById(int? id);
        Task<Categories> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<Categories> GetAll();
        Task<IEnumerable<Categories>> GetAllAsync();

        void Add(Categories category);
        void Update(Categories category);
        void Remove(Categories category);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
