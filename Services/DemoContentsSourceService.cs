using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using learn_Russian_API.Models.Content.DemoContents;
using learn_Russian_API.Presistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace learn_Russian_API.Services
{
    public interface IDemoContentsSourceService
    {
        DemoContentsModel update(long id,DemoContentsModel updaterequest);
        bool Delete(long id);
    }
    public class DemoContentsSourceService: IDemoContentsSourceService
    {
        private readonly AppDbContext _context;
        
        public DemoContentsSourceService(AppDbContext context)
        {
            _context = context;
        }
        
        public bool Delete(long id)
        {
            var found = _context.DemoContentsModel.Find(id);
            if (found !=null)
            {
                _context.DemoContentsModel.Remove(found);
                _context.SaveChanges();
                return true;
            }

            return false;

        }

        public DemoContentsModel update(long id,DemoContentsModel updaterequest)
        {
            var found = _context.DemoContentsModel.Find(id);
            if (found != null)
            {
                found.title = updaterequest.title;
                found.src = updaterequest.src;
                _context.DemoContentsModel.Update(found);
                _context.SaveChanges();
                return found;
            }
            return null;
        }

    }
}