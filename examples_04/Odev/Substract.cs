using System.Threading.Tasks;

namespace Odev
{
    public class Substract : TwoOperation
    {
        public Substract(double param1, double param2) : base(param1, param2)
        {

        }

        public override double Apply()
        {
            return param1 - param2;
        }

        public async override Task<double> ApplyAsync()
        {
            double result = await Task.Run(() =>
            {


                return Apply();

            });

            return result;
        }
    }


}
