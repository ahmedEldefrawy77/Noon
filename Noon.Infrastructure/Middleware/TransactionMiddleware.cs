using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage;
using Noon.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noon.Infrastructure.Middleware
{
    public class TransactionMiddleware : IMiddleware
    {
        
        
            private readonly ApplicationDbContext _context;

            public TransactionMiddleware(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task InvokeAsync(HttpContext context, RequestDelegate next)
            {
                if (context.Request.Method != HttpMethods.Get || context.Request.Method != HttpMethods.Options)
                {
                    IDbContextTransaction? transaction = null;
                    try
                    {
                        transaction = _context.Database.BeginTransaction();

                        await next(context);

                        await transaction.CommitAsync();

                      


                    }
                    catch (Exception)
                    {
                        transaction?.Rollback();

                        
                        throw;
                    }
                }
            }
        
    }
}

