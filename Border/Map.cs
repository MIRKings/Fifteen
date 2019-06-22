

namespace Border
{
    struct Map
    {
        private int size;
        int[,] map;
        public Map(int size)
            {
            this.size = size;
            map= new int[size,size];
            }
        public void Set (Cord xy, int value)
        {
            if (xy.OnBord(size))
                map[xy.x, xy.y]= value;            
        }
        public int Get (Cord xy)
        {
            if (xy.OnBord(size))
                return map[xy.x, xy.y];
            return 0;
        }

        public void Copy(Cord from, Cord to)
        {
            Set(to, Get(from));
        }
    }
}
