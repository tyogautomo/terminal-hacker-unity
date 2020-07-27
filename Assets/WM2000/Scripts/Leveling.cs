using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts {
    public class Leveling {
        public string name { get; set; }
        public int level { get; set; }
        public List<string> words = new List<string>();

        public Leveling(int level) {
            this.level = level;
        }

        public void DetermineLevelName(int level) {
            if (level == 1) {
                string[] levelOneWords = { "jungle", "laser", "vision", "castle", "minion" };
                name = "The Wanderer";
                words = new List<string>(levelOneWords);
            } else if (level == 2) {
                string[] levelTwoWords = { "illusion", "rainbow", "fantasy", "vanguard", "cauldron" };
                name = "The Alchemist";
                words = new List<string>(levelTwoWords);
            } else if (level == 3) {
                string[] levelThreeWords = { "fabrication", "imagination", "speculation", "magnification", "preference" };
                name = "The Black Witch";
                words = new List<string>(levelThreeWords);
            }
        }
    }
}
