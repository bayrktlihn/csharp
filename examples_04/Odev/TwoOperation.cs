namespace Odev
{
    public abstract class TwoOperation : Operation
    {
        protected double param1;
        protected double param2;

        public TwoOperation(double param1, double param2)
        {
            this.param1 = param1;
            this.param2 = param2;
        }

        public abstract double Apply();
    }


}
