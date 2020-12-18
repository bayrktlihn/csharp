namespace Odev
{
    public class Addition : TwoOperation
    {
        public Addition(double param1, double param2):base(param1, param2)
        {
           
        }

        public override double Apply()
        {
            return param1 + param2;
        }
    }


}
