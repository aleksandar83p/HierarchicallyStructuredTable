namespace HierarchicallyStructuredTable
{
    public class Node
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int? Parent { get; set; }
        public int? Left { get; set; }
        public int? Right { get; set; }

        public override string ToString()
        {
            return $"{Name}   |   {Id}   |   {Parent}";
        }

        public string GetLeftAndRight()
        {
            return $"{Name}   |   {Left}   |   {Right}";
        }
    }
}
