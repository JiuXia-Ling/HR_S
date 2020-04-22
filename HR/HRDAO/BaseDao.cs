using HREFProject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRDAO
{
    public class BaseDao<T> where T:class
    {
        HRDbContext db = new HRDbContext();

        private void FenLi(T t)
        {
            var ObjContext = ((IObjectContextAdapter)db).ObjectContext;//第1处
            //2 创建新的 ObjectSet< TEntity > 实例
            var objSet = ObjContext.CreateObjectSet<T>();
            //3 为特定对象创建实体键，如果实体键已存在，则返回该键。
            var objKey = ObjContext.CreateEntityKey(objSet.EntitySet.Name, t);//第2处
            //4 返回具有指定实体键的对象。
            object objT;
            var ext = ObjContext.TryGetObjectByKey(objKey, out objT);
            //5 从对象上下文移除对象。
            if (ext)
            {
                ObjContext.Detach(objT);
            }
        }

        #region 通用添加
        public int Add(T t)
        {
            db.Set<T>().Add(t);
            return db.SaveChanges();
        }
        #endregion

        #region 通用修改
        public int Upd(T t)
        {
            FenLi(t);
            db.Set<T>().Attach(t);
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
        #endregion

        #region 通用简单查询
        public List<T> select()
        {
            return db.Set<T>().AsNoTracking().ToList();
        }
        #endregion

        #region 通用删除
        public int Delete(T t)
        {
            db.Set<T>().Attach(t);
            db.Entry(t).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }
        #endregion

        #region 主键查询
        public T selectById(Object obj)
        {
            return db.Set<T>().Find(obj);
        }
        #endregion
        
        #region 存储过程通用分页
        public List<T> SelectPageList<T>(string sqlstr, int pageIndex, int pagesize, string orderByField, ref int totalCount) where T : class
        {
            SqlParameter[] spm = new SqlParameter[5];
            spm[0] = new SqlParameter("@Sql", sqlstr);
            spm[1] = new SqlParameter("@PageIndex", pageIndex);
            spm[2] = new SqlParameter("@PageSize", pagesize);
            spm[3] = new SqlParameter("@OrderByField", orderByField);
            spm[4] = new SqlParameter("@TotalRecord", totalCount);
            spm[4].Direction = ParameterDirection.Output;
            var data = db.Database.SqlQuery<T>("exec Fenye @Sql,@PageIndex,@PageSize,@OrderByField,@TotalRecord out", spm).ToList();
            totalCount = Convert.ToInt32(spm[4].Value.ToString());
            return data;
        }
        #endregion
    }
}
