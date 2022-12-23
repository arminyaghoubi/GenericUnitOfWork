﻿using GenericUnitOfWork.Common.Extensions;
using GenericUnitOfWork.Common.ViewModels;
using GenericUnitOfWork.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GenericUnitOfWork.DAL.Repositories;

public class Repository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> _dbset;

    public Repository(ApplicationDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(_context));
        _dbset = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken cancellationToken = default) =>
        await _dbset.FindAsync(keyValues, cancellationToken);

    public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbset;

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return await query.FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<TResult?> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector
        , Expression<Func<TEntity, bool>> predicate = null,
        bool disableTracking = true,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = _dbset;

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate is not null)
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        return await query
            .Select(selector)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public IPagedList<TEntity> GetPagedList(
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        int page = 1,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbset;

        if (disableTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = query.Include(include);

        if (predicate is not null)
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        if (order is not null)
            query = query.OrderBy(order);

        return query.ToPagedList(page, pageSize);
    }

    public IPagedList<TResult> GetPagedList<TResult>(
        Func<TEntity, TResult> selector,
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, object>> include = null,
        Expression<Func<TEntity, object>> order = null,
        int page = 1,
        int pageSize = 20,
        bool disableTracking = true,
        bool ignoreQueryFilters = false)
    {
        IQueryable<TEntity> query = _dbset;

        if (disableTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = query.Include(include);

        if (predicate is not null)
            query = query.Where(predicate);

        if (ignoreQueryFilters)
            query = query.IgnoreQueryFilters();

        if (order is not null)
            query = query.OrderBy(order);

        return query.ToPagedList(selector, page, pageSize);
    }

    public async Task<TEntity> InsertAsync(TEntity entity, CancellationToken cancellationToken = default) =>
        (await _dbset.AddAsync(entity, cancellationToken)).Entity;

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
        await _dbset.AddRangeAsync(entities, cancellationToken);

    public void Update(TEntity entity) => _dbset.Update(entity);

    public void UpdateRange(IEnumerable<TEntity> entities) => _dbset.UpdateRange(entities);

    public void Delete(TEntity entity) => _dbset.Remove(entity);

    public void DeleteRange(IEnumerable<TEntity> entities) => _dbset.RemoveRange(entities);
}