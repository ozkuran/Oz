using System.Collections.Generic;
using System.Linq;

namespace Oz.Algorithms.Data.Clustering
{
    /// <summary> Cluster class
    /// <para>Cluster class which could be used for clustering data</para>
    /// <para>Mahmut Ali ÖZKURAN
    /// 16.02.2015
    /// ver. 0.0.1.3
    /// </para>
    /// </summary>
    // Mahmut Ali ÖZKURAN
    // 16.02.2015
    // Cluster class which could be used for clustering data
    // ver. 0.0.1.3
    public class Cluster
    {
        private List<List<string>> _cluster  = new List<List<string>>();

        /// <summary> AddItem method 
        /// <para>Adds given items to cluster</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public void AddItem(string itemName, string subItemName)
        {
            if (subItemName == "")
            {
                _cluster.Add(new List<string> {itemName});
            }
        }

        /// <summary> AddSubCluster method 
        /// <para>Adds given subCluster to cluster</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public void AddSubCluster(List<string> subClusterList)
        {
            _cluster.Add(subClusterList);
        }

        /// <summary> ReturnCluster method 
        /// <para>Returns cluster with given string</para>
        /// <para>Mahmut Ali ÖZKURAN
        /// 16.02.2015
        /// ver. 0.0.1.1
        /// </para>
        /// </summary>
        public List<string> ReturnCluster(string inputString)
        {
            return _cluster.FirstOrDefault(list => list.Contains(inputString));
        }
    }
}
