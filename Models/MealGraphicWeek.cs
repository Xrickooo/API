namespace KursachBot.Model
{
    public class MealGraphic
    {

        public Week week { get; set; }
    }

    public class Week
    {
        public Monday monday { get; set; }
        public Tuesday tuesday { get; set; }
        public Wednesday wednesday { get; set; }
        public Thursday thursday { get; set; }
        public Friday friday { get; set; }
        public Saturday saturday { get; set; }
        public Sunday sunday { get; set; }

        public class Monday
        {
            public Meals[] meals { get; set; }
            public Nutrients nutrients { get; set; }

        }
        public class Tuesday : Monday { }
        public class Wednesday : Monday { }
        public class Thursday : Monday { }
        public class Friday : Monday { }
        public class Saturday : Monday { }
        public class Sunday : Monday { }

        public class Meals
        {
            public string title { get; set; }
            public int id { get; set; }

        }
        public class Nutrients
        {
            public double calories { get; set; }
            public double protein { get; set; }
            public double fat { get; set; }
        }
    }
    public class MealGraphicDay
    {
        public Meals meals { get; set; }
    }
    public class Meals
    {
        public string title { get; set; }
        public int id { get; set; }
        public int readyInMinutes { get; set; }
        public string sourceUrl { get; set; }

    }


}


