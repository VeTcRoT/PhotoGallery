﻿using Microsoft.EntityFrameworkCore;

namespace PhotoGallery.Domain.Helpers
{
    public interface IPageData
    {
        int CurrentPage { get; }
        int TotalPages { get; }
        int PageSize { get; }
        int TotalCount { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
    public class PagedList<T> : List<T>, IPageData
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageNumber == 0 || pageSize == 0)
            {
                pageNumber = 1;
                pageSize = 6;
            }

            if (pageSize > 6)
                pageSize = 6;

            var count = source.Count();
            var items = await source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).ToListAsync();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
