using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using SmartSql.DyRepository;

namespace Permission.Service
{
    public  class BaseService<T, H> where T : IRepository<H, string> where H : Common.BaseEntity
    {
        T tParameter { get; }
        public BaseService(T tParameter)
        {
            this.tParameter = tParameter;
        }

        /// <summary>
        /// 创建信息
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public int Insert(H h)
        {
            if (string.IsNullOrEmpty(h.Id))
            {
                h.Id = System.Guid.NewGuid().ToString("N");
            }
            if (h.CreateTime == null)
            {
                h.CreateTime = DateTime.Now;
            }
            return tParameter.Insert(h);
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <param name="h"></param>
        /// <returns></returns>
        public int Update(H h)
        {
            return tParameter.Update(h);
        }

        /// <summary>
        /// 根据id删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteById(string id)
        {
            return tParameter.DeleteById(id);
        }

        /// <summary>
        /// 根据ID获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public H GetById(string id)
        {
            return tParameter.GetById(id);
        }

        /// <summary>
        /// 根据条件查询单条数据
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public H GetEntity(object param)
        {
            return tParameter.GetEntity(param);
        }

        /// <summary>
        /// 根据条件查询列表
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public IList<H> Query(object param)
        {
            return tParameter.Query(param);
        }

        /// <summary>
        /// 分页获取数据
        /// </summary> 
        /// <param name="param">条件</param>
        /// <returns></returns>
        public QueryPageResponse QueryByPage(Pager param)
        {

            object conditions = param;
            if (param.Conditions.Keys.Any())
            {
                conditions = param.Conditions;
            }

            int Total = tParameter.GetRecord(conditions);
            object Records = null;
            Records = tParameter.QueryByPage(conditions);

            return new QueryPageResponse(param)
            {
                Total = Total,
                Records = Records
            };
        }

    }
}