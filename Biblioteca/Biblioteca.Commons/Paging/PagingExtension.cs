﻿using Biblioteca.Commons.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Commons.Paging
{
    public static class PagingExtension
    {
        public static async Task<RecordsResponse<T>> GetPagedAsync<T>(
            this IQueryable<T> query,
            int page,
            int take)
        {
            var originalPages = page;
            if (page > 0)
            {
                page--;
            }

            if (page > 0)
                page = page * take;

            var result = new RecordsResponse<T>
            {
                Items = await query.Skip(page).Take(take).ToListAsync(),
                Total = await query.CountAsync(),
                Page = originalPages
            };

            if (result.Total > 0)
            {
                result.Pages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(result.Total) / take));
            }

            return result;
        }
    }
}
