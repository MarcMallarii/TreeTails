using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TreeTails.Model;

namespace TreeTails.ViewModel
{
    class TreeListViewModel
    {
        private Services.DatabaseContext getContext()
        {
            return new Services.DatabaseContext();
        }

        public async Task<List<TreeModel>> GetAllTreeLists()
        {
            var _dbContext = getContext();
            var res = await _dbContext.Puno.ToListAsync();
            return res;

        }
        public async Task<int> UpdateTreeList(TreeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Puno.Update(obj);
            int c = await _dbContext.SaveChangesAsync();
            return c;
        }

        public int InsertTreeList(TreeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Puno.Add(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }

        public int DeleteTreeList(TreeModel obj)
        {
            var _dbContext = getContext();
            _dbContext.Puno.Remove(obj);
            int c = _dbContext.SaveChanges();
            return c;
        }
    }
}
