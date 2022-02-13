using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexBotPrj
{

    public class Rootobject
    {
        public Battle_Royale battle_royale { get; set; }
        public Arenas arenas { get; set; }
        public Ranked ranked { get; set; }
        public Arenasranked arenasRanked { get; set; }
        public Control control { get; set; }
    }

    public class Battle_Royale
    {
        public Current current { get; set; }
        public Next next { get; set; }
    }

    public class Current
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
        public string asset { get; set; }
        public int remainingSecs { get; set; }
        public int remainingMins { get; set; }
        public string remainingTimer { get; set; }
    }

    public class Next
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
    }

    public class Arenas
    {
        public Current1 current { get; set; }
        public Next1 next { get; set; }
    }

    public class Current1
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
        public string asset { get; set; }
        public int remainingSecs { get; set; }
        public int remainingMins { get; set; }
        public string remainingTimer { get; set; }
    }

    public class Next1
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
    }

    public class Ranked
    {
        public Current2 current { get; set; }
        public Next2 next { get; set; }
    }

    public class Current2
    {
        public string map { get; set; }
        public string asset { get; set; }
    }

    public class Next2
    {
        public string map { get; set; }
    }

    public class Arenasranked
    {
        public Current3 current { get; set; }
        public Next3 next { get; set; }
    }

    public class Current3
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
        public string asset { get; set; }
        public int remainingSecs { get; set; }
        public int remainingMins { get; set; }
        public string remainingTimer { get; set; }
    }

    public class Next3
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
    }

    public class Control
    {
        public Current4 current { get; set; }
        public Next4 next { get; set; }
    }

    public class Current4
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
        public string asset { get; set; }
        public int remainingSecs { get; set; }
        public int remainingMins { get; set; }
        public string remainingTimer { get; set; }
    }

    public class Next4
    {
        public int start { get; set; }
        public int end { get; set; }
        public DateTime readableDate_start { get; set; }
        public DateTime readableDate_end { get; set; }
        public string map { get; set; }
        public string code { get; set; }
        public int DurationInSecs { get; set; }
        public int DurationInMinutes { get; set; }
    }

}
