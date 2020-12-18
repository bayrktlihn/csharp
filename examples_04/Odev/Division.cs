namespace Odev
{
    public class Division : TwoOperation
    {
        public Division(double param1, double param2) : base(param1, param2)
        {

        }

        public override double Apply()
        {
            return param1 / param2;
        }
    }


}
