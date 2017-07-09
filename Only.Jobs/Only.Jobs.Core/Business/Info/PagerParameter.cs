using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Web;

namespace Only.Jobs.Core.Business.Info
{
    /// <summary>
    /// 页面参数模型
    /// </summary>
    public class PageParameter
    {
        public PageParameter()
        {

        }

        /// <summary>
        ///  带2个参数的构造函数
        /// </summary>
        /// <param name="rows">每页显示行数</param>
        /// <param name="currentPageIndex">当前页索引</param>
        public PageParameter(int rows, int currentPageIndex)
        {
            this.rows = rows;
            this.currentPageIndex = currentPageIndex;
        }

        /// <summary>
        ///  带3个参数的构造函数
        /// </summary>
        /// <param name="rows">每页显示行数</param>
        /// <param name="currentPageIndex">当前页索引</param>
        /// <param name="dictionary">条件参数集合</param>
        public PageParameter(int rows, int currentPageIndex, ConcurrentDictionary<string, string> dictionary)
        {
            this.rows = rows;
            this.currentPageIndex = currentPageIndex;
            this.dictionary = dictionary;
        }

        /// <summary>
        /// 每页显示行数
        /// </summary>
        public int rows { get; set; }

        /// <summary>
        /// 当前页索引
        /// </summary>
        public int currentPageIndex { get; set; }

        /// <summary>
        /// 条件参数集合
        /// </summary>
        private ConcurrentDictionary<string, string> dictionary { get; set; }

        public ConcurrentDictionary<string, string> GetDictionary()
        {
            return dictionary;
        }

        /// <summary>
        /// 设置dictionary
        /// </summary>
        /// <param name="concurrentDictionary"></param>
        public void SetDictionary(ConcurrentDictionary<string, string> concurrentDictionary)
        {
            if (dictionary == null)
            {
                dictionary = new ConcurrentDictionary<string, string>();
            }
            dictionary = concurrentDictionary;
        }

        /// <summary>
        /// 获取dictionary项数量
        /// </summary>
        /// <returns></returns>
        public int GetDictionaryCount()
        {
            if (dictionary == null || dictionary.Count < 1)
            {
                return 0;
            }
            return dictionary.Count;
        }


        /// <summary>
        /// 键是否存在
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public bool ContainsKey(string key)
        {
            if (dictionary == null)
            {
                return false;
            }
            else
            {
                return dictionary.ContainsKey(key);
            }
        }

        /// <summary>
        /// 移除键
        /// </summary>
        /// <param name="key">键</param>
        public void Remove(string key)
        {
            if (dictionary == null)
            {

            }
            else
            {
                string val = string.Empty;
                dictionary.TryRemove(key, out val);
            }
        }

        /// <summary>
        /// 新增参数
        /// </summary>
        /// <param name="Key">键</param>
        /// <param name="Value">值</param>
        public void AddParameter(string Key, object Value)
        {
            if (dictionary == null)
                dictionary = new ConcurrentDictionary<string, string>();

            if (dictionary.ContainsKey(Key))
            {
                dictionary[Key] = Value.ToString();
            }
            else
            {
                dictionary.TryAdd(Key, Value.ToString());
            }
        }


        /// <summary>
        /// 获取参数值
        /// </summary>
        /// <param name="ParameterKey">参数键</param>
        /// <returns></returns>
        public string GetParameter(string ParameterKey)
        {
            string value = System.Guid.Empty.ToString();
            if (dictionary != null && dictionary.Count > 0)
            {
                dictionary.TryGetValue(ParameterKey, out value);
            }
            if (!string.IsNullOrEmpty(value))
                value = HttpUtility.UrlDecode(value);

            return value;
        }

        /// <summary>
        /// 获取Int参数值
        /// </summary>
        /// <param name="ParameterKey">参数键</param>
        /// <returns></returns>
        public int GetParameterInt(string ParameterKey)
        {
            string value = "-1";
            int result = 0;
            if (dictionary != null && dictionary.Count > 0)
            {
                dictionary.TryGetValue(ParameterKey, out value);
            }
            if (!string.IsNullOrWhiteSpace(value))
            {
                int.TryParse(value, out result);
            }
            return result;
        }

        /// <summary>
        /// 获取Guid参数值
        /// </summary>
        /// <param name="ParameterKey">参数键</param>
        /// <returns></returns>
        public System.Guid GetParameterGuid(string ParameterKey)
        {
            string value = System.Guid.Empty.ToString();
            System.Guid result = System.Guid.Empty;
            if (dictionary != null && dictionary.Count > 0)
            {
                dictionary.TryGetValue(ParameterKey, out value);
            }
            if (!string.IsNullOrWhiteSpace(value))
            {
                System.Guid.TryParse(value, out result);
            }
            return result;
        }

        /// <summary>
        /// 获取bool参数值
        /// </summary>
        /// <param name="ParameterKey">参数键</param>
        /// <returns></returns>
        public bool GetParameterBool(string ParameterKey)
        {
            return GetParameterBool(ParameterKey, false);
        }

        /// <summary>
        /// 获取bool参数值
        /// </summary>
        /// <param name="ParameterKey">参数键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public bool GetParameterBool(string ParameterKey, bool defaultValue)
        {
            string value = string.Empty;
            bool result = false;
            if (dictionary != null && dictionary.Count > 0)
            {
                dictionary.TryGetValue(ParameterKey, out value);
            }
            if (!string.IsNullOrWhiteSpace(value))
            {
                if (value.ToLower() == "false")
                    result = false;
                else if (value.ToLower() == "true")
                    result = true;
            }
            return result;
        }
    }
}
