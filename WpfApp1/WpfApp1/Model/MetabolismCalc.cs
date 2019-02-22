using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    class MetabolismCalc
    {
        private int age;
        private int metabolism;
        private int dayKcal;
        public MetabolismCalc(double strength, int weightGoal)
        {

            Account account = new AccountGet().GetAccountInfo(Properties.Settings.Default.Username);

            int weight = account.Weight;
            int height = account.Height;
            int bodyfat = account.Bodyfat;
            int age = getAge(account.Born, DateTime.Today);
            int lossWeight = weightGoal - weight;

            this.metabolism = (int)(13.397 * weight + 4.799 * height - 5.677 * age + 88.36);
            this.dayKcal = (int)(this.metabolism * strength);
        }
        public int getAge(DateTime born, DateTime today)
        {
            this.age = today.Year - born.Year;

            if (today.Month < born.Month || (today.Month == born.Month && today.Day < born.Day))
            {
                this.age--;
            }
            return this.age;
        }
        public int getMetabolism()
        {
            return this.metabolism;
        }
        public int getDayKcal()
        {
            return this.dayKcal;
        }
    }
}
