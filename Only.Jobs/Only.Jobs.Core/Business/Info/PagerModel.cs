using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Only.Jobs.Core.Business.Info
{
    public class PagerModel<T> where T : class
    {
        public PagerModel()
        { }

        /// <summary>
        /// 带4个参数的构造函数
        /// </summary>
        /// <param name="rows">每页显示行数</param>
        /// <param name="currentPage">当前页</param>
        /// <param name="totalRecord">结果总记录数</param>
        /// <param name="jsonArray">JSON数据</param>
        public PagerModel(int rows, int currentPage, int totalRecord, List<T> dataList)
        {
            this.CurrentPage = currentPage;
            this.TotalRecord = totalRecord;
            this.dataList = dataList;

            CalculateTotalPage(rows, totalRecord);
        }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage { get; set; }

        /// <summary>
        /// 当前页
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// 结果总记录数
        /// </summary>
        public int TotalRecord { get; set; }

        /// <summary>
        /// JSON数据
        /// </summary>
        public List<T> dataList { get; set; }

        /// <summary>
        /// 根据每页显示数与总记录数计算出总页数
        /// </summary>
        /// <param name="rows">每页显示数</param>
        /// <param name="totalRecord">结果总记录数</param>
        public void CalculateTotalPage(int rows, int totalRecord)
        {
            if (rows > 0 && totalRecord > 0)
            {
                this.TotalPage = Convert.ToInt32(Math.Ceiling((double)totalRecord / (double)rows));
            }
        }
    }
}
