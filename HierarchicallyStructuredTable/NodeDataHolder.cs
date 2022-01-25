namespace HierarchicallyStructuredTable
{
    public class NodeDataHolder
    {
        public int Counter { get; private set; }

        public void IncrementCounter()
        {
            Counter++;
        }

        public int IncrementAndGet()
        {
            IncrementCounter();
            return Counter;
        }
    }
}
