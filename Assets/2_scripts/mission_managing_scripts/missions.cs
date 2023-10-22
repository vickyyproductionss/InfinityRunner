using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missions
{
    public class mission_score
    {
        public string statement;
        
        public mission_score(int score)
        {
            statement = "Score " + score + " in one run.";
        }
    }
    
    public class mission_diamonds
    {
        public string statement;
        public mission_diamonds(int diamonds)
        {
            statement = "Collect " + diamonds + " diamonds in one run.";
        }
    }
    public class mission_total_diamonds
    {
        public string statement;
        public mission_total_diamonds(int diamonds)
        {
            statement = "Collect " + diamonds + " diamonds in total.";
        }
    }

    public class mission_speed
    {
        public string statement;
        public mission_speed(int speed)
        {
            statement = "Speed upto " + speed + "km/h.";
        }
    }
    public class mission_boxes
    {
        public string statement;
        public mission_boxes(int numBox)
        {
            statement = "Blow up " + numBox + " wooden boxes from your route in one run.";
        }
    }

    public class mission_coins
    {
        public string statement;
        public mission_coins(int coinAmount)
        {
            statement = "Collect " + coinAmount + " coins in one run.";
        }
    }

    public class mission_total_coins
    {
        public string statement;
        public mission_total_coins(int coinAmount)
        {
            statement = "Collect " + coinAmount + " coins in total.";
        }
    }
    
}
