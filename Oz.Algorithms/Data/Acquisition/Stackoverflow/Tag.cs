namespace Oz.Algorithms.Data.Acquisition.Stackoverflow
{
    internal class Tag
    {
        public int? TagId { get; set; }
        public string Name { get; set; }
        public int? Count { get; set; }

        public Tag()
        {
            TagId = null;
            Name = null;
            Count = null;
        }


        public void SetTag(int tagId, string name, int count)
        {
            TagId = tagId;
            Name = Name;
            Count = count;
        }
    }

}
