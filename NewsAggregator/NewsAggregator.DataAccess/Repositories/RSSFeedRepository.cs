<<<<<<< HEAD
﻿
using Microsoft.EntityFrameworkCore;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class RSSFeedRepository : IRSSFeedRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;
        public RSSFeedRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<RSSFeed> GetAll()
        {
            return _dbContext.RssFeeds.Include(x => x.Category);
        }
        public IQueryable<RSSFeed> GetActiveFeeds()
        {
            return _dbContext.RssFeeds.Include(x => x.Category).Where(x => x.IsActive);
        }
        public RSSFeed? GetById(int id)
        {
            return _dbContext.RssFeeds.Include(x => x.Category).SingleOrDefault(r => r.Id == id);
        }
        public void Create(RSSFeed entity)
        {
            _dbContext.RssFeeds.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(RSSFeed entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(RSSFeed entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

       
    }
}
=======
﻿
using Microsoft.EntityFrameworkCore;
using NewsAggregator.DataAccess.Abstraction;
using NewsAggregator.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.DataAccess.Repositories
{
    public class RSSFeedRepository : IRSSFeedRepository
    {
        private readonly NewsAggregatorDbContext _dbContext;
        public RSSFeedRepository(NewsAggregatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<RSSFeed> GetAll()
        {
            return _dbContext.RssFeeds.Include(x => x.Category);
        }
        public IQueryable<RSSFeed> GetActiveFeeds()
        {
            return _dbContext.RssFeeds.Include(x => x.Category).Where(x => x.IsActive);
        }
        public RSSFeed? GetById(int id)
        {
            return _dbContext.RssFeeds.Include(x => x.Category).SingleOrDefault(r => r.Id == id);
        }
        public void Create(RSSFeed entity)
        {
            _dbContext.RssFeeds.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(RSSFeed entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(RSSFeed entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

       
    }
}
>>>>>>> 5aee1f0008efc821c2ec559e2a78de6380c7377c
