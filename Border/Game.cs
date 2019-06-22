using System;


namespace Border
{

    public class Game
    {
        int size;
        Map map;
        Cord space;

        public int mouves { get; private set; }

        public Game(int size)
        {
            this.size = size;
            map = new Map(size);
        }

        public void Start(int seed = 0)
        {
            int digit = 0;
            foreach(Cord xy in new Cord().YieldCord(size))
            map.Set(xy, ++digit);
            space = new Cord(size);
            if (seed > 0)
                Shiffle(seed);
            mouves = 0;
        }

        void Shiffle (int seed)
        {
            Random random = new Random(seed);
            for (int j = 0; j < seed; j++)
                PressAt(random.Next(size), random.Next(size));
            
        }

        public int PressAt(int x, int y)
        {
            return PressAt(new Cord(x, y));
        }

        int PressAt(Cord xy)
        {
            if(space.Equals(xy))
                return 0;
             if (xy.x != space.x && xy.y != space.y)
                return 0;

            int steps = Math.Abs(xy.x - space.x) +
                        Math.Abs(xy.y - space.y);
            
                while (xy.x != space.x)
                Shift(Math.Sign(xy.x - space.x), 0);

            while (xy.y != space.y)
                Shift(0, Math.Sign(xy.y - space.y));
            mouves += steps;
            return steps;

        }

        void Shift (int sx, int sy)
        {
            Cord next = space.Add(sx, sy);
            map.Copy(next, space);
            space = next;
        }

        public int GetDijitAt(int x, int y)
        {
            return GetDijitAt(new Cord (x,y));
        }

        int GetDijitAt( Cord xy)
        {
            if (space.Equals(xy))
                return 0;
            return map.Get(xy);
        }

        public bool Solved()
        {
            if (!space.Equals(new Cord(size)))
                return false;
            int digit = 0;
            foreach (Cord xy in new Cord().YieldCord(size))
                if (map.Get(xy) != ++digit)
                    return space.Equals(xy);
            return true;
        }

    }
}